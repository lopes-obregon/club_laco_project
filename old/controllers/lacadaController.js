const path = require('path');
const { BrowserWindow } = require('electron');

// Função para criar e carregar lacada.html
function openLacadaPage(dirname) {

    
  let lacadaWindow = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
      preload: path.join(dirname, 'preload.js'),
      contextIsolation: true,
    },
  });

  // Carregue a página lacada.html na pasta views
  lacadaWindow.loadFile(path.join(dirname, 'views', 'lacada.html'));
  lacadaWindow.on('closed', () => {
    lacadaWindow = null;
  });
}

module.exports = { openLacadaPage };
