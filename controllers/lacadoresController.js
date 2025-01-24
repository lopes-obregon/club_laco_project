$(function(){
    $('input[name="irmaogp1"][value="false"]').prop('checked', true);
    
    $("#inscricaoForm").on("submit", function(e){
        e.preventDefault();
        //captura os dados do formulário
        const dados_lacador = {
            nome: $("#nome").val(),
            classe: $('input[name="radiogroup1"]:checked').val(),
            equipe: $("#equipe").val(),
            tem_irmão: $('input[name="irmaogp1"]:checked').val(),

        }
        console.log(dados_lacador);
    });
    
});