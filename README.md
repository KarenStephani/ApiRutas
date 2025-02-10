# API para Calcular la Ruta Más Corta entre Dos Ciudades

## Descripción General

Este API permite calcular la ruta más corta entre dos ciudades en función de las conexiones viales dadas. Utiliza un algoritmo de búsqueda de rutas:  Dijkstra, para encontrar el camino más eficiente entre los puntos de inicio y destino.

### Funcionalidades principales:
- Calcular la ruta más corta entre dos ciudades.
- Retornar la distancia total de la ruta.
- Retornar las ciudades por las que pasa la ruta más corta.

---

## Requisitos

- .NET 8 SDK o superior.
- Visual Studio 2022 o superior (opcional para desarrollo).
- Git para control de versiones.

---
## Pruebas locales
POST : https://localhost:7256/Route/optimal-route

REQUEST (ejm):
{
"cities": ["A", "B", "C", "D"],
"roads": [
{"from": "A", "to": "B", "time": 10},
{"from": "B", "to": "C", "time": 15},
{"from": "A", "to": "C", "time": 30},
{"from": "C", "to": "D", "time": 5},
{"from": "B", "to": "D", "time": 25}
],
"origin": "A",
"destination": "D"
}

## Clonando el Repositorio

Si deseas contribuir o modificar el proyecto, puedes clonar el repositorio desde GitHub usando los siguientes comandos:

```bash
git clone https://github.com/KarenStephani/ApiRutas
cd nombre-del-repositorio

