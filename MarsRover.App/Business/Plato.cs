using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.App.Business
{
    public interface IPlato
    {
        Pozisyon PlatoPozisyon { get; }
    }
    public class Plato : IPlato
    {
        public Pozisyon PlatoPozisyon { get; set; }
        public Plato(Pozisyon pozisyon)
        {
            PlatoPozisyon = pozisyon;
        }
    }
}
