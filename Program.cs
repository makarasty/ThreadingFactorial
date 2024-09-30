using System.Numerics;

class Program
{
	static void Main()
	{
		const int arraySize = 100;
		int[] array = new int[arraySize];
		BigInteger[] factorials = new BigInteger[arraySize];

		Random random = new();

		for (int i = 0; i < array.Length; i++)
		{
			array[i] = random.Next(1, 101);
		}

		Task[] tasks = new Task[arraySize];

		for (int i = 0; i < arraySize; i++)
		{
			int index = i;
			tasks[i] = Task.Run(() =>
			{
				factorials[index] = Factorial(array[index]);
			});
		}

		Task.WaitAll(tasks);

		Console.WriteLine("Розрахунок закінчено.");

		for (int i = 0; i < arraySize; i++)
		{
			Console.WriteLine($"Факторіал числа: {array[i]}! = {factorials[i]}");
		}
	}

	static BigInteger Factorial(int n)
	{
		if (n == 0)
		{
			return 1;
		}

		return n * Factorial(n - 1);
	}
}
