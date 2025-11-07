using System;
using System.Drawing;

namespace TM;
class TesteMesa2
{
	public static void Teste1()
	{
		Console.WriteLine("Insira o Valor");
		double valor = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Insira a Taxa");
		double taxa = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Insira o Periodo");
		double periodo = Convert.ToDouble(Console.ReadLine());

		double valorFinal;

		for (int i = 1; i <= periodo; i++)
		{
			valorFinal = valor * Math.Pow((1 + taxa), i);
			Console.Write($"\nMês: {i}\t");
			Console.Write($"Montante: {valor.ToString("f2")}\t");
			Console.Write($"Taxa: {taxa.ToString("f3")}\t");
			Console.Write($"Valor Presente: {valorFinal.ToString("f2")}");
		}
	}

	public static void Teste2()
	{
		Console.WriteLine("Insira o Valor");
		double valor = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Insira a Taxa");
		double taxa = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Insira o Periodo");
		double periodo = Convert.ToDouble(Console.ReadLine());

		double valorFinal;

		for (int i = 1; i <= periodo; i++)
		{
			valorFinal = valor * Math.Pow((1 + taxa), i);
			Console.Write($"\nMês: {i}\t");
			Console.Write($"Montante: {valor.ToString("f2")}\t");
			Console.Write($"Taxa: {taxa.ToString("f3")}\t");
			Console.Write($"Valor Presente: {valorFinal.ToString("f2")}");
		}
	}

	public static void Teste3()
	{
		Console.WriteLine("Valor: ");
		double valor = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Taxa: ");
		double taxa = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Periodo em anos: ");
		double periodoAnos = Convert.ToDouble(Console.ReadLine());

		double valorFinal;

		for(int i = 1; i <= periodoAnos; i++)
		{
			valorFinal = valor * Math.Pow((1 + taxa), i);
			Console.Write($"\nAno: {i}\t");
			Console.Write($"Montante: {valor.ToString("f2")}\t");
			Console.Write($"Taxa: {taxa.ToString("f3")}\t");
			Console.Write($"RL: {(valorFinal - valor).ToString("f2")}");

			if (i == periodoAnos) Console.WriteLine($"\nValor final: {valorFinal.ToString("f2")}");
		}
	}

	public static void Teste4()
	{
		Console.WriteLine("Valor: ");
		double valor = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Taxa: ");
		double taxa = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Periodo em meses: ");
		double periodo = Convert.ToDouble(Console.ReadLine());

		double valorFinal;

		for (int i = 0; i <= periodo; i++)
		{
			if (i == 5) valor -= 1000;
			valorFinal = valor * Math.Pow((1 + taxa), i);

			Console.Write($"\nMês: {i}\t");
			Console.Write($"Montante: {valor.ToString("f2")}\t");
			Console.Write($"Taxa: {taxa.ToString("f3")}\t");
			Console.Write($"RL: {(valorFinal - valor).ToString("f2")}\t");
			Console.Write($"RA: {(valorFinal).ToString("f2")}");
		}
	}

	public static void Teste5()
	{
		Console.WriteLine("Valor: ");
		double valor = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Taxa: ");
		double taxa = Convert.ToDouble(Console.ReadLine());
		Console.WriteLine("Periodo em meses: ");
		double periodo = Convert.ToDouble(Console.ReadLine());

		double valorFinal;

		valorFinal = valor * Math.Pow((1 + taxa), periodo);

		// valor = Math.Pow((1 + taxa), periodo) / valorFinal;
	}
}