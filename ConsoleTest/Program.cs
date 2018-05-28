using System;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("貴方の年齢は何歳？");
            var age = ReadValue();

            Console.WriteLine("あなたの身長は何cm？");
            var height = ReadValue();

            Console.WriteLine($"あなたの年齢は{age}歳、身長は{height}cmです。");
            Console.ReadLine();
        }

        private static int ReadValue()
        {
            while (true)
            {
                var line = Console.ReadLine();
                if (int.TryParse(line, out int res)) return res;

                Console.WriteLine("数字を入力してください。", line);
            }
        }
    }
}
