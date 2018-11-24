namespace Data
{
    public class Label
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public Color Color { get; set; }
        public Font Font { get; set; }

        public Label()
        {

        }
        public Label(string firstName, string lastName, string imagePath, Color color, Font font)
        {
            FirstName = firstName;
            LastName = lastName;
            ImagePath = imagePath;
            Color = color;
            Font = font;
        }
    }
}
