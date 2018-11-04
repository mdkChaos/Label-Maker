using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Label_Maker.Model
{
    public class Label
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }

        public Label()
        {

        }

        public Label(string firstName,string lastName, string imagePath)
        {
            FirstName = firstName;
            LastName = lastName;
            ImagePath = imagePath;
        }
    }
}
