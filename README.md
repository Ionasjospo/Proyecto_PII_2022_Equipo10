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
El desafio más dificil de esta primera parte, fue el hecho de crar el diagrama UML sin tener codigo previsto. Tambien aplicar patrones fue una tarea complicada ya que hubo mucho espacio de discusión  y cambios entre nosotros. <p/></br>
Cada integrante debia agregó una funcionalidad extra para sumar al proyecto, las cuáles fueron aceptadas por el cliente(los profesores), estas son:
</br>
<p>
<h2>Funcionalidad extra de Ionas</h2>
Desde el principio estaba preocupado por como mejorar las respuestas del chatbot para que no sean simples matrices con letras y números. Pensó que el usuario podria enviar al chatbot las posiciones de los barcos para que el mismo posteriormente le responda con una imagen con los barcos colocados. Pareciá complicado de realizarlo pero investigó y encontro la libreria <a href = "#MagickImage"> MagickImage</a> la cual se implenta gracias a <a href="#NuGet">NuGet</a>  tiene un clase con un método para superponer imagenes. 
</br>
</br>
<img src= "Docs\Colocacion.jpeg">
<p/>
</br>    
<p>
<h2>Funcionalidad extra de Ricardo</h2>
Se va implementar una modalidad para que los jugadores mientras estan combatiendo puedan enviar mensajes entre si, esto produce una mayor interaccion entre jugadores y un enfrentamiento mas entretenido 
<p/>
<br>    
<p>
<h2>Funcionalidad extra de Gonzalo</h2>
<p>
Lo que se va a implementar en este grupo ademas de los requisitos de la letra planteada es tener una modalidad 2vs2. Esto consiste en poder generar un enfrentamiento de manera que 4 usuarios puedan combatir en equipos de a 2.
Esto genera una mayor complejidad al bot y una gran experiencia para los jugadores.
<p/>
<br>
<p>  
<h2>Funcionalidad extra de Christopher</h2>
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
<p></br></br></p>
<h1> Hito 2 (21 de junio)</h1>

<p>

En esta segunda entrega nos encontramos con nuevos desafios por delante. Comenzamos repartiendo las clases y responsabilidades que cada integrante debería hacer antes de una fecha previamente planeada. A medida que fuimos avanzando en nuetro programa encontramos clases nuevas que no estaban planeadas anteriormente. Como anticipamos en la primera parte, el diagrama uml cambió bastante ya que encontramos nuevas clases que eran necesarias. Para esta entrega priorizamos la lógica del juego y por ahora no implementamos nada del bot de Telegram. 
Con respecto a las funcionalidades extras de cada integrante: 
</p> <br>

<h2> Funcionalidades nuevas</h2>
<h3>Mostrar imagen del tablero</h3> 
Decidimos que las imagenes se vayan creando en simultaneo a medida que el jugador va colocando sus buques de guerra o sus bombas en su tablero. Todo iba genial hasta que comenzamos a 'testear' nuestro programa. Nos encontramos con un error que era que desde 'Library.Test' no nos reconocia el path de las imagenes que estaban dentro del repositorio. La única solución que encontramos hasta ahora es guardar las imagenes en nuestras computadoras, hay que seguir este <a href=#RutaImagenes>procedimiento</a>. <br>
<br>
<h3>Modalidad 2vs2 </h3>
La modalidad 2vs2 se implementó correctamente a pesar que parecia complicada, ofrece una mayor libertad al usurio y más diversion a los usuarios ya que pueden jugar con amigos al mismo tiempo juntos!.<br>
<h3>Chat entre jugadores</h3>
Como en esta entrega no hicimos uso del bot esta funcionalidad se vió opacada pero para la proxima entrega va a estar implementada y los jugadores serán capaz de hablar entre ellos <br>
<h3>Bomba especial</h3>
Ofrece una funcionalidad distinta y genera competitividad entre los usuario, ya que estos van a querer ganar para que se le sume al contador de victorias para que cuando acumulen 5 victorias tengan la super bomba que es una gran ventaja frente al rival. 
Se cumplió con ella y se implemento correctamente.
<br>
<br>
<h2> Concluciones</h2>  
El desafio más dificil de esta entrega fue el hecho de respetar y utilizar los principios y patrones dados en clase.</br> 
</br>
Otra situación que se nos dificultó fueron los Unit Test, si bien realizarlos no son muy complicados, dejamos para ultimo momento ya que queriamos terminar la parte logica, y esto pudo haber sido un error.</br>
</br>
Nos hace falta trabajar con el bot de Telegram para para concluir con algunas funcionalidad, además de asignarle un ID correspondiente a cada Usuario.
</p></br></p>
<h3>Ejección de TEST</h3>
<p>Los TEST correspondiente a los siguientes archivos deben ejecutarse de a uno, pues generan error en caso de ejecutarse en a la misma vez:</br>
- JoinMatchTest</br>
- UserTest</br>
</p>
<p></br></br></p>

<h1> Hito 3 (5 de julio)</h1>
<p>
<p>La entrega final fue la más divertida porque comenzamos a poder vizualizar el trabajo que habiamos hecho. 

En esta ultima parte, debido a que empezamos a interactuar con el bot directamente, pudimos observar que el core del programa se implementaba bien en el bot, y no fue tan complicado crear la mayoria de los handlers ya que teniamos todos los metodos necesarios.

Respecto a las funcionalidades extras negociadas con el cliente:

Las funcionalidades extras nos permitio ser creativos y experimentar con ciertos temas, en nuestro caso se presentaron las ideas de un ataque especial, una forma de juego alternativa, un chat entre jugadores y la presentacion del juego atraves de imagenes generadas por nosotros

Chat: Fue más complicado de lo que nos parecio al principio, pero finalmente logramos implementarla. Ofrece libertad a los jugadores para poder hablar entre ellos 
 
Imagenes: Ofrece una elegante ayuda visual al usuario y es algo que nos distingue de la competencia en el mercado. 

2vs2:
La modalidad 2 vs 2 fue todo un reto, se pudo implementar pero no se desarrollo un handler para que 4 usuarios jueguen a la vez, no por dificultad si no por tiempo, 
ya que como se menciono anteriormente se priorizaron otras fucionalidades.

Bomba Especial:
La bomba especial se pudo implementar de forma exitosa y funcional pero no se mostro en el bot, ya que ya habiamos implementado una forma de atacar y esto conllevaba 
mas modificaciones.



Aspectos de la entrega que nos hubieran gustado desarrollar mas:

Como en el anterior hito se nos presentaron problemas a la hora de realizar los Unit test, mas especificamente los test con los handlers, pero al final se pudieron llevar a cabo correctamente.


Mas haya del resultado final, desde un principio aspirabamos a mucho, esto resulto ser un inconveniente a la hora de desarrollar aspectos de mayor prioridad,
Se pudo realizar todas las funcionalidades extras a nivel logico, luego a vincularnos con el bot, estas no pudieron ser efectuadas, ya que conllevaron mas tiempo
de lo estipulado.

<p>
<br>
<h2> Conclusiones</h2>  
<p>
<p>Como conclusiones del proyecto, la propuesta estuvo muy buena y nos motivo a trabajar en ella. En lineas generales debimos aprender a trabajar constantemente y no dejar todo para el ultimo día como nos sucedio.





<p></br></br></p>

<h2>Notas IMPORTANTES a tener en cuenta</h2>
<h3><a name = "RutaImagenes">Ruta de imágenes</a></h3>
<p>Hemos encontrado que la ejecución de los TEST no toman correctamente el ruta de las imagenes indicándolo con referencia relativa, (aunque funcione correctamente desde program) por lo que fue necesario aplicarlas con referencias absolutas.</br>
Por lo tanto, antes de comenzar a trabajar con este programa, es necesario cargar las imagenes con el siguiente procedimiento:</br>
- Copiar la carpeta "\src\Library\Images".</br>
- Pegar esta carpeta en "C:\".</br>
De esta forma que queda una carpeta:</br>
- "C:\Images\" con las imágenes correspondientes a los barcos y el tablero original del juego.</br>
- también queda "C:\Images\CombinedImages\" donde aparecerán las imágenes del tablero modificado a medida se avanza la batalla.</br>
</p>

<p></br></br></p>

<h1>Apendice</h1>

<h2> Patrones</h2>
<p>
Los patrones utilizados se encuentran en el PDF correspondiente dentro de la carpeta "\doc".

<h2><a name="NuGet">NuGet</a></h2>
Aprendimos a usar la herramienta <a href="https://docs.microsoft.com/en-us/nuget/what-is-nuget">NuGet </a>(lo aprendimos nosotros y fue muy satisfactorio) que es el manejador oficial de paquetes de .NET y .NET Core. Un paquete es una libreria compilada que nos permiten utilizar funcionalidades extras a nuestro proyecto. Quizas Nuget, en las proximas entregas nos sea realmente útil.

<h2><a href="https://github.com/dlemstra/Magick.NET.git" name="MagickImage">MagickImage</a></h2>
Es una libreria gratuita para manejar imagenes con una alta calidad. Tiene muchisimas funcionalidades que pueden ser util, como por ejemplo, superponer imagenes, cambiar el tamaño de estas, crear gif, entre otras muchas más. Para usar esta libreria necesitas instalarte la extension de Nuget en visual studio code. Luego dentro de ella buscar "Magick Image" e instalar el paquete.

<h2>Imagenes</h2> 
La imagenes fueron creadas por nosotros con los programas Adobe Illustrator y Adobe Photoshop. Se tomó como referencia imagenes de buques de guerra en google. 

<h2>Fuentes</h2>
Las principales fuentes utilizadas fueron del libro UML y Patrones Optimizado de Craig Larman. Para los patrones una fuente muy util fue <a href="https://refactoring.guru/es">RefactoringGuru</a>. Ademas de los conocimientos aprendidos de clase y sus repositorios con código de ejemplo.
