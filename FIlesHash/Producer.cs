
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesHash
{
    class HashProducer
    {
        public ConsumerData Produce(ProducerData data)
        {
            ConsumerData path = new FilesHash.ConsumerData();
            path.FilePath = data.FilePath;
            return path;
        }
    }
}
