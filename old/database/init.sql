CREATE TABLE IF NOT EXISTS Equipes (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  nomeFazenda TEXT,
  numeroDaEquipe INTEGER
);
CREATE TABLE IF NOT EXISTS Competidores (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  nome TEXT,
  equipe_id INTEGER,
  FOREIGN KEY (equipe_id) REFERENCES Equipes(id)
);

CREATE TABLE IF NOT EXISTS Categorias (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  nome TEXT
);

CREATE TABLE IF NOT EXISTS NumeroDeLargadas (
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  numeroDeLargada INTEGER
);
CREATE TABLE IF NOT EXISTS Lacador(
  id INTEGER PRIMARY KEY AUTOINCREMENT,
  nome TEXT,
  classe TEXT,
  irmao TEXT,
  categorias TEXT
); 

CREATE TABLE IF NOT EXISTS Equipe_Lacador (
  equipe_id INTEGER,
  lacador_id INTEGER,
  PRIMARY KEY (equipe_id, lacador_id),
  FOREIGN KEY (equipe_id) REFERENCES Equipes(id),
  FOREIGN KEY (lacador_id) REFERENCES Lacador(id)
);
