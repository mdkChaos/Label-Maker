using System.Collections.Generic;

namespace Data
{
    public static class FontRepository
    {
        private static Dictionary<string, Font> fonts;
        public static Dictionary<string, Font> Fonts
        {
            get
            {
                if (fonts == null)
                {
                    fonts = GetFonts();
                }

                return fonts;
            }
        }

        private static Dictionary<string, Font> GetFonts()
        {
            Dictionary<string, Font> fonts = new Dictionary<string, Font>
            {
                { "Angry Birds", new Font("Angry Birds", "Resources/Fonts/#AngryBirds") },
                { "Arial", new Font("Arial", "Resources/Fonts/#Arial") },
                { "Lato Heavy Italic", new Font("Lato Heavy Italic", "Resources/Fonts/#Lato Heavy") },
                { "Monotype Corsiva", new Font("Monotype Corsiva", "Resources/Fonts/#Monotype Corsiva") },
                { "Tahoma", new Font("Tahoma", "Resources/Fonts/#Tahoma") }
            };

            return fonts;
        }
    }
}
