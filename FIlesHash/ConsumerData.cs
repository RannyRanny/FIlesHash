namespace FilesHash
{
    class ConsumerData
    {
        public string FilePath { get; set; }

        public ConsumerData(string path)
        {
            FilePath = path;
        }
		public override string ToString()
		{
			return FilePath;
		}
	}
}
