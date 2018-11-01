import Logger from './Logger';

/**
 * Interact with xivapi
 */
class Api
{
    constructor()
    {
        this.settings = {
            mode: 'cors'
        };
    }

    /**
     * Call JS fetch.
     *
     * @param endpoint
     * @param callback
     */
    get(endpoint, callback)
    {
        const url = `https://xivapi.com${endpoint}`;
        Logger.log(`GET: ${url}`);

        fetch(url, this.settings)
            .then(response => response.json())
            .then(data => callback(data));
    }

    /**
     * Get FFXIV Map information
     *
     * @param id
     * @param callback
     */
    getMap(id, callback)
    {
        this.get(`/Map/${id}`, callback);
    }
}

export default new Api();

