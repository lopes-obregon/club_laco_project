$(function(){
    
    $("#inscricaoForm").on("submit", function(e){
        //captura os dados do formulário
        let categorias_lista = [];
        $('#addcategoria option').each(function() {
            categorias_lista.push($(this).val());
        });
        e.preventDefault();
        const dados_lacador = {
            nome: $("#nome").val(),
            classe: $('input[name="radiogroup1"]:checked').val(),
            equipe: $("#equipe").val(),
            tem_irmão: $('input[name="irmaogp1"]:checked').val(),
            categorias: categorias_lista,

        }
        console.log(dados_lacador);
    });
    
});