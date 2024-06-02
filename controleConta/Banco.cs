namespace controleConta
{
    public class Banco
    {
        private string nome;
        private string numero;

        public Banco(string nome, string numero)
        {
            this.nome = nome;
            this.numero = numero;
        }

        public string Nome { get => nome; private set => nome = value; }
        public string Numero { get => numero; private set => numero = value; }
    }
}
