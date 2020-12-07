using System;
using Xunit;
using MarsRover.App.Business;

namespace MarsRover.Test
{
    public class MarsRoverTestMethods
    {
        [Fact]
        public void Test1()
        {
            Plato plato = new Plato(new Pozisyon(5, 5));
            Korsan korsan = new Korsan(plato, new Pozisyon(1, 2), Yon.N);
            korsan.Talimat("LMLMLMLMM");
            string sonuc = korsan.ToString();
            Assert.Equal("1 3 N", sonuc);
        }

        [Fact]
        public void Test2()
        {
            Plato plato = new Plato(new Pozisyon(5, 5));
            Korsan korsan = new Korsan(plato, new Pozisyon(3, 3), Yon.E);
            korsan.Talimat("MMRMMRMRRM");
            string sonuc = korsan.ToString();
            Assert.Equal("5 1 E", sonuc);
        }

        [Fact]
        public void Test3()
        {
            Plato plato = new Plato(new Pozisyon(9, 9));
            Korsan korsan = new Korsan(plato, new Pozisyon(3, 4), Yon.S);
            korsan.Talimat("MLMRMMLLMM");
            string sonuc = korsan.ToString();
            Assert.Equal("4 3 N", sonuc);
        }

        [Fact]
        public void Test4()
        {
            Plato plato = new Plato(new Pozisyon(6, 7));
            Korsan korsan = new Korsan(plato, new Pozisyon(2, 3), Yon.N);
            korsan.Talimat("RRRRLLLLLRRLMLLR");
            string sonuc = korsan.ToString();
            Assert.Equal("2 4 W", sonuc);
        }
    }
}
