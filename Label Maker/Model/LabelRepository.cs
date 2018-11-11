using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Data;
using DataProvider;

namespace LabelMaker.Model
{
    public static class LabelRepository
    {
        private static ObservableCollection<Label> labels;

        public static ObservableCollection<Label> AllLabels
        {
            get
            {
                return labels = ExcelProvider.Labels;
            }
        }

        public static async Task GetLabelsAsync()
        {
            await ExcelProvider.GetLabelsAsync();
        }
    }
}
