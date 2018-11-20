namespace Data
{
    public class Font
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public Font()
        {

        }

        public Font(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}
