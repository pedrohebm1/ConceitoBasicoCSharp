namespace controleConta
{
    public class Agencia
    {
        public String NumeroAgencia {  get; private set; }
        public String Cep { get; private set; }
        public String Telephone { get; private set; }
        public Banco Banco { get; private set; }

        public Agencia(string numeroAgencia, string cep, string telephone, Banco banco)
        {
            NumeroAgencia = numeroAgencia;
            Cep = cep;
            Telephone = telephone;
            Banco = banco;
        }
    }
}
