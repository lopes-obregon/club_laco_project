using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompetiFácilLaço.Model
{
    internal class Laçador
    {
        //propriedades da classe
        public string Nome { get; set; }
        public string Escala { get; set; }
        public string Irmão { get; set; }
        public List<string> Categoria { get; set; }

        //construtor da classe
        public Laçador(string nome, string escala, string irmão, List<string> categoria)
        {
            Nome = nome;
            Escala = escala;
            Irmão = irmão;
            Categoria = categoria;
        }
        public string  WriteTeste() {
            string file_name = "teste.txt";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file_name);
            //criar o arquivo caso não exista ou escrever nele 
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                sw.WriteLine("Nome: " + Nome);
                sw.WriteLine("Escala: " + Escala);
                sw.WriteLine("Irmão: " + Irmão);
                sw.WriteLine("Categoria:");
                foreach (var item in Categoria)
                {
                    sw.WriteLine(item);
                }
                sw.WriteLine(" ");
                return "Competidor: " + Nome + " Cadastrado com sucesso!";
            }

        
        }
    }
}
