namespace DonemSonuOdevi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Kaç öğrenci kaydetmek istiyorsunuz?");
                int bitisdegeri = int.Parse(Console.ReadLine());
                Console.WriteLine("Vize notunun yüzde kaçı alınacak?");
                int vizeyüzde = int.Parse(Console.ReadLine());
                Console.WriteLine("Final notunun yüzde kaçı alınacak?");
                int finalyüzde = int.Parse(Console.ReadLine());

                string[] ogrenciBilgileri = new string[bitisdegeri];
                int[] ogrenciNotlari = new int[bitisdegeri];
                int[] ogrenciNumaralari = new int[bitisdegeri];
                int[] vizeNotlari = new int[bitisdegeri];
                int[] finalNotlari = new int[bitisdegeri];

                int minVize = 101;
                int maxVize = -1;
                int minFinal = 101;
                int maxFinal = -1;

                for (int i = 0; i < bitisdegeri; i++)
                {
                    Console.WriteLine("Öğrencinin Adını Giriniz.");
                    string ad = Console.ReadLine();
                    Console.WriteLine("Öğrencinin Soyadını Giriniz.");
                    string soyad = Console.ReadLine();
                    Console.WriteLine("Öğrencinin Numarasını Giriniz.");
                    int numara = int.Parse(Console.ReadLine());
                    Console.WriteLine("Öğrencinin Vize Notunu Giriniz");
                    int vize = int.Parse(Console.ReadLine());
                    Console.WriteLine("Öğrencinin Final Notunu Giriniz");
                    int final = int.Parse(Console.ReadLine());

                    if (vize < 0 || vize > 100 || final < 0 || final > 100)
                    {
                        Console.WriteLine("Vize ve Final notları 0-100 aralığında olmalıdır!");
                        i--;
                        continue;
                    }

                    if (vize < minVize) minVize = vize;
                    if (vize > maxVize) maxVize = vize;
                    if (final < minFinal) minFinal = final;
                    if (final > maxFinal) maxFinal = final;

                    int ortalama = (vize * vizeyüzde / 100) + (final * finalyüzde / 100);

                    string harfnotu;
                    if (ortalama >= 85)
                    {
                        harfnotu = "AA";
                    }
                    else if (ortalama >= 75)
                    {
                        harfnotu = "BA";
                    }
                    else if (ortalama >= 60)
                    {
                        harfnotu = "BB";
                    }
                    else if (ortalama >= 50)
                    {
                        harfnotu = "CB";
                    }
                    else if (ortalama >= 40)
                    {
                        harfnotu = "CC";
                    }
                    else if (ortalama >= 30)
                    {
                        harfnotu = "DC";
                    }
                    else if (ortalama >= 20)
                    {
                        harfnotu = "DD";
                    }
                    else if (ortalama >= 10)
                    {
                        harfnotu = "FD";
                    }
                    else
                    {
                        harfnotu = "FF";
                    }

                    string ogrenciBilgisi = $"{numara} {ad} {soyad} - Vize: {vize} - Final: {final} - {harfnotu} - Ortalama: {ortalama}";

                    ogrenciBilgileri[i] = ogrenciBilgisi;
                    ogrenciNotlari[i] = ortalama;
                    ogrenciNumaralari[i] = numara;
                    vizeNotlari[i] = vize;
                    finalNotlari[i] = final;
                }

                Array.Sort(ogrenciNumaralari, ogrenciBilgileri);

                Console.WriteLine("Öğrenciler:");

                for (int i = 0; i < ogrenciBilgileri.Length; i++)
                {
                    Console.WriteLine(ogrenciBilgileri[i]);
                }

                int toplamNot = 0;
                for (int i = 0; i < ogrenciNotlari.Length; i++)
                {
                    toplamNot += ogrenciNotlari[i];
                }

                double sinifOrtalama = (double)toplamNot / ogrenciNotlari.Length;

                Console.WriteLine($"Sınıf Ortalaması: {sinifOrtalama}");

                Console.WriteLine($"En düşük vize notu: {minVize}");
                Console.WriteLine($"En yüksek vize notu: {maxVize}");
                Console.WriteLine($"En düşük final notu: {minFinal}");
                Console.WriteLine($"En yüksek final notu: {maxFinal}");

            }
            catch (FormatException)
            {
                Console.WriteLine("Hatalı formattaki bir giriş yaptınız! Lütfen sayıları doğru formatta girin.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Girdiğiniz sayı çok büyük veya çok küçük. Lütfen geçerli bir sayı girin.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Beklenmeyen bir hata oluştu...");
            }
        }
    }
}
