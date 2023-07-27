using System;
using System.Collections.Generic;

class Transacao
{
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
}

class Program
{
    static List<Transacao> transacoes = new List<Transacao>();

    static void Main()
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("===== Controle de Finanças =====");
            Console.WriteLine("1 - Adicionar Receita");
            Console.WriteLine("2 - Adicionar Despesa");
            Console.WriteLine("3 - Listar Transações");
            Console.WriteLine("4 - Calcular Saldo");
            Console.WriteLine("0 - Sair");

            Console.Write("Escolha uma opção: ");
            string escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    AdicionarTransacao(true);
                    break;
                case "2":
                    AdicionarTransacao(false);
                    break;
                case "3":
                    ListarTransacoes();
                    break;
                case "4":
                    CalcularSaldo();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void AdicionarTransacao(bool receita)
    {
        Console.Write("Digite a descrição da transação: ");
        string descricao = Console.ReadLine();

        Console.Write("Digite o valor da transação: ");
        decimal valor = decimal.Parse(Console.ReadLine());

        if (!receita)
        {
            valor = -valor; // despesas têm valor negativo
        }

        Transacao transacao = new Transacao
        {
            Descricao = descricao,
            Valor = valor
        };

        transacoes.Add(transacao);

        Console.WriteLine("Transação adicionada com sucesso!");
    }

    static void ListarTransacoes()
    {
        Console.WriteLine("===== Lista de Transações =====");
        foreach (var transacao in transacoes)
        {
            string tipo = transacao.Valor >= 0 ? "Receita" : "Despesa";
            Console.WriteLine($"{transacao.Descricao} ({tipo}): {transacao.Valor:C}");
        }
        Console.WriteLine("===============================");
    }

    static void CalcularSaldo()
    {
        decimal saldo = 0;

        foreach (var transacao in transacoes)
        {
            saldo += transacao.Valor;
        }

        Console.WriteLine($"Saldo total: {saldo:C}");
    }
}
