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
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                printDialog.PrintDocument(((IDocumentPaginatorSource)window.DocumentReader.Document).DocumentPaginator, "A Label Document");
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
                Margin = new Thickness(10)
            };
            for (int i = 0; i < 55; i++)
            {
                View.Label viewLabel = new View.Label();

                viewLabel.Border.BorderBrush = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));

                viewLabel.FirstName.Text = label.FirstName;
                viewLabel.FirstName.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));
                viewLabel.FirstName.FontFamily = new FontFamily(new Uri(label.Font.BaseURI), "./" + label.Font.Path);
                viewLabel.FirstName.FontSize = label.Font.FontSize;

                viewLabel.LastName.Text = label.LastName;
                viewLabel.LastName.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));
                viewLabel.LastName.FontFamily = new FontFamily(new Uri(label.Font.BaseURI), "./" + label.Font.Path);
                viewLabel.LastName.FontSize = label.Font.FontSize;

                if (label.ImagePath != "0")
                {
                    viewLabel.Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\img\\" + label.ImagePath + ".png", UriKind.RelativeOrAbsolute));
                }

                wrapPanel.Children.Add(viewLabel);
            }
            BlockUIContainer container = new BlockUIContainer(wrapPanel);

            return container;
        }

        private BlockUIContainer GetSatinLabel(Label label)
        {
            WrapPanel wrapPanel = new WrapPanel
            {
                Margin = new Thickness(10)
            };
            for (int i = 0; i < 55; i++)
            {
                View.Label viewLabel = new View.Label();
                viewLabel.Border.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));

                viewLabel.FirstName.Text = label.FirstName;
                viewLabel.FirstName.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));
                viewLabel.FirstName.FontFamily = new FontFamily(new Uri(label.Font.BaseURI), "./" + label.Font.Path);

                viewLabel.LastName.Text = label.LastName;
                viewLabel.LastName.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(label.Color.ColorHEX));
                viewLabel.LastName.FontFamily = new FontFamily(new Uri(label.Font.BaseURI), "./" + label.Font.Path);

                if (label.ImagePath != "0")
                {
                    viewLabel.Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\img\\" + label.ImagePath + ".png", UriKind.RelativeOrAbsolute));
                }

                wrapPanel.Children.Add(viewLabel);
            }
            BlockUIContainer container = new BlockUIContainer(wrapPanel);

            return container;
        }

        #endregion
    }
}
