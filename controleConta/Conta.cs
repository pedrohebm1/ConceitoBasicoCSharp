using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace controleConta
{
    public class Conta
    {
        public decimal Saldo { get; private set; }

        public int Numero { get; private set;  }

        public Conta(int numero)
        {
            Numero = numero;
        }

        public void Depositar(decimal valor)
        {
            Saldo += valor;
        }

        public bool Sacar(decimal valor)
        {
            if (valor > Saldo) return false;

            Saldo -= valor;
            return true;
        }
    }
}
