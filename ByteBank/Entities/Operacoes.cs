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

            Console.WriteLine("1 - CADASTRAR NOVO USUÁRIO\n");

            Console.Write("Digite o número de CPF: \n");

            string cpf = Console.ReadLine();

            ValidarCpf(cpf);

            Console.Write("Digite o nome do Usuário: \n");

            string titular = Console.ReadLine();

            Console.WriteLine("Digite seu E-mail para login: ");

            string email = Console.ReadLine();

            Console.Write("Escolha uma senha com 4 dígitos: \n");

            string senha = Console.ReadLine();

            Console.Write("Digite a quantia a ser depositada: \n");

            double saldo = double.Parse(Console.ReadLine());

            int conta = accountNumberSeed;

            accountNumberSeed++;



            Clientes.Add(new DadosBancarios(titular, cpf, senha, saldo, conta, email));

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Usuário cadastrado com sucesso.\n");

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

            Console.WriteLine("2 - DELETAR USUÁRIO \n");

            Console.WriteLine("Por favor, digite o CPF do usuário a ser deletado: ");

            string UsuarioASerDeletado = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == UsuarioASerDeletado);

            DadosBancarios deletar = Clientes.Find(x => x.Cpf == UsuarioASerDeletado);

            if (BuscarIndex == -1)
            {
                Console.Clear();

                Console.WriteLine("2 - DELETAR USUÁRIO\n");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível deletar esta Conta");

                Console.WriteLine("MOTIVO: Conta não encontrada.");

                Thread.Sleep(3000);

                Console.ResetColor();

            }
            else
            {

                Console.WriteLine("Confirme agora a senha da conta a ser deletada: ");

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

                    Console.WriteLine($"Usuário {deletar.Titular} deletado com sucesso!");

                    Thread.Sleep(3000);

                    Clientes.Remove(deletar);
                }


            }


            Console.WriteLine();

        }

        public static void ListarTodasAsContas(List<DadosBancarios> Clientes)
        {
            Console.WriteLine(" 3 - LISTAR TODAS AS CONTAS REGISTRADAS\n");

            foreach (DadosBancarios obj in Clientes)
            {

                Console.WriteLine(obj);


            }
            Thread.Sleep(4000);
        }


        public static void DetalharUsuario(List<DadosBancarios> Clientes)
        {
            Console.WriteLine("4 - DETALHES DE UM USUÁRIO \n");

            Console.WriteLine("Digite o cpf do usuário a ser detalhado: ");

            string UsuarioDetalhado = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == UsuarioDetalhado);

            DadosBancarios usuario = Clientes.Find(x => x.Cpf == UsuarioDetalhado);

            Console.WriteLine();


            if (BuscarIndex == -1)
            {
                Console.WriteLine("4 - DETALHES DE UM USUÁRIO \n");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível apresentar esta Conta");

                Console.WriteLine("MOTIVO: Conta não encontrada.");

                Console.ResetColor();

                Thread.Sleep(2000);

            }
            else
            {
                Console.WriteLine("4 - DETALHES DE UM USUÁRIO \n");

                Console.WriteLine("Confirme agora a senha da conta a ser detalhada: ");

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
            Console.WriteLine("5 - TOTAL ARMAZENADO NO BANCO \n");
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

            Console.WriteLine("[1] - Depósito");

            Console.WriteLine("[2] - Saque");

            Console.WriteLine("[3] - Transferência");

            Console.WriteLine("[4] - Sair\n\n");

            Console.Write(" Digite a opção desejada: \n");


        }


        public static void Deposito(List<DadosBancarios> Clientes)
        {

            Console.Clear();

            Console.WriteLine("[1]DEPÓSITOn\n");

            Console.WriteLine("Digite o CPF do titular da conta: \n");

            String CpfParaDeposito = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == CpfParaDeposito);

            DadosBancarios cpfEncontrado = Clientes.Find(x => x.Cpf == CpfParaDeposito);

            if (BuscarIndex == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível apresentar esta Conta");

                Console.WriteLine("MOTIVO: Conta não encontrada.\n");

                Console.ResetColor();

                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("[1]DEPÓSITO\n");

                Console.WriteLine("Agora confirme o número da conta para efetuar o depósito: \n");

                int NumeroDaConta = int.Parse(Console.ReadLine());

                int BuscarIndex2 = Clientes.FindIndex(x => x.Conta == NumeroDaConta);

                if (BuscarIndex2 == -1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Não foi possível efetuar o depósito.");

                    Console.WriteLine("MOTIVO: Conta não encontrada.");

                    Console.ResetColor();

                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine("Qual o valor do Depósito? \n");

                    double valorDeposito = double.Parse(Console.ReadLine());

                    Console.ForegroundColor = ConsoleColor.Green;

                    Console.WriteLine($"O valor {valorDeposito}, foi depositado com sucesso! ");

                    Console.ResetColor();

                    cpfEncontrado.Saldo += valorDeposito;

                    Thread.Sleep(4000);

                }

            }

        }

        public static void Saque(List<DadosBancarios> Clientes)
        {
            Console.Clear();

            Console.WriteLine("[2]SAQUE\n");

            Console.WriteLine("Digite o CPF do titular da conta: \n");

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

                Console.WriteLine("Por favor, agora digite o número da conta: \n");

                int numeroDaConta = int.Parse(Console.ReadLine());

                int BuscarIndex2 = Clientes.FindIndex(x => x.Conta == numeroDaConta);

                if (BuscarIndex2 == -1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Não foi possível sacar desta conta.");

                    Console.WriteLine("MOTIVO: Conta não encontrada.");

                    Console.ResetColor();

                    Thread.Sleep(3000);
                }
                else
                {

                    Console.WriteLine("[2]SAQUE\n");

                    Console.WriteLine("Confirme sua senha: \n");

                    string senha = Console.ReadLine();

                    int BuscarIndex3 = Clientes.FindIndex(x => x.Senha == senha);

                    if (BuscarIndex3 == -1)
                    {

                        Console.WriteLine("Não foi possível sacar desta conta.");

                        Console.WriteLine("MOTIVO: Senha Inválida.");

                        Thread.Sleep(4000);
                    }
                    else
                    {

                        DadosBancarios cpfEncontrado = Clientes.Find(x => x.Cpf == CpfParaSaque);

                        Console.WriteLine("Valor do saque: \n");

                        double valorDoSaque = double.Parse(Console.ReadLine());

                        if(valorDoSaque > cpfEncontrado.Saldo)
                        {
                            Console.ForegroundColor = ConsoleColor.Red; 

                            Console.WriteLine("Não foi possível sacar desta conta.");

                            Console.WriteLine("MOTIVO: Saldo insuficiente.");

                            Thread.Sleep(3000);

                            Console.ResetColor();
                        }

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Saque efetuado com sucesso!");

                        Console.ResetColor();

                        Thread.Sleep(4000);

                        cpfEncontrado.Saldo -= valorDoSaque;
                    }

                }


            }


        }

        public static void Transferencia(List<DadosBancarios> Clientes)
        {
            Console.Clear();

            Console.WriteLine("[3] - TRANSFERENCIA: \n");

            Console.WriteLine("Digite o número do seu CPF: \n");

            string cpfTitular = Console.ReadLine();

            int BuscarIndex = Clientes.FindIndex(x => x.Cpf == cpfTitular);

            if (BuscarIndex == -1)
            {
                Console.WriteLine("[3] - TRANSFERENCIA: \n");

                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine("Não foi possível efetuar a transferência.");

                Console.WriteLine("MOTIVO: CPF não encontrado.");

                Thread.Sleep(4000);

                Console.ResetColor();
            }
            else
            {

                Console.WriteLine("[3] - TRANSFERENCIA: \n");

                DadosBancarios cpfTitularEncontrado = Clientes.Find(x => x.Cpf == cpfTitular);

                Console.WriteLine("Digite o número da sua conta: \n");

                int numeroDaConta = int.Parse(Console.ReadLine());

                int BuscarIndex2 = Clientes.FindIndex(x => x.Conta == numeroDaConta);

                if (BuscarIndex2 == -1)
                {

                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Não foi possível efetuar a transferência.");

                    Console.WriteLine("MOTIVO: Conta não encontrada.");

                    Thread.Sleep(4000);

                    Console.ResetColor();

                }
                else
                {


                    Console.WriteLine("Digite sua senha: \n");

                    string senha = Console.ReadLine();

                    int BuscarIndex3 = Clientes.FindIndex(x => x.Senha == senha);

                    if (BuscarIndex3 == -1)
                    {


                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Não foi possível efetuar a transferência.");

                        Console.WriteLine("MOTIVO: Senha inválida.");

                        Thread.Sleep(4000);

                        Console.ResetColor();
                    }
                    else
                    {

                        Console.WriteLine("Digite o número do CPF do titular da conta de destino: \n");

                        string cpfDestino = Console.ReadLine();

                        int cpfClienteDestino = Clientes.FindIndex(x => x.Cpf == cpfDestino);

                        if (cpfClienteDestino == -1)
                        {


                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine("Não foi possível efetuar a transferência.");

                            Console.WriteLine("MOTIVO: Cliente não encontrado.");

                            Thread.Sleep(4000);

                            Console.ResetColor();
                        }
                        else
                        {

                            Console.WriteLine("Digite o número da conta de destino: \n");

                            int conta = int.Parse(Console.ReadLine());

                            int BuscarIndex5 = Clientes.FindIndex(x => x.Conta == conta);

                            if (BuscarIndex5 == -1)
                            {

                                Console.ForegroundColor = ConsoleColor.Red;

                                Console.WriteLine("Não foi possível efetuar a transferência.");

                                Console.WriteLine("MOTIVO: Conta não encontrada.");

                                Thread.Sleep(4000);

                                Console.ResetColor();
                            }
                            else
                            {

                                Console.WriteLine("Digite o valor da transferência: \n");

                                double valorTransferido = double.Parse(Console.ReadLine());


                                DadosBancarios cpfParaTranferencia = Clientes.Find(x => x.Cpf == cpfTitular);

                                if(valorTransferido > cpfParaTranferencia.Saldo)
                                {

                                    Console.ForegroundColor = ConsoleColor.Red;

                                    Console.WriteLine("Não foi possível efetuar a transferência.");

                                    Console.WriteLine("MOTIVO: Saldo insuficiente.");

                                    Thread.Sleep(4000);

                                    Console.ResetColor();
                                }
                                else
                                {
                                    cpfParaTranferencia.Saldo -= valorTransferido;

                                    DadosBancarios CpfDestino = Clientes.Find(x => x.Cpf == cpfDestino);


                                    CpfDestino.Saldo += valorTransferido;

                                    Console.ForegroundColor = ConsoleColor.Green;

                                    Console.WriteLine("Transferência efetuada com sucesso.");

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
}
