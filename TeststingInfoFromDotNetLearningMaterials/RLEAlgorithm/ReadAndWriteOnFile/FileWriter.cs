namespace RLEAlgorithm.ReadAndWriteOnFile
{
    using Contracts;
    using System.IO;

    public class FileWriter : IWriter
    {
        private const string Path = @"..\RLEAlgorithm\ReadAndWriteOnFile\rle.out.txt";

        public void Write(string output)
        {
            File.AppendAllText(Path,output);
        }

        public void WriteLine(string output)
        {
            using (StreamWriter writer = new StreamWriter(Path))
            {
                writer.WriteLine(output);
            }
        }
    }
}
