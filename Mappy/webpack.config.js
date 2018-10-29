let Encore = require('@symfony/webpack-encore');

console.log(__dirname);

Encore
    .setOutputPath('public/assets/')
    .setPublicPath('/assets')
    .enableSourceMaps(true)
    .addEntry('js/app', './src/js/app.js')
    .addStyleEntry('css/app', './src/css/app.scss')
    .addLoader({
        test: /\.handlebars/,
        loader: 'handlebars-loader',
        options: {
            partialDirs: [
                __dirname + '/src/templates'
            ]
        }
    })
    .enableSassLoader()
;

// enaboe node environment
let config = Encore.getWebpackConfig();
config.target = 'electron-renderer';
module.exports = config;
