using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ayrikreddetmeyontem
{
    class Program
    {
        public double f(double x)
        {
            double fonkResult;
            fonkResult = x;
           // fonkResult = Math.Sqrt(x);

            return fonkResult;
        }
        public double dikdortgenAlan(int altsinir, int ustsinir)
        {
            
            return (Math.Abs(altsinir) + ustsinir) * max(altsinir,ustsinir);
 
        }
        public double mutlakMax(int altsinir, int ustsinir)
        {
            double mutlakmax = 0;
            for (double i = altsinir; i <= ustsinir; i++)
            {
                if (Math.Abs(f(i)) > mutlakmax)
                {
                    mutlakmax = Math.Abs(f(i));
                }
            }
            return mutlakmax;
        }
        public double max(int altsinir, int ustsinir)
        {
            double pozMax = 0,negMax=0,max;
            for (double i = altsinir; i <= ustsinir; i++)
            {
                if(f(i)>pozMax)
                {
                    pozMax = f(i);
                }
                else if(f(i)<negMax)
                {
                    negMax = f(i);
                }
            }
                 if(negMax==0)
                 {
                    max = pozMax;
                 }
                 if (pozMax == 0)
                  {
                      max = negMax;
                  }
                 else
                 {
                     max = Math.Abs(negMax) + pozMax;
                 }
            return max;
        }
        public void rastgeleSayiUret(int altsinir, int ustsinir,ulong iterasyon)
	{
        double taralıAlanrastgeleAdet=0;
       
		Random r=new Random();
        for (ulong i = 0; i < iterasyon; i++)
        {
            double rastgelesayiX = (r.Next(altsinir, ustsinir+1));
            double rastgelesayiY = (r.NextDouble()) * f(mutlakMax(altsinir,ustsinir));

            if (f(rastgelesayiX) >= rastgelesayiY)
            {
                taralıAlanrastgeleAdet++;
            }
            
        }
   	    Console.WriteLine("TaralıAlanrastgeleAdet: " + taralıAlanrastgeleAdet +"\n\n"+ "toplamRastgeleSayi: " + iterasyon+"dir");
            Console.WriteLine("Monte carlo reddetme yöntemi sonucu Alan:" + toplamAlan+" dir");
            //toplam monte carlo alanını verir
            double toplamAlan = (taralıAlanrastgeleAdet / iterasyon) * dikdortgenAlan(altsinir, ustsinir);
            
	}
        static void Main(string[] args)
        {
            Program prg=new Program();
            Console.WriteLine("alt sınır giriniz");
            int altSinir =Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("üst sınır giriniz");
            int ustSinir = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("iterasyon sayisi giriniz");
            ulong iterasyon = Convert.ToUInt64(Console.ReadLine());

            prg.rastgeleSayiUret(altSinir, ustSinir, iterasyon);
            Console.ReadKey();
        }
    }
}
