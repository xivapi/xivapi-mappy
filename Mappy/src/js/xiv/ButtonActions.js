/**
 * Watches all the buttons
 */
class ButtonActions
{
    watch()
    {
        this.watchToggleOptionsView();
    }

  
    /**
     * Watch for toggling options on and off
     */
    watchToggleOptionsView()
    {
        document.getElementById('Action.ToggleOptionsView').onclick = event => {
            const ui = document.getElementById('options');
            ui.classList.toggle('open');
        };
    }
}

export default new ButtonActions();
