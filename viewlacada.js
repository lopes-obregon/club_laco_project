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
				if(db.get('pontos').size().value() > 0  ){
					op = dialog.showMessageBoxSync({type: 'info', buttons: buttons, message:'Talvez haja armadas para repor deseja verificar ?'});
					//deseja verificar a reposição de armadas
					if(op == 0){
						//rechamada
						let listNameClass = reChamada(valorAtual, listaOrdemLacador);
						//adiciona botões
						addButton();
						//funções dos botoes
						acoesButton(listNameClass, valorAtual, tamBd);
					}
				}else{
					location.reload();
				}
				
			}
		}else{
			if(db.get('pontos').size().value() > 0  ){
				op = dialog.showMessageBoxSync({type: 'info', buttons: buttons, message:'Talvez haja armadas para repor deseja verificar ?'});
				//deseja verificar a reposição de armadas
				if(op == 0){
					//rechamada
					let listNameClass = reChamada(valorAtual, listaOrdemLacador);
					//adiciona botões
					addButton();
					//funções dos botoes
					acoesButton(listNameClass, valorAtual, tamBd);
				}
			}else{
				printfTabela(valorAtual);
				let listNameClass = elementosTabela(listaOrdemLacador, valorAtual);
			db.update('valorAtual', valorAtual => valorAtual + 1)
				.write()
			//função que adiciona os botões
			addButton();
			//funções dos botoes
			acoesButton(listNameClass, valorAtual, tamBd);
			
			}
			
			
			
		}
		
	})
	
})
//procedimento com as ações dos botões
function acoesButton(listNameClass, valorAtual, tamBd){
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
		let responseDb;
		getTable(listNameClass)
		console.log(valorAtual);
		if(valorAtual -1 < 0){
			responseDb = db.get(`Equipes[${valorAtual}].nomeFazenda`).value();
		}else{
			if(valorAtual > tamBd){
				valorAtual -= 1;
			}
			responseDb = db.get(`Equipes[${valorAtual-1}].nomeFazenda`).value();
		} 
		let obj = {name1:listNameClass[0], armadas1:[], name2:listNameClass[1], armadas2:[], name3:listNameClass[2],armadas3:[]
		, name4:listNameClass[3], armadas4:[], name5:listNameClass[4], armadas5:[]};
		console.log(matPoint);

		for(let i in listNameClass){
			//salva os dados da tabela no banco de dados.
				
				if(i == 0){
					obj.armadas1.push(matPoint[i]);
				}else{
					if(i == 1){
						obj.armadas2.push(matPoint[i]);
					}else{
						if(i == 2){
							obj.armadas3.push(matPoint[i]);
						}else{
							if(i == 3){
								obj.armadas4.push(matPoint[i]);
							}else{
								if(i == 4){
									obj.armadas5.push(matPoint[i]);
								}
							}
						}
					}
				}
				
		}
		if(db.get("pontos").find({nomeFazenda: responseDb}).value() == undefined){
			//não existe então insere na tabela
			db.get('pontos').push({nomeFazenda: responseDb, lacadores:obj}).write();
		}else{
			//atualiza a tabela do banco de dados
			console.log("atualizando banco");
			db.get("pontos").find({nomeFazenda: responseDb}).assign({lacadores:obj}).write();			

		}
		
		dialog.showMessageBoxSync({type:'info', buttons:buttons, message:"Pontos Salvo com sucesso!"})
		
	});
}
//função que chama a criação dos elementos da tabela
function elementosTabela(listaOrdemLacador, valorAtual){
	let name 
	let listNameClass = []
	matPoint = [];
	for(let j in listaOrdemLacador){
		if(valorAtual - 1 < 0){
			valorAtual = 0;
			name = db.get(`Equipes[${valorAtual}].nomes.${listaOrdemLacador[j]}`).value()
		}else{
			name = db.get(`Equipes[${valorAtual-1}].nomes.${listaOrdemLacador[j]}`).value()
		}
		$('[class="tabela').append("<tr>")
		$('[class="tabela').append(`<td>${name}</td>`)
		add_view_classificao(name);
		listNameClass.push(name);
		checkArmada(matPoint, listNameClass);
		//função que verifica se tem armada ou não e adiciona na matriz
		function  checkArmada(mat, listNameClass){
			console.log(mat);
			let aux = "";
			if(mat.length <= 5){
				mat.push([]);
			}
			for(let i in listNameClass){
				aux = listNameClass[i].replace( /\s/g, '' );
				
				for(let j = 0; j < 6; j++){
					aux = String(aux + j);
					if($(`#${aux}`).prop('checked') == true){
						mat[i].push(1);
					}else{
						if($(`#${aux}`).prop('indeterminate') == true){
							mat[i].push(-1);
						}else{
							matPoint[i].push(0);
						}
					}
					aux = listNameClass[i].replace( /\s/g, '' );
				}
			}
		}
		$('[class="tabela').append("</tr>")
	}
	return listNameClass;
}
//função que seta os pontos na tabela
function setPointTable(listNameClass, lacadoresPoint){
	let id ="";
	matPoint = [];
	for(let i in listNameClass){
		id = listNameClass[i]
		matPoint.push([]);
		for(let j = 0; j < 6; j++){
			id = String(id + j);
			if(lacadoresPoint[i][0][j] == 1){
				//se armada igual 1 então é armada positiva
				$(`#${id}`).prop("checked", true);
				$(`#${id}`).prop("disabled", true);
				matPoint[i].push(1);
			}else{
				if(lacadoresPoint[i][0][j] == -1){
					//se armada igual a -1 então a armada é negativa
					$(`#${id}`).prop("indeterminate", true);
					$(`#${id}`).prop("disabled", true);
					matPoint[i].push(-1);
				}else{
					matPoint[i].push(0);
				}

			}
			id = listNameClass[i];
		}
	}

}
//função que adiciona os botoes
function addButton(){
	$('#center').append(`<button id="calcResRodada"> Calcular Resultado Da Rodada</button>`)
	$('#center').append('<button id="save">Salvar Resultado Da Tabela </button>');
	$('#center').append('<button id="corrigi">Corrigir Armada </button>');
}
//função que imprime a tabela
function printfTabela(numLargada){
	$('#center').append(`<p>Numero Da Largada: ${numLargada}</p>`);
	$('#center').add('table').addClass("tabela")
	$('[class="tabela').append("<tr><th>Nome Do Laçador</th><th>1º</th><th>2º</th><th>3º</th><th>4º</th><th>5º</th><th>6º</th></tr>")
}
//função que faz uma rechamada
function reChamada(valorAtual, listaOrdemLacador){
	//variavel que obtem o tamanho do banco
	let tamPontos = db.get('pontos').size().value()
	//para dar o primeiro indicie do banco
	tamPontos = (valorAtual - tamPontos) -1;
	let pontos = db.get(`pontos[${tamPontos}].lacadores`).value();
	//array
	let pontosArmada = [];
	let listNameClass;
	encheMatriz(pontosArmada, 0, pontos.armadas1);
	encheMatriz(pontosArmada, 1, pontos.armadas2);
	encheMatriz(pontosArmada, 2, pontos.armadas3);
	encheMatriz(pontosArmada, 3, pontos.armadas4);
	encheMatriz(pontosArmada, 4, pontos.armadas5);
	function encheMatriz(matriz, index, armada){
		matriz.push([])
		for(let i = 0; i < 6; i++){
			matriz[index].push(armada[i]);
		}
	}
	//imprime na tabela
	printfTabela(tamPontos+1);
	listNameClass = elementosTabela(listaOrdemLacador, tamPontos);
	for(let i = 0; i < 6; i++){
		if((pontos.armadas1[i] | pontos.armadas2[i]  | pontos.armadas3[i] | pontos.armadas4[i] | pontos.armadas5[i]) == 0){
			
			setPointTable(listNameClass, pontosArmada);
		}
	}
	return listNameClass;
}
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