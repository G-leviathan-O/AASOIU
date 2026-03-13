using distance_DamerauLevenshtein;

namespace AASOIUClassic
{
	internal class Program
	{
		static void Main(string[] args)
		{
			while (true) {
				Console.WriteLine("Введите первую строку(\"exit\" для выхода): ");
				string str1 = Console.ReadLine() ?? "";
				if (str1 == "exit")
					break;
				Console.WriteLine("Введите вторую строку: ");
                string str2 = Console.ReadLine() ?? "";
				DamerauLevenshtein.WriteDistance(str1, str2);
            }
		}
	}
}
