/**
 * Just JQuery things
 */
window.$ = window.jQuery = require('jquery');
window.Bootstrap = require('bootstrap');

/**
 * Watch window actions
 */
import Window from './xiv/Window';
Window.watch();

import ButtonActions from './xiv/ButtonActions'
ButtonActions.watch();