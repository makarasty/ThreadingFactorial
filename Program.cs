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

		Task<System.Numerics.BigInteger>[] tasks = new Task<System.Numerics.BigInteger>[array.Length];

		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i];
			tasks[i] = Task.Run(() => Factorial(num));
		}

		Task.WaitAll(tasks);

		for (int i = 0; i < tasks.Length; i++)
		{
			Console.WriteLine($"Факторіал числа: {array[i]}! = {tasks[i].Result}");
		}
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
