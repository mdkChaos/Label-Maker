namespace Data
{
    public class Font
    {
        public string Name { get; set; }
        public string BaseURI { get; set; }
        public string Path { get; set; }
        public string FullPath { get { return BaseURI + Path; } }

        public Font()
        {

        }

        public Font(string name, string baseURI, string path)
        {
            Name = name;
            BaseURI = baseURI;
            Path = path;
        }
    }
}
