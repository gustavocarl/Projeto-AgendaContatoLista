using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaContatoLista
{
    internal class Contato
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public ListaTelefone Telefones { get; set; }
        public Contato Proximo { get; set; }

        public Contato(string nome, string email, ListaTelefone telefones)
        {
            Id = -1;
            Nome = nome;
            Email = email;
            Telefones = telefones;
            Proximo = null;
        }

        public override string ToString()
        {
            return "---- Dados do Contato ----\nNome: " + Nome + "\nEmail: " + Email + "\nTelefones: " + Telefones.Print();
        }
    }
}
