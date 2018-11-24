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
                { "Black", new Color("Black", "#0e0e10") },
                { "Red", new Color("Red", "#cc2c24") },
                { "Blue", new Color("Blue", "#005b8c") },
                { "Pink", new Color("Pink", "#bc4077") },
                { "Green", new Color("Green", "#61993b") },
                { "Ginger", new Color("Ginger", "#e25303") },
                { "Purple", new Color("Purple", "#76689a") }
            };

            return colors;
        }
    }
}
