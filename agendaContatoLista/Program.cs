using System;

namespace agendaContatoLista
{
    internal class Program
    {
        public static int MenuPrincipal()
        {
            int opcao;
            Console.Clear();
            Console.WriteLine("Informe a opção desejada:\n1 - Inserir um contato\n2 - Editar um contato\n3 - Localizar um contato" +
                "\n4 - Imprimir os contatos\n5 - Remover um contato\n6 - Sair");
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        public static Contato CadastrarContatos()
        {
            int opcaoTelefone;
            string nomeContato, emailContato, tipoDeTelefone, dddContato, telefoneContato;

            ListaTelefone telefones = new ListaTelefone();
            Console.WriteLine("Inserindo Contatos");
            Console.WriteLine("Insira o nome do contato: ");
            nomeContato = Console.ReadLine();
            Console.WriteLine("Insira o email do contato: ");
            emailContato = Console.ReadLine();
            Console.WriteLine("Telefones");
            do
            {
                Console.WriteLine("Insira o tipo de telefone:\nExemplo: Comercial - Residêncial - Celular");
                tipoDeTelefone = Console.ReadLine();
                Console.WriteLine("Informe o DDD: ");
                dddContato = Console.ReadLine();
                Console.WriteLine("Insira o telefone do contato: ");
                telefoneContato = Console.ReadLine();
                Console.WriteLine("Deseja inserir outro telefone:\n1 - Sim\n2 - Não ");
                opcaoTelefone = int.Parse(Console.ReadLine());
                telefones.Push(new Telefone(tipoDeTelefone, dddContato, telefoneContato));
            } while (opcaoTelefone == 1);
            return new Contato(nomeContato, emailContato, telefones);
        }

        static void Main(string[] args)
        {
            int opcao;
            ListaContato listaDeContatos = new ListaContato();

            opcao = MenuPrincipal();
            do
            {
                switch (opcao)
                {
                    case 1:
                        listaDeContatos.Push(CadastrarContatos());
                        opcao = MenuPrincipal();
                        break;
                    case 2:
                        listaDeContatos.Edit();
                        opcao = MenuPrincipal();
                        break;
                    case 3:
                        listaDeContatos.Search();
                        opcao = MenuPrincipal();
                        break;
                    case 4:
                        Console.WriteLine("Imprimir os contatos");
                        listaDeContatos.Print();
                        opcao = MenuPrincipal();
                        break;
                    case 5:
                        Console.WriteLine("Removendo os contatos");
                        listaDeContatos.Pop();
                        opcao = MenuPrincipal();
                        break;
                    case 6:
                        break;
                    default:
                        Console.WriteLine("Você selecionou uma opção inválida");
                        opcao = MenuPrincipal();
                        Console.ReadLine();
                        break;
                }
            } while (opcao < 6);
        }
    }
}
