namespace FilesHash
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Oracle.ManagedDataAccess.Client;
    using System.Collections.Concurrent;
    /// <summary>
    /// Namespace for main methods of calculating hash
    /// </summary>
    static class Hasher
    {
        private static string dbPath = AppDomain.CurrentDomain.BaseDirectory + "db.sqlite";
        private static BlockingCollection<ConsumerData> col = new BlockingCollection<ConsumerData>();

        public static void Produce(object directoryPathObj)
        {
            string directoryPath = (string)directoryPathObj;
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine("No such directory");
                return;
            }

            IEnumerator<string> dirEnum;
            try
            {
                dirEnum = Directory.EnumerateDirectories(directoryPath).GetEnumerator();
                IEnumerator<string> fileEnumerator;
                fileEnumerator = Directory.EnumerateFiles(directoryPath).GetEnumerator();
                while (fileEnumerator != null && fileEnumerator.MoveNext())
                {
                    col.Add(new ConsumerData(fileEnumerator.Current));
                }
                while (dirEnum != null && dirEnum.MoveNext())
                {
                    Produce(dirEnum.Current);
                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Access denied " + directoryPath);
            }
        }

        public static void Consume()
        {
            using (OracleConnection connection = new OracleConnection(@"Data Source=localhost//XE; User ID=Ranny; Password=Ranny"))
            {
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                foreach (var data in col.GetConsumingEnumerable())
                {
                    HashConsumer consumer = new HashConsumer();
                    consumer.Consume(data, connection);
                }
            }
        }
    }
}
