using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using DataProvider;

namespace LabelMaker.Model
{
    public static class LabelRepository
    {
        private static List<Label> labels;

        public static List<Label> AllLabels
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
