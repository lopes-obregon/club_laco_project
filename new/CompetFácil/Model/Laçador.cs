using System.Text.Json;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using CompetFácil.Persistência;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using CompetFácil.Model;
using System.Diagnostics.CodeAnalysis;


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
        public List<Categoria>? Categorias { get; set; }
        //1- positivo 2- negativo 0- vazio
        public byte[] Pontos { get; set; }
        //get set
        public Equipe? Equipe { get => equipe;  set => equipe = value;  }
        //construtor da classe
        public Laçador(string nome, string sobreNome,string escala, Laçador? irmão, List<Categoria>? categoria)
        {
            Nome = nome;
            SobreNome = sobreNome;
            Escala = escala;
            Categorias = categoria;
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
                this.Categorias = laçadorEncontrado.Categorias;
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
                foreach (var item in Categorias)
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
        public static string SaveDb(Laçador novoLaçador, List<Categoria>? categoriasList)
        {
            DataBase dataBase = new DataBase();
            dataBase.Database.EnsureCreated();//criar tabela caso não exista.
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
                            irmãoExistente.Irmão = novoLaçador;
                        }
                        else
                        {
                            novoLaçador.Irmão = null;
                        }
                    
                    }
                   /*if(novoLaçador.Categoria is not null)
                    {
                        foreach(var cat in novoLaçador.Categoria)
                        {
                            var categoriaExistente = dataBase.Categorias.Find(cat.Id);
                            if(categoriaExistente != null)
                            {
                                categoriaExistente?.Laçadores.Add(novoLaçador);
                            }

                        }
                    }*/
                    //garante que o id seja gerado automaticamente
                   if(categoriasList is not null)
                    {
                        foreach(var cat in categoriasList)
                        {
                            
                            if(cat != null)
                            {
                                // categoriaDb.Laçadores?.Add(novoLaçador);
                                cat.Laçadores.Add(novoLaçador);
                                if (novoLaçador.Categorias == null)
                                    novoLaçador.Categorias = new List<Categoria>();

                                novoLaçador.Categorias.Add(cat);
                                dataBase.Entry(cat).State = EntityState.Modified;
                            }
                        }
                    }
                    novoLaçador.Id = 0;
                    dataBase.Laçadores.Add(novoLaçador);
                    
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
           using  DataBase dataBase = new DataBase();
            try
            {
                var laçadorBuscado = dataBase.Laçadores
                    .Include(l=> l.Irmão)
                    .Include(l => l.Categorias)
                    .FirstOrDefault(l => l.Nome == nomeCompetidor);
                Laçador? laçadorEncontrado = laçadorBuscado as Laçador;
                return laçadorEncontrado;
            }
            catch {  return null; }
        }


        internal static sbyte AlterarLaçadorDb(Laçador? laçadorEncontrado, string? nomeTextBox, string? sobreNomeTexBox, string? posição, object? irmãoSelecionado, List<Categoria>? categorias)
        {
            using DataBase dataBase = new DataBase();
            
            
            
            if(laçadorEncontrado != null)
            {
                //anexar o objeto ao contexto
                var laçadorAntigo = dataBase.Laçadores
                    .Include(l => l.Categorias)
                    .FirstOrDefault(la => la.Id == laçadorEncontrado.Id);
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
                    else if (categorias != null) {
                        var categoriasDb = categorias
                            .Select(c => dataBase.Categorias.Find(c.Id))
                            .Where(c => c != null)
                            .ToList();
                        var categoriasRemovidas = laçadorAntigo.Categorias
                            .ExceptBy(categoriasDb.Select(c => c.Id), c => c.Id)
                            .ToList();
                        foreach (var cat in categoriasRemovidas)
                        {
                            cat.Laçadores.Remove(laçadorAntigo);
                            dataBase.Entry(cat).State = EntityState.Modified;
                            laçadorAntigo.Categorias.Remove(cat);
                        }
                        laçadorAntigo.Categorias = categoriasDb; 
                        dataBase.Laçadores.Update(laçadorAntigo);
                    }
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
                var laçadorDb = dataBase.Laçadores.Include(la => la.Irmão).FirstOrDefault(la => la.Id == laçador.Id);

                if(laçadorDb is not null)
                {
                    //se tiver irmão 
                    Laçador? irmão = dataBase.Laçadores
                        .Include(ir => ir.Irmão)
                        .FirstOrDefault(ir => ir.Id == laçador.Irmão.Id);
                    //verificando se o irmão aponta para esse irmão 
                    if ((irmão != null) && (irmão.Id == laçadorDb.Irmão.Id))
                    {
                        laçadorDb.Irmão = null;
                      
                        irmão.Irmão = null;
                    }
                    //remove as categorias
                   if(laçadorDb.Categorias is not null)
                    {
                        laçadorDb.Categorias = null;
                        
                    }
                    dataBase.Laçadores.Remove(laçadorDb);
                    dataBase.SaveChanges();
                    return true;

                }
            }
            else
            {
                if (laçador is not null)
                {

                    if (laçador.Categorias != null)
                    {
                        laçador.Categorias = null;
                        dataBase.Entry(laçador).State = EntityState.Modified;
                    }
                    dataBase.Laçadores.Remove(laçador);
                    dataBase.SaveChanges();
                    return true;
                   /* Laçador? laçadorEncontrado = dataBase.Laçadores
                        .Include(la => la.Categorias)
                        .SingleOrDefault(la => la.Id == laçador.Id);

                    if (laçadorEncontrado is not null && laçadorEncontrado.Categorias is not null)
                    {
                        //quebra a relação 
                        laçadorEncontrado.Categorias = null;
                        dataBase.Entry(laçadorEncontrado).State = EntityState.Modified;
                        dataBase.Laçadores.Remove(laçadorEncontrado);
                        dataBase.SaveChanges();
                        return true;
                    }*/
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

        internal static bool SavePnt(Laçador laçador)
        {
            using (DataBase data = new DataBase())
            {
                try
                {
                    var laBuscado = data.Laçadores.FirstOrDefault(la => la.Id == laçador.Id);
                    Laçador? laEncontrado = laBuscado as Laçador;
                    if (laEncontrado is not null)
                    {
                        laEncontrado.Pontos = laçador.Pontos;
                    }
                    data.SaveChanges();
                    return true;

                }catch{ return false; }
            }
        }
    }
}
