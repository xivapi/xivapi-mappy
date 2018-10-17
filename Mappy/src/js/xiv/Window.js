const { remote } = require('electron');

/**
 * Handle window actions
 */
class Window
{
    constructor()
    {
        this.maximizeState = false;
    }

    watch()
    {
        $('#LauncherWindowMin').on('click', () => {
            remote.BrowserWindow.getFocusedWindow().minimize();
        });

        $('#LauncherWindowMax').on('click', () => {
            const window = remote.BrowserWindow.getFocusedWindow();
            this.maximizeState ? window.unmaximize() : window.maximize();
            this.maximizeState = !this.maximizeState;
        });

        $('#LauncherWindowClose').on('click', () => {
            remote.BrowserWindow.getFocusedWindow().close();
        });
    }
}

export default new Window();

