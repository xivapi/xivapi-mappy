const moment = require("moment");

/**
 * Watches all the buttons
 */
class Logger
{
    static ui()
    {
        return $('.log');
    }

    static log(text)
    {
        const date = moment().format('hh:mm:ss');
        Logger.ui().append(`<div>${date} &nbsp; ${text}</div>`);
    }

    static line()
    {
        Logger.log('-----------------------------------');
    }
}

export default Logger;
