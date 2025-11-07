using System;

class TesteMesa1
{
	public static void Main(string[] args)
	{
		Console.WriteLine("TESTE DE MESA 1:1");
		Teste1();

		Console.WriteLine("TESTE DE MESA 1:2");
		Teste2();

		Console.WriteLine("TESTE DE MESA 1:3");
		Teste3();
	}

	private static void Teste1()
	{
		int[] v = new int[10];

		int a = 10;
		int b = 20;
		int c = (a + b) / 2;
		c -= 40;

		v[3] = a + b + c;

		for (int i = 0; i <= 3; i++)
		{
			Console.Write($"a: {a}\t");
			Console.Write($"b: {b}\t");
			Console.Write($"c: {c}\t");
			Console.Write($"v[{i}]: {v[i]}\n");
		}

		Console.WriteLine("Fim do loop\n\n");
	}

	private static void Teste2()
	{
		int[] v = new int[10];
		int a = 2;


		while (a < 6)
		{
			v[a] = 10 * a;

			Console.Write($"a: {a}\t");
			Console.Write($"v[{a}]: {v[a]}\n");

			a += 1;
		}

		Console.WriteLine("Fim do loop");
		// ultimo print para mostrar 'a' incrementando enquanto
		// 'v[a]' fica vazio pela sequencia do codigo
		Console.Write($"a: {a}\t");
		Console.Write($"v[{a}]: {v[a]}\n\n\n");
	}

	private static void Teste3()
	{
		int[] v = new int[10];

		int a = 7;
		int b = a - 6;

		while (b < a)
		{
			Console.Write($"a: {a}\t");
			Console.Write($"b: {b}\t");

			v[b] = b + a;
			
			Console.Write($"v[{b}]: {v[b]}\n");
			
			b = b + 2;
		}

		Console.WriteLine("Fim do loop");
		// ultimo print para mostrar 'b' indo de 5 para 7 pos loop
		// enquanto 'v[b]' fica vazio por ter ficado fora do loop
		Console.Write($"a: {a}\t");
		Console.Write($"b: {b}\t");
		Console.Write($"v[{b}]: {v[b]}\n\n\n");
	}
}