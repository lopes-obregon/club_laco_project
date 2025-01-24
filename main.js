const { app, BrowserWindow } = require('electron');
const path = require('path');
const {ipcMain} = require('electron');
const { openLacadaPage } = require('./controllers/lacadaController');
const inscriverController = require('./controllers/inscreverController');
let mainWindow;
const inscrever_html = new inscriverController();
function createWindow() {
  mainWindow = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
      preload: path.join(__dirname, 'preload.js'),
      contextIsolation: true, // Para maior segurança
      nodeIntegration: false, // Evite ativar diretamente para reduzir vulnerabilidades
    },
  });

  // Use um arquivo no controller para carregar as views
  mainWindow.loadFile(path.join(__dirname, 'views', 'index.html'));

  // Ative o DevTools apenas em desenvolvimento
  if (!app.isPackaged) {
    mainWindow.webContents.openDevTools();
  }

  mainWindow.on('closed', () => {
    mainWindow = null;
  });
}
//Escutando o evento open-lacada-page
ipcMain.on('open-lacada-page', () => {
  openLacadaPage(__dirname);
});
//escutao evendo de open-inscever-page
ipcMain.on('open-inscrever-page', () => {
  //inscriverController.openInscriverPage(__dirname);
  inscrever_html.openInscriverPage(__dirname);
});
// Eventos principais do app
app.on('ready', createWindow);

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') {
    app.quit();
  }
});

app.on('activate', () => {
  if (mainWindow === null) {
    createWindow();
  }
});
