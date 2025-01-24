$(()=>{
    //console.log("inscreverEventController");
    //garantir que está marcado para falso
    $('input[name="irmaogp1"][value="false"]').prop('checked', true);
    //garantindo que a caixa de texto do irmão está invisivel
    $('input[name="irmao1"]').hide();

    //console.log($('input[name="irmaogp1"]').val()); 
    $('input[name="irmaogp1"]').on('change', function(){
        //console.log($('input[name="irmaogp1"]:checked').val());
        if($('input[name="irmaogp1"]:checked').val() == 'true'){
            $('input[name="irmao1"]').show();
        }else{
            $('input[name="irmao1"]').hide();
        }
    });



});