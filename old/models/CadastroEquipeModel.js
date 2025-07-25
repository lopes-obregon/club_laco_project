import database from './databaseModel.js';
export default class CadastroEquipeModel {
    static saveTeamName(teamName, callback) {
        database.run(`INSERT INTO Equipes (nome) VALUES ('${teamName}')`, function(err) {
            if(err) 
                return callback(err, null); 
            callback(null, this.lastID);
        });
    }
}