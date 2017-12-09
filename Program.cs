using System;
namespace RC4
{
    class Program
    {
        static void Main(string[] args)
        {
            string key;
            string message;
            Console.Write("Masukkan kunci : ");
            key = Console.ReadLine();
            Console.Write("Masukkan Pesan : ");
            message = Console.ReadLine();
            Console.Clear();
            Console.WriteLine(" ");
            Console.WriteLine("=====================================");
            Console.WriteLine(" ");
            StreamRC4 r = new StreamRC4(key);
            r.encrypt(ref message);

            Console.WriteLine(" ");
            Console.WriteLine("=====================================");
            Console.WriteLine(" ");
            StreamRC4 d = new StreamRC4(key);
            d.Decrypt(ref message);
        }
    }
}
