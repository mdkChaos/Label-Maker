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
                //"pack://application:,,,/Resources/Fonts/#Tahoma"
                new Font("Angry Birds", "#AngryBirds"),
                new Font("Arial", "#Arial"),
                new Font("Lato Heavy Italic", "#Lato Heavy"),
                new Font("Monotype Corsiva", "#Monotype Corsiva"),
                new Font("Tahoma", "#Tahoma")
            };

            return fonts;
        }
    }
}
