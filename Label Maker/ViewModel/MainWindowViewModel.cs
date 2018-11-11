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

namespace LabelMaker.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private MainWindow window = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

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
            //window.A4.Blocks.Clear();
            ObservableCollection<Label> listOfUsers = LabelRepository.AllLabels;

            foreach (Label user in listOfUsers)
            {
                WrapPanel wrapPanel = new WrapPanel
                {
                    Margin = new Thickness(10)
                };
                BlockUIContainer container = new BlockUIContainer(wrapPanel);

                for (int i = 0; i < 55; i++)
                {
                    View.Label label = new View.Label();
                    label.FirstName.Text = user.FirstName;
                    label.LastName.Text = user.LastName;
                    label.Image.Source = new BitmapImage(new Uri(Environment.CurrentDirectory + "\\img\\" + user.ImagePath + ".png", UriKind.RelativeOrAbsolute));

                    wrapPanel.Children.Add(label);
                }
                window.A4.Blocks.Add(container);
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



        #endregion
    }
}
