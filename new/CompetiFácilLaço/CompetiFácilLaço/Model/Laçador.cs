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
        public static string SaveJson(Laçador laçador)
        {
            string fileName = "teste.json";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            //opção de encoder 
            var opt = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                WriteIndented = true

            };
            string json = JsonSerializer.Serialize(laçador, opt);
            try
            {
                File.WriteAllText(path, json);
                return "Competidor salvo com sucesso!";

            }catch (Exception ex) {return "Não foi possivel salvar o Competidor erro:" + ex;}
        }
      
        public static  Laçador ConsultarLaçador(string nomeCompetidor)
        {
            string fileName = "teste.txt";
            string resultadoString;
            //READ FILE
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
            if (File.Exists(path))
            {
                StringBuilder sb = new StringBuilder();
                using (StreamReader sr = new StreamReader(path))
                {
                    string linha;
                    while ((linha = sr.ReadLine()) != null) {
                        if (linha.Equals(nomeCompetidor)) {  sb.Append(linha); break; }
                    
                    }
                }
               resultadoString = sb.ToString();
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
