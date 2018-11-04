namespace Data
{
    public class Label
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }

        public Label()
        {

        }
        public Label(string firstName, string lastName, string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            ImagePath = imagePath;
        }
    }
}
