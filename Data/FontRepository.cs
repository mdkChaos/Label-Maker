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
                { "1", new Font() { Name = "Angry Birds", Path = "Resources/Fonts/#AngryBirds" } },
                { "2", new Font() { Name = "Calligraph", Path = "Resources/Fonts/#Calligraph" } },
                { "3", new Font() { Name = "Lato Heavy Italic", Path = "Resources/Fonts/#Lato Heavy"} },
                { "4", new Font() { Name = "Lobster", Path = "Resources/Fonts/#Lobster"} },
                { "5", new Font() { Name = "Monotype Corsiva", Path = "Resources/Fonts/#Monotype Corsiva"} },
                { "6", new Font() { Name = "Tahoma", Path = "Resources/Fonts/#Tahoma"} },
                { "7", new Font() { Name = "Yikes!", Path = "Resources/Fonts/#Yikes!"} }
            };

            return fonts;
        }
    }
}
