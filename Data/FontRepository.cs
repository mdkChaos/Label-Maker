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
                { "1", new Font("Angry Birds", "Resources/Fonts/#AngryBirds") },
                { "2", new Font("Calligraph", "Resources/Fonts/#Calligraph") },
                { "3", new Font("Lato Heavy Italic", "Resources/Fonts/#Lato Heavy") },
                { "4", new Font("Lobster", "Resources/Fonts/#Lobster") },
                { "5", new Font("Monotype Corsiva", "Resources/Fonts/#Monotype Corsiva") },
                { "6", new Font("Tahoma", "Resources/Fonts/#Tahoma") },
                { "7", new Font("Yikes!", "Resources/Fonts/#Yikes!") }
            };

            return fonts;
        }
    }
}
