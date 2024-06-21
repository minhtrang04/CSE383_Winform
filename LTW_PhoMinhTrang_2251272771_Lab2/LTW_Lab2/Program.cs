using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        class Pho
        {
            double thit;
            double banhpho;
            double hanh;
            public Pho()
            {
                thit = 0;
                banhpho = 0;
                hanh = 0;
            }
            public Pho(double thitNew, double banhphoNew, double hanhNew)
            {
                thit = thitNew;
                banhpho = banhphoNew;
                hanh = hanhNew;
            }
            public double tinhtien()
            {
                return thit * 15000 + banhpho * 10000 + hanh * 2000;
            }
            public void nhap()
            {
                Console.Write("Luong thit = ");
                thit = double.Parse(Console.ReadLine());
                Console.Write("Luong banh pho = ");
                banhpho = double.Parse(Console.ReadLine());
                Console.Write("Luong hanh = ");
                hanh = double.Parse(Console.ReadLine());
            }
            public void xuat()
            {
                Console.WriteLine(thit + "\t" + banhpho + "\t" + hanh + "\t" + tinhtien());
            }
            public double Thit { get { return thit; } set { thit = value; } }
            public double Banhpho { get { return banhpho; } set { banhpho = value; } }
            public double Hanh { get { return hanh; } set { thit = hanh; } }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            try { 
            
            Pho[] batpho = new Pho[5];
                //Ví dụ truy cập chỉ số ngoài mảng 5
                //Pho str2 = batpho[6];

                for (int i = 0; i < 5; i++)
            {
                batpho[i] = new Pho();
                Console.WriteLine("Nhap du lieu cho bat pho thu {0}: ", i + 1);
                batpho[i].nhap();
            }
            Console.WriteLine("Thong tin 10 bat pho vua nhap la:\n");
            Console.WriteLine("STT" + "\t" + "Thit" + "\t" + "Banhpho" + "\t" + "Hanh" + "\t" + "Thanhtien");
            for (int i = 0; i < 5; i++)
            {
                Console.Write("{0}\t", i + 1);
                batpho[i].xuat();
            }
            Pho max = batpho[0];
            int sttmax = 0;
            for (int i = 0; i < 5; i++)
            {
                if (max.tinhtien() < batpho[i].tinhtien())
                {
                    max = batpho[i];
                    sttmax = 1;
                }
            }
            Pho min = batpho[0];
            int sttmin = 0;
            for (int i = 0; i < 5; i++)
            {
                if (min.tinhtien() > batpho[i].tinhtien())
                {
                    min = batpho[i];
                    sttmin = i;
                }
            }
            Console.WriteLine("Bat pho thu {1} co gia thap nhat la {0}", min.tinhtien(), sttmin);
            Console.WriteLine("Bat pho thu {1} co gia cao nhat la {0}", max.tinhtien(), sttmax);}
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Error:Chỉ số ngoài mảng ");
            }
            catch (NullReferenceException)
            {
                 Console.WriteLine("Error: đối tượng chưa được cấp phát");
            }
            catch (InvalidCastException)
            { 
              Console.WriteLine("Error: Không chuyển đổi được kiểu dữ liệu");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error: ");
            }

            Console.ReadKey();
        }
    }
}
