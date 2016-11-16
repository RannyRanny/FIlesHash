using System;
using System.Threading;

namespace FilesHash
{
    class Program
    {
        static void Main(string[] args)
        {
			Console.WriteLine("Enter path to hash files");
			string path = Console.ReadLine();
			Thread producer = new Thread(Hasher.Produce);
			producer.Start(path);	
			var threads = new[] { new Thread(Hasher.Consume), new Thread(Hasher.Consume), new Thread(Hasher.Consume), new Thread(Hasher.Consume) };
			foreach(Thread t in threads)
			{
				t.Start();
			}
			Console.ReadLine();
        }
    }
}
