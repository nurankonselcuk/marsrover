using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.App.Business
{
    public interface IPozisyon
    {
        int X { get; set; }
        int Y { get; set; }
    }
    public class Pozisyon : IPozisyon
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Pozisyon(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
