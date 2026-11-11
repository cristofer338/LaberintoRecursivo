# LaberintoRecursivo

## Descripción

LaberintoRecursivo es una aplicación de consola desarrollada en C# que permite encontrar la salida de un laberinto mediante el uso de **recursividad y backtracking**.

El programa explora diferentes caminos hasta encontrar la salida, evitando paredes y casillas que ya fueron visitadas. También registra estadísticas para analizar el comportamiento del algoritmo.

## Objetivo

Implementar un algoritmo recursivo para resolver un problema de búsqueda de caminos, comprender el funcionamiento de las llamadas recursivas y evaluar su comportamiento con diferentes tamaños de laberintos.

## Tecnologías utilizadas

- Lenguaje: C#
- Entorno de desarrollo: Visual Studio
- Plataforma: .NET
- Tipo de aplicación: Consola

## Funcionalidades

El programa cuenta con las siguientes opciones:

1. Resolver un laberinto pequeño de 7 × 7.
2. Resolver un laberinto mediano de 11 × 11.
3. Resolver un laberinto grande de 15 × 15.
4. Salir del programa.

Al finalizar cada búsqueda, muestra:

- Resultado de la búsqueda.
- Camino encontrado.
- Cantidad de llamadas recursivas.
- Cantidad de casillas del camino.
- Tiempo de ejecución en milisegundos.

## Funcionamiento de la recursividad

El algoritmo utiliza un método llamado `BuscarCamino()`, que se llama a sí mismo para explorar las casillas vecinas del laberinto.

### Caso base

El caso base ocurre cuando el algoritmo llega a la casilla de salida. En ese momento devuelve `true` y termina la búsqueda.

### Caso recursivo

El caso recursivo consiste en explorar las cuatro direcciones posibles:

- Derecha.
- Abajo.
- Izquierda.
- Arriba.

Cada movimiento genera una nueva llamada al método recursivo.

### Backtracking

Cuando una ruta no permite llegar a la salida, el algoritmo retrocede y elimina la última casilla del camino. De esta manera puede explorar otras alternativas.

## Representación del laberinto

Los símbolos utilizados son:

| Símbolo | Significado |
|---|---|
| S | Inicio |
| E | Salida |
| # | Pared |
| . | Espacio libre |
| * | Camino encontrado |

## Estructura del proyecto

```text
LaberintoRecursivo/
│
├── Program.cs
│
├── LaberintoRecursivo.csproj
│
└── README.md
```

## Ejecución del proyecto

1. Abrir el proyecto en Visual Studio.
2. Ejecutar la aplicación con `Ctrl + F5`.
3. Seleccionar el tamaño del laberinto.
4. Observar el resultado de la búsqueda.
5. Revisar las estadísticas de ejecución.

También se puede ejecutar desde una terminal ubicada en la carpeta del proyecto:

```bash
dotnet run
```

## Pruebas de ejecución

Se realizarán pruebas con tres tamaños diferentes:

| Prueba | Tamaño |
|---|---|
| 1 | 7 × 7 |
| 2 | 11 × 11 |
| 3 | 15 × 15 |

Los resultados de cada prueba se utilizarán para comparar la cantidad de llamadas recursivas y el tiempo de ejecución.

## Conclusión

Este proyecto permite comprender cómo la recursividad puede utilizarse para resolver problemas de búsqueda. Mediante el algoritmo de backtracking, el programa explora diferentes caminos y retrocede cuando encuentra una ruta sin salida.

Además, las mediciones permiten observar cómo cambia el comportamiento del algoritmo al utilizar laberintos de diferentes tamaños.

## Autor

**Nombre:** Cristofer Alejandro Barboza Chavez

**Asignatura:** Estructuras de Datos

**Unidad:** 2 - Recursividad

**Proyecto:** LaberintoRecursivo
