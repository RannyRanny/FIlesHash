using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FilesHash
{
    class Hash
    {
        [PrimaryKey]
        public string Path { get; }

        public string CalculatedHash { get; }

        public Hash(string path, string hash)
        {
            Path = path;
            CalculatedHash = hash;
        }
    }
}
