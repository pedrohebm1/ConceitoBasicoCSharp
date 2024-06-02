using System;
using System.Collections.Generic;

namespace controleConta
{
    class Program
    {
        static List<Conta> contas = new List<Conta>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Bem-vindo ao Sistema de Controle de Contas");
                Console.WriteLine("1 - Criar Conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Transferir");
                Console.WriteLine("5 - Listar Contas");
                Console.WriteLine("6 - Sair");
                Console.Write("Escolha uma opção: ");
                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CriarConta();
                        break;
                    case 2:
                        Depositar();
                        break;
                    case 3:
                        Sacar();
                        break;
                    case 4:
                        Transferir();
                        break;
                    case 5:
                        ListarContas();
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("Opção inválida, tente novamente.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void CriarConta()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Saldo inicial: ");
            decimal saldo = decimal.Parse(Console.ReadLine());

            Console.Write("Número da agência: ");
            string numeroAgencia = Console.ReadLine();

            Console.Write("CEP da agência: ");
            string cep = Console.ReadLine();

            Console.Write("Telefone da agência: ");
            string telefone = Console.ReadLine();

            Console.Write("Nome do banco: ");
            string nomeBanco = Console.ReadLine();

            Console.Write("Número do banco: ");
            string numeroBanco = Console.ReadLine();

            Banco banco = new Banco(nomeBanco, numeroBanco);
            Agencia agencia = new Agencia(numeroAgencia, cep, telefone, banco);

            Console.Write("Nome do titular: ");
            string nomeTitular = Console.ReadLine();

            Console.Write("CPF do titular: ");
            string cpfTitular = Console.ReadLine();

            Console.Write("Ano de nascimento do titular: ");
            int anoNascimento = int.Parse(Console.ReadLine());

            Cliente titular = new Cliente(nomeTitular, cpfTitular, anoNascimento);
            Conta conta = new Conta(numero, saldo, agencia, titular);

            contas.Add(conta);

            Console.WriteLine("Conta criada com sucesso!");
        }

        static Conta BuscarConta(int numero)
        {
            return contas.Find(c => c.Numero == numero);
        }

        static void Depositar()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Conta conta = BuscarConta(numero);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            Console.Write("Valor do depósito: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            conta.Depositar(valor);
            Console.WriteLine("Depósito realizado com sucesso!");
        }

        static void Sacar()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Conta conta = BuscarConta(numero);
            if (conta == null)
            {
                Console.WriteLine("Conta não encontrada.");
                return;
            }

            Console.Write("Valor do saque: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            try
            {
                conta.Sacar(valor);
                Console.WriteLine("Saque realizado com sucesso!");
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void Transferir()
        {
            Console.Write("Número da conta de origem: ");
            int numeroOrigem = int.Parse(Console.ReadLine());

            Conta contaOrigem = BuscarConta(numeroOrigem);
            if (contaOrigem == null)
            {
                Console.WriteLine("Conta de origem não encontrada.");
                return;
            }

            Console.Write("Número da conta de destino: ");
            int numeroDestino = int.Parse(Console.ReadLine());

            Conta contaDestino = BuscarConta(numeroDestino);
            if (contaDestino == null)
            {
                Console.WriteLine("Conta de destino não encontrada.");
                return;
            }

            Console.Write("Valor da transferência: ");
            decimal valor = decimal.Parse(Console.ReadLine());

            try
            {
                contaOrigem.Transferir(valor, contaDestino);
                Console.WriteLine("Transferência realizada com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ListarContas()
        {
            Console.WriteLine("Lista de Contas:");
            foreach (var conta in contas)
            {
                Console.WriteLine($"Número: {conta.Numero}, Saldo: {conta.Saldo}, Titular: {conta.Titular.Nome}");
            }
        }
    }
}