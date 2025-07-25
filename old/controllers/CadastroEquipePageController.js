const path = require('path');
const { BrowserWindow } = require('electron');

class CadastroEquipePageController {
    constructor() {
        this.lacadaWindow = null;
    }

    // Função para criar e carregar lacada.html
    openCadastrarEquipePage(dirname) {
        try {
            this.lacadaWindow = new BrowserWindow({
                width: 800,
                height: 600,
                webPreferences: {
                    preload: path.join(dirname, 'preload.js'),
                    contextIsolation: true,
                    enableRemoteModule: false, // Adiciona segurança extra
                },
            });

            // Carregue a página lacada.html na pasta views
            this.lacadaWindow.loadFile(path.join(dirname, 'views', 'cadastrarEquipe.html'));
            this.lacadaWindow.on('closed', () => {
                this.lacadaWindow = null;
            });
        } catch (error) {
            console.error('Erro ao abrir a página de inscrição:', error);
        }
    }
}

module.exports = CadastroEquipePageController;