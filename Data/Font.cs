namespace Data
{
    public class Font
    {
        public string Name { get; set; }
        public string BaseURI { get; set; } = "pack://application:,,,/";
        public string Path { get; set; }
        public double FontSize { get; set; } = 19;
        public string FullPath { get { return BaseURI + Path; } }

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
