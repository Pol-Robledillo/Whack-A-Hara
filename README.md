# Whack-A-Hara

En este repositorio se encuentra el Proyecto 1 del segundo año de DAMv en el Instituto Tecnológico de Barcelona del equipo Todo Al Rojo.

## Descripción del proyecto

En este proyecto tenemos como objetivo desarrollar un prototipo de juego que ayude a detectar el daltonismo. Para ello hemos investigado los diferentes tipos de daltonismo que existen, las formas que hay actualmente de detectar el daltonismo y las combinaciones de colores que se usan en los tests. Con esto hemos sido capaces de trasladar el test de Ishihara a una idea gamificada de test.

### Documentación
- [Documentación sobre daltonismo](https://docs.google.com/document/d/1rUloU6iC5ZZ8AF271Kn5ATTJiayniCXy2d3W1Tua7Kc/edit?usp=sharing)
- [Guía de estilos](https://docs.google.com/document/d/1GnE_0E84Sk9iOk6OEpGW-ho_ddcWyVczH7baiDo_wUE/edit?usp=sharing)

## Nuestro juego

La idea que hemos desarrollado es juntar el clásico mata topos con el test de Ishihara. Los topos irán apareciendo en pantalla y el jugador deberá golpear a aquellos que sean del color correspondiente. A medida que el juego avance, las combinaciones de colores cambiaran para poder poner a prueba los diferentes tipos de daltonismo. Para que el juego sea capaz de medir la severidad, tendremos diferentes niveles de colores que serán más o menos difíciles de diferenciar para un daltónico.

### Esquemas
- [Wireframe para el videojuego](https://www.figma.com/design/eVLZ8N815d3DshVDXGYZlJ/WireFrame_WhackAHara?node-id=0-1&t=4dZ0wU0cA8BsdqMu-1)
- [UML](https://drive.google.com/file/d/1XSSzMD1h5LHBmjE0xDLkk-9_ODv5BncK/view?usp=sharing)
- [Diagrama de escenas](https://www.canva.com/design/DAGUlQ0U0Do/Dr2J10S32qzlvlbED1L-sw/edit?utm_content=DAGUlQ0U0Do&utm_campaign=designshare&utm_medium=link2&utm_source=sharebutton)

## Contenido
- [Proyecto Unity](https://github.com/Pol-Robledillo/Whack-A-Hara/tree/main/Whack-A-Hara)
    - [Scripts](https://github.com/Pol-Robledillo/Whack-A-Hara/tree/main/Whack-A-Hara/Assets/Scripts)
    - [Sprites](https://github.com/Pol-Robledillo/Whack-A-Hara/tree/main/Whack-A-Hara/Assets/Sprites)
    - [Audios](https://github.com/Pol-Robledillo/Whack-A-Hara/tree/main/Whack-A-Hara/Assets/Audio)

## Sistema de puntuación

Al finalizar las rondas del juego, aparece una pantalla con una recomendación según tu índice de daltonismo. Pero, ¿cómo se ha hecho?
- Al inicio de cada ronda, se te indicará qué color es el que tienes que golpear. En cada ronda, el topo correcto sumará puntos. Otro topo es de color parecido, el cual resta una pequeña parte de puntuación. Por último, un topo será muy distinto a ojos de una persona sin daltonismo, pero si lo golpeas te restará una gran cantidad de puntos.
- La ronda 1 es una prueba, con colores rojos, azules y verdes puros para comprobar cuál es tu nivel de juego. De esta forma, podemos evaluar tu resultado independientemente de qué tan bueno seas en el mata topos.
- A partir de la ronda 2 es cuando empieza la prueba. Cada una de las distintas rondas valorará un distinto tipo de daltonismo.
- En la pantalla final se te darán los resultados, comparando cada una de las rondas con cuánta puntuación sacaste en la ronda 1. Tras eso, se hará un diagnóstico:
    - Si la diferencia de puntuación es muy baja, lo más probable es que no tengas daltonismo.
    - Si la diferencia es considerable, pero no muy alta, probablemente tengas cierto grado. Podrías ir a ver a un óptico para que te diga si es así o no.
    - Si, en cambio, la diferencia es muy alta, es muy probable que tengas un alto grado de daltonismo. Es recomendable ir a ver a un profesional para confirmarlo.

## Equipo
**Pol Robledillo**:    Unity Developer, Game Designer  
- Email: pol.robledillo.7e7@itb.cat  
- GitHub: [Pol-Robledillo](https://github.com/Pol-Robledillo)  

**Jan España**:       Game Designer, Diseñador 2D  
- Email: jan.espana.7e7@itb.cat  
- GitHub: [JanEspana](https://github.com/JanEspana)  

**Marta Alarcón**:    Diseñadora 2D, Unity UI  
- Email: marta.alarcon.7e7@itb.cat  
- GitHub: [MartaAlarcon](https://github.com/MartaAlarcon)  

**Raul Palomo**:      Scrum Master  
- Email: raul.palomo.7e7@itb.cat  
- GitHub: [RaulPalomo](https://github.com/RaulPalomo)  
