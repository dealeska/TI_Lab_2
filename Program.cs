using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TI_Lab_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Key key = new Key();
            key.CreateKeys();

            RSA cipher = new RSA();
            long[] kek = cipher.Encrypt("AAAAA POMOGITE SPASITE KAKOI SE BRED!!!", key.publicKey, key.module);

            for (int i = 0; i < kek.Length; i++)
                Console.Write(kek[i].ToString());
            Console.WriteLine("\n");
            
            Console.WriteLine(cipher.Decrypt(kek, key.privateKey, key.module));
            Console.ReadLine();
            
        }
    }
}
