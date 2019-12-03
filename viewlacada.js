window.$ = window.jQuery = require('./node_modules/jquery')
const low = require('lowdb')
const FileSync = require('lowdb/adapters/FileSync')
const adapter = new FileSync('db.json')
const db = low(adapter)
const {dialog} = require('electron').remote
var buttons = ['OK', 'Cancel']
const dialogOptions = {type: 'info', buttons: buttons, message: 'Não a mais chamadas, deseja atualizar?'}
//dicionario
var lacador = new Map()
$(function(){
	//objeto
	//variavel global
	//variavel local
	let tamBd = db.get('Equipes').size().value()
	let listaOrdemLacador = ['nomeDoPrimeiroLacador', 'nomeDoSegundoLacador', 'nomeDoTerceiroLacador', 'nomeDoQuartoLacador', 'nomeDoQuintoLacador']
	$('#buttonCenter').append('<button id="novaLargada">Novo numéro de largada</button>')
	$('#novaLargada').click(function(){
		let valorAtual = db.get('valorAtual').value()
		$('#center').remove()
		$('#buttonCenter').append('<div id="center"></div>')
		if(valorAtual > tamBd ){
			//alert("Não a mais equipes cadastradas todas ja foram chamadas!")
			let op = dialog.showMessageBoxSync(dialogOptions)
			if (op == 0) {
				location.reload()
			}
		}else{
			$('#center').append(`<p>Numero Da Largada: ${valorAtual}</p>`)
			$('#center').add('table').addClass("tabela")
			$('[class="tabela').append("<tr><th>Nome Do Laçador</th><th>1º</th><th>2º</th><th>3º</th><th>4º</th><th>5º</th><th>6º</th></tr>")	
			let name 
			let listNameClass = []
			for(let j in listaOrdemLacador){
				name = db.get(`Equipes[${valorAtual-1}].nomes.${listaOrdemLacador[j]}`).value()
				$('[class="tabela').append("<tr>")
				$('[class="tabela').append(`<td>${name}</td>`)
				add_view_classificao(name)
				listNameClass.push(name)
				$('[class="tabela').append("</tr>")
			}
			db.update('valorAtual', valorAtual => valorAtual + 1)
				.write()
			$('#center').append(`<button id="calcResRodada"> Calcular Resultado Da Rodada</button>`)
			$('#calcResRodada').click(function(){
				let listValorTotal = []
				let aux 
				for(let i = 0; i < 6; i++){
					aux = calc_result(i,listNameClass)
					listValorTotal.push(aux) 
				}
				print_total_rodada(listValorTotal)
				get_lacada_dos_lacador(listNameClass)
				print_individual_lacada()
			})

			
		}
		
	})
	
})
//função que obtem os valores
function get_lacada_dos_lacador(lista_name){
	let auxname
	let auxchecked
	let auxvalor = 0
	let aux
	for(let i in lista_name){
		aux = lista_name[i].replace( /\s/g, '' )
		for(let j = 0; j < 6; j++){
			auxname = String(aux + j)
			auxchecked = $(`input[type=radio][name=${auxname}]:checked`).val()
			if(auxchecked  === '1'){
				auxchecked = Number(auxchecked)
				auxvalor += auxchecked
			}
		}
		lacador.set(lista_name[i],auxvalor)
		auxvalor = 0
	}
}
//função que impre quanto cada um laçou
function print_individual_lacada(){
	$('#center').append('<p> Cada Laçador Laçou</p>')
	for(var[key, value] of lacador){
		$('#center').append(`<p> O laçador ${key} fez ${value} armada`)
	}
	lacador.clear()
}
//função que imprime os resultados
function print_total_rodada(listValor){
	//$('[class="tabela2').append('<tr><th>Rodadas</th><th>Valor Da Rodada<')
	let index  = 0
	let totalAcumulado = 0
	$('#center').append('<p>Total Da Rodada</p>')
	for(i in listValor){
		index += 1
		$('#center').append(`<p><b>${index}º</b>: ${listValor[i]} </p>`)	
		totalAcumulado += listValor[i]
	}
	$('#center').append(`<p> Total Acumulado: ${totalAcumulado}</p>`)
}
//função que calcula os resultados
function calc_result(index, nameClass){
	let name
	let valor
	let valorTotal = 0
	let aux
	for(i in nameClass){
		aux = nameClass[i].replace( /\s/g, '' )
		name = String(aux + index)
		valor = $(`input[type=radio][name=${name}]:checked`).val()
		if (valor === '1') {
			valor = Number(valor)
			valorTotal += valor
		}
	}
	return valorTotal
}

//adiciona o radio na tabela
function add_view_classificao(name_class){
	let name
	name_class = name_class.replace( /\s/g, '' )
	for(let i = 0; i < 6; i++){
		name = String(name_class + i)
		$('[class="tabela').append(`<td><input type="radio" value="1" name="${name}"></td>`)
	}
	
}


//$('#center').append(`<p>Ola laçador</p>`)
	/*console.log(db.get('Equipes').size().value())
	console.log(db.get('Equipes[0].nome').value())*/