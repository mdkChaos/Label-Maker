﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Color
    {
        public string ColorHEX { get; set; }
        public string Name { get; set; }

        public Color()
        {

        }

        public Color(string colorHEX, string name)
        {
            ColorHEX = colorHEX;
            Name = name;
        }
    }
}
