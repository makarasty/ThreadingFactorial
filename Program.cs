class Program
{
	static void Main()
	{
		const int arraySize = 100;
		int[] array = new int[arraySize];

		System.Numerics.BigInteger[] factorials = new System.Numerics.BigInteger[arraySize];

		Random random = new();

		for (int i = 0; i < array.Length; i++)
		{
			array[i] = random.Next(1, 101);
		}
		// Можна було і await Task.WhenAll(...) але треба використовувати async Task...
		Parallel.For(0, arraySize, i =>
		{
			factorials[i] = Factorial(array[i]);
		});

		Console.WriteLine("Розрахунок закінчено.");

		for (int i = 0; i < arraySize; i++)
		{
			Console.WriteLine($"Факторіал числа: {array[i]}! = {factorials[i]}");
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
