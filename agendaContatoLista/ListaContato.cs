using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaContatoLista
{
    internal class ListaContato
    {
        public Contato Head { get; set; }
        public Contato Tail { get; set; }

        public ListaContato()
        {
            Head = Tail = null;
        }

        public int ContarContatos()
        {
            int totalContatos = 0;
            Contato aux = Head;
            do
            {
                totalContatos++;
                aux = aux.Proximo;
            } while (aux != null);
            return totalContatos;
        }

        public void Push(Contato aux)
        {
            Contato aux1 = Head, aux2 = Head;
            StringComparer order = StringComparer.CurrentCultureIgnoreCase;

            if (Vazia())
            {
                Head = aux;
                Tail = aux;
                Console.WriteLine("Dados inseridos com sucesso");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Contato contatoTemporario;
                contatoTemporario = buscarContato(aux.Nome);
                do
                {
                    if (order.Compare(aux.Nome, Head.Nome) <= 0)
                    {
                        aux.Proximo = Head;
                        Head = aux;
                        aux1 = null;
                    }
                    else if (order.Compare(aux.Nome, Tail.Nome) >= 0)
                    {
                        Tail.Proximo = aux;
                        Tail = aux;
                        aux1 = null;
                    }
                    else
                    {
                        if (order.Compare(aux1.Nome, aux.Nome) <= 0)
                        {
                            if (aux1 == aux2)
                            {
                                aux1 = aux1.Proximo;
                            }
                            else
                            {
                                aux2 = aux1;
                                aux1 = aux1.Proximo;
                            }
                        }
                        else
                        {
                            aux.Proximo = aux1;
                            aux2.Proximo = aux;
                            aux1 = null;
                        }
                    }
                } while (aux1 != null);
                aux1 = null;
                aux2 = null;
                Console.WriteLine("Dados inseridos com sucesso");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
        }

        public void Print()
        {
            if (Vazia())
            {
                Console.WriteLine("Não há contatos nessa lista");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadKey();
            }
            else
            {
                Contato aux = Head;
                do
                {
                    Console.WriteLine(aux.ToString());
                    Console.ReadKey();
                    aux = aux.Proximo;
                } while (aux != null);
                Console.WriteLine("Fim da impressão");
            }
        }

        public void Edit()
        {
            StringComparer order = StringComparer.CurrentCultureIgnoreCase;
            Console.WriteLine("Edição de Contatos");
            if (Vazia())
            {
                Console.WriteLine("Não há nenhum contato cadastrado!");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                Contato aux = Head, contatoArmazenado = null;
                Console.WriteLine("Informe o contato que deseja editar: ");
                string buscarContatoEditavel = Console.ReadLine();
                int quantidadeDeContatos = 0;
                quantidadeDeContatos = quantidadeDeIguais(buscarContatoEditavel);
                if (quantidadeDeContatos < 1)
                {
                    Console.WriteLine("Nome não encontrado");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadKey();
                }
                else if (quantidadeDeContatos < 2)
                {
                    contatoArmazenado = buscarContato(buscarContatoEditavel);

                    Console.Clear();
                    Console.WriteLine("\n" + contatoArmazenado.ToString());
                    Console.ReadKey();
                    Console.WriteLine("Qual campo deseja editar: \n1 - Nome\n2 - E-mail\n3 - Telefones");
                    int campoParaEditar = int.Parse(Console.ReadLine());
                    if (campoParaEditar == 1)
                    {
                        Console.WriteLine("Informe o novo nome: ");
                        string novoNome = Console.ReadLine();
                        Contato novoContato = new Contato(novoNome, contatoArmazenado.Email, contatoArmazenado.Telefones);
                        RemoverContato(contatoArmazenado);
                        Push(novoContato);
                        Console.WriteLine("Contato alterado com sucesso");
                        Console.ReadKey();
                    }
                    else if (campoParaEditar == 2)
                    {
                        Console.WriteLine("Informe o novo e-mail: ");
                        string novoEmail = Console.ReadLine();
                        Contato novoContato = new Contato(contatoArmazenado.Nome, novoEmail, contatoArmazenado.Telefones);
                        RemoverContato(contatoArmazenado);
                        Push(novoContato);
                        Console.WriteLine("Contato alterado com sucesso");
                        Console.ReadKey();
                    }
                    else if (campoParaEditar == 3)
                    {
                        ListaTelefone telefonesEdicao = new ListaTelefone();
                        int totalTelefones = contatoArmazenado.Telefones.ContarTelefones();
                        telefonesEdicao = telefonesEdicao.EditarTelefone(contatoArmazenado.Telefones);
                        contatoArmazenado.Telefones = telefonesEdicao;
                    }

                }
                else if (quantidadeDeContatos > 1)
                {
                    Console.WriteLine("Você tem mais que um contato com o mesmo nome:\n");
                    contatoArmazenado = buscarContato(buscarContatoEditavel);

                    do
                    {
                        if (order.Compare(aux.Nome, buscarContatoEditavel) == 0)
                        {
                            Console.WriteLine("Posição: " + aux.Id);
                            Console.WriteLine(aux.ToString());
                        }
                        Console.ReadKey();
                        aux = aux.Proximo;
                    } while (aux != null);

                    Console.WriteLine("Informe qual posição deseja ser editado:\n");
                    int opcaoDeEdicao = int.Parse(Console.ReadLine());
                    contatoArmazenado = BuscarIdentificador(opcaoDeEdicao);

                    if (opcaoDeEdicao == contatoArmazenado.Id)
                    {
                        Console.Clear();
                        Console.WriteLine("\n" + contatoArmazenado.ToString());
                        Console.ReadKey();
                        Console.WriteLine("Qual campo deseja editar: \n1 - Nome\n2 - E-mail\n3 - Telefones");
                        int campoParaEditar = int.Parse(Console.ReadLine());
                        if (campoParaEditar == 1)
                        {
                            Console.WriteLine("Informe o novo nome: ");
                            string novoNome = Console.ReadLine();
                            Contato novoContato = new Contato(novoNome, contatoArmazenado.Email, contatoArmazenado.Telefones);
                            RemoverContato(contatoArmazenado);
                            Push(novoContato);
                            Console.WriteLine("Contato alterado com sucesso");
                            Console.ReadKey();
                        }
                        else if (campoParaEditar == 2)
                        {
                            Console.WriteLine("Informe o novo e-mail: ");
                            string novoEmail = Console.ReadLine();
                            Contato novoContato = new Contato(contatoArmazenado.Nome, novoEmail, contatoArmazenado.Telefones);
                            RemoverContato(contatoArmazenado);
                            Push(novoContato);
                            Console.WriteLine("Contato alterado com sucesso");
                            Console.ReadKey();
                        }
                        else if (campoParaEditar == 3)
                        {
                            ListaTelefone telefonesEdicao = new ListaTelefone();
                            int totalTelefones = contatoArmazenado.Telefones.ContarTelefones();
                            telefonesEdicao = telefonesEdicao.EditarTelefone(contatoArmazenado.Telefones);
                            contatoArmazenado.Telefones = telefonesEdicao;
                        }
                        Console.WriteLine("Contato alterado com sucesso!");
                    }

                }
            }
        }

        public void RemoverContato(Contato contatoExclusao)
        {
            StringComparer order = StringComparer.CurrentCultureIgnoreCase;
            Contato aux1 = Head.Proximo, aux2 = Head;
            if (order.Compare(Head.Nome, contatoExclusao.Nome) == 0)
            {
                Head = contatoExclusao.Proximo;
                if (Head == null)
                {
                    Tail = null;
                }
            }
            else
            {
                do
                {
                    if ((order.Compare(aux1.Nome, contatoExclusao.Nome) == 0) && (order.Compare(aux1.Email, contatoExclusao.Email) == 0))
                    {
                        aux2.Proximo = aux1.Proximo;
                        if (aux2.Proximo == null)
                        {
                            Tail = aux2;
                        }
                        aux1 = null;
                    }
                    else
                    {
                        aux2 = aux1;
                        aux1 = aux1.Proximo;
                    }
                } while (aux1 != null);
                if (ContarContatos() == 1)
                {
                    Tail = Head;
                }
                aux1 = null;
                aux2 = null;
            }
        }

        public void Pop()
        {
            StringComparer order = StringComparer.CurrentCultureIgnoreCase;
            if (Vazia())
            {
                Console.WriteLine("Não contém nenhum contato nessa lista!");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadKey();
            }
            else
            {
                Contato aux = Head, contatoEncontrado = null, aux1 = Head, aux2 = Head;
                Console.WriteLine("Informe o nome do contato que será removido: ");
                string buscarNome = Console.ReadLine();
                int quantidadeContatos = 0;
                quantidadeContatos = quantidadeDeIguais(buscarNome);

                if (quantidadeContatos < 1)
                {
                    Console.WriteLine("Nome não encontrado");
                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadKey();
                    return;
                }
                else if (quantidadeContatos < 2)
                {
                    do
                    {
                        if (order.Compare(aux.Nome, buscarNome) == 0)
                        {
                            contatoEncontrado = aux;
                        }
                        aux = aux.Proximo;
                    } while (aux != null);
                    Console.WriteLine(contatoEncontrado.ToString());
                    RemoverContato(contatoEncontrado);
                    Console.WriteLine("O contato foi removido com sucesso!!!");
                    Console.ReadKey();
                    return;
                }
                else if (quantidadeContatos > 1)
                {
                    Console.Write("Você tem mais que um contato com o mesmo nome:\n");
                    do
                    {
                        if (order.Compare(aux.Nome, buscarNome) == 0)
                        {
                            Console.WriteLine("Posição: " + aux.Id);
                            Console.WriteLine(aux.ToString());
                        }
                        Console.ReadKey();
                        aux = aux.Proximo;
                    } while (aux != null);
                    Console.WriteLine("Informe a posição que deseja remover:\n");
                    int opcaoDeExclusao = int.Parse(Console.ReadLine());
                    contatoEncontrado = BuscarIdentificador(opcaoDeExclusao);
                    if (opcaoDeExclusao == contatoEncontrado.Id)
                    {
                        RemoverContato(contatoEncontrado);
                        Console.WriteLine("Contato removido com sucesso!!!");
                        Console.ReadKey();
                        return;
                    }

                }
            }
        }

        public Contato BuscarIdentificador(int id)
        {
            Contato aux = Head, contatoEncontrado = null;
            do
            {
                if (id == aux.Id)
                {
                    contatoEncontrado = aux;
                }
                aux = aux.Proximo;
            } while (aux != null);
            return contatoEncontrado;
        }

        public Contato buscarContato(string nome)//Localizar o nome do contato
        {
            Contato aux = Head, contatoEncontrado = null;
            StringComparer order = StringComparer.CurrentCultureIgnoreCase;
            do
            {
                if (order.Compare(aux.Nome, nome) == 0)
                {
                    contatoEncontrado = aux;
                }
                aux = aux.Proximo;
            } while (aux != null);
            return contatoEncontrado;
        }

        public void Search()//Localizar o contato e imprimir na tela
        {
            StringComparer order = StringComparer.CurrentCultureIgnoreCase;
            Contato aux = Head, contatoEncontrado = null;
            Console.WriteLine("Localizar Contato");
            if (Vazia())
            {
                Console.WriteLine("Não há nenhum contato inserido na lista!!!");
                Console.WriteLine("Não contém nenhum contato nessa lista!");
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
            }
            else
            {
                int quantidadeContatos = 0;
                Console.WriteLine("Informe o nome do contato para pesquisar: ");
                string buscarContato = Console.ReadLine();
                quantidadeContatos = quantidadeDeIguais(buscarContato);
                if (quantidadeContatos < 1)
                {
                    Console.WriteLine("Nome não encontrado");
                    Console.ReadKey();
                }
                else if (quantidadeContatos < 2)
                {
                    do
                    {
                        if (order.Compare(aux.Nome, buscarContato) == 0)
                        {
                            contatoEncontrado = aux;

                        }
                        aux = aux.Proximo;
                    } while (aux != null);
                    Console.Write(contatoEncontrado.ToString());
                    Console.ReadKey();
                }
                else if (quantidadeContatos > 1)
                {
                    do
                    {

                        if (order.Compare(aux.Nome, buscarContato) == 0)
                        {
                            Console.WriteLine($"ID: {aux.Id}");
                            Console.WriteLine(aux.ToString());
                            Console.ReadKey();
                        }
                        aux = aux.Proximo;
                    } while (aux != null);
                }
            }
        }

        public int quantidadeDeIguais(string nome)
        {
            Contato aux = Head;
            int contador = 0;
            do
            {
                if (aux.Nome == nome)
                {
                    contador++;
                    aux.Id = contador;
                }
                aux = aux.Proximo;
            } while (aux != null);
            return contador;
        }

        public bool Vazia()
        {
            if ((Head == null) && (Tail == null))
                return true;
            else
                return false;
        }
    }
}