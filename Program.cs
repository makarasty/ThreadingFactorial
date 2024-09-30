class Program
{
	static void Main()
	{
		int[] array = new int[100];
		Random random = new();

		for (int i = 0; i < array.Length; i++)
		{
			array[i] = random.Next(1, 101);
		}

		Task[] tasks = new Task[array.Length];

		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i];
			tasks[i] = Task.Run(() =>
			{
				System.Numerics.BigInteger numF = Factorial(num);

				Console.WriteLine($"Факторіал числа: {num}! = {numF}");
			});
		}

		Task.WaitAll(tasks);
	}

	static System.Numerics.BigInteger Factorial(int n)
	{
		if (n == 0)
		{
			return 1;
		}

		return n * Factorial(n - 1);
	}
}
