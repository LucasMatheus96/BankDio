using System;
using System.Collections.Generic;
using Dio.Bank;


namespace Dio.Bank
{
    class Program
    {
        static List<Conta> listConta = new List<Conta>();
        static void Main(string[] args)
        {

           
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X")
            {

                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                 opcaoUsuario = ObterOpcaoUsuario();
            }
       

            Console.WriteLine("Obrigado por utilizar nossos serviços");
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank a seu dispor");
            Console.WriteLine("Informe a opção desejada");

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir uma nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();

            Console.WriteLine();

            return opcaoUsuario;
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o numero da conta");
            int entradaNumeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor que deseja sacar");
            double entradaValorSaque = double.Parse(Console.ReadLine());

            listConta[entradaNumeroConta].Sacar(entradaValorSaque);

        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o numero da sua conta");
            int entradaMinhaConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o numero da conta de destino");
            int entradaNumeroConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Informe o valor que deseja transferir");
            double entradaValorSaque = double.Parse(Console.ReadLine());

           
            listConta[entradaMinhaConta].Transferir(entradaValorSaque, listConta[entradaNumeroConta]);

            listConta[entradaMinhaConta].ToString();
            listConta[entradaNumeroConta].ToString();
        }

        private static void Depositar()
        {
            Console.WriteLine("Informe o numero da conta");
            int entradaMinhaConta = int.Parse(Console.ReadLine());

           
            Console.WriteLine("Informe o valor que deseja depositar");
            double entradaValorDeposito = double.Parse(Console.ReadLine());

            listConta[entradaMinhaConta].Depositar(entradaValorDeposito);

        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.WriteLine("Digite 1 para conta fisica ou 2 para juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Limite de credito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta
                                                    , entradaSaldo
                                                    , entradaCredito
                                                    , entradaNome);
            listConta.Add(novaConta);

        }

        private static void ListarContas()
        {
            string retorno = "";

            if (listConta.Count == 0)
            {
                retorno ="Nenhuma conta cadastrada";
                Console.WriteLine(retorno);
            }
            foreach (var listaDeContas in listConta){
                 
                retorno += listaDeContas.ToString();
            }
            Console.WriteLine(retorno);
           
        }
    }

}