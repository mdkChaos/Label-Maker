using LabelMaker.Helpers;
using System.Linq;
using System.Windows;
using LabelMaker.Model;
using LabelMaker.View;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Threading.Tasks;
using Label = Data.Label;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Media;
using System.Collections.Generic;

namespace LabelMaker.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        private bool isSimple;

        #endregion

        #region Properties



        #endregion

        #region Constractors

        public MainWindowViewModel()
        {
            GetLabelsCommand = new DelegateCommand(async o => await GetLabelsAsync());
            InsertLabelOnCanvasCommand = new DelegateCommand(o => InsertLabelOnCanvas());
            PrintCommand = new DelegateCommand(o => Print());
        }

        #endregion

        #region Command

        public DelegateCommand GetLabelsCommand { get; set; }
        public DelegateCommand InsertLabelOnCanvasCommand { get; set; }
        public DelegateCommand PrintCommand { get; set; }

        #endregion

        #region Command implementation

        private async Task GetLabelsAsync()
        {
            await LabelRepository.GetLabelsAsync();
        }

        private void InsertLabelOnCanvas()
        {
            window.A4.Blocks.Clear();

            isSimple = (bool)window.Simple.IsChecked;

            List<Label> labels = LabelRepository.AllLabels;

            foreach (Label label in labels)
            {
                window.A4.Blocks.Add(AddLabel(label));
            }
        }

        private void Print()
        {
            PrintDialog printDialog = new PrintDialog
            {
                SelectedPagesEnabled = true,
                UserPageRangeEnabled = true
            };

            FlowDocument document = window.A4;

            //document.PageHeight = printDialog.PrintableAreaHeight;
            //document.PageWidth = printDialog.PrintableAreaWidth;

            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)document).DocumentPaginator, "A Label Document");
            }
        }

        #endregion

        #region Methods

        private BlockUIContainer AddLabel(Label label)
        {
            BlockUIContainer container = null;

            if (isSimple)
            {
                container = GetSimpleLabel(label);
            }
            else
            {
                container = GetSatinLabel(label);
            }

            return container;
        }

        private BlockUIContainer GetSimpleLabel(Label label)
        {
            WrapPanel wrapPanel = new WrapPanel
            {
                Margin = new Thickness(ConvertMmToPixel(5))
            };
            for (int i = 0; i < 55; i++)
            {
                View.Label viewLabel = GetLabel(label, 3.7, 0, 3.7, 2.4);

                wrapPanel.Children.Add(viewLabel);
            }
            BlockUIContainer container = new BlockUIContainer(wrapPanel);

            return container;
        }

        private BlockUIContainer GetSatinLabel(Label label)
        {
            StackPanel stackPanel = new StackPanel
            {
                Margin = new Thickness(ConvertMmToPixel(3), ConvertMmToPixel(7), ConvertMmToPixel(3), ConvertMmToPixel(6))
            };
            for (int i = 0; i < 9; i++)
            {
                WrapPanel wrapPanel = new WrapPanel
                {
                    Margin = new Thickness(0)
                };

                wrapPanel.Children.Add(GetLabel(label, 10, 2, 29.5, 1.5));
                wrapPanel.Children.Add(GetBorder(0.5, 20));
                wrapPanel.Children.Add(GetLabel(label, 29.5, 2, 29.5, 1.5));
                wrapPanel.Children.Add(GetBorder(0.5, 20));
                wrapPanel.Children.Add(GetLabel(label, 29.5, 2, 10, 1.5));

                stackPanel.Children.Add(wrapPanel);

                WrapPanel wrapPanel1 = new WrapPanel
                {
                    Margin = new Thickness(0)
                };

                wrapPanel1.Children.Add(GetBorder(4, 0.5, 0, 0, 42, 1.5));
                wrapPanel1.Children.Add(GetBorder(4, 0.5, 41.5, 0, 53, 1.5));
                wrapPanel1.Children.Add(GetBorder(4, 0.5, 52.5, 0, 42, 1.5));
                wrapPanel1.Children.Add(GetBorder(4, 0.5, 42, 0, 0, 1.5));

                stackPanel.Children.Add(wrapPanel1);
            }
            BlockUIContainer container = new BlockUIContainer(stackPanel);

            return container;
        }

        private Border GetBorder(double width, double height)
        {
            return new Border
            {
                BorderBrush = new SolidColorBrush(Colors.DarkGray),
                BorderThickness = new Thickness(1),
                Background = new SolidColorBrush(Colors.LightGray),
                Height = ConvertMmToPixel(height),
                Width = ConvertMmToPixel(width)
            };
        }

        private Border GetBorder(double width, double height, double left, double top, double right, double bottom)
        {
            return new Border
            {
                BorderBrush = new SolidColorBrush(Colors.DarkGray),
                BorderThickness = new Thickness(1),
                Background = new SolidColorBrush(Colors.LightGray),
                Height = ConvertMmToPixel(height),
                Width = ConvertMmToPixel(width),
                Margin = new Thickness(ConvertMmToPixel(left),
                                       ConvertMmToPixel(top),
                                       ConvertMmToPixel(right),
                                       ConvertMmToPixel(bottom))
            };
        }

        private View.Label GetLabel(Label label, double left, double top, double right, double bottom)
        {
            View.Label viewLabel = new View.Label
            {
                Margin = new Thickness(ConvertMmToPixel(left),
                                       ConvertMmToPixel(top),
                                       ConvertMmToPixel(right),
                                       ConvertMmToPixel(bottom))
            };

            viewLabel.Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));

            viewLabel.FirstName.Text = label.FirstName;
            viewLabel.FirstName.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));
            viewLabel.FirstName.FontFamily = new FontFamily(new Uri(label.Font.BaseURI), "./" + label.Font.Path);
            viewLabel.FirstName.FontSize = label.Font.FontSize;

            viewLabel.LastName.Text = label.LastName;
            viewLabel.LastName.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));
            viewLabel.LastName.FontFamily = new FontFamily(new Uri(label.Font.BaseURI), "./" + label.Font.Path);
            viewLabel.LastName.FontSize = label.Font.FontSize;

            if (!string.IsNullOrEmpty(label.ImagePath))
            {
                viewLabel.Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\img\\" + label.ImagePath + ".png", UriKind.RelativeOrAbsolute));
            }

            return viewLabel;
        }

        /// <summary>
        /// Convert millimeter to pixel
        /// </summary>
        /// <param name="mm">Size in millimeters</param>
        /// <returns>Return size in pixeles</returns>
        private double ConvertMmToPixel(double mm)
        {
            return mm * 96 / 25.4;
        }

        #endregion
    }
}
