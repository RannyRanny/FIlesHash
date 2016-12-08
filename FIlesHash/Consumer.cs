using Oracle.ManagedDataAccess.Client;
using System;
using System.Security.Cryptography;
using System.Text;

namespace FilesHash
{
    class HashConsumer
    {
        public void Consume(ConsumerData data, OracleConnection connection)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                string hash = this.GetMd5Hash(md5Hash, data.FilePath);

                Console.WriteLine(data.FilePath + "       " + hash);
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = connection;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText= "INSERT INTO HASHES (FILENAME, FILEHASH) VALUES('"+data.ToString()+"', '"+hash+"')";
                cmd.ExecuteNonQuery();

            }
        }

        private string GetMd5Hash(MD5 md5Hash, string input)
        {
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            return BitConverter.ToString(data);
        }
    }
}
