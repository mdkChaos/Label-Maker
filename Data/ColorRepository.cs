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
                { "1", new Color() { Name = "Black", ColorHEX = "#0e0e10" } },
                { "2", new Color() { Name = "Red", ColorHEX = "#cc2c24" } },
                { "3", new Color() { Name = "Blue", ColorHEX = "#005b8c" } },
                { "4", new Color() { Name = "Pink", ColorHEX = "#bc4077" } },
                { "5", new Color() { Name = "Green", ColorHEX = "#61993b" } },
                { "6", new Color() { Name = "Ginger", ColorHEX = "#e25303"} },
                { "7", new Color() { Name = "Purple", ColorHEX = "#76689a"} }
            };

            return colors;
        }
    }
}
