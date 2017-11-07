namespace RLEAlgorithm
{
    using Contracts;
    using ReadAndWriteOnFile;
    using ReadAndWriteOnTheConsole;
    using System.Text;

    public class Converter
    {
        public void FromString()
        {
            IReader reader = new FileReader();

            string input = reader.ReadLine();

            char reminder = input[0];
            int cnt = 0;

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                if (reminder == input[i])
                {
                    cnt++;
                }
                else
                {
                    sb.Append($"{cnt}{reminder}");
                    cnt = 1;
                }

                reminder = input[i];
            }

            sb.Append($"{cnt}{reminder}");

            IWriter writer = new FileWriter();

            writer.WriteLine(sb.ToString());
        }

        public void FromCode()
        {
            IReader reader = new FileReader();
            StringBuilder sb = new StringBuilder();

            string input = reader.ReadLine();

            for (int i = 0; i < input.Length; i+=2)
            {
                string result = new string(input[i + 1], int.Parse(input[i].ToString()));

                sb.Append(result);
            }

            IWriter writer = new FileWriter();

            writer.WriteLine(sb.ToString());
        }
    }
}
