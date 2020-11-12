// This file is required by the index.html file and will
// be executed in the renderer process for that window.
// No Node.js APIs are available in this process because
// `nodeIntegration` is turned off. Use `preload.js` to
// selectively enable features needed in the rendering
// process.
window.$ = window.jQuery = require('./node_modules/jquery')
const { readFileSync } = require('fs')

window.readConfig = function () {
  const data = readFileSync('./config.json')
  return data
}
$(function(){
	//chama a pagina
	$('#inscreve').click(function(){
		new_window('inscrever.html')
	})
	$('#lacada').click(function(){
		new_window('lacada.html')
	})
	$('#verifica').click(function(){
		new_window('verifica.html')
	})
})

//função que cria  a nova janela
function new_window(name_view){
	const {remote} = require('electron')
	const {BrowserWindow} = remote
	const win = new BrowserWindow({webPreferences:{nodeIntegration: true}})
	win.webContents.openDevTools()
	win.loadFile(name_view)
}