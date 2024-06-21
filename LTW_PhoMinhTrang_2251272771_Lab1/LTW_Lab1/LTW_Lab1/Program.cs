using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTW_Lab1
{
    class Program
    {
        static bool checksnt(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i < n / 2; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        static bool checkscp(int n)
        {
            int scp = (int)Math.Sqrt(n);
            return scp * scp == n;
        }
        static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu mang: ");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n > 0)
            {
                int[] number = new int[n];
                for (int i = 0; i < n; i++)
                {
                    Console.Write("Nhap phan tu thu " + (i+1) + ": ");
                    number[i] = Convert.ToInt32(Console.ReadLine());
                }
                int count1 = 0; 
                int count2 = 0;
                int sum1 = 0;
                int sum2 = 0;
                //So nguyen to
                Console.Write("\nCac so nguyen to trong mang la:");
                for(int i=0; i < n; i++)
                {
                    if (checksnt(number[i]))
                    {
                        Console.Write(" " + number[i]);
                        count1++;
                        sum1 += number[i];
                    }
                }
                Console.Write("\n=> Co tong " + count1 +" so nguyen to trong mang");
                Console.Write("\nTong cac so nguyen to trong mang la: "+sum1);

                //So chinh phuong
                Console.Write("\n\nCac so chinh phuong trong mang la:");
                for (int i = 0; i < n; i++)
                {
                    if (checkscp(number[i]))
                    {
                        Console.Write(" " + number[i]);
                        count2++;
                        sum2 += number[i];
                    }
                }
                Console.Write("\n=> Co tong " + count2 + " so chinh phuong trong mang");
                Console.Write("\nTong cac so chinh phuong trong mang la: " + sum2);
            }
            else
            {
                Console.WriteLine("Nhap so nguyen n > 0");
            }
            Console.ReadKey();
        }
    }
}
