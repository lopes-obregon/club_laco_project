using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace CompetiFácilLaço.Model
{
    internal class Laçador
    {
        //propriedades da classe
        public string Nome { get; set; }
        public string Escala { get; set; }
        public string Irmão { get; set; }
        public int Id { get; set; }
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
        public static string SaveJson(Laçador novoLaçador)
        {
            string fileName = "teste.json";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            //opção de encoder 
            var opt = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true

            };
            List<Laçador> listaLaçadores = new List<Laçador>();

            // string json = JsonSerializer.Serialize(laçador, opt);
            try
            {
                //se arquivo já existe
                if (File.Exists(path))
                {
                    string jsonExiste = File.ReadAllText(path);
                    if (!string.IsNullOrEmpty(jsonExiste))
                    {
                        listaLaçadores = JsonSerializer.Deserialize<List<Laçador>>(jsonExiste);
                    }
                    if (listaLaçadores != null) { 
                        int index = listaLaçadores.Count;
                        novoLaçador.Id = index++;

                    }
                    else
                    {
                        novoLaçador.Id = 1;
                    }
                        listaLaçadores.Add(novoLaçador);
                    string jsonAtualizado = JsonSerializer.Serialize(listaLaçadores, opt);
                    File.WriteAllText(path, jsonAtualizado);

                }
                
                
                return "Competidor salvo com sucesso!";

            }catch (Exception ex) {return "Não foi possivel salvar o Competidor erro:" + ex;}
        }
        public static string SaveDb(Laçador novoLaçador)
        {
           

            return null;
        }
        public static  Laçador ConsultarLaçador(string nomeCompetidor)
        {
            string fileName = "teste.json";
          
            //READ FILE
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            string json = File.ReadAllText(path);
            List<Laçador> laçadores = JsonSerializer.Deserialize<List<Laçador>>(json); 
            //filtro pelo nome
            Laçador laçador = laçadores.FirstOrDefault(competidor => competidor.Nome == nomeCompetidor);
            if (laçador != null)
            {
                return laçador;
            }
            else
            {
                return null;
            }
           
        }
    }
}
