// All of the Node.js APIs are available in the preload process.
// It has the same sandbox as a Chrome extension.
const { contextBridge, ipcRenderer } = require('electron')
window.addEventListener('DOMContentLoaded', () => {
  const replaceText = (selector, text) => {
    const element = document.getElementById(selector)
    if (element) element.innerText = text
  } 
  
  for (const type of ['chrome', 'node', 'electron']) {
    replaceText(`${type}-version`, process.versions[type])
  }
})
contextBridge.exposeInMainWorld('electron', {
  tela: (arg)=> ipcRenderer.send(arg)  // Certifique-se de que 'ipcRenderer' é a chave certa
});

console.log('Preload script loaded');

