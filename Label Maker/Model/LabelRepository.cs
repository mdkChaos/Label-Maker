using System.Collections.Generic;
using System.Threading.Tasks;
using Data;
using DataProvider;

namespace LabelMaker.Model
{
    public static class LabelRepository
    {
        public static List<Label> AllLabels
        {
            get
            {
                return ExcelProvider.Labels;
            }
        }

        public static async Task GetLabelsAsync()
        {
            await ExcelProvider.GetLabelsAsync();
        }
    }
}
