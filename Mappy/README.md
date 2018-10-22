# XIVAPI Mappy

An Electron + C# app to record in-game position and entity data.

# Getting started

Get onto the latest version of electron, at least v3.0.0+

- `npm -g i electron@3.0.4`

Get the project setup:

- Download repo
- cd `/repo/`
- `yarn`

Run the app with:

- Start it: `electron .` or (`bash bin/electron`)

JS/CSS compiling with:

- Local: `yarn run encore dev --watch` (or `bash bin/webpack`
- Production: `yarn dist` (or `bash bin/webpack_dist`)

> If you need SASS installed: `yarn add sass-loader node-sass --dev`