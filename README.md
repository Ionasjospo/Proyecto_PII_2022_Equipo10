# Proyecto_PII_2022_Equipo10

# Universidad Católica del Uruguay
<img src="https://ucu.edu.uy/sites/all/themes/univer/logo.png">

## Facultad de Ingeniería y Tecnologías
### Programación II

## Proyecto 2022 - Primer Semestre - [Batalla naval (juego)](https://es.wikipedia.org/wiki/Batalla_naval_(juego)).

<img src= "Docs\batallaV2.png">


## Equipo 10
### Integrantes:

    - Ricardo Castro
    - Gonzalo DaSilva
    - Ionas Josponis
    - Christopher Bentancor

## Hito 01 (26 de mayo)
---
<p>Cuando lanzaron la consigna del proyecto, la batalla naval, nos parecio una buena y motivadora idea para que aprendamos. El hecho de crear un juego, y conectar a los usuarios por un chatbot realmente nos gusto porque quizas se asemeja a lo que pensamos cuando empezamos a programar. 
Al principio, pensamos que era muy complicado para estudiantes de primer año de ingenieria informatica desarollar un juego desde cero, pero conforme que empezamos a trabajar y aprender sobre el diagramado de clases, principios, patrones y sus respectivos ejemplos, esa primera sensación se fue desvaneciendo. 
Nuestra metodología para trabajar en el proyecto se baso en la prueba y error. Primero pensamos juntos que clases eran las más importantes y necesarias. Utilizamos la herramienta <a href="https://trello.com/b/9FXnZtpb/proyectopii2022equipo10">Trello</a> para organizarnos mejor y asignarnos tareas para cada integrante del equipo. Respecto a los diagramas UML, fuimos creando nuevo diagramas cada vez que necesitabamos modificarlo, para tener varias versiones (las cuales estan en el <a href="#doc">Documento</a> ) y poder visualizarlas si fuese necesario, para finalmente tener el diagrama final el cual entregaremos. El diagrama el cual vamos a entregar en el primer hito no va a ser el mismo que para la entrega final, ya que cuando empezemos a desarrollar código, van a surgir nuevas clases y dependencias. Cada vez que creabamos clases en el diagrama pensabamos en que patrones aprendidos en clase podriamos aplicar. Esto nos permitira tener una base para guiarnos a la hora de empezar a programar. 
Para poder diseñar las clases, utilizamos algo similar a un diagrama de interacción, en este caso plasmamos interacciones entre dos usuarios y el sistema, este documento nos ayudó a visualizar cuáles serían las interacciones (desde inicio a fin, con situaciones iterativas y opcionales, permitiendo de esa forma llegar al diagrama de clases creado. Cuando tengamos el feedback del diagrama UML, nos dividiremos las clases a programar para cada integrante del grupo, pondremos una fecha limite para terminarlas y "mergearlas" todas a la rama principal main. 
El desafio más dificil de esta primera parte, fue el hecho de crar el diagrama UML sin tener codigo previsto. Tambien aplicar patrones fue una tarea complicada ya que hubo mucho espacio de discusión  y cambios entre nosotros. <p/><br> 
Cada integrante debia agregó una funcionalidad extra para sumar al proyecto, las cuáles fueron aceptadas por el cliente(los profesores), estas son:
<br>
<p>
    Funcionalidad extra de Ionas:
    <br> 
    Desde el principio estaba preocupado por como mejorar las respuestas del chatbot para que no sean simples matrices con letras y números. Pensó que el usuario podria enviar al chatbot las posiciones de los barcos para que el mismo posteriormente le responda con una imagen con los barcos colocados. Pareciá complicado de realizarlo pero investigó y encontro la libreria <a href = "#MagickImage"> MagickImage<a/> la cual se implenta gracias a <a href="#NuGet">NuGet</a>  tiene un clase con un método para superponer imagenes. <p/>
    <br>    
</p>
    
<p>
    Funcionalidad extra de Ricardo: 
    <br> 
    Ricardo decidio poder crear un chat para los usuarios.
    <br>    
</p>
    
<p>

    Funcionalidad extra de Gonzalo: 
<br> Gonzalo negocio con los profesores poder jugar partidas 2vs2
</p>
 
<p>
    Funcionalidad extra de Christofer:
    Christofer penso en un nuevo tipo de bomba el cual se consigue ganando 5 partidas, la bomba explota más
    <br>
    
</p>


<br> 
<br> 

Reflexionamos que esta entrega quizas es la más pesada, ya que hay que pensar varias veces el diagrama UML. Las proximas entregas seran más interesantes ya que contienen código que es lo que más nos gusta a nosotros, los programadores.
Nos encanto el hecho de usar GitHub, es una herramienta muy util para llevar proyectos de este estilo.

## Anexo
<a name="doc">Documento</a>
<a href="https://docs.google.com/document/d/1Jx9uts9U03fkiUoHpgJhPRXCghwjseM5EBgLrv6mH20/edit?usp=sharing">Documento</a>
<br>
Este documento es para explicar todo lo relacionado nuestro software, agregar cosas que quizas no corresponden en el README.


<a name="NuGet">Nuget</a>
<br>
Aprendimos a usar la herramienta <a href="https://docs.microsoft.com/en-us/nuget/what-is-nuget">NuGet</a>(lo aprendimos nosotros y fue muy satisfactorio) que es el manejador oficial de paquetes de .NET y .NET Core. Un paquete es una libreria compilada que nos permiten utilizar funcionalidades extras a nuestro proyecto. Quizas Nuget, en las proximas entregas nos sea realmente útil.

<a name="MagickImage">MagickImage</a>
<br><a href="https://github.com/dlemstra/Magick.NET.git">MagickImage</a> Es una libreria gratuita para manejar imagenes con una alta calidad. Tiene muchisimas funcionalidades que pueden ser util, como por ejemplo, superponer imagenes, cambiar el tamaño de estas, crear gif, entre otras muchas más 
 
Las principales fuentes utilizadas fueron del libro UML y Patrones Optimizado de Craig Larman. Para los patrones una fuente muy util fue <a href="https://refactoring.guru/es">RefactoringGuru</a>. Ademas de los conocimientos aprendidos de clase y sus repositorios con código de ejemplo.

## Hito 02 (21 de junio)
---
## Hito 03 (5 de julio)
---