namespace RLEAlgorithm.ReadAndWriteOnFile
{
    using Contracts;
    using System.IO;

    public class FileReader : IReader
    {
        private const string Path = @"..\RLEAlgorithm\ReadAndWriteOnFile\rle.in.txt";

        public string ReadLine() => File.ReadAllText(Path);
    }
}
