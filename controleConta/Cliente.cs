namespace controleConta
{
    public class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public int AnoNascimento { get; private set; }

        public Cliente(String nome, String cpf, int anoNascimento)
        {
            this.Nome = nome;
            this.Cpf = cpf;
            this.AnoNascimento = anoNascimento;
        }
    }
}
