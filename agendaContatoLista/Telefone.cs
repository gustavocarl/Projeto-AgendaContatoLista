using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaContatoLista
{
    internal class Telefone
    {
        public int ID { get; set; }
        public string Tipo { get; set; }
        public string Ddd { get; set; }
        public string NumeroDeTelefone { get; set; }
        public Telefone Proximo { get; set; }

        public Telefone(string tipo, string ddd, string numeroDeTelefone)
        {
            ID = -1;
            Tipo = tipo;
            Ddd = ddd;
            NumeroDeTelefone = numeroDeTelefone;
            Proximo = null;
        }

        public override string ToString()
        {
            return "\n---- Dados do Telefone ----\nTipo: " + Tipo + "\nTelefone: (" + Ddd + ") " + NumeroDeTelefone + "\n"; 
        }
    }
}