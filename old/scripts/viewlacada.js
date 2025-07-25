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
	let listNameClass;
	let valorAtual;
	$('#buttonCenter').append('<button id="novaLargada" class="bt"  >Novo numéro de largada</button>');
	$('#buttonCenter').append('<button id="rechamada" class="bt">Rechamada</button>');
	//acoesButton(listNameClass, valorAtual, tamBd, listaOrdemLacador);
	//ações dos botões principais
	$('#novaLargada').click(function(){
		valorAtual = db.get('valorAtual').value()
		$('#center').remove()
		$('#buttonCenter').append('<div id="center"></div>')
		if(valorAtual > tamBd ){
			//alert("Não a mais equipes cadastradas todas ja foram chamadas!")
			let op = dialog.showMessageBoxSync(dialogOptions)
			if (op == 0) {
				//if(calcArmadaDev() == true){
				if(db.get("pontos").size().value() <= db.get("valorCheck").value()){
					//garantido pelomenos 1
					//cria um botão para fazer uma rechamada
					dialog.showMessageBoxSync({type:'info', buttons: buttons, message: 'Armdadas que podem ser repostas!'});
					
				}else{
					location.reload();
				}
				
			}
		}else{
			
			printfTabela(valorAtual);
			let listNameClass = elementosTabela(listaOrdemLacador, valorAtual);
			db.update('valorAtual', valorAtual => valorAtual + 1)
				.write()
			//função que adiciona os botões
			addButton();
			//funções dos botoes
			acoesButton(listNameClass, valorAtual, tamBd, listaOrdemLacador);
			
			
		}
		
	});
	$('#rechamada').click(function(){
		let tamPontos = db.get("valorCheck").value();//variavel com o valor a se dirigir
		valorAtual = db.get('valorAtual').value();
		tamDbPontos = db.get("pontos").size().value()
		$('#center').remove();
		$('#buttonCenter').append('<div id="center"></div>');
		//se valor atual maior que valorCheck então tem armadas para repor
		if((tamPontos > tamDbPontos)){
			//senão escreva :não á armadas para repor no nomento aguarde terminar as chamadas
			dialog.showMessageBoxSync({type:'info', buttons: buttons, message: 'Não á armadas para repor no nomento!'});

		}else{
			printfTabela(tamPontos);
			let listNameClass = reChamada(listaOrdemLacador, tamPontos);
			//console.log(listNameClass);
			if(listNameClass == undefined){
				$("#rechamada").remove();
				dialog.showMessageBoxSync({type:'info', buttons: buttons, message: 'Todos as fazendas já foram rechamadas!'});
			}else{
				
				//função que adiciona os botões
				addButton();
				//valor atual recebe o valorCheck para inserir em salvar
				valorAtual = db.get("valorCheck").value();
				//atualiza para o pŕoximo
				db.update("valorCheck", valorCheck => valorCheck + 1).write()
				//funções dos botoes
				acoesButton(listNameClass, valorAtual, tamBd, listaOrdemLacador);
			}
		}
		
		
	});
})
//procedimento que calcula se tem alguma equipe com armada devendo
function calcArmadaDev(){
	let tamanhoTabelaPontos = db.get("pontos").size().value()//variavel com a quantidade de equipes
	let index = 0;//variavel que serve para o index
	//variavel para o resultado
	let result = false;
	while(index <= tamanhoTabelaPontos){
		//realiza uma consulta
		let response = db.get(`pontos[${index}].lacadores`).value();
		let matLista = [];
		trasformaObjetoEmArray(response, matLista);
		//procedimento que trasfroma o objeto em uma matriz de array
		function trasformaObjetoEmArray(obj, mat){
			if(obj != undefined){
				for(let i = 0; i < 5; i++){
					mat.push([]);
					if(i == 0){
						mat[i].push(obj.armadas1);
					}else{
						if(i == 1){
							mat[i].push(obj.armadas2);
						}else{
							if(i == 2){
								mat[i].push(obj.armadas3);
							}else{
								if(i == 3){
									mat[i].push(obj.armadas4);
								}else{
									if(i == 4){
										mat[i].push(obj.armadas5);
									}
								}
							}
						}
					}
				}
			}
		}
		console.log(matLista);
		for(let i = 0; i < 5; i++){
			if(verificaArmada(matLista[i]["0"]["0"], 0, false) == true){
				//tem armadas para repor resultado recebe verdadeiro e paro de executar
				result = true;
				break;
			}else{
				//se o laçador verificado não tiver então vai para o proximo
				result = false;
			}
		}
		console.log(result)
		function verificaArmada(listaDePontos, index, resultado){
			//se index igual o tamanho da lista então retorna verdadeiro
			if((index >= listaDePontos.length) & (resultado == true) ){
				return true;
			}else{
				//se index >= lista de pontos  e resultado igual a falso então  retorne falso
				if((index >= listaDePontos.length) & (resultado == false)){
					return false;
				}else{
					//se lista de pontos na posição index  for igual a zero então retorna verdadeiro;
					if(listaDePontos[index] == 0){
						return true;
					}else{
						//se for menor então chama de novo
						if((index < listaDePontos.length) & (resultado == false)){
							verificaArmada(listaDePontos, index+1, false);
						}
					}
				}	
			}
		}
		index++;
	}
	//alguem momento vai sair ou com falso ou com verdadeiro independente do resulta retorna ele
	return result;
}
//procedimento para chamar as rechamadas

//procedimento com as ações dos botões
function acoesButton(listNameClass, valorAtual, tamBd, listaOrdemLacador){
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
		getTable(listNameClass);
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
			db.get("pontos").find({nomeFazenda: responseDb}).assign({lacadores:obj}).write();			

		}
		
		dialog.showMessageBoxSync({type:'info', buttons:buttons, message:"Pontos Salvo com sucesso!"})
		
	});
	
}
function buttonRechamada(listaOrdemLacador, valorAtual, tamBd){
	let tamPontos = db.get("valorCheck").value();
	printfTabela(tamPontos);
	let listNameClass = reChamada(listaOrdemLacador);
	if(listNameClass == undefined){
		$("#rechamada").remove();
		let op = dialog.showMessageBoxSync({type:'info', buttons: buttons, message: 'Todos as fazendas já foram rechamadas!'});
		if(op == 1){
			location.reload();
		}
	}else{
		//função que adiciona os botões
		addButton();
		//funções dos botoes
		acoesButton(listNameClass, valorAtual, tamBd, listaOrdemLacador);
	}
	
}
//função que chama a criação dos elementos da tabela
function elementosTabela(listaOrdemLacador, valorAtual){
	let name 
	let listNameClass = []
	matPoint = [];
	for(let j in listaOrdemLacador){
		name = db.get(`Equipes[${valorAtual-1}].nomes.${listaOrdemLacador[j]}`).value()
		if(name == undefined){
			$("#rechamada").remove();
				break;
			
		}
		$('[class="tabela').append("<tr>")
		$('[class="tabela').append(`<td>${name}</td>`)
		add_view_classificao(name);
		listNameClass.push(name);
		$('[class="tabela').append("</tr>")
	}
	checkArmada(matPoint, listNameClass);
		//função que verifica se tem armada ou não e adiciona na matriz
		function  checkArmada(mat, listNameClass){
			let aux = "";
			
			for(let i in listNameClass){
				if(mat.length <= 5){
					mat.push([]);
				}
				aux = listNameClass[i].replace( /\s/g, '' );
				
				for(let j = 0; j < 6; j++){
					aux = String(aux + j);
					if($(`#${aux}`).prop('checked') == true){
						mat[i].push(1);
					}else{
						if($(`#${aux}`).prop('indeterminate') == true){
							mat[i].push(-1);
						}else{
							mat[i].push(0);
						}
					}
					aux = listNameClass[i].replace( /\s/g, '' );
				}
			}
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
	$('#center').append(`<button id="calcResRodada" class="bt" > Calcular Resultado Da Rodada</button>`)
	$('#center').append('<button id="save" class="bt" >Salvar Resultado Da Tabela </button>');
	$('#center').append('<button id="corrigi" class="bt" >Corrigir Armada </button>');
}
//função que imprime a tabela
function printfTabela(numLargada){
	$('#center').append(`<p class="largada">Numero Da Largada: ${numLargada}</p>`);
	$('#center').add('table').addClass("tabela")
	$('[class="tabela').append("<tr><th>Nome Do Laçador</th><th>1º</th><th>2º</th><th>3º</th><th>4º</th><th>5º</th><th>6º</th></tr>")
}
//função que faz uma rechamada
function reChamada(listaOrdemLacador, tamPontos){
	//variavel que obtem os laçadores
	let pontos = db.get(`pontos[${tamPontos-1}].lacadores`).value();
	//array
	let pontosArmada = [];
	let listNameClass;
	if(pontos == undefined){
		$("#rechamada").remove();
	}else{
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
		listNameClass = elementosTabela(listaOrdemLacador, tamPontos);
		for(let i = 0; i < 6; i++){
			if((pontos.armadas1[i] | pontos.armadas2[i]  | pontos.armadas3[i] | pontos.armadas4[i] | pontos.armadas5[i]) == 0){
				
				setPointTable(listNameClass, pontosArmada);
			}
		}
		return listNameClass;
	}
	
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
				//se onde corrir for diferente de disable então corrigi
				if($(`#${auxName}`).prop('disabled') == !true){
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
	//$('#center').append('<p> Cada Laçador Laçou</p>')
	$('#buttonCenter').append('<div id="individual"></div>');
	$('#individual').append('<p>Cada Laçador Laçou</p>')
	for(var[key, value] of lacador){
		$('#individual').append(`<p> O laçador ${key} fez ${value} armada`)
	}
	lacador.clear()
}
//função que imprime os resultados
function print_total_rodada(listValor){
	//$('[class="tabela2').append('<tr><th>Rodadas</th><th>Valor Da Rodada<')
	let index  = 0
	let totalAcumulado = 0
	/*
	$('#center').append('<p>Total Da Rodada</p>');*/
	$('#buttonCenter').append('<div id="tRodada"></div>');
	$('#tRodada').append('<p>Total Da Rodada</p>');//adicionando na div a tag p
	for(i in listValor){
		index += 1
		$('#tRodada').append(`<p><b>${index}º</b>: ${listValor[i]} </p>`)	
		totalAcumulado += listValor[i]
	}
	$('#tRodada').append(`<label> Total Acumulado: ${totalAcumulado}</label>`)
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