namespace FilesHash
{
    class HashProducer
    {
        public ConsumerData Produce(ProducerData data)
        {
            ConsumerData path = new ConsumerData(data.FilePath);
            return path;
        }
    }
}
