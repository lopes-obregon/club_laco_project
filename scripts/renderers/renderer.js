// This file is required by the index.html file and will
// be executed in the renderer process for that window.
// No Node.js APIs are available in this process because
// `nodeIntegration` is turned off. Use `preload.js` to
// selectively enable features needed in the rendering
// process.
// Importa o ipcRenderer para comunicação com o processo principal


// Manipulador de eventos para os botões
/*$(function () {
    // Verifique se window.Electron.ipcRenderer está disponível
	console.log(window.electron.tela);  // Verifique se isso retorna a função
    $('#lacada').on('click', function() {
        if (window.Electron && window.Electron.ipcRenderer) {
            window.Electron.ipcRenderer.send('open-window', 'lacada.html');
			
        } else {
            console.error('ipcRenderer não disponível');
        }
    });
});*/

$(function () {
	// Chama a página de laçada
	//console.log(window.Electron);
//console.log(window.Electron.ipcRenderer);  // Verifique se isso retorna a função
	$('#lacada').on('click', function(){
        window.electron.tela('open-lacada-page');
    });
	// Chama a página de inscrição
   $('#inscreve').on('click', function(){
		window.electron.tela('open-inscrever-page');
	});

    //chama  a pagina para inscrever a equipe
    $('#cadastrarEquipe').on('click', ()=>{
        window.electron.tela('open-cadastrarEquipe-page');
    });
});
