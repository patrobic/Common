namespace Shared.Files
{
    public class BaseOutputFile
    {
        public BaseOutputFile(byte[] data, string name, string path)
        {
            Data = data;
            Name = name;
            Path = path;
        }

        public byte[] Data { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }
    }
}
