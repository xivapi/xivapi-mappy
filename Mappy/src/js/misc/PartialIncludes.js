/**
 * Includes HTML files, webpack was doing my head-in
 */
class PartialIncludes
{
    include(callback)
    {
        let complete = 0;
        const partials = $('[data-partial]');

        // load each partial
        partials.each((i, dom) => {
            const filename = $(dom).data('partial');
            const filenameFull = 'partials/' + filename;

            // load it
            $(dom).load(filenameFull, null, () => {
                complete++;

                // if we've loaded them all, run callback
                if (complete === partials.length) {
                    callback();
                }
            });
        });
    }
}

export default new PartialIncludes();
