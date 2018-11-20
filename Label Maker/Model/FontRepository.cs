using Data;
using System.Collections.ObjectModel;

namespace LabelMaker.Model
{
    public static class FontRepository
    {
        private static ObservableCollection<Font> fonts;
        public static ObservableCollection<Font> Fonts
        {
            get
            {
                if (fonts == null)
                {
                    fonts = CreateFonts();
                }

                return fonts;
            }
        }

        private static ObservableCollection<Font> CreateFonts()
        {
            ObservableCollection<Font> fonts = new ObservableCollection<Font>
            {
                new Font("Angry Birds", "pack://application:,,,/Resources/Fonts/#AngryBirds"),
                new Font("Arial", "pack://application:,,,/Resources/Fonts/#Arial"),
                new Font("Lato Heavy Italic", "pack://application:,,,/Resources/Fonts/#lato-heavy-italic"),
                new Font("Monotype Corsiva", "pack://application:,,,/Resources/Fonts/#monotype corsiva"),
                new Font("Tahoma", "pack://application:,,,/Resources/Fonts/#Tahoma"),
                new Font("Windsor", "pack://application:,,,/Resources/Fonts/#windsor")
            };

            return fonts;
        }
    }
}
