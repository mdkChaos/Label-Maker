using Data;
using System.Collections.ObjectModel;

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
            ObservableCollection<Color> colors = new ObservableCollection<Color>
            {
                new Color("#0e0e10", "Black"),
                new Color("#cc2c24", "Red"),
                new Color("#005b8c" , "Blue"),
                new Color("#bc4077", "Pink"),
                new Color("#61993b", "Green"),
                new Color("#e25303", "Ginger"),
                new Color("#76689a", "Purple")
            };

            return colors;
        }
    }
}
