# Proyecto_PII_2022_Equipo10

# Universidad Católica del Uruguay
<img src="https://ucu.edu.uy/sites/all/themes/univer/logo.png">

## Facultad de Ingeniería y Tecnologías
### Programación II

## Proyecto 2022 - Primer Semestre - [Batalla naval (juego)](https://es.wikipedia.org/wiki/Batalla_naval_(juego)).

<img src= "Docs\batallaV2.png">


<br> 
<center><h1> Integrantes equipo 10:</h1>
<h2>Ricardo Castro</h3>
<h2>Gonzalo Da Silva</h3>
<h2>Ionas Josponis</h3>
<h2>Christopher Bentancor</h3></center>
  
<br>

<h1> Hito 1 (26 de mayo)</h1>
<p>Cuando lanzaron la consigna del proyecto, la batalla naval, nos parecio una buena y motivadora idea para que aprendamos. El hecho de crear un juego, y conectar a los usuarios por un chatbot realmente nos gusto porque quizas se asemeja a lo que pensamos cuando empezamos a programar. 
Al principio, pensamos que era muy complicado para estudiantes de primer año de ingenieria informatica desarollar un juego desde cero, pero conforme que empezamos a trabajar y aprender sobre el diagramado de clases, principios, patrones y sus respectivos ejemplos, esa primera sensación se fue desvaneciendo. 
Nuestra metodología para trabajar en el proyecto se baso en la prueba y error. Primero pensamos juntos que clases eran las más importantes y necesarias. Utilizamos la herramienta <a href="https://trello.com/b/9FXnZtpb/proyectopii2022equipo10">Trello</a> para organizarnos mejor y asignarnos tareas para cada integrante del equipo. Respecto a los diagramas UML, fuimos creando nuevo diagramas cada vez que necesitabamos modificarlo, para tener varias versiones (las cuales estan en el <a href="#doc">Documento</a> ) y poder visualizarlas si fuese necesario, para finalmente tener el diagrama final el cual entregaremos. El diagrama el cual vamos a entregar en el primer hito no va a ser el mismo que para la entrega final, ya que cuando empezemos a desarrollar código, van a surgir nuevas clases y dependencias. Cada vez que creabamos clases en el diagrama pensabamos en que patrones aprendidos en clase podriamos aplicar. Esto nos permitira tener una base para guiarnos a la hora de empezar a programar. 
Para poder diseñar las clases, utilizamos algo similar a un diagrama de interacción, en este caso plasmamos interacciones entre dos usuarios y el sistema, este documento nos ayudó a visualizar cuáles serían las interacciones (desde inicio a fin, con situaciones iterativas y opcionales, permitiendo de esa forma llegar al diagrama de clases creado. Cuando tengamos el feedback del diagrama UML, nos dividiremos las clases a programar para cada integrante del grupo, pondremos una fecha limite para terminarlas y "mergearlas" todas a la rama principal main. 
El desafio más dificil de esta primera parte, fue el hecho de crar el diagrama UML sin tener codigo previsto. Tambien aplicar patrones fue una tarea complicada ya que hubo mucho espacio de discusión  y cambios entre nosotros. <p/><br> 
Cada integrante debia agregó una funcionalidad extra para sumar al proyecto, las cuáles fueron aceptadas por el cliente(los profesores), estas son:
<br>
<p>
    <b> Funcionalidad extra de Ionas:</b>
    <br> 
    Desde el principio estaba preocupado por como mejorar las respuestas del chatbot para que no sean simples matrices con letras y números. Pensó que el usuario podria enviar al chatbot las posiciones de los barcos para que el mismo posteriormente le responda con una imagen con los barcos colocados. Pareciá complicado de realizarlo pero investigó y encontro la libreria <a href = "#MagickImage"> MagickImage</a> la cual se implenta gracias a <a href="#NuGet">NuGet</a>  tiene un clase con un método para superponer imagenes. 
    <br>
    <br>
    <img src= "Docs\Colocacion.jpeg">
<p/>
    <br>    
    <p> <b> Funcionalidad extra de Ricardo:</b>
    <br>
    Se va implementar una modalidad para que los jugadores mientras estan combatiendo puedan enviar mensajes entre si, esto produce una mayor interaccion entre jugadores y un enfrentamiento mas entretenido 
    <p/>
    <br>    
    <p>
    <b> Funcionalidad extra de Gonzalo:</b>
    <br> 
    Lo que se va a implementar en este grupo ademas de los requisitos de la letra planteada es tener una modalidad 2vs2. Esto consiste en poder generar un enfrentamiento de manera que 4 usuarios puedan combatir en equipos de a 2.
    Esto genera una mayor complejidad al bot y una gran experiencia para los jugadores.
    <p/>
    <br>
    <p>  
    <b> Funcionalidad extra de Christopher:</b>
    <br> 
    Se va a implementar una modalidad que al acumular 5 victorias conseguidas en el juego, el usuario va a recibir un objeto especial.
    Este objeto especial es una bomba que su funcionalidad es que al ser disparada su rango de explosion aumenta a 5 cuadrados formando asi una cruz en el tablero.
    Esto aumenta las posibilidades de darle al blanco y que sea meritorio el hecho de haber conseguido mas victorias en el juego<p/>
    <br>
    <center><img src= "Docs\Bomba.jpeg"></center>
    

    
   </p> 

<br> 
<br> 

Reflexionamos que esta entrega quizas es la más pesada, ya que hay que pensar varias veces el diagrama UML. Las proximas entregas seran más interesantes ya que contienen código que es lo que más nos gusta a nosotros, los programadores.
Nos encanto el hecho de usar GitHub, es una herramienta muy util para llevar proyectos de este estilo.

<h1> Hito 2 (21 de junio)</h1>
poner lo de los conflictos
poner los patrones
preguntar rutas
preguntar cuantos test por posicion
limpieza de cosas al pedo
<p>
    En esta segunda entrega nos encontramos con nuevos desafios por delante. Comenzamos repartiendo las clases y responsabilidades que cada integrante debería hacer antes de una fecha previamente planeada. A medida que fuimos avanzando en nuetro programa encontramos clases nuevas que no estaban planeadas anteriormente. Como anticipamos en la primera parte, el diagrama uml cambió bastante ya que encontramos nuevas clases que eran necesarias. Para esta entrega priorizamos la lógica del juego y por ahora no implementamos nada del bot de Telegram. 
    Con respecto a las funcionalidades extras de cada integrante: 
</p> <br>
        Mostrar imagen del tablero: <br>
        Decidimos que las imagenes se vayan creando en simultaneo a medida que el jugador va colocando sus buques de guerra o sus bombas en su tablero. Todo iba genial hasta que comenzamos a 'testear' nuestro programa. Nos encontramos con un error que era que desde 'Library.Test' no nos reconocia el path de las imagenes que estaban dentro del repositorio. La única solución que encontramos hasta ahora es guardar las imagenes en nuestras computadoras, para poder asi usar rutas absolutas "C:\Images". Para poder usar los test deberas crear una carpeta en el disco local C: llamada Images ("C:\Images") donde contengan nuestras imagenes. <br>
        <br>Modalidad 2vs2: <br>
        La modalidad 2vs2 se implementó correctamente a pesar que parecia complicada, ofrece una mayor libertad al usurio y más diversion a los usuarios ya que pueden jugar con amigos al mismo tiempo juntos!.<br>
        <br>Chat entre jugadores: <br>
        Como en esta entrega no hicimos uso del bot esta funcionalidad se vió opacada pero para la proxima entrega va a estar implementada y los jugadores serán capaz de hablar entre ellos <br>
        <br>Bomba especial: <br>
        Ofrece una funcionalidad distinta y genera competitividad entre los usuario, ya que estos van a querer ganar para que se le sume al contador de victorias para que cuando acumulen 5 victorias tengan la super bomba que es una gran ventaja frente al rival. 
        Se cumplió con ella y se implemento correctamente. <br>     
El desafio más dificil de esta entrega fue el hecho de respetar y utilizar los principios y patrones dados en clase. Otra cosa que se nos dificultó fueron los Unit Test, si bien realizarlos no son muy complicados, dejamos para ultimo momento ya que queriamos terminar la parte logica y eso fue un error. 
plabras claves nueva y investigamos a fondo algunas

<h1>Anexo</h1>
Documento:<br>
Este Documento es para explicar todo lo relacionado nuestro software, agregar cosas que quizas no corresponden en el README.


<a name="NuGet">NuGet:</a>
<br>
Aprendimos a usar la herramienta <a href="https://docs.microsoft.com/en-us/nuget/what-is-nuget">NuGet </a>(lo aprendimos nosotros y fue muy satisfactorio) que es el manejador oficial de paquetes de .NET y .NET Core. Un paquete es una libreria compilada que nos permiten utilizar funcionalidades extras a nuestro proyecto. Quizas Nuget, en las proximas entregas nos sea realmente útil.

<a href="https://github.com/dlemstra/Magick.NET.git" name="MagickImage">MagickImage:</a>
<br>
Es una libreria gratuita para manejar imagenes con una alta calidad. Tiene muchisimas funcionalidades que pueden ser util, como por ejemplo, superponer imagenes, cambiar el tamaño de estas, crear gif, entre otras muchas más. Para usar esta libreria necesitas instalarte la extension de Nuget en visual studio code. Luego dentro de ella buscar "Magick Image" e instalar el paquete.

Imagenes: La imagenes fueron creadas por nosotros con los programas Adobe Illustrator y Adobe Photoshop. Se tomó como referencia imagenes de buques de guerra en google. 
 
Las principales fuentes utilizadas fueron del libro UML y Patrones Optimizado de Craig Larman. Para los patrones una fuente muy util fue <a href="https://refactoring.guru/es">RefactoringGuru</a>. Ademas de los conocimientos aprendidos de clase y sus repositorios con código de ejemplo.

 



<h1> Hito 3 (5 de julio)</h1>