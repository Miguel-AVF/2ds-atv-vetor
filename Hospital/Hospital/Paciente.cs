using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    class Paciente : Pessoa
    {
        //Dados
        public bool Preferencial;

        public Paciente(string nome, int idade)//Criando variaveis
        {
            Nome = nome;
            Idade = idade;
            Preferencial = idade >= 60; //Se a idade for maior ou igual 60 é preferencial
        }
    }
}
