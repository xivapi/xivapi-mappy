const electron = require('electron');
const app = electron.app;
const BrowserWindow = electron.BrowserWindow;
const globalShortcut = electron.globalShortcut;
const os = require('os');
let win;

app.on('ready', () => {
    // Create the browser window.
    win = new BrowserWindow({
        icon: 'build/logo.ico',
        width: 720,
        height: 480,
    });

    // load page
    win.loadFile('public/index.html');

    // Enable keyboard shortcuts for Developer Tools on various platforms.
    let platform = os.platform();
    if (platform === 'darwin') {
        globalShortcut.register('Command+Shift+I', () => {
            win.webContents.openDevTools()
        })
    } else if (platform === 'linux' || platform === 'win32') {
        globalShortcut.register('Control+Shift+I', () => {
            win.webContents.openDevTools()
        })
    }

    win.on('closed', () => {
        win = null
    });
});

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit()
    }
});
