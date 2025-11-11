using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace TM;

class TesteMesa3
{
	public static void Teste6()
	{
		var entrada1 = new EntradaJuros(1000, 0.03, new DataJuros(meses: 8, dias: 10));
		entrada1.MostrarEntrada();
		var entrada2 = new EntradaJuros(5500, 0.0248, new DataJuros(meses: 8, dias: 10));
		entrada2.MostrarEntrada();
		var entrada3 = new EntradaJuros(12000, 0.02, new DataJuros(meses: 8, dias: 10));
		entrada3.MostrarEntrada();
	}
	public static void Teste7()
	{
		var entrada1 = new EntradaJuros(valorInicial: 1000, taxa: 0.03, data: new DataJuros(meses: 8, dias: 10));
		entrada1.RemoverValorEntrada(mes: 3, valor: 1000);
		entrada1.MostrarEntrada();
	}
	public static void Teste8()
	{
		Console.Write("Quantas entradas serão adicionadas? ");
		int nEntradas = Convert.ToInt32(Console.ReadLine());
		int aux = nEntradas;

		while (nEntradas > 0)
		{
			Console.Write($"\nInsira o valor da entrada {(aux - nEntradas) + 1}: ");
			double valorEntrada = Convert.ToInt32(Console.ReadLine());
			Console.Write($"Insira a taxa de juros: ");
			double taxa = Convert.ToDouble(Console.ReadLine());
			Console.Write($"Insira o periodo (meses): ");
			int dataMes = Convert.ToInt32(Console.ReadLine());
			Console.Write($"Insira o periodo (dias): ");
			int dataDias = Convert.ToInt32(Console.ReadLine());

			Console.Write("\nDeseja fazer uma retirada (s / n)? ");
			char retiradaResposta = Convert.ToChar(Console.ReadLine());

			Console.WriteLine();
			var entrada = new EntradaJuros(valorInicial: valorEntrada, taxa: taxa, data: new DataJuros(meses: dataMes, dias: dataDias));

			if (retiradaResposta.Equals('s'))
			{
				Console.Write($"Insira o mês de retirada: ");
				int retiradaMes = Convert.ToInt32(Console.ReadLine());
				Console.Write($"Insira o valor de retirada: ");
				double retiradaValor = Convert.ToDouble(Console.ReadLine());
				entrada.RemoverValorEntrada(mes: retiradaMes, valor: retiradaValor);
			}
			
			Console.WriteLine();

			entrada.MostrarEntrada();

			nEntradas -= 1;
		}
	}
}


class DataJuros
{
	private int _meses;
	private int _dias;
	public int Meses { get { return _meses; } set { _meses = value; } }
	public int Dias { get { return _dias; } set { _dias = value; } }

	public DataJuros(int meses, int dias)
	{
		_meses = meses;
		_dias = dias;
	}
	public double RetornarJurosDias()
	{
		return _meses + (Convert.ToDouble(_dias) / 30);
	}
}
class EntradaJuros
{
	private readonly double _valorInicial;
	private readonly double _taxa;
	private readonly DataJuros _data;
	private double _valorBase;
	private double[] _retiradas;
	private double[] _valores;

	public EntradaJuros (double valorInicial, double taxa, DataJuros data)
	{
		_taxa = taxa;
		_data = data;
		// Meses + 2 onde +1 é o valor inicial e +1 o sobrante em dias
		_valores = new double[data.Meses + 2];
		_retiradas = new double[data.Meses + 2];
		_valorBase = valorInicial;
		_valorInicial = valorInicial;

		CalcularValores(0, valorInicial, taxa, data);
		
		// log de entrada
		Console.WriteLine("Adicionado Entrada:");
		Console.Write($"Investido: ${valorInicial}\t");
		Console.Write($"Taxa: {(taxa * 100).ToString("f2")}%\t");
		Console.Write($"Periodo: {data.Meses} meses {(data.Dias > 0 ? ("e " + data.Dias + " dias") : "")}\n\n");
	}

	public void MostrarEntrada()
	{
		string res = "";
		for (int i = 0; i < _valores.Length; i++)
		{
			ref double valorAtual = ref _valores[i];

			res += $"Taxa: {(_taxa * 100).ToString("f2")}%\t";
			res += $"Valor: ${valorAtual.ToString("f2")}\t\t";

			//if (valorAtual - _retiradas[i] < _valorBase) // case remoção
			if (valorAtual - _retiradas[i] >= _valorInicial)
			{
				res += $"Lucro liquido: ${((valorAtual - _valorInicial).ToString("f2"))}\t\t";
			}
			else
			{
				res += $"Lucro liquido: ${((valorAtual - _valorBase).ToString("f2"))}\t\t";
			}
			
			res += $"Mês: { ( (i < _valores.Length - 1) ? i : $"{i} ({_data.Dias} dias)") }\n";
		}

		Console.WriteLine(res);
	}

	private void CalcularValores(int mesInicio, double valorInicial, double taxa, DataJuros data)
	{
		int maxValores = data.Meses + 2;

		for (int i = mesInicio; i <= maxValores - 2; i++)
		{
			_valores[i] = valorInicial * Math.Pow((1 + taxa), i - mesInicio);
		}
		_valores[maxValores - 1] = valorInicial * Math.Pow((1 + taxa), data.RetornarJurosDias() - mesInicio);
	}

	public void RemoverValorEntrada(int mes, double valor)
	{
		Console.WriteLine($"${valor.ToString("f2")} removido no mês {mes}\n");

		if (valor <= _valores[mes])
		{
			_valorBase = _valores[mes] -= Convert.ToDouble(valor);
			CalcularValores(mes, _valores[mes], _taxa, _data);
			_retiradas[mes] = valor;
		}
		else Console.WriteLine("Valor de remoção excede o saldo");

		double temp = 0;
		for (int i = 0; i < _retiradas.Length; i++)
		{
			temp += _retiradas[i];
			_retiradas[i] = temp;
		}
	}
}
