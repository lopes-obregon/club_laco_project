import path from 'path';
import sqlite3 from 'sqlite3';

// Conexão com o banco
console.log('Conectando ao banco de dados SQLite...');
console.log(__dirname );
const db_path = path.join(__dirname, "../database/db.sqlite");
console.log("Path db:" + db_path);
const db = new sqlite3.Database(db_path, (err) => {
  if (err) {
    console.error('Erro ao conectar ao banco de dados:', err.message);
  } else {
    console.log('Conectado ao banco SQLite.');
  }
});

export default db;
