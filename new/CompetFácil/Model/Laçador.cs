using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using CompetFácil.Persistência;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using CompetFácil.Model;


namespace CompetiFácilLaço.Model
{
    internal class Laçador
    {
        //propriedades da classe
        private Equipe? equipe;
        public int Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Escala { get; set; }
        public Laçador? Irmão { get; set; }
        public List<string> Categoria { get; set; }
        public byte[] Pontos { get; set; }
        //get set
        public Equipe? Equipe { get => equipe;  set => equipe = value;  }
        //construtor da classe
        public Laçador(string nome, string sobreNome,string escala, Laçador? irmão, List<string> categoria)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Escala = escala;
            Categoria = categoria;
            Pontos = new byte[6];
            if(irmão == null)
            {
                Irmão = null;
            }
            else
            {
                Irmão = irmão;

            }
        }
        public Laçador() { }

        public Laçador(int id)
        {
           
            using DataBase data = new DataBase();
            var laçadorBuscado = data.Laçadores.FirstOrDefault(l => l.Id == id);
            Laçador? laçadorEncontrado = laçadorBuscado as Laçador;
            if (laçadorEncontrado != null)
            {
                this.Id = laçadorEncontrado.Id;
                this.Nome = laçadorEncontrado.Nome;
                this.SobreNome = laçadorEncontrado.SobreNome;
                this.Escala = laçadorEncontrado.Escala;
                this.Categoria = laçadorEncontrado.Categoria;
                this.Pontos = laçadorEncontrado.Pontos;
                this.Irmão = laçadorEncontrado.Irmão;
                this.equipe = laçadorEncontrado.Equipe;

            }
            else
            {
                throw new Exception($"Laçador com ID {id} não encontrado !");
            }

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
            DataBase dataBase = new DataBase();
            dataBase.Database.EnsureCreated();
            try
            {
                if (novoLaçador != null)
                {
                    //referencia o irmão caso não seja null;
                    if(novoLaçador.Irmão != null)
                    {
                        //se existe um irmão 
                       var irmãoExistente = dataBase.Laçadores.Find(novoLaçador.Irmão.Id); //procure no banco pelo irmão com o mesmo id e referencie
                        //se encontrou a referencia correta
                        if(irmãoExistente  != null)
                        {
                            novoLaçador.Irmão = irmãoExistente;
                        }
                        else
                        {
                            novoLaçador.Irmão = null;
                        }
                    
                    }
                    //garante que o id seja gerado automaticamente
                    novoLaçador.Id = 0;
                    dataBase.Laçadores.Add(novoLaçador);
                    Console.WriteLine(dataBase.DbPath);
                    dataBase.SaveChanges();
                    return "Competidor cadastrado com sucesso!";
                }
                else
                {
                    return "Error de inserção, algo deu errado";
                }
            }catch (Exception ex) { return "Error de inserção:" + ex;}
          
            
        }
        public static  Laçador ConsultarLaçadorJson(string nomeCompetidor)
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

        internal static List<Laçador> GetLaçdores()
        {
            DataBase db = new DataBase();
            try
            {
                List<Laçador> laçadores = db.Laçadores.ToList();
                return laçadores;

            }
            catch
            {
                return null;
            }
        }
        public override string ToString()
        {
            return $"{Id} - {Nome} {SobreNome}";
        }

        internal static Laçador? ConsultarLaçadorDb(string nomeCompetidor)
        {
            DataBase dataBase = new DataBase();
            try
            {
                var laçadorBuscado = dataBase.Laçadores
                    .Include(l=> l.Irmão)
                    .FirstOrDefault(l => l.Nome == nomeCompetidor);
                Laçador? laçadorEncontrado = laçadorBuscado as Laçador;
                return laçadorEncontrado;
            }
            catch {  return null; }
        }


        internal static sbyte AlterarLaçadorDb(Laçador? laçadorEncontrado, string? nomeTextBox, string? sobreNomeTexBox, string? posição, object? irmãoSelecionado, List<string>? categorias)
        {
            using DataBase dataBase = new DataBase();
            
            
            
            if(laçadorEncontrado != null)
            {
                //anexar o objeto ao contexto
                var laçadorAntigo = dataBase.Laçadores.FirstOrDefault(la => la.Id == laçadorEncontrado.Id);
                if (laçadorAntigo != null)
                {
                    if (nomeTextBox != null)
                    {
                        //marca como modificado
                        if (laçadorAntigo != null)
                        {
                            laçadorAntigo.Nome = nomeTextBox;
                            // dataBase.Entry(laçadorEncontrado).State = EntityState.Modified;// marca como estado de modificado
                        }
                    }
                    else if (sobreNomeTexBox != null) { laçadorAntigo.SobreNome = sobreNomeTexBox; }
                    else if (posição != null) { laçadorAntigo.Escala = posição; }
                    else if (irmãoSelecionado != null)
                    {
                        Laçador? laçadorIrmãoSelecionado = irmãoSelecionado as Laçador;
                        if (laçadorIrmãoSelecionado != null)
                        {
                            Laçador? irmãoExiste = dataBase.Laçadores.Find(laçadorIrmãoSelecionado.Id) as Laçador;
                            //encontrou irmão existente
                            if (irmãoExiste != null)
                            {
                                laçadorAntigo.Irmão = irmãoExiste;
                            }

                        }

                    }
                    else if (categorias != null) { laçadorAntigo.Categoria = categorias; }
                        dataBase.SaveChanges();
                    return 1;
                }
                else
                {
                    return -1;
                }
                // var laçadorAntigo = dataBase.Laçadores.FirstOrDefault(la => la.Id == laçadorEncontrado.Id);


            }

            
            return -1;
        }
        internal static bool Remove(Laçador? laçador)
        {
            using DataBase dataBase = new DataBase();
            //vejo se tem irmão
            if( laçador != null &&laçador.Irmão != null)
            {


                //se tiver irmão 
                Laçador? irmão = dataBase.Laçadores.Find(laçador.Irmão.Id);
                //verificando se o irmão aponta para esse irmão 
                if ((irmão != null) && (irmão.Id == laçador.Irmão.Id))
                {
                    laçador.Irmão = null;
                }
                dataBase.Laçadores.Remove(laçador);
                dataBase.SaveChanges();
                return true;
            }
            else
            {
                if (laçador is not null)
                {


                    Laçador? laçadorEncontrado = dataBase.Laçadores.Find(laçador.Id);
                    if (laçadorEncontrado is not null)
                    {
                        dataBase.Laçadores.Remove(laçadorEncontrado);
                        dataBase.SaveChanges();
                        return true;
                    }
                }
            }
                return false;
        }

        internal static Laçador? ConsultarLaçadorDb(string nome, string sobreNome)
        {
            //strings já são garantidas que não são vazias ou nulas
           using DataBase data = new DataBase();
            try
            {
                var laçadorBuscado = data.Laçadores
                    .Include(laçador => laçador.Irmão)
                    .FirstOrDefault(laçador => laçador.Nome == nome && laçador.SobreNome == sobreNome);
                Laçador? laçadorEncontrado = laçadorBuscado as Laçador;
                return laçadorEncontrado;
            }catch  {return null;}
        }

        internal static Laçador? GetLaçadorComId(int id)
        {
            using DataBase data = new DataBase();
            try
            {
                var laçadorBuscado = data.Laçadores
                    .Include(e => e.Equipe)
                    .FirstOrDefault(l => l.Id == id);
                Laçador? laçadorEncontrado = laçadorBuscado as Laçador;
                if (laçadorEncontrado is not null)
                    return laçadorEncontrado;
                else
                    return null;
            }catch{ return null;}
        }
    }
}
