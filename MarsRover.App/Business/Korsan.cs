using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.App.Business
{
    public interface IKorsan
    {
        IPlato KorsanPlato { get; set; }
        IPozisyon KorsanPozisyon { get; set; }
        Yon KorsanYon { get; set; }
        void Talimat(string commands);
        string ToString();
    }

    public class Korsan : IKorsan
    {
        public IPlato KorsanPlato { get; set; }
        public IPozisyon KorsanPozisyon { get; set; }
        public Yon KorsanYon { get; set; }

        public Korsan(IPlato korsanPlato, IPozisyon korsanPozisyon, Yon korsanYon)
        {
            KorsanPlato = korsanPlato;
            KorsanPozisyon = korsanPozisyon;
            KorsanYon = korsanYon;
        }

        public void Talimat(string komutlar)
        {
            foreach (var komut in komutlar)
            {
                switch(komut)
                {
                    case 'L' : KorsanYon += 90; break;
                    case 'R' : KorsanYon -= 90; break;
                    case 'M' : HareketEt(); break;
                }
                if(PlatoDisindaMi())
                    break;
            }
            YonBelirle(KorsanYon);
        }

        private bool PlatoDisindaMi() 
        {
            // verilen talimat yerine getirilirken herhangi bir komutla plato disina ciktiysa korsanin x pozisyonu -1 verilir ve talimatlar durdurulur kullaniciya uyarı verilir.
            if (KorsanPozisyon.X > KorsanPlato.PlatoPozisyon.X || KorsanPozisyon.Y > KorsanPlato.PlatoPozisyon.Y || KorsanPozisyon.X < 0 || KorsanPozisyon.Y < 0)
            {
                KorsanPozisyon.X = -1;
                return true;
            }
            return false;
        }

        private void YonBelirle(Yon korsanYon)
        {
            int deger = (Convert.ToInt32(korsanYon)) % 360;
            if (Math.Abs(deger) == 0 )
                KorsanYon = Yon.E;
            else if (deger == 90 || deger == -270)
                KorsanYon = Yon.N;
            else if (Math.Abs(deger) == 180)
                KorsanYon = Yon.W;
            else if (deger == -90 || deger == 270)
                KorsanYon = Yon.S;
        }

        private void HareketEt()
        {
            YonBelirle(KorsanYon);
            switch (KorsanYon) 
            {
                case Yon.E: KorsanPozisyon.X += 1; break;
                case Yon.N: KorsanPozisyon.Y += 1; break;
                case Yon.W: KorsanPozisyon.X -= 1; break;
                case Yon.S: KorsanPozisyon.Y -= 1; break;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", KorsanPozisyon.X, KorsanPozisyon.Y, KorsanYon);
        }
    }
}
