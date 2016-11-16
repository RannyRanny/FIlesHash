namespace FilesHash
{
    struct ProducerData
    {
        public string FilePath { get; set; }

        public ProducerData(string path)
        {
            FilePath = path;
        }
    }
}
