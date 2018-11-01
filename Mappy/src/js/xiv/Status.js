/**
 * Watches all the buttons
 */
class Status
{
    static ui()
    {
        return $('.status');
    }

    static text(text)
    {
        Status.ui().find('.text').html(text);
    }
}

export default Status;
