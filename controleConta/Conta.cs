namespace controleConta
{
    public class Conta
    {
        public decimal Saldo { get; private set; }
        public int Numero { get; private set;  }
        public Agencia Agencia { get; private set; }
        public Cliente Titular {  get; private set; }

        public Conta(int numero, decimal saldo, Agencia agencia, Cliente titular)
        {
            if (saldo < 10) throw new ArgumentOutOfRangeException("Erro: É necessário o saldo inicial haver no mínimo R$10,00");
            if (agencia == null) throw new ArgumentNullException("Error: é necessário possuir uma agencia para abrir a conta");
            if (titular == null) throw new ArgumentNullException("Error: é necessário possuir um titular para abrir a conta");

            Saldo = saldo;
            Numero = numero;
            Agencia = agencia;
            Titular = titular;
        }

        public void Depositar(decimal valor) {
            if (valor > 0) Saldo += valor;
        }

        public bool Sacar(decimal valor) {
            if (!(Saldo - (valor+0.10m) > 0)) throw new ArithmeticException("Erro: Saldo insuficiente para sacar.");

            Saldo -= valor+.10m;
            return true;
        }

        public void Transferir(decimal valor, Conta conta) {
            if (!(Saldo >= valor)) throw new ArgumentOutOfRangeException("Erro: O valor da transferência não corresponde ao saldo.");
            if (!(valor > 0)) throw new ArgumentException("Erro: Favor inserir um valor válido");
            if (conta == null) throw new ArgumentNullException("Erro: É necessário inserir uma conta para realizar a transferência");

            Saldo -= valor;
            conta.Depositar(valor);
        }
    }
}
