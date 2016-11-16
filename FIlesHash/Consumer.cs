using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FilesHash
{
    class HashConsumer
    {
        public void Consume(ConsumerData data, SQLite.SQLiteConnection connection)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = GetMd5Hash(md5Hash, data.FilePath);
                connection.Insert(new Hash(data.FilePath, hash));
            }
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            return Encoding.Default.GetString(data);
        }

    }
}
