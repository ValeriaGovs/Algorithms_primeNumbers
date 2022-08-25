using System;
using System.Diagnostics;

namespace Algorithms_primeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            
            Console.WriteLine($" 1 вариант. простой перебор");
            program.timeTest(program.isPrime_0);
            Console.WriteLine($"");

            Console.WriteLine($" 2 вариант. улучшенный");
            program.timeTest(program.isPrime_1);
            Console.WriteLine($"");

            Console.WriteLine($" 3 вариант. до n/2");
            program.timeTest(program.isPrime_2);
            Console.WriteLine($"");

            Console.WriteLine($" 4 вариант. до n/2, исключаем четные");
            program.timeTest(program.isPrime_3);
            Console.WriteLine($"");

            Console.WriteLine($" 5 вариант. ищем до корня n");
            program.timeTest(program.isPrime_4);
            Console.WriteLine($"");

            Console.WriteLine($" 5 вариант. ищем до корня n улучшенное");
            program.timeTest(program.isPrime_5);
            Console.WriteLine($"");
        }

        public delegate bool func(ulong n);


        void timeTest( func f)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            int count = 0;
            for (ulong n = 1; n <= 10; n *= 10)
            {
                clock.Start();

                if (f(n))
                {
                    Console.WriteLine($" {n}");
                    count++;
                }

                Console.Write($" до {n}  простых чисел: {count}");
                clock.Stop();

                TimeSpan ts = clock.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);
                Console.WriteLine($"{elapsedTime} ");
            }
        }




        bool isPrime_0(ulong n)
        {
            ulong count =0;
            for (ulong i = 1; i<=n; i++)
            {
                if (n % i == 0)
                    count++;
            }
            return count == 2;
        }

        bool isPrime_1(ulong n)
        {
            for (ulong i = 2; i < n; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
        bool isPrime_2(ulong n)
        {
            for (ulong i = 2; i <= n/2; i++)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        bool isPrime_3(ulong n)
        {
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            
            for (ulong i = 3; i <= n / 2; i+=2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        bool isPrime_4(ulong n)
        {
            if (n == 2) return true;
            if (n % 2 == 0) return false;

            for (ulong i = 3; i <=Math.Sqrt(n); i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }

        bool isPrime_5(ulong n)
        {
            if (n == 2) return true;
            if (n % 2 == 0) return false;
            ulong s =(ulong) Math.Sqrt(n);
            for (ulong i = 3; i <= s; i += 2)
            {
                if (n % i == 0)
                    return false;
            }
            return true;
        }
    }


}
