using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilesHash
{
    static class HashQueue
    {
        private const int queueMaxLength=10;
        public static Queue<ConsumerData> MainQueue=new Queue<ConsumerData>();
        public static void Enqueue(ProducerData data)
        {
            lock (MainQueue)
            {
                if (MainQueue.Count >= queueMaxLength) Monitor.Wait(MainQueue);
                MainQueue.Enqueue(new ConsumerData(data.FilePath));
            }
        }
        public static ConsumerData Dequeue()
        {
            ConsumerData data;
            lock(MainQueue)
            {
                data = MainQueue.Dequeue();
                Monitor.PulseAll(MainQueue);
            }
            return data;
        }
    }
}
