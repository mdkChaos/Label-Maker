using LabelMaker.Helpers;
using System.Linq;
using System.Windows;
using LabelMaker.Model;
using LabelMaker.View;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Label = Data.Label;
using System.Windows.Media.Imaging;
using System;
using System.Windows.Threading;
using Data;
using System.Windows.Media;
using Color = Data.Color;

namespace LabelMaker.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
        private string font;
        private string color;
        private bool isSimple;

        #endregion

        #region Properties

        public ObservableCollection<Color> Colors { get; }
        public ObservableCollection<Font> Fonts { get; }

        #endregion

        #region Constractors

        public MainWindowViewModel()
        {
            GetLabelsCommand = new DelegateCommand(async o => await GetLabelsAsync());
            InsertLabelOnCanvasCommand = new DelegateCommand(o => InsertLabelOnCanvas());
            PrintCommand = new DelegateCommand(o => Print());
            Colors = ColorRepository.Colors;
            Fonts = FontRepository.Fonts;
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
            if (window.Color.SelectedItem is Color colors)
            {
                color = colors.ColorHEX;
            }

            if (window.Font.SelectedItem is Font fonts)
            {
                font = fonts.Path;
            }

            isSimple = (bool)window.Simple.IsChecked;

            ObservableCollection<Label> listOfUsers = LabelRepository.AllLabels;

            foreach (Label user in listOfUsers)
            {
                window.A4.Blocks.Add(AddLabel(user));
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

        private BlockUIContainer AddLabel(Label user)
        {
            BlockUIContainer container = null;

            if (isSimple)
            {
                container = GetSimpleLabel(user);
            }

            return container;
        }

        private BlockUIContainer GetSimpleLabel(Label user)
        {
            WrapPanel wrapPanel = new WrapPanel
            {
                Margin = new Thickness(10)
            };
            for (int i = 0; i < 55; i++)
            {
                View.Label label = new View.Label();
                label.Border.BorderBrush = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(color));
                label.FirstName.Text = user.FirstName;
                label.FirstName.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(color));
                label.FirstName.FontFamily = new FontFamily(font);
                label.LastName.Text = user.LastName;
                label.LastName.Foreground = new SolidColorBrush((System.Windows.Media.Color)ColorConverter.ConvertFromString(color));
                label.LastName.FontFamily = new FontFamily(font);
                label.Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\img\\" + user.ImagePath + ".png", UriKind.RelativeOrAbsolute));

                wrapPanel.Children.Add(label);
            }
            BlockUIContainer container = new BlockUIContainer(wrapPanel);

            return container;
        }

        private BlockUIContainer GetSatinLabel(Label user)
        {
            WrapPanel wrapPanel = new WrapPanel
            {
                Margin = new Thickness(10)
            };
            for (int i = 0; i < 55; i++)
            {
                View.Label label = new View.Label();
                label.FirstName.Text = user.FirstName;
                label.LastName.Text = user.LastName;
                label.Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\img\\" + user.ImagePath + ".png", UriKind.RelativeOrAbsolute));

                wrapPanel.Children.Add(label);
            }
            BlockUIContainer container = new BlockUIContainer(wrapPanel);

            return container;
        }

        #endregion
    }
}
