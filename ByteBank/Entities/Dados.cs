namespace ByteBank.Entities
{
    public class DadosBancarios
    {
        public string Titular;

        public string Cpf;

        public string Senha;

        public double Saldo;

        public int Conta;

       


        public DadosBancarios(string titular, string cpf, string senha, double saldo, int conta)
        {
            Titular = titular;

            Cpf = cpf;

            Senha = senha;

            Saldo = saldo;

            Conta = conta;

           


        }

        public override string ToString()
        {

            return $"Número da Conta {Conta} Titular: {Titular} CPF: {Cpf} Saldo: {Saldo:F2}";

        }

    }
}
