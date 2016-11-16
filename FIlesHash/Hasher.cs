using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace FilesHash
{
    static class Hasher
    {
        private static string dbPath = AppDomain.CurrentDomain.BaseDirectory + "db.sqlite";
        public static async void Produce(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("No such directory");
                return;
            }
            IEnumerator<string> fileEnumerator;
            fileEnumerator = Directory.EnumerateFiles(directoryPath).GetEnumerator();
            while(fileEnumerator!=null&&fileEnumerator.MoveNext())
            {
                HashQueue.Enqueue(new ProducerData(fileEnumerator.Current));
            }
            IEnumerator<string> dirEnum;
            dirEnum = Directory.EnumerateDirectories(directoryPath).GetEnumerator();
            while (dirEnum != null && dirEnum.MoveNext())
            {
                Produce(dirEnum.Current);
            }
        }

        public static async void Consume()
        {
            using(SQLite.SQLiteConnection connection=new SQLite.SQLiteConnection(dbPath))
            {

            }
        }
    }
}
