namespace controleConta.Tests
{
    [TestClass]

    public class ContaTests
    {
        Random random = new Random();

        public void ContaTest()
        {
        }

        [TestMethod]
        public void Depositar()
        {
            Banco banco = new Banco("Itau", "495");
            decimal saldo = new Decimal(random.Next(5, 2000));
            Agencia agencia = new Agencia("004", "23945943", "2432048506", banco);
            Cliente cliente = new Cliente("Castanha e arroz", "18374859301", 2004);

            Conta c = new Conta(123123, 10m, agencia, cliente);
            c.Depositar(saldo);

            Assert.AreEqual(saldo+10, c.Saldo);
        }

        [TestMethod]
        public void Sacar()
        {
            decimal saldo = new Decimal(random.Next(50, 2000))+.10m;
            decimal saldoSacar = new Decimal(random.Next(0, 50));
            decimal taxaSaque = 0.10m;

            Banco banco = new Banco("Itau", "495");
            Agencia agencia = new Agencia("004", "23945943", "2432048506", banco);
            Cliente cliente = new Cliente("Castanha e arroz", "18374859301", 2004);
            Conta c = new Conta(123123, saldo, agencia, cliente);

            Assert.IsTrue(c.Sacar(saldoSacar));
            Assert.AreEqual(saldo - (saldoSacar+taxaSaque), c.Saldo);
        }

        [TestMethod]
        public void SacarSaldoInsuficiente()
        {
            decimal saldo = new Decimal(random.Next(50, 2000));
            decimal saldoSacar = saldo;

            Banco banco = new Banco("Itau", "495");
            Agencia agencia = new Agencia("004", "23945943", "2432048506", banco);
            Cliente cliente = new Cliente("Castanha e arroz", "18374859301", 2004);
            Conta c = new Conta(123123, saldo, agencia, cliente);

            Assert.ThrowsException<ArithmeticException>(() => c.Sacar(saldoSacar));
        }

        [TestMethod]
        public void Transferir()
        {
            decimal saldo1 = new Decimal(random.Next(50, 2000));
            decimal saldo2 = new Decimal(random.Next(50, 2000));
            decimal valorTransferir = new Decimal(random.Next(0, 50));

            Banco banco1 = new Banco("Itau", "495");
            Agencia agencia1 = new Agencia("004", "23945943", "2432048506", banco1);
            Cliente cliente1 = new Cliente("Tanga", "18374859301", 2004);
            Conta c1 = new Conta(123123, saldo1, agencia1, cliente1);

            Banco banco2 = new Banco("Itau", "495");
            Agencia agencia2 = new Agencia("004", "23945943", "2432048506", banco2);
            Cliente cliente2 = new Cliente("Bartholomeu", "18374859301", 2004);
            Conta c2 = new Conta(123123, saldo2, agencia2, cliente2);

            c1.Transferir(valorTransferir, c2);

            Assert.AreEqual(c1.Saldo, saldo1 - valorTransferir);
            Assert.AreEqual(c2.Saldo, saldo2 + valorTransferir);
        }

        [TestMethod]
        public void TransferirSaldoInvalido()
        {
            decimal saldo1 = new Decimal(random.Next(50, 2000));
            decimal saldo2 = new Decimal(random.Next(50, 2000));
            decimal valorTransferir = saldo1+0.10m;

            Banco banco1 = new Banco("Itau", "495");
            Agencia agencia1 = new Agencia("004", "23945943", "2432048506", banco1);
            Cliente cliente1 = new Cliente("Tanga", "18374859301", 2004);
            Conta c1 = new Conta(123123, saldo1, agencia1, cliente1);

            Banco banco2 = new Banco("Itau", "495");
            Agencia agencia2 = new Agencia("004", "23945943", "2432048506", banco2);
            Cliente cliente2 = new Cliente("Bartholomeu", "18374859301", 2004);
            Conta c2 = new Conta(123123, saldo2, agencia2, cliente2);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => c1.Transferir(valorTransferir, c2));
        }

        [TestMethod]
        public void TransferirSaldoSemConta()
        {
            decimal saldo1 = new Decimal(random.Next(50, 2000));
            decimal valorTransferir = saldo1;

            Banco banco1 = new Banco("Itau", "495");
            Agencia agencia1 = new Agencia("004", "23945943", "2432048506", banco1);
            Cliente cliente1 = new Cliente("Tanga", "18374859301", 2004);
            Conta c1 = new Conta(123123, saldo1, agencia1, cliente1);

            Assert.ThrowsException<ArgumentNullException>(() => c1.Transferir(valorTransferir, null));


        }
    }
}