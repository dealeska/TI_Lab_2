using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_Lab_2
{
    class RSA
    {
        private long Fast_Exp(long a, long z, long n)
        {
            long a1 = a, z1 = z, x = 1;
            while (z1 != 0)
            {
                while (z1 % 2 == 0)
                {
                    z1 = z1 / 2;
                    a1 = (a1 * a1) % n;
                }
                z1 = z1 - 1;
                x = (x * a1) % n;
            }
            return x;
        }

        private long[] CreateNewTextNum(long[] textNum, long key, long module)
        {
            long[] result = new long[textNum.Length];

            for (int i = 0; i < textNum.Length; i++)
                result[i] = Fast_Exp(textNum[i], key, module);

            return result;
        }

        public long[] Encrypt(string plaintext, long key, long module)
        {
            long[] textNum = new long[plaintext.Length];
            string ciphertext = "";            

            for (int i = 0; i < plaintext.Length; i++)
                textNum[i] = plaintext[i];

            textNum = CreateNewTextNum(textNum, key, module);

            for (int i = 0; i < textNum.Length; i++)
            {
                ciphertext += textNum[i] + " ";
            }

            return textNum;
        }

        public string Decrypt(long[] ciphertext, long key, long module)
        {
            string plaintext = "";
            long[] textNum = new long[ciphertext.Length];

            textNum = CreateNewTextNum(ciphertext, key, module);

            for (int i = 0; i < ciphertext.Length; i++)
            {
                plaintext += (char)(textNum[i]);
            }

            return plaintext;
        }
    }
}
