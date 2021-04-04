using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TI_Lab_2
{
    class Key
    {
        private long[] numbers = { 317, 257, 65537 };
        public long privateKey { get; private set; }
        public long publicKey { get; private set; }
        private long p, q, e, eilerFunc, privateExp;
        public long module { get; private set; }

        private long FindSimpleNumber()
        {
            bool isSimple = false;
            Random random = new Random();
            long simpleNum = 0;

            while (!isSimple)
            {
                simpleNum = random.Next(10000, 20000);
                isSimple = true;
                for (long i = 2; i < Math.Sqrt(simpleNum) + 1; i++)
                {
                    if (simpleNum % i == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }
            }
            return simpleNum;
        }

        private long FindOpenExp(int eilerNum)
        {
            Random rand = new Random();
            long openExp = 0;

            openExp = rand.Next(0, numbers.Length);
            
            return numbers[openExp];
        }

        private void EuclidEx(long a, long b, out long x, out long d)
        {
            long q, r, x1, x2;

            x1 = 0; x2 = 1;           

            while (b > 0)
            {
                q = a / b;
                r = a - q * b;
                x = x2 - q * x1;
                a = b; b = r;
                x2 = x1; x1 = x;
            }

            d = a;
            x = x2;            
        }

        private long FindPrivateExp(long a, long n)
        {
            long x, d;
            EuclidEx(a, n, out x, out d);

            if (d == 1)
                return x;

            return 0;
        }


        public void CreateKeys()
        {
            bool isSimple = false;
            Random random = new Random();           

            while (!isSimple)
            {
                p = random.Next(10000, 20000);
                isSimple = true;
                for (long i = 2; i < Math.Sqrt(p) + 1; i++)
                {
                    if (p % i == 0)
                    {
                        isSimple = false;
                        break;
                    }
                }
            }

            q = FindSimpleNumber();

            module = p * q;

            eilerFunc = (p - 1) * (q - 1);

            e = FindOpenExp((int)eilerFunc);
            publicKey = e;

            privateExp = FindPrivateExp(e, eilerFunc);

            if (privateExp < 0)
                privateExp = privateExp + eilerFunc;
            if (privateExp == 0)
                CreateKeys();

            privateKey = privateExp;
        }

    }
}
