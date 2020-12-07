using System;
using System.Collections;
using System.Text.RegularExpressions;
using MarsRover.App.Business;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Girmek istediğiniz komutlar bittiğinde sonucu gormek icin \"0\" a basabilirsiniz");
            Console.WriteLine("Input:");
            string platoStr;
            platoStr = Console.ReadLine();
            Plato plato = PlatoTanimla(platoStr);
                        
            while(plato.PlatoPozisyon.X == 0)
            {
                Console.WriteLine("Plato sinirlarini dogru girmelisiniz! ör: 5 5");
                platoStr = Console.ReadLine();
                plato = PlatoTanimla(platoStr);
            }
            
            int sayac = 0;
            string deger = "";
            Korsan korsan = new Korsan(plato, new Pozisyon(0, 0), Yon.E);

            ArrayList sonucStr = new ArrayList();
            
            Regex komutReg = new Regex(@"^[L,R,M]*$");
            Regex pozYonReg = new Regex(@"^[0-9]* [0-9]* [E,N,W,S]$");
           
            while (deger != "0")
            {
                deger = Console.ReadLine();
                sayac++;
                if(deger != "0")
                {
                    if (sayac % 2 == 0)
                    {
                        if (komutReg.IsMatch(deger))
                        {
                            deger = Sadelestir(deger.Trim());
                            korsan.Talimat(deger);
                            // verilen talimat yerine getirilirken herhangi bir komutla plato disina ciktiysa talimatlar durdurulur kullaniciya uyarı verilir.
                            if (korsan.KorsanPozisyon.X > plato.PlatoPozisyon.X || korsan.KorsanPozisyon.Y > plato.PlatoPozisyon.Y || korsan.KorsanPozisyon.X < 0 || korsan.KorsanPozisyon.Y < 0 || korsan.KorsanPozisyon.X == -1)
                                Console.WriteLine("Korsan için verilen komut, korsanın plato dışına çıkmasına sebep oldu!");
                            else
                                sonucStr.Add(korsan.ToString());
                        }
                        else
                        { 
                            Console.WriteLine("L, R, M disinda komut verilemez.");
                            sayac--;
                        }
                    }
                    else
                    {
                        if (pozYonReg.IsMatch(deger))
                        {
                            string[] korsanPozisyonYonArr = deger.Trim().Split(' ');

                            korsan.KorsanPozisyon.X = Convert.ToInt32(korsanPozisyonYonArr[0]);
                            korsan.KorsanPozisyon.Y = Convert.ToInt32(korsanPozisyonYonArr[1]);
                            if (korsan.KorsanPozisyon.X > plato.PlatoPozisyon.X || korsan.KorsanPozisyon.Y > plato.PlatoPozisyon.Y || korsan.KorsanPozisyon.X < 0 || korsan.KorsanPozisyon.Y < 0)
                            {
                                Console.WriteLine("Verilen baslangic pozisyonu plato dışında olamaz!");
                                sayac--;
                            }
                            else
                            {
                                korsan = YonBelirle(korsanPozisyonYonArr[2], korsan);
                            }
                        }
                        else
                        {
                            Console.WriteLine("E, N, W, S disinda yon verilemez.");
                            sayac--;
                        }
                    }
                }
            }

            Console.WriteLine("Output:");
            foreach(var sonuc in sonucStr)
            {
                Console.WriteLine(sonuc);
            }
        }

        private static Plato PlatoTanimla(string platoStr)
        {
            Plato plato = new Plato(new Pozisyon(0,0));
            string[] platoStrArr = platoStr.Trim().Split(' ');
            if(platoStrArr.Length == 2)
            {
                int[] platoIntArr = new int[2];
                platoIntArr[0] = Convert.ToInt32(platoStrArr[0]);
                platoIntArr[1] = Convert.ToInt32(platoStrArr[1]);
                plato = new Plato(new Pozisyon(platoIntArr[0], platoIntArr[1]));
            }
           
            return plato;
        }

        private static string Sadelestir(string komut)
        {
            return komut.Replace("LR", "").Replace("RL","").Replace("RRRR","").Replace("LLLL","");
        }

        private static Korsan YonBelirle(string yonStr, Korsan korsan)
        {
            switch (yonStr)
            {
                case "E": korsan.KorsanYon = Yon.E; break;
                case "N": korsan.KorsanYon = Yon.N; break;
                case "W": korsan.KorsanYon = Yon.W; break;
                case "S": korsan.KorsanYon = Yon.S; break;
            }
            return korsan;
        }
    }
}
