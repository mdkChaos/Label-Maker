using System.Collections.Generic;

namespace Data
{
    public static class ColorRepository
    {
        private static Dictionary<string, Color> colors;
        public static Dictionary<string, Color> Colors
        {
            get
            {
                if (colors == null)
                {
                    colors = GetColors();
                }
                return colors;
            }
        }

        private static Dictionary<string, Color> GetColors()
        {
            Dictionary<string, Color> colors = new Dictionary<string, Color>
            {
                { "1", new Color("Black", "#0e0e10") },
                { "2", new Color("Red", "#cc2c24") },
                { "3", new Color("Blue", "#005b8c") },
                { "4", new Color("Pink", "#bc4077") },
                { "5", new Color("Green", "#61993b") },
                { "6", new Color("Ginger", "#e25303") },
                { "7", new Color("Purple", "#76689a") }
            };

            return colors;
        }
    }
}
