const fs = require('fs');
const path = require('path');
const sqlite3 = require('sqlite3').verbose();

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

    // Executa o script SQL de inicialização
    console.log('Executando script de inicialização...');
    const db_path_init = path.join(__dirname, "../database/init.sql");
    const initScript = fs.readFileSync(db_path_init, 'utf8');

    db.exec(initScript, (err) => {
      if (err) {
        console.error('Erro ao executar o script init.sql:', err.message);
      } else {
        console.log('Banco de dados inicializado com sucesso.');
      }
    });
  }
});
module.exports = db;