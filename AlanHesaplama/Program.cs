using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlanHesaplama
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Hesaplama();
            Console.ReadLine();
        }

        private static void Hesaplama()
        {
            List<byte> ister = new List<byte>();
            List<double> ucgen = new List<double>();
            List<double> dikdörtgen = new List<double>();
            double cevre = 0, alan = 0, hacim = 0;
            ister = Karsilama();
            if (ister[1] == 1)
            {
                if (ister[0] == 1)
                {
                    ucgen = Üçgen();
                    foreach (var item in ucgen)
                        cevre += item;
                    Console.WriteLine("Girmiş olduğunuz kenar uzunluklarının oluşturduğu üçgenin çevresi: " + cevre + " olarak hesaplanmıştır.");
                }
                else if (ister[0] == 2)
                {
                    cevre = 2 * Math.PI * (Daire());
                    Console.WriteLine("Girmiş olduğunuz yarı çaplı dairenin çevresi: " + cevre + " olarak hesaplanmıştır.");
                }
                else if (ister[0] == 3)
                {
                    cevre = 4 * (Kare());
                    Console.WriteLine("Girmiş olduğunuz  kenar uzunluklu karenin çevresi: " + cevre + " olarak hesaplanmıştır.");
                }
                else
                {
                    dikdörtgen = Dikdörtgen();
                    cevre = (2 * dikdörtgen[0]) + (2 * dikdörtgen[1]);
                    Console.WriteLine("Girmiş olduğunuz  kenar uzunluklarına ait dikdörtgenin çevresi: " + cevre + " olarak hesaplanmıştır.");
                }
            }
            else if (ister[1] == 2)
            {
                if (ister[0] == 1)
                {
                    ucgen = Üçgen();
                    foreach (var item in ucgen)
                        cevre += item;
                    alan = Math.Sqrt((cevre / 2) * ((cevre / 2) - ucgen[0]) * ((cevre / 2) - ucgen[1]) * ((cevre / 2) - ucgen[2]));
                    Console.WriteLine("Girmiş olduğunuz kenar uzunluklarının oluşturduğu üçgenin alanı: " + alan + " olarak hesaplanmıştır.");
                }
                else if (ister[0] == 2)
                {
                    alan = Math.PI * Math.Pow(Daire(), 2);
                    Console.WriteLine("Girmiş olduğunuz yarı çaplı dairenin alanı: " + alan + " olarak hesaplanmıştır.");
                }
                else if (ister[0] == 3)
                {
                    alan = Math.Pow(Kare(), 2);
                    Console.WriteLine("Girmiş olduğunuz  kenar uzunluklu karenin alanı: " + alan + " olarak hesaplanmıştır.");
                }
                else
                {
                    dikdörtgen = Dikdörtgen();
                    alan = dikdörtgen[0] * dikdörtgen[1];
                    Console.WriteLine("Girmiş olduğunuz  kenar uzunluklarına ait dikdörtgenin alanı: " + alan + " olarak hesaplanmıştır.");
                }
            }
            else
            {
                if (ister[0] == 1)
                {
                    ucgen = Üçgen();
                    foreach (var item in ucgen)
                        cevre += item;
                    alan = Math.Sqrt((cevre / 2) * ((cevre / 2) - ucgen[0]) * ((cevre / 2) - ucgen[1]) * ((cevre / 2) - ucgen[2]));
                    Console.WriteLine("Lütfen hesaplamak istediğiniz üçgene ait yüksekliği giriniz: ");
                    hacim = (Convert.ToDouble(Console.ReadLine())) * alan;
                    Console.WriteLine("Girmiş olduğunuz kenar uzunlukları ve yükseklik ile oluşturulan üçgen prizmanın hacmi: " + hacim + " olarak hesaplanmıştır.");
                }
                else if (ister[0] == 2)
                {
                    hacim = ((4 * Math.PI * Math.Pow(Daire(), 3)) / 3);
                    Console.WriteLine("Girmiş olduğunuz yarı çaplı kürenin hacmi: " + hacim + " olarak hesaplanmıştır.");
                }
                else if (ister[0] == 3)
                {
                    hacim = Math.Pow(Kare(), 3);
                    Console.WriteLine("Girmiş olduğunuz  kenar uzunluklu kübün hacmi: " + hacim + " olarak hesaplanmıştır.");
                }
                else
                {
                    dikdörtgen = Dikdörtgen();
                    alan = dikdörtgen[0] * dikdörtgen[1];
                    Console.WriteLine("Lütfen hesaplamak istediğiniz dikdörgene ait yüksekliği giriniz: ");
                    hacim = (Convert.ToDouble(Console.ReadLine())) * alan;
                    Console.WriteLine("Girmiş olduğunuz  kenar uzunluklarına ait dikdörtgen prizmanın hacmi: " + hacim + " olarak hesaplanmıştır.");
                }
            }
            YeniIslem();
        }

        private static void YeniIslem()
        {
            try
            {
                Console.WriteLine("Yeni bir hesaplama işlemi yapmak ister misiniz?\n1-Evet\n2-Hayır");
                byte cevap = Convert.ToByte(Console.ReadLine());
                if (cevap == 1)
                {
                    Hesaplama();
                }
                else if (cevap == 2)
                {
                    Console.WriteLine("Görüşmek üzere...");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    YeniIslem();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı değer girdiniz.");
                YeniIslem();
            }

        }

        private static List<byte> Karsilama()
        {
            try
            {
                List<byte> ister = new List<byte>();
                Console.WriteLine("İşlem yapmak istediğiniz Geometrik şekli seçiniz;\n1-Üçgen\n2-Daire\n3-Kare\n4-Diktörgen");
                byte x = Convert.ToByte(Console.ReadLine());
                if (x <= 4 && x > 0)
                {
                    ister.Add(x);
                    Console.WriteLine("İşlem yapmak istediğiniz işlemi seçiniz;\n1-Çevre\n2-Alan\n3-Hacim");
                    byte y = Convert.ToByte(Console.ReadLine());
                    if (y <= 3 && y > 0)
                        ister.Add(y);
                    else
                    {
                        Console.WriteLine("Hatalı değer girdiniz.");
                        return Karsilama();
                    }
                }
                else
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Karsilama();
                }

                return ister;
            }
            catch
            {
                Console.WriteLine("Hatalı değer girdiniz.");
                return Karsilama();
            }
        }

        private static double Daire()
        {
            try
            {
                Console.WriteLine("Lütfen hesaplama yapmak istediğiniz yarı çapı giriniz:  ");
                double x = Convert.ToDouble(Console.ReadLine());
                if (x <= 0)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Daire();
                }
                else
                {
                    return x;
                }

            }
            catch
            {
                Console.WriteLine("Hatalı değer girdiniz.");
                return Daire();
            }
        }

        private static List<double> Dikdörtgen()
        {
            List<double> koseUzunluklari = new List<double>();
            try
            {
                Console.WriteLine("Lütfen hesaplama yapmak istediğiniz köşe uzunluklarını giriniz. \n1. Köşe Uzunluğu: ");
                koseUzunluklari.Add(Convert.ToDouble(Console.ReadLine()));
                if (koseUzunluklari[0] <= 0)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Dikdörtgen();
                }
                Console.WriteLine("2. Köşe Uzunluğunu: ");
                koseUzunluklari.Add(Convert.ToDouble(Console.ReadLine()));
                if (koseUzunluklari[1] <= 0)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Dikdörtgen();
                }
                return koseUzunluklari;

            }
            catch
            {
                Console.WriteLine("Hatalı değer girdiniz.");
                return Dikdörtgen();
            }
        }

        private static List<double> Üçgen()
        {
            List<double> koseUzunluklari = new List<double>();
            try
            {
                Console.WriteLine("Lütfen hesaplama yapmak istediğiniz köşe uzunluklarını giriniz.\n1. Köşe Uzunluğu: ");
                koseUzunluklari.Add(Convert.ToDouble(Console.ReadLine()));
                if (koseUzunluklari[0] <= 0)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Üçgen();
                }
                Console.WriteLine("2. Köşe Uzunluğunu: ");
                koseUzunluklari.Add(Convert.ToDouble(Console.ReadLine()));
                if (koseUzunluklari[1] <= 0)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Üçgen();
                }
                Console.WriteLine("3. Köşe Uzunluğunu: ");
                koseUzunluklari.Add(Convert.ToDouble(Console.ReadLine()));
                if (koseUzunluklari[2] <= 0)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Üçgen();
                }
                return koseUzunluklari;
            }
            catch
            {
                Console.WriteLine("Hatalı değer girdiniz.");
                return Üçgen();
            }

        }

        private static double Kare()
        {
            try
            {
                Console.WriteLine("Lütfen hesaplama yapmak istediğiniz köşe uzunluğunu giriniz. \nKöşe Uzunluğu: ");
                double x = Convert.ToDouble(Console.ReadLine());
                if (x <= 0)
                {
                    Console.WriteLine("Hatalı değer girdiniz.");
                    return Kare();
                }
                else
                {
                    return x;
                }

            }
            catch
            {
                Console.WriteLine("Hatalı değer girdiniz.");
                return Kare();
            }
        }
    }
}
