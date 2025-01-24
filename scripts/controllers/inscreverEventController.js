$(()=>{
    let categorias = ['Individual', 'Pai e Filho', 'Pai e Filho Mirim', 'Casal Laçador', 'Dupla de Irmão', 'Pai e Filho Bandeira', 'Avó e Neto', 'Bandeira', 'Mirim', 'Amazonas Mirim']
    let categoria_selecionada = [];
    //console.log("inscreverEventController");
    //garantir que está marcado para falso
    $('input[name="irmaogp1"][value="false"]').prop('checked', true);
    //garantindo que a caixa de texto do irmão está invisivel
    $('input[name="irmao1"]').hide();

    textoVisivel();
    printCategorias(categorias);
    inserirCategoria(categoria_selecionada);

});
//deixa visivel ou invisivel a caixa de texto do irmão
function textoVisivel(){
    //console.log($('input[name="irmaogp1"]').val()); 
    $('input[name="irmaogp1"]').on('change', function(){
        //console.log($('input[name="irmaogp1"]:checked').val());
        if($('input[name="irmaogp1"]:checked').val() == 'true'){
            $('input[name="irmao1"]').show();
        }else{
            $('input[name="irmao1"]').hide();
        }
    });
}
//imprime as categorias
function printCategorias(categorias){
    for(let i in categorias){
        $('#categorias').append(`<option>${categorias[i]}</option>`);
    }
}
function inserirCategoria(categoria_selecionada){
    $('#inserir').on('click', function(){
        categoria_selecionada.push($('#categorias').val());
        printCategoriaSelecionada(categoria_selecionada);
    });
}
function printCategoriaSelecionada(categoria_selecionada){
    $('#addcategoria').empty();
    categoria_selecionada.forEach(categoria => {
        $('#addcategoria').append(`<option>${categoria}</option>`);
    });
}