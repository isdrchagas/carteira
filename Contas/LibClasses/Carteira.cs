using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contas.LibClasses
{
    public class Carteira
    {
        private const double Tarifa = 19.90;
        public double Saldo
        {
            get;
            private set;
        }
        public string Dono { get; set; }
        private int NumeroConta { get; set; }
        private string CPF { get; set; }
        private double LimiteConta { get; set; }

        public bool Sacar(double Valor)
        {
            if (Valor > this.Saldo)
                return false;

            this.Saldo -= Valor;
            //this.Saldo = Saldo - Valor;
            return true;
        }

        public bool Depositar(double Valor)
        {
            if (Valor < 0) return false;
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
            //se nao tiver saldo cancela transferencia retornando false
            if (this.Saldo <= valor)
                return false;

            //Executa transferencia tirando da conta origram e deposinto na conta destino
            this.Sacar(valor);
            bool tOK = destino.Depositar(valor);
            if (tOK)// se transferencia ocorreu com sucesso retorna true
                return true;
            else// caso ocorrer erro faz o rollback voltando dinheiro para conta de origem
            {
                this.Depositar(valor);
                return false;
            }
        }
        
        private bool isValidSystemDateTime(DateTime DataSistema)
        {
            TimeSpan start = new TimeSpan(08, 0, 0);
            TimeSpan end = new TimeSpan(18, 0, 0);
            var dataSistema = DataSistema.TimeOfDay;

            if (dataSistema < start || dataSistema > end) return false;
            
            return true;
        }
    }
}
