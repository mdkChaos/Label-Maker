using System.Collections.ObjectModel;
using Data;
using DataProvider;

namespace Label_Maker.Model
{
    public static class LabelRepository
    {
        private static ObservableCollection<Label> labels;
        public static ObservableCollection<Label> AllLabels
        {
            get
            {
                labels = GetLabels();
                return labels;
            }
        }
        private static ObservableCollection<Label> GetLabels()
        {
            return ExcelProvider.GetLabelsAsincAsync().Result;
        }
    }
}
