using System.Collections.Generic;
using System.Threading;
using System;

namespace ByteBank.Entities
{
    public class Program
    {

        public static void Main(string[] args)
        {
            List<DadosBancarios> Clientes = new List<DadosBancarios>();

            int option;

            int optionsMenu2;


            do
            {
                Operacoes.ShowMenu();

                bool converterEntrada = int.TryParse(Console.ReadLine(), out option);

                if (option < 0 || option > 6 || !converterEntrada)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Opção inválida, tente novamente.");

                    Thread.Sleep(3000);

                    Console.ResetColor();

                    Operacoes.ShowMenu();

                    converterEntrada = int.TryParse(Console.ReadLine(), out option);

                }



                switch (option)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("O programa está sendo encerrado.");

                        Console.ResetColor();

                        break;

                    case 1:

                        Operacoes.RegistrarNovoUsuario(Clientes);


                        break;

                    case 2:

                        Operacoes.DeletarUsuario(Clientes);

                        break;

                    case 3:

                        Operacoes.ListarTodasAsContas(Clientes);


                        break;

                    case 4:

                        Operacoes.DetalharUsuario(Clientes);


                        break;

                    case 5:

                        Operacoes.SomaDeValores(Clientes);

                        break;

                    case 6:


                        do
                        {
                            Console.Clear();

                            Operacoes.ShowMenu2();

                            bool converterEntrada2 = int.TryParse(Console.ReadLine(), out optionsMenu2);

                            if(optionsMenu2 < 1 || optionsMenu2 > 4 || !converterEntrada2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine("Opção inválida, tente novamente.");

                                Thread.Sleep(3000);

                                Console.ResetColor();

                                Operacoes.ShowMenu2();

                                converterEntrada2 = int.TryParse(Console.ReadLine(), out optionsMenu2);

                            }

                            switch (optionsMenu2)
                            {
                                case 1:

                                    Operacoes.Deposito(Clientes);

                                    break;

                                case 2:

                                    Operacoes.Saque(Clientes);

                                    break;

                                case 3:

                                    Operacoes.Transferencia(Clientes);

                                    break;

                                case 4:

                                    Console.WriteLine("Voltando ao menu principal.");

                                    break;

                            }
                        } while (optionsMenu2 != 4);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("-----------------------------------------------------------------------------------");
                        Console.ResetColor();

                        break;

                }



            } while (option != 0);


        }

    }
}
