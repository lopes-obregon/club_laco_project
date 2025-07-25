import CadastroEquipeModel from '../models/CadastroEquipeModel.js';
//maim
$(()=>{
    console.log('CadastroEquipeController');
    $('#teamForm').on('submit', function(event) {
        event.preventDefault();
        let teamName = $('#teamName').val();
        console.log('teamName', teamName);
        CadastroEquipeModel.saveTeamName(teamName);
    });
});