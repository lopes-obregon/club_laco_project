window.$ = window.jQuery = require('./node_modules/jquery')
const low = require('lowdb')
const FileSync = require('lowdb/adapters/FileSync')
const adapter = new FileSync('db.json')
const db = low(adapter)
const {dialog} = require('electron').remote
var buttons = ['OK', 'Cancel']
const dialogOptions = {type: 'info', buttons: buttons, message: 'Por favor insira mais um nome, não pode conter equipes com nemos de 5(cinco) laçadores!'}
const dialogOptions2 = {type: 'info', buttons: buttons, message: 'A lista ja tem   5(cinco) laçadores por favor remova um nome para incerir ou trocar o nome!'}
const dialogOptions3 = {type: 'info', buttons: buttons, message: 'Alterações salva com sucesso!'}
//variavel global
var listaName = []
//função main jquery
$(function(){
	$('[class="buttonsAll').hide()
	$('#pesquisa').click(function(){
		let pesquisa = $('input[type=search][name=pesquisa').val()
		let tamBD = db.get('Equipes').size().value()
		let nameFazenda
		pesquisa = String(pesquisa)
		for(let i = 0; i < tamBD; i++){
			nameFazenda = db.get(`Equipes[${i}].nomeFazenda`).value()
			console.log(nameFazenda);
			if(nameFazenda === pesquisa){
				print_pesquisa(i)
			}
		}
		$('[class="buttonsAll').show()
	})
	$('#removeName').click(function(){
		let valor = $('[class="print').val()
		for(let i in listaName){
			if(listaName[i] == valor){
				listaName.splice(i,1)
			}
		}
		print_remove()
	})
	$('#saveAlt').click(function(){
		if(listaName.length < 5){
			dialog.showMessageBoxSync(dialogOptions)
		}else{
			save_db()
			dialog.showMessageBoxSync(dialogOptions3)
			location.reload()
		}
	})
	$('#add_new_name').click(function(){
		let novo_nome = $('input[type=text][name=newName]').val()
		if(listaName.length >= 5){
			dialog.showMessageBoxSync(dialogOptions2)
		}else{
			listaName.push(novo_nome)
			print_remove()
		}
		
	})
})
//pesquisa no banco
function pesquisa_banco_and_add(index){
	let listaOrdemLacador = ['nomeDoPrimeiroLacador', 'nomeDoSegundoLacador', 'nomeDoTerceiroLacador', 'nomeDoQuartoLacador', 'nomeDoQuintoLacador']
	for( i in listaOrdemLacador){
		db.update(`Equipes[${index}].nomes.${listaOrdemLacador[i]}`, valor => listaName[i]).write()
	}
}
//função que salva no banco de dados
function save_db(){
	let pesquisa = $('input[type=search][name=pesquisa').val()
	let tamBD = db.get('Equipes').size().value()
	let nameFazenda
	db.update('Equipes')
	for(let i = 0; i < tamBD; i++){
		nameFazenda = db.get(`Equipes[${i}].nomeFazenda`).value()
		if(nameFazenda == pesquisa){
			pesquisa_banco_and_add(i)
		}
	}	
}
//função que impreme depois que removido
function print_remove(){
	$('[class="print_add').remove()
	for(let i in listaName){
		$('[class="print').append(`<option class="print_add">${listaName[i]}</option>`)
	}
}
//adiciona os nomes de todos os companheiros
function print_pesquisa(index){
	let listaOrdemLacador = ['nomeDoPrimeiroLacador', 'nomeDoSegundoLacador', 'nomeDoTerceiroLacador', 'nomeDoQuartoLacador', 'nomeDoQuintoLacador']
	let equipe
	$('#resultado').append('<p>Nome Do Laçador<p>')
	$('#resultado').append(`<select class="print" size="5"></select>`)
	for(i in listaOrdemLacador){
		equipe = db.get(`Equipes[${index}].nomes.${listaOrdemLacador[i]}`).value()
		$('[class="print').append(`<option class="print_add">${equipe}</option>`)
		listaName.push(equipe)
	}
	
}