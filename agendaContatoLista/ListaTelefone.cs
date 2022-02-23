using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace agendaContatoLista
{
    internal class ListaTelefone
    {
        public Telefone Head { get; set; }
        public Telefone Tail { get; set; }

        public ListaTelefone()
        {
            Head = null;
            Tail = null;
        }

        public int ContarTelefones()
        {
            int contarTelefones = 0;
            Telefone aux = Head;
            do
            {
                contarTelefones++;
                aux = aux.Proximo;
            } while (aux != null);
            return contarTelefones;
        }

        public void SetarIdentificador()
        {
            int contarIdentificadores = 0;
            Telefone aux = Head;
            do
            {
                aux.ID = -1;
                aux.ID = contarIdentificadores + 1;
                contarIdentificadores++;
                aux = aux.Proximo;
            } while (aux != null);
        }

        public Telefone BuscarIdentificador(int id)
        {
            Telefone aux = Head, telefoneEncontrado = null;
            do
            {
                if (id == aux.ID)
                {
                    telefoneEncontrado = aux;
                }
                aux = aux.Proximo;
            } while (aux != null);
            return telefoneEncontrado;
        }
        public ListaTelefone EditarTelefone(ListaTelefone listaDeTelefones)
        {
            int quantidadeTelefones = listaDeTelefones.ContarTelefones(), totalDeTelefones = 0, escolhaDeOpcao;
            string novoTipoTelefone, novoDDDTelefone, novoNumeroTelefone;
            Telefone telefoneTemp;
            ListaTelefone novosTelefones = new ListaTelefone();
            listaDeTelefones.SetarIdentificador();
            if (quantidadeTelefones == 0)
            {
                escolhaDeOpcao = 0;
                Console.WriteLine("Não há telefones nesse contato");
                Console.WriteLine("Você deseja:\n1 - Menu\n2 - Adicionar Telefone");
                escolhaDeOpcao = int.Parse(Console.ReadLine());
                if (escolhaDeOpcao == 1)
                {
                    return listaDeTelefones;
                }
                else if (escolhaDeOpcao == 2)
                {
                    Console.WriteLine("Insira o tipo de telefone:\nExemplo: Comercial - Residêncial - Celular");
                    novoTipoTelefone = Console.ReadLine();
                    Console.WriteLine("Insira o DDD: ");
                    novoDDDTelefone = Console.ReadLine();
                    Console.WriteLine("Insira o telefone do contato: ");
                    novoNumeroTelefone = Console.ReadLine();
                    novosTelefones.Push(new Telefone(novoTipoTelefone, novoDDDTelefone, novoNumeroTelefone));

                    return novosTelefones;
                }
            }
            for (int i = 0; i < quantidadeTelefones; i++)
            {
                Console.WriteLine("\n---------------------\n");
                Console.WriteLine("Posição: " + (i + 1));
                telefoneTemp = listaDeTelefones.BuscarIdentificador(i + 1);
                Console.WriteLine(telefoneTemp.ToString());
                totalDeTelefones++;
            }
            escolhaDeOpcao = 0;
            Console.WriteLine("Deseja editar ou remover um telefone:\n1 - Editar\n2 - Remover");
            escolhaDeOpcao = int.Parse(Console.ReadLine());
            if (escolhaDeOpcao == 1)
            {
                escolhaDeOpcao = 0;
                Console.WriteLine("Informe a posição que será editada: ");
                escolhaDeOpcao = int.Parse(Console.ReadLine());
                telefoneTemp = listaDeTelefones.BuscarIdentificador(escolhaDeOpcao);
                Console.Clear();
                Console.WriteLine(telefoneTemp.ToString());
                if (listaDeTelefones.Head == listaDeTelefones.Tail)
                {
                    Console.WriteLine("Insira o tipo de telefone:\nExemplo: Comercial - Residêncial - Celular");
                    novoTipoTelefone = Console.ReadLine();
                    Console.WriteLine("Insira o DDD: ");
                    novoDDDTelefone = Console.ReadLine();
                    Console.WriteLine("Insira o telefone do contato: ");
                    novoNumeroTelefone = Console.ReadLine();
                    novosTelefones.Push(new Telefone(novoTipoTelefone, novoDDDTelefone, novoNumeroTelefone));

                    return novosTelefones;
                }
                else
                {
                    for (int i = 0; i < quantidadeTelefones; i++)
                    {
                        if (listaDeTelefones.BuscarIdentificador(i + 1).ID != telefoneTemp.ID)
                        {
                            novosTelefones.Push(new Telefone(listaDeTelefones.BuscarIdentificador(i + 1).Tipo, listaDeTelefones.BuscarIdentificador(i + 1).Ddd, listaDeTelefones.BuscarIdentificador(i + 1).NumeroDeTelefone));
                        }
                    }
                    Console.WriteLine("Insira o tipo de telefone:\nExemplo: Comercial - Residêncial - Celular");
                    novoTipoTelefone = Console.ReadLine();
                    Console.WriteLine("Informe o DDD: ");
                    novoDDDTelefone = Console.ReadLine();
                    Console.WriteLine("Insira o telefone do contato: ");
                    novoNumeroTelefone = Console.ReadLine();
                    novosTelefones.Push(new Telefone(novoTipoTelefone, novoDDDTelefone, novoNumeroTelefone));
                    Console.WriteLine("Telefone alterado com sucesso");
                    Console.ReadKey();
                    return novosTelefones;
                }
            }
            else if (escolhaDeOpcao == 2)
            {
                escolhaDeOpcao = 0;
                Console.WriteLine("Informe a posição que será removida: ");
                escolhaDeOpcao = int.Parse(Console.ReadLine());
                telefoneTemp = listaDeTelefones.BuscarIdentificador(escolhaDeOpcao);
                Console.Clear();
                Console.WriteLine(telefoneTemp.ToString());
                for (int i = 0; i < quantidadeTelefones; i++)
                {
                    if (listaDeTelefones.BuscarIdentificador(i + 1).ID != telefoneTemp.ID)
                    {
                        novosTelefones.Push(new Telefone(listaDeTelefones.BuscarIdentificador(i + 1).Tipo, listaDeTelefones.BuscarIdentificador(i + 1).Ddd, listaDeTelefones.BuscarIdentificador(i + 1).NumeroDeTelefone));
                    }
                }
                Console.WriteLine("Telefone removido com sucesso!");
                Console.ReadKey();
                return novosTelefones;
            }
            return listaDeTelefones;
        }

        public void Push(Telefone telefone)
        {
            StringComparer order = StringComparer.CurrentCultureIgnoreCase;
            Telefone aux1 = Head, aux2 = Head;

            if (Vazia())
            {
                Head = telefone;
                Tail = telefone;
            }
            else
            {
                do
                {
                    if (order.Compare(telefone.Tipo, Head.Tipo) < 0)
                    {
                        telefone.Proximo = Head;
                        Head = telefone;
                        aux1 = null;
                    }
                    else if (order.Compare(telefone.Tipo, Tail.Tipo) > 0)
                    {
                        Tail.Proximo = telefone;
                        Tail = telefone;
                        aux1 = null;
                    }
                    else
                    {
                        if (order.Compare(aux1.Tipo, telefone.Tipo) < 0)
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
                            telefone.Proximo = aux1;
                            aux2.Proximo = telefone;
                            aux1 = null;
                        }
                    }
                } while (aux1 != null);
                aux1 = null;
                aux2 = null;
            }
        }

        public string Print()
        {
            string retornarTelefones = "";
            Telefone aux = Head;
            do
            {
                retornarTelefones = retornarTelefones + aux.ToString();
                aux = aux.Proximo;
            } while (aux != null);
            return retornarTelefones;
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