using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string op = "";
            Fila fila = new Fila();

            while (op != "q" && op != "Q")
            {
                Console.WriteLine("===================================");
                Console.WriteLine(" SISTEMA DE FILA DO HOSPITAL ");
                Console.WriteLine("===================================");
                Console.WriteLine("1 - Cadastrar paciente");
                Console.WriteLine("2 - Listar fila");
                Console.WriteLine("3 - Atender paciente");
                Console.WriteLine("4 - Alterar cadastro");
                Console.WriteLine("q - Sair");
                Console.WriteLine("===================================");
                Console.Write("Escolha uma opção: ");

                op = Console.ReadLine();
                switch (op)                //opções e metodos 
                {
                    case "1":
                        fila.Cadastro();  
                        break;

                    case "2":
                        fila.Listar();
                        break;

                    case "3":
                        fila.Atender();
                        break;

                    case "4":
                        fila.Alterar();
                        break;

                    case "q":
                    case "Q":
                        Console.WriteLine("\n...Encerrando Programa...");
                        break;

                    default:
                        Console.WriteLine("//--Comando Inválido--//");
                        break;
                }

                if (op != "q" && op != "Q")
                {
                    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                    Console.ReadKey();
                }
            }
        }
    }
}
