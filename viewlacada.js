window.$ = window.jQuery = require('./node_modules/jquery')
const low = require('lowdb')
const FileSync = require('lowdb/adapters/FileSync')
const adapter = new FileSync('db.json')
const db = low(adapter)
const {dialog} = require('electron').remote
var buttons = ['OK', 'Cancel']
var matPoint =[];
const dialogOptions = {type: 'info', buttons: buttons, message: 'Não a mais chamadas, deseja atualizar?'};
const prompt = require('electron-prompt');
//dicionario
var lacador = new Map()
$(function(){
	//objeto
	//variavel global
	//variavel local
	let count = 0;
	//document.getElementById("test").indeterminate = true;
	/*$('#test').click(function(){
		
		if($('input[type=checkbox]:checked').val() == undefined){
			//document.getElementById('test').indeterminate = true;
			$(this).prop("indeterminate", true);
			

		}
		
		if(count > 2){
			$(this).prop("indeterminate", false);
			$(this).prop("checked", false);
			count = 0;

		}
		count++;
		console.log(count)
	})*/
	let tamBd = db.get('Equipes').size().value()
	let listaOrdemLacador = ['nomeDoPrimeiroLacador', 'nomeDoSegundoLacador', 'nomeDoTerceiroLacador', 'nomeDoQuartoLacador', 'nomeDoQuintoLacador']
	$('#buttonCenter').append('<button id="novaLargada">Novo numéro de largada</button>');
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
				add_view_classificao(name);
				listNameClass.push(name)
				matPoint.push([]);
				for(let i = 0; i < 6; i++){
					matPoint[j].push(0);
				}
				$('[class="tabela').append("</tr>")
			}
			db.update('valorAtual', valorAtual => valorAtual + 1)
				.write()
			$('#center').append(`<button id="calcResRodada"> Calcular Resultado Da Rodada</button>`)
			$('#center').append('<button id="save">Salvar Resultado Da Tabela </button>');
			$('#center').append('<button id="corrigi">Corrigir Armada </button>');
			//funções dos botoes
			$('#corrigi').click(function(){
				prompt({
					title: 'Corrigir',
					label: 'Qual laçador deseja corrir?',
					value: 'Nome laçador',
					type: 'input'
				})
				.then((name) => {
					if(name === null) {
						console.log('user cancelled');
					} else {
						prompt({
							title:'Corrigir',
							label:'Qual armada deseja corrir?',
							value:'1',
							type: 'input'
						})
						.then(armada =>{
							if(name === null){
								console.log('cancelado');
							}else{
								//função que corrigi a armada
								setArmada(listNameClass, name, armada);
							}
						});
					}
				})
				.catch(console.error);
				
			});
			$('.armadas').change(function(){
				for(let i in listNameClass){
					for(let j = 0; j < 6; j++){
						let aux="";
						aux = String(listNameClass[i] + j);
						$(`#${aux}`).click(function(){
								if(($(this).prop("indeterminate") == true)){
										$(this).prop("indeterminate", false);
										$(this).prop("checked", false);
								}
								//console.log($(`input[type=checkbox][name=${aux}][id=${aux}]:checked`).val())
								if($(`input[type=checkbox][name=${aux}][id=${aux}]:checked`).val()== undefined){
									$(this).prop("indeterminate", true);
									//$(`input[type=checkbox][name=${aux}]:checked`).val()
								}
						});
					}
				}
			});
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
			//botão que salva no banco
			$('#save').click(function(){
				getTable(listNameClass)
				console.log(matPoint)
			});
			
		}
		
	})
	
})
//obtem o resultado da tabela
function getTable(listName){
	let auxName;
	let aux;
	for( let i in listName){
		aux = listName[i].replace( /\s/g, '' );
		for(let j = 0; j < 6; j++){
			auxName = String(aux + j);
			if($(`#${auxName}`).prop('checked') == true){
				matPoint[i][j] = 1;
			}else{
				if($(`#${auxName}`).prop('indeterminate') == true){
					matPoint[i][j] = -1;
				}
			}

		}
	}
}
//função que corrigi armadas
function setArmada(listName, name, armada){
	let aux;
	let auxName;
	armada = armada -1;
	for(let i in listName){
		//retira o espaço
		aux = listName[i].replace( /\s/g, '' );
		for(let j = 0; j < 6; j++){
			auxName = String(aux +j);
			if((listName[i] == name)  & (armada == j) ){
				//achei onde corrigir
				if($(`#${auxName}`).prop('indeterminate') == true){
					$(`#${auxName}`).prop('indeterminate', false);
				}else{
					if($(`#${auxName}`).prop('checked') == true){
						$(`#${auxName}`).prop('checked', false);
					}
				}
			}

		}
	}
}
//função que obtem os valores
function get_lacada_dos_lacador(lista_name){
	let auxname
	let auxvalor = 0
	let aux
	for(let i in lista_name){
		//retira o espaço
		aux = lista_name[i].replace( /\s/g, '' )
		for(let j = 0; j < 6; j++){
			auxname = String(aux + j)
			
			if($(`#${auxname}`).prop('checked') == true){
				auxvalor ++;
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
	let valorTotal = 0
	let aux
	for(i in nameClass){
		aux = nameClass[i].replace( /\s/g, '' )
		name = String(aux + index)
		if ($(`#${name}`).prop('checked') == true) {
			valorTotal ++;

		}
	}
	return valorTotal;
}

//adiciona o checkbox na tabela
function add_view_classificao(name_class){
	let name
	name_class = name_class.replace( /\s/g, '' )
	for(let i = 0; i < 6; i++){
		name = String(name_class + i)
		$('[class="tabela').append(`<td><input type="checkbox"  name="${name}" id="${name}" class="armadas" ></td>`)
	}
	
}


//$('#center').append(`<p>Ola laçador</p>`)
	/*console.log(db.get('Equipes').size().value())
	console.log(db.get('Equipes[0].nome').value())*/