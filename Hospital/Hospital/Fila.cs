using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Fila
    {
        Paciente[] fila = new Paciente[100];
        int PacienteNum = 0;

        public void Cadastro()
        {
            if (PacienteNum >= 100)
            {
                Console.WriteLine("Fila cheia!"); //se a fila estiver cheia retorna a tela inicial
                return;
            }

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Idade: ");
            int idade = int.Parse(Console.ReadLine());

            Paciente paciente = new Paciente(nome, idade);

            if (paciente.Preferencial)
            {
                // se o paciente for preferencial manda ele pro topo da fila
                int posicao = 0;
                while (posicao < PacienteNum && fila[posicao].Preferencial)
                {
                    posicao++;
                }

                // Arrasta todo mundo que está daquela posição em diante para trás
                for (int i = PacienteNum; i > posicao; i--)
                {
                    fila[i] = fila[i - 1];
                }

                fila[posicao] = paciente;
            }
            else
            {
                // Paciente jovem vai direto para o fim da fila atual
                fila[PacienteNum] = paciente;
            }

            PacienteNum++;
            Console.WriteLine("\nPaciente cadastrado com sucesso!");
        }

        public void Listar()
        {
            if (PacienteNum == 0)
            {
                Console.WriteLine("\nA fila está vazia.\n");
            }
            else
            {
                Console.WriteLine("\n--- LISTA DE PACIENTES ---");
                for (int i = 0; i < PacienteNum; i++)              //mostra os dados do paciente
                {
                    string tipo = fila[i].Preferencial ? "[PREFERENCIAL]" : "[NORMAL]";     // ? e : funciona como if e else
                    Console.WriteLine("Posição {0} \t| Nome: {1,-15} \t| Idade: {2} \t| {3}",   //-15 espaçamento entre as informações
                    i, fila[i].Nome, fila[i].Idade, tipo);
                }
            }
        }

        public void Atender()
        {
            if (PacienteNum == 0)
            {
                Console.WriteLine("\nFila vazia. Nenhum paciente para atender.\n");
            }
            else
            {
                Console.WriteLine("\nAtendendo agora: " + fila[0].Nome + " (" + fila[0].Idade + " anos)");

                // Move todos os restantes uma posição para a frente
                for (int i = 0; i < PacienteNum - 1; i++)
                {
                    fila[i] = fila[i + 1];
                }

                fila[PacienteNum - 1] = null; // Limpa a última posição que sobrou / null significa que esta vazil
                PacienteNum--;

                Console.WriteLine("Próximo paciente pronto para atendimento.");
            }
        }

        public void Alterar()
        {
            if (PacienteNum == 0)
            {
                Console.WriteLine("\nFila vazia. Não há cadastros para alterar.\n");
                return;
            }

            Listar(); // Mostra a lista pra escolher de que vai trocar as informações
            Console.Write("\nDigite o número da posição do paciente que deseja alterar: ");

            int posicao = int.Parse(Console.ReadLine());

            if (posicao >= 0 && posicao < PacienteNum)
            {
                Console.Write("Novo Nome (Atual: " + fila[posicao].Nome + "): ");  //altera o nome
                string novoNome = Console.ReadLine();

                Console.Write("Nova Idade (Atual: " + fila[posicao].Idade + "): "); //altera a idade
                int novaIdade = int.Parse(Console.ReadLine());

                // Guarda as alterações
                fila[posicao].Nome = novoNome;
                fila[posicao].Idade = novaIdade;
                fila[posicao].Preferencial = novaIdade >= 60;


                Console.WriteLine("\nCadastro alterado com sucesso!");
            }
            else
            {
                Console.WriteLine("\nPosição inválida!"); //caso marque uma posição que não existe
            }
        }
    }
}
