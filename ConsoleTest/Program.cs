using System;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var errorMessage = "\"{0}\"は数字ではありません。\r\n数字を入れてください。";

            Console.WriteLine("貴方の年齢は何歳？");
            var age = ReadValue<int>(int.TryParse, errorMessage).Result;

            Console.WriteLine("あなたの身長は何cm？");
            var height = ReadValue<int>(int.TryParse, errorMessage).Result;

            Console.WriteLine($"あなたの年齢は{age}歳、身長は{height}cmです。");
            Console.ReadLine();
        }

        private static async Task<T> ReadValue<T>(TryConvert<T> converter, string errorMessage)
        {
            while (true)
            {
                var line = await Console.In.ReadLineAsync();
                if (converter(line, out T res)) return res;

                Console.WriteLine(errorMessage, line);
            }
        }

        // delegateは、C言語で言うところの、関数ポインタやその型定義のこと。
        // C#は、きっちりした静的型付き言語なので、関数ポインタにも型を定義しないといけない。
        // 関数（メソッド）の型とはすなわち、引数の型と戻り値の型の組み合わせ。

        // 例：
        // 変数「errorMessage」の型は「string」
        // メソッド「Main」の型は「string[] -> void」
        // メソッド「int.TryParse」の型は「string, out int -> bool」

        // プログラム内で使うために、「string, out int -> bool」を「TryConvert」という名前で定義
        // （intの代わりに、ジェネリックという機能でTを使っているけど。）
        private delegate bool TryConvert<T>(string src, out T value);
    }
}
