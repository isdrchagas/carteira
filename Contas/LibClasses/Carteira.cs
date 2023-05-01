using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.LibClasses
{
    public class Carteira
    {
        public DateTime? UltimoPagamentoTarifa { get; set; }
        public double Saldo
        {
            get;
            private set;
        }
        public string Dono { get; set; }
        private int _numeroConta;
        public int NumeroConta { 
            get { return _numeroConta; } 
            private set { _numeroConta = value; } 
        }

        private string _cpf;

        public string Cpf
        {
            get { return _cpf; }
            private set { _cpf = value; }
        }
        public double LimiteConta { get; set; }

        public Carteira (double saldo, string dono, string cpf)
        {
            Saldo = saldo;
            Dono = dono;
            NumeroConta = GerarNumeroConta();
            LimiteConta = GerarLimiteConta(Saldo);
            UltimoPagamentoTarifa = null;
            Cpf = cpf;
        }

        public bool Sacar(double Valor)
        {
            if (!hasAvailableBalance(Valor)) return false;

            this.Saldo -= Valor;
            return true;
        }
        
        public bool Sacar(double Valor, DateTime DataSistema)
        {
            if (!isValidSystemDateTime(DataSistema)) return false;

            var result = Sacar(Valor);
            return result;
        }

        public bool Depositar(double Valor)
        {
            if (Valor <= 0) return false;
            this.Saldo += Valor;
            return true;
        }
        
        public bool Depositar(double Valor, DateTime dataSistema)
        {
            if (!isValidSystemDateTime(dataSistema)) return false;
            return Depositar(Valor);
        }

        public bool Transferir
            (Carteira destino, double valor)
        {
            if (valor <= 0 || this.Saldo <= valor) return false;
            
            this.Sacar(valor);
            bool result = destino.Depositar(valor);
            
            if (result)
            {
                return true;
            }
            else
            {
                this.Depositar(valor);
                return false;
            }
        }

        private int GerarNumeroConta()
        {
            Random randomNumber = new Random();
            int numeroConta = randomNumber.Next(100000, 999999);
            NumeroConta = numeroConta;
            
            return NumeroConta;

        }
        
        private bool isValidSystemDateTime(DateTime DataSistema)
        {
            TimeSpan start = new TimeSpan(08, 0, 0);
            TimeSpan end = new TimeSpan(18, 0, 0);
            var dataSistema = DataSistema.TimeOfDay;

            if (dataSistema < start || dataSistema > end) return false;
            
            return true;
        }

        private bool hasAvailableBalance(Double Valor)
        {
            if (Valor <= 0) return false;
            if (Valor > this.Saldo && Valor > this.LimiteConta) return false;
            
            return true;
        }

        public double GerarLimiteConta(double saldo)
        {
            double limiteConta = saldo/10;
            LimiteConta = limiteConta;
            return LimiteConta;
        }

        public bool CheckCpf(String cpfFirstDigits)
        {
            var firstThreeDigits = this.Cpf.Substring(0, 3);
            return cpfFirstDigits.Equals(firstThreeDigits);
        }
    }
}
