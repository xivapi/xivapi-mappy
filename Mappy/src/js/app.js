import PartialIncludes from './misc/PartialIncludes';
import Logger from './xiv/Logger';
import Window from './xiv/Window';
import ButtonActions from './xiv/ButtonActions'



/**
 * Just JQuery things
 */
window.$ = window.jQuery = require('jquery');
window.Bootstrap = require('bootstrap');

/**
 * Look for partial includes, include them all and then
 * initiate all bind events in the callback
 */
PartialIncludes.include(() => {
    /**
     * Intro
     */
    Logger.log('Welcome to XIVAPI Mappy!');
    Logger.log('Version: 1.0');
    Logger.log("Discord: https://discord.gg/MFFVHWC");
    Logger.line();

    /**
     * Watch window actions
     */
    Window.watch();
    /**
     * Watch for button actions
     */

    ButtonActions.watch();
});
