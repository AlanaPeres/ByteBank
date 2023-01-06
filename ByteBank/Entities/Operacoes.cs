using System.Collections.Generic;
using System.Threading;
using System;

namespace ByteBank.Entities
{
    public class Operacoes
    {

        public static void ShowMenu()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("------------------------------------------------BEM VINDO AO BYTEBANK------------------------------------------------\n\n\n");

            Console.ForegroundColor = ConsoleColor.White;


            Console.WriteLine("1 - Cadastrar novo usuário");

            Console.WriteLine("2 - Deletar um usuário");

            Console.WriteLine("3 - Listar todas as contas registradas");

            Console.WriteLine("4 - Detalhes de um usuário");

            Console.WriteLine("5 - Total armazenado no banco");

            Console.WriteLine("6 - Transações financeiras\n\n"); //depósito, transferência, saque e sair.

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------\n\n");

            Console.Write("Digite a opção desejada: \n");

            Console.ResetColor();


        }



        public static void RegistrarNovoUsuario(List<DadosBancarios> Clientes)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("1 - CADASTRAR NOVO USUÁRIO\n");

            Console.ResetColor();

            Console.Write("Digite o número de CPF: \n");

            string cpf = Console.ReadLine();

            ValidarCpf(cpf);

            Console.Write("\nDigite o nome do Usuário: \n");

            string titular = Console.ReadLine();

            Console.Write("\nEscolha uma senha com 4 dígitos: \n");

            string senha = Console.ReadLine();

            Console.Write("\nDigite a quantia a ser depositada: \n");

            double saldo = double.Parse(Console.ReadLine());

            int conta = accountNumberSeed;

            accountNumberSeed++;



            Clientes.Add(new DadosBancarios(titular, cpf, senha, saldo, conta));

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nUsuário cadastrado com sucesso.");

            DadosBancarios Buscar = Clientes.Find(x => x.Cpf == cpf);

            Console.WriteLine($"O número de registro da sua conta é {Buscar.Conta}.");

            Console.ResetColor();

            Thread.Sleep(4000);
        }


        private static int accountNumberSeed = 1234567890;

        public static bool ValidarCpf(string cpf)
        {
            bool CpfValido = true;

            if (cpf.Length != 11)
            {
                int contador = 0;

                CpfValido = false;

                do
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("O CPF deve conter 11 dígitos. \n");

                    Console.WriteLine("Digite novamente o CPF: \n");

                    Console.ResetColor();

                    cpf = Console.ReadLine();

                    Thread.Sleep(3000);

                } while (CpfValido == true);

            }

            return CpfValido;
        }


        public static void DeletarUsuario(List<DadosBancarios> Clientes)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("2 - DELETAR USUÁRIO \n");

            Console.ResetColor();

            Console.WriteLine("\nPor favor, digite o CPF do usuário a ser deletado: ");

            string UsuarioASerDeletado = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == UsuarioASerDeletado);

            DadosBancarios deletar = Clientes.Find(x => x.Cpf == UsuarioASerDeletado);

            if (BuscarIndex == -1)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("2 - DELETAR USUÁRIO\n");

                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível deletar esta Conta");

                Console.WriteLine("MOTIVO: Conta não encontrada.");

                Thread.Sleep(3000);

                Console.ResetColor();

            }
            else
            {

                Console.WriteLine("\nConfirme agora a senha da conta a ser deletada: ");

                string senhaAserDeletada = Console.ReadLine();

                int buscarIndex2 = Clientes.FindIndex(x => x.Senha == senhaAserDeletada);

                if (buscarIndex2 == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Não foi possível deletar esta conta.");

                    Console.WriteLine("MOTIVO: Senha inválida.");

                    Thread.Sleep(3000);

                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"\nUsuário {deletar.Titular} deletado com sucesso!");

                    Thread.Sleep(3000);

                    Clientes.Remove(deletar);
                }


            }


            Console.WriteLine();

        }

        public static void ListarTodasAsContas(List<DadosBancarios> Clientes)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(" 3 - LISTAR TODAS AS CONTAS REGISTRADAS\n");

            Console.ResetColor();

            foreach (DadosBancarios obj in Clientes)
            {

                Console.WriteLine(obj);


            }
            Thread.Sleep(5000);
        }


        public static void DetalharUsuario(List<DadosBancarios> Clientes)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("4 - DETALHES DE UM USUÁRIO \n");

            Console.ResetColor();

            Console.WriteLine("\nDigite o cpf do usuário a ser detalhado: ");

            string UsuarioDetalhado = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == UsuarioDetalhado);

            DadosBancarios usuario = Clientes.Find(x => x.Cpf == UsuarioDetalhado);

            Console.WriteLine();


            if (BuscarIndex == -1)
            {
             
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nNão foi possível apresentar esta Conta");

                Console.WriteLine("MOTIVO: Conta não encontrada.");

                Console.ResetColor();

                Thread.Sleep(2000);

            }
            else
            {

                Console.WriteLine("\nConfirme agora a senha da conta a ser detalhada: ");

                string senhaAserDetalhada = Console.ReadLine();

                int buscarIndex2 = Clientes.FindIndex(x => x.Senha == senhaAserDetalhada);

                if (buscarIndex2 == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Não foi possível detalhar esta conta.");

                    Console.WriteLine("MOTIVO: Senha inválida.");

                    Console.ResetColor();

                    Thread.Sleep(4000);
                }
                else
                {
                    Console.WriteLine(usuario);

                    Thread.Sleep(3000);

                }

            }


        }

        public static void SomaDeValores(List<DadosBancarios> Clientes)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("5 - TOTAL ARMAZENADO NO BANCO \n");

            Console.ResetColor();

            double soma = 0;

            foreach (DadosBancarios obj in Clientes)
            {
                soma += obj.Saldo;
            }

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine($"O saldo armazenado no banco é {soma.ToString("f2")}");

            Thread.Sleep(3000);

        }


        public static void ShowMenu2()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("6 - Transações financeiras \n");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Write("---------------------------------------------------------------------------------------------------------------------\n\n");

            Console.ResetColor();

            Console.WriteLine("[1] - Depósito");

            Console.WriteLine("[2] - Saque");

            Console.WriteLine("[3] - Transferência");

            Console.WriteLine("[4] - Sair\n\n");

            Console.Write(" Digite a opção desejada: \n");


        }




        public static void Deposito(List<DadosBancarios> Clientes)
        {

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("[1]DEPÓSITO\n");

            Console.ResetColor();

            Console.WriteLine("Digite o CPF do titular da conta: ");

            String cpfEntrada1 = Console.ReadLine();

            Console.WriteLine("\nNúmero da conta: ");

            int numeroDaConta = int.Parse(Console.ReadLine());

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == cpfEntrada1);

            int BuscarIndex2 = Clientes.FindIndex(x => x.Conta == numeroDaConta);

            DadosBancarios clienteEncontrado = Clientes.Find(x => x.Cpf == cpfEntrada1);
            
            if (BuscarIndex == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível apresentar esta Conta");

                Console.WriteLine("MOTIVO: Conta não encontrada.\n");

                Console.ResetColor();

                Thread.Sleep(3000);

            } 
            else if(BuscarIndex2 == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível apresentar esta Conta");

                Console.WriteLine("MOTIVO: Conta inválida.\n");

                Console.ResetColor();

                Thread.Sleep(3000);
            }
            else
            {
                    Console.WriteLine("\nQual o valor do Depósito? ");

                    double valorDeposito = double.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"\nO valor {valorDeposito.ToString("f2")}, foi depositado com sucesso! ");

                    Console.ResetColor();

                    clienteEncontrado.Saldo += valorDeposito;

                    Thread.Sleep(4000);

            }

            

        }

        public static void Saque(List<DadosBancarios> Clientes)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("[2]SAQUE\n");

            Console.ResetColor();

            Console.WriteLine("Digite o CPF do titular da conta: ");

            string CpfParaSaque = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == CpfParaSaque);


            if (BuscarIndex == -1)
            {


                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível sacar desta Conta");

                Console.WriteLine("MOTIVO: Cliente não encontrado(a).");

                Console.ResetColor();

                Thread.Sleep(3000);
            }
            else
            {

                Console.WriteLine("\nConfirme sua senha: ");

                string senha = Console.ReadLine();

                int BuscarIndex3 = Clientes.FindIndex(x => x.Senha == senha);
            

                    if (BuscarIndex3 == -1)
                    {
                         Console.ForegroundColor = ConsoleColor.Red;

                         Console.WriteLine("Não foi possível sacar desta conta.");

                         Console.WriteLine("MOTIVO: Senha Inválida.");

                         Console.ResetColor();

                         Thread.Sleep(4000);
                    }
                    else
                    {

                        DadosBancarios clienteEncontrado = Clientes.Find(x => x.Cpf == CpfParaSaque);

                        Console.WriteLine("\nValor do saque: ");

                        double valorDoSaque = double.Parse(Console.ReadLine());


                    if(valorDoSaque > clienteEncontrado.Saldo)
                    {
                            Console.ForegroundColor = ConsoleColor.Red; 

                            Console.WriteLine("Não foi possível sacar desta conta.");

                            Console.WriteLine("MOTIVO: Saldo insuficiente.");

                            Thread.Sleep(3000);

                            Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("\nSaque efetuado com sucesso!");

                        Console.ResetColor();

                        Thread.Sleep(4000);

                        clienteEncontrado.Saldo -= valorDoSaque;
                    }

                        
                    }

            }


        }


        public static void Transferencia(List<DadosBancarios> Clientes)
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("[3] - TRANSFERENCIA: \n");

            Console.ResetColor();


            Console.WriteLine("Digite o CPF do titular da conta: ");

            string cpfEntrada = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == cpfEntrada);

            if (BuscarIndex == -1)
            {

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("\nNão foi possível efetuar a transferência.");

                Console.WriteLine("MOTIVO: Conta não encontrada.");

                Thread.Sleep(4000);

                Console.ResetColor();
            }
            else
            {

                DadosBancarios cpfEncontrado = Clientes.Find(x => x.Cpf == cpfEntrada);

                Console.WriteLine("\nSenha: ");

                string senhaEntrada = Console.ReadLine();

                int BuscarIndex2 = Clientes.FindIndex(x => x.Senha == senhaEntrada);

                if (BuscarIndex2 == -1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nNão foi possível efetuar a transferência.");

                    Console.WriteLine("MOTIVO: Senha inválida.");

                    Thread.Sleep(4000);

                    Console.ResetColor();

                }
                else
                {

                    Console.WriteLine("\nDigite o número do CPF do titular da conta de destino: ");

                    string cpfDestino = Console.ReadLine();

                    int cpfClienteDestino = Clientes.FindIndex(x => x.Cpf == cpfDestino);


                if (cpfClienteDestino == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nNão foi possível efetuar a transferência.");

                    Console.WriteLine("MOTIVO: Cliente não encontrado.");

                    Thread.Sleep(4000);

                    Console.ResetColor();
                }
                else
                {

                    Console.WriteLine("\nDigite o número da conta de destino: ");

                    int conta = int.Parse(Console.ReadLine());

                    int BuscarIndex5 = Clientes.FindIndex(x => x.Conta == conta);

                if (BuscarIndex5 == -1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nNão foi possível efetuar a transferência.");

                    Console.WriteLine("MOTIVO: Conta não encontrada.");

                    Thread.Sleep(4000);

                    Console.ResetColor();
                 }
                else
                {

                    Console.WriteLine("\nDigite o valor da transferência: ");

                    double valorTransferido = double.Parse(Console.ReadLine());


                    DadosBancarios cliente = Clientes.Find(x => x.Cpf == cpfEntrada);

                if(valorTransferido > cpfEncontrado.Saldo)
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("\nNão foi possível efetuar a transferência.");

                    Console.WriteLine("MOTIVO: Saldo insuficiente.");

                    Thread.Sleep(4000);

                    Console.ResetColor();
                }
                else
                {
                    cliente.Saldo -= valorTransferido;

                    DadosBancarios CpfDestino = Clientes.Find(x => x.Cpf == cpfDestino);


                    CpfDestino.Saldo += valorTransferido;

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine("\nTransferência efetuada com sucesso.");

                    Thread.Sleep(4000);

                    Console.ResetColor();
                 }

                                

                }


            }

        }
    }
}
        }


    }

