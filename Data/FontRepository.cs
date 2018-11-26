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
                { "Calligraph", new Font("Calligraph", "Resources/Fonts/#Calligraph") },
                { "Lato Heavy Italic", new Font("Lato Heavy Italic", "Resources/Fonts/#Lato Heavy") },
                { "Lobster", new Font("Lobster", "Resources/Fonts/#Lobster") },
                { "Monotype Corsiva", new Font("Monotype Corsiva", "Resources/Fonts/#Monotype Corsiva") },
                { "Tahoma", new Font("Tahoma", "Resources/Fonts/#Tahoma") },
                { "Yikes!", new Font("Yikes!", "Resources/Fonts/#Yikes!") }
            };

            return fonts;
        }
    }
}
