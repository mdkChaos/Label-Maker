using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelMaker.Model
{
    public static class ColorRepository
    {
        private static ObservableCollection<Color> colors;
        public static ObservableCollection<Color> Colors
        {
            get
            {
                if (colors == null)
                {
                    colors = CreateColors();
                }
                return colors;
            }
        }

        private static ObservableCollection<Color> CreateColors()
        {
            Color color;
            ObservableCollection<Color> colors = new ObservableCollection<Color>();

            color = new Color("#0e0e10", "Black");
            colors.Add(color);
            color = new Color("#cc2c24", "Red");
            colors.Add(color);

            return colors;
        }
    }
}
