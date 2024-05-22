using Microsoft.VisualStudio.TestTools.UnitTesting;
using controleConta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace controleConta.Tests
{
    [TestClass]

    public class ContaTests
    {
        Random random = new Random();

        public void ContaTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Depositar()
        {
            decimal saldo = new Decimal(random.Next(50, 2000));

            Conta c = new Conta(123123);
            c.Depositar(saldo);

            Assert.AreEqual(saldo, c.Saldo);
        }

        [TestMethod]
        public void Sacar()
        {
            decimal saldo = new Decimal(random.Next(50, 2000));
            decimal saldoSacar = new Decimal(random.Next(0, 50));
            Conta c = new Conta(123123);

            c.Depositar(saldo);

            Assert.IsTrue(c.Sacar(saldoSacar));
            Assert.AreEqual(saldo - saldoSacar, c.Saldo);
        }
    }
}