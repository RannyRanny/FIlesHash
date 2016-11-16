using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesHash
{
    struct ConsumerData
    {
        public string FilePath { get; set; }

        public ConsumerData(string path)
        {
            FilePath = path;
        }
    }
}
