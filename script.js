//para fazer um novo cadastro devemos apagar todos os dados ou recarregar a pagina
window.$ = window.jQuery = require('./node_modules/jquery')
const { futimes } = require('fs')
const low = require('lowdb')
const FileSync = require('lowdb/adapters/FileSync')
const adapter = new FileSync('db.json')
const db = low(adapter)
// Set some defaults (required if your JSON file is empty)
db.defaults({ 
	Equipes: [],
	NumeroDeLargadas: [
	],
	valorAtual:1
})
  .write()
//variaveis global
var categoria = ['Individual', 'Pai e Filho', 'Pai e Filho Mirim', 'Casal Laçador', 'Dupla de Irmão', 'Pai e Filho Bandeira', 'Avó e Neto', 'Bandeira', 'Mirim', 'Amazonas Mirim']
var categoriaEquipe = ['Captão', 'Trio-1', 'Trio-2', 'Trio-3', 'Fecha Rosca']
var cate = []
//main jquery
$(function(){
	for(let i in categoria){
		$('#categorias').append(`<option>${categoria[i]}</option>`)		
	}
	$('#inserir').click(function(){
		cate.push($('#categorias').val())
		print_categoria()	
	})
	$('#remove_list').click(function(){
		let valor = $('#addcategoria').val()
		if (valor == null) {
			alert('Por favor selecione uma categoria da lista para remover')
		}else{
			for(let i in cate){
				if(cate[i] == valor){
					cate.splice(i, 1)
				}
			}
		}
		print_categoria()	
	})
	$('#cadastrar').click(function(){
		cadastrar_lacador()	
	})
	for(let i = 0; i < 5; i++){
		$(`input[type=text][name=irmao${i+1}]`).hide();

	}
	//$('input[type=text][name=irmao1]').hide();
	$('.irmao').change(function(){
		for(let i = 0; i < 5; i++){
			if($(`input[type=radio][name=irmaogp${i+1}]:checked`).val() == 'true'){
				$(`input[type=text][name=irmao${i+1}]`).show();
			}
		}
		
			
	});
	
	/*$('#busca').click(function(){
		if($('input[type=radio][name=op1]:checked').val() == "sim"){
			printNames();

		}


	})*/
})

//funções da janela de inscrição
//funções adicionais
function print_categoria(){
	$('[class="categoriaadd').remove()
	for(let i in cate){
		$('#addcategoria').append(`<option class="categoriaadd">${cate[i]}</option>`)
	}
}
//adicioando no banco de dados
function cadastrar_lacador(){
	let nameTeam = $('input[type=text][name=nameTeam').val()
	let valor = return_numb_team()
	let names = {
		nomeDoPrimeiroLacador : $('input[type=text][name=name1]').val(),
		categoriaEquipePrimeiro:$('input[type=radio][name=radiogroup1]:checked').val(),
		nomeIrmaosPri: $('input[type=text][name=irmao1]').val(),

		nomeDoSegundoLacador:$('input[type=text][name=name2').val(),
		categoriaEquipeSegundo:$('input[type=radio][name=radiogroup2]:checked').val(),
		nomeIrmaosSeg: $('input[type=text][name=irmao2]').val(),

		nomeDoTerceiroLacador:	$('input[type=text][name=name3').val(),
		categoriaEquipeTerceiro: $('input[type=radio][name=radiogroup3]:checked').val(),
		nomeIrmaosTer: $('input[type=text][name=irmao3]').val(),

		nomeDoQuartoLacador:$('input[type=text][name=name4').val(),
		categoriaEquipeQuarto:$('input[type=radio][name=radiogroup4]:checked').val(),
		nomeIrmaosQuar: $('input[type=text][name=irmao4]').val(),

		nomeDoQuintoLacador:$('input[type=text][name=name5').val(),
		categoriaEquipeQuinto:$('input[type=radio][name=radiogroup5]:checked').val(),
		nomeIrmaosQuin: $('input[type=text][name=irmao5]').val()

	}
	if(($('[class="categoriaadd').val() == null)){
		alert('Nem uma categoria foi selecionada. Por favor insirir, depois  cadastrar.')
	}else{
		db.get('Equipes')
			.push({numeroDaEquipe: valor,nomeFazenda: nameTeam, nomes: names,categoriaDaFazenda: cate})
			.write()
		db.get('NumeroDeLargadas')
			.push({numeroDeLargada: valor}).write()
		alert('Cadastro realizado com sucesso!')
		alert('Numero de largada da Equipe é: ' + valor)			
		//da reload na page para realizar novos cadastros
		location.reload()			
		
		
	}	
}
//função que retorna o numero da equipe
function return_numb_team(){
	//baseado pelo ordem de cadastro
	let valor = 0
	let tamBd = db.get('Equipes').size().value()
	for(let i = 0; i < tamBd; i++){
		 valor = db.get(`Equipes[${i}].numeroDaEquipe`).value()	
	}
	return valor += 1
	
}