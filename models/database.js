const fs = require('fs');
const sqlite3 = require('sqlite3').verbose();

// Conexão com o banco
const db = new sqlite3.Database('./database/db.sqlite', (err) => {
  if (err) {
    console.error('Erro ao conectar ao banco de dados:', err.message);
  } else {
    console.log('Conectado ao banco SQLite.');

    // Executa o script SQL de inicialização
    const initScript = fs.readFileSync('./database/init.sql', 'utf8');
    db.exec(initScript, (err) => {
      if (err) {
        console.error('Erro ao executar o script init.sql:', err.message);
      } else {
        console.log('Banco de dados inicializado com sucesso.');
      }
    });
  }
});
