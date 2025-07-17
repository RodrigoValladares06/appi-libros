const express = require('express');
const app = express();
const port = 3000;

// Middleware para parsear JSON
app.use(express.json());

// Ruta principal
app.get('/', (req, res) => {
  res.send('¡Hola, mundo! Este es tu backend funcionando 🔥');
});

// Ruta POST para recibir datos
app.post('/mensaje', (req, res) => {
  const { nombre, mensaje } = req.body;
  res.send(`Mensaje recibido de ${nombre}: ${mensaje}`);
});

// Levantar el servidor
app.listen(port, () => {
  console.log(`Servidor escuchando en http://localhost:${port}`);
});
