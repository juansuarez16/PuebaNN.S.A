const { env } = require('process');

const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
  env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'http://localhost:19551';

const PROXY_CONFIG = [
  {
    context: [
      "/weatherforecast",
   ],
    proxyTimeout: 10000,
    target: target,
    secure: false,
    headers: {
      Connection: 'Keep-Alive',
      'Access-Control-Allow-Origin': '*', // Permitir solicitudes desde cualquier origen
      'Access-Control-Allow-Methods': 'GET, POST, PUT, DELETE, OPTIONS', // Permitir los métodos HTTP comunes
      'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept, Authorization' // Permitir los encabezados comunes
    }
  }
]

module.exports = PROXY_CONFIG;
