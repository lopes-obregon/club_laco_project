const path = require('path');
const { BrowserWindow } = require('electron');
 class inscriverController {
  constructor() {
    this.lacadaWindow = null;
  }

  // Função para criar e carregar lacada.html
  openInscriverPage(dirname) {
    this.lacadaWindow = new BrowserWindow({
      width: 800,
      height: 600,
      webPreferences: {
        preload: path.join(dirname, 'preload.js'),
        contextIsolation: true,
      },
    });

    // Carregue a página lacada.html na pasta views
    this.lacadaWindow.loadFile(path.join(dirname, 'views', 'inscrever.html'));
    this.lacadaWindow.on('closed', () => {
      this.lacadaWindow = null;
    });

  }
 
}

module.exports = inscriverController;