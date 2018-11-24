namespace Data
{
    public class Color
    {
        public string Name { get; set; } = "Black";
        public string ColorHEX { get; set; } = "#0e0e10";

        public Color()
        {

        }

        public Color(string name, string colorHEX)
        {
            Name = name;
            ColorHEX = colorHEX;
        }
    }
}
