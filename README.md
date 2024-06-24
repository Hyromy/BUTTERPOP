*`documento sujeto a cambios`*

<!-- 
si estas leyendo esto por favor instala la siguiente extencion:
ve a la seccion extenciones y busca "GitHub Markdown Preview" v0.3.0 o posterior

si vas a realizar algun cambio en el documento hazlo en una sub-rama de doc
seguido de un nombre general de lo que vayas a hacer. ejemplo:

git switch doc
git branch doc_ortografia
git switch doc_ortografia

las cosas que vayas a hacer marcalas con una "x" o "X" de esta manera
- [x] Nombre de la actividad

para indicar que esa actividad esta en proceso
cuando hayas terminado elimina la linea que acabas de marcar

esto con la finalidad de:
saber que actividades aun no se realizan (- [ ])
saber que actividades estan en desarrollo (- [x])
saber que actividades fueron completadas (eliminar la actividad de la lista)

es importante que los cambios que vayas a hacer en la documentacion sean identicos
entre este archivo README.md y el documento word,
ya que esto facilita la deteccion de cambios en el documento

en caso de que detectes alguna inconcistencia en el documento
puedes agregar ese punto en esta lista de pendientes
para que tu o alguien mas lo resuelva posteriormente

cuando quieras comitear tus cambios, guarda y cierra el documento word,
escribe git status, en la terminal deben de aparecer este archivo .md
y el documento word en rojo (solo deben de aparecer esos 2)
posteriormente agrega un nombre al commit, no debe de ser ambiguio
pero si tiene que ser general, y resumir muy brevemente que fue lo que hiciste
ejemplo:

git status
git add .
git commit -m "correciones ortograficas en resumen, abstact e introduccion"

posteriormente tendras la opcion de:
subir tu rama (git push -u origin tu_rama)
importar los cambios a la rama doc (git switch doc    ->    git merge tu_rama)
o continuar haciendo correciones.

Gracias por tu atencion y paciencia, tqm
-->

### Cambios pendientes por realizar
#### Figuras
- [x] Agregar una introducción a cada figura
- [ ] Agregar cuadro te texto de figura a los diccionarios de datos 
- [ ] Agregar figuras a cada tabla del plan de pruebas
- [ ] Reordenar las interfaces (maquetas) en doc

#### Diagramas de secuencia
- [ ] Agregar diagrama "Gestionar película" en README
- [ ] Agregar diagrama "Gestionar película" en DOC

#### Diagrama de actividades
- [ ] Corregir diagrama de actividades

#### Diagrama de base de datos
- [ ] Agregar modelo de base de datos en README
- [ ] Agregar modelo de base de datos en DOC

#### Diseño de pruebas
- [ ] Realizar diseño de pruebas de "crear lista" en README
- [ ] Realizar diseño de pruebas de "crear lista" en DOC
- [ ] Realizar diseño de pruebas de "actualizar lista" en README
- [ ] Realizar diseño de pruebas de "actualizar lista" en DOC
- [ ] Realizar diseño de pruebas de "gestionar pelicula" en README
- [ ] Realizar diseño de pruebas de "gestionar pelicula" en DOC

---

![uttec](img_doc/general/uttec.jpg)

# BUTTERPOP - DIGITAL DREAM<br>INTEGRAGORA II<br>REPORTE TÉCNICO

### PARA OBTENER EL TÍTULO DE
### TÉCNICO SUPERIOR UNIVERSITARIO EN TECNOLOGÍAS DE LA INFORMACIÓN ÁREA DESARROLLO DE SOFTWARE MULTIPLATAFORMA

*P R E S E N T A*

**ANDREA DOMÍNGEZ ZENTENO**<br>
**EMANUEL GARCIA CAPOTE**<br>
**JESÚS MÍGUEL ROSALES MURILLO**<br>
**JOEL GONZÁLEZ CRUZ**<br>
**JOSÉ JULÁN MARTÍNEZ DE LA CRUZ**<br>

ASESORA DE LA ORGANIZACIÓN: DRA. MORAMAY RAMÍREZ HERNÁNDEZ<br>
ASESORA ACADÉMICA: LDA. SANDRA RAQUEL LÓPEZ ARCE SOROA<br>
ORGANIZACIÓN: "DIGITAL DREAM S.A. DE C.V."<br>
GENERACIÓN: ENERO 2023-DICIEMBRE 2024<br>
CUATRIMESTRE DE TÉRMINO: SEPTIEMBRE-DICIEMBRE 2024 

---

## ÍNDICE
- [RESUMEN](#resumen)
- [ABSTRACT](#abstract)
- [INTRODUCCIÓN](#introducción)
- [OBJETIVOS](#objetivos)
- [PROGRAMA Y CRONOGRAMA](#programa-y-cronograma)
- [MARCO TEÓRICO](#marco-teórico)
- [METODOLOGÍA](#metodología)
- [CAPÍTULO 1 RECOLECCIÓN Y REFINAMIENTO DE REQUISITOS](#capítulo-1-recolección-y-refinamiento-de-requisitos)
    - [Necesidades del cliente](#11-nececidades-del-cliente)
    - [Identificación y definición de roles de usuario](#12-identificación-y-definición-de-roles-de-usuario)
    - [Requerimientos funcionales](#13-requerimientos-funcionales)
    - [Requerimientos no funcionales](#14-requerimientos-no-funcionales)
    - [Requerimientos de hardware](#15-requerimientos-de-hardware)
    - [Requerimientos de software](#16-requerimientos-de-software)
    - [Diagrama general de casos de uso](#17-diagrama-general-de-casos-de-uso)
    - [Especificación de los casos de uso](#18-especificación-de-los-casos-de-uso)
    - [Diagramas de secuencia](#19-diagramas-de-secuencia)
    - [Diagrama de actividades](#110-diagrama-de-actividades)
- [CAPÍTULO 2 DISEÑO Y DESARROLLO DEL PROYECTO](#capítulo-2-diseño-y-desarrollo-del-proyecto)
    - [Diagrama de la base de datos (relacional)](#21-diagrama-de-la-base-de-datos-relacional)
    - [Diccionario de datos](#22-diccionario-de-datos)
    - [Diseño de pruebas](#23-diseño-de-pruebas)
    - [Diseño de las interfaces (maquetas)](#24-diseño-de-las-interfaces-maquetas)

## RESUMEN

## ABSTRACT

## INTRODUCCIÓN
Cinemas AJEM será una empresa mexicana líder en entretenimiento dedicada al desarrollo y operación de complejos múltiples de exhibición cinematográfica. Con más de 23 años en el mercado, se posicionará en el top 10 de las mejores cadenas cinematográficas del mundo, contando con 335 complejos y 2,898 pantallas en 98 ciudades de la República Mexicana.

El departamento de ventas de Cinemas AJEM se encargará no solo del manejo y control de todas las ventas registradas dentro del cine, sino que también participará en diversas actividades con el objetivo de promover la compra de sus servicios y productos por parte de los clientes, tales como la venta de comida, boletería, dulcería, etc.

Respecto a estas operaciones, existirá un problema relacionado al apartado de boletería, ya que con la llegada de las plataformas de streaming, su público fuente, prefiere ver películas vía online en lugar de acudir al cine, lo que reduce considerablemente sus ventas.

Basándose en este problema surgirá la necesidad de incrementar sus ventas por medio de una aplicación multiplataforma amigable, segura, estable y fácil de usar que permitirá a los usuarios, que no lograron ver la película en su momento, o que prefieran volver a disfrutar de ella desde la comodidad de su casa, la compra/renta de las películas disponibles en su cartelera.

La implementación de esta aplicación podría aumentar considerablemente las ventas de las proyecciones del cine, ya que, además de permitir la compra/renta de películas de manera fácil para los usuarios, también brindará una experiencia única a los clientes permitiéndoles opinar, organizar sus películas en listas de reproducción, además les permitirá acumular puntos para canjearlos por cupones o descuentos, motivando así una visita próxima a sus sucursales.

Debido a la necesidad mencionada anteriormente, la participación de desarrolladores técnicos universitarios en el área de desarrollo de software multiplataforma de la Universidad Tecnológica de Tecámac será la adecuada, ya que poseerán los conocimientos necesarios en diseño, codificación, almacenamiento y manejo de datos para desarrollar la aplicación de manera efectiva y brindar una solución a la reducción de ventas del cine.

El presente documento tendrá como objetivo mostrar, explicar y analizar el proceso de realización de la app. Estará dividido en tres capítulos de gran importancia, ya que cada uno proporcionará información detallada sobre cómo se desarrollará la aplicación multiplataforma.

El capítulo uno se enfocará en la recolección y refinamiento de los requisitos sugeridos por el cliente. Esto incluirá identificar y comprender sus necesidades, establecer los roles de usuario para la aplicación y definir los requerimientos funcionales y no funcionales del sistema. Esta sección servirá como base para determinar los requerimientos de software y hardware necesarios para la realización de la aplicación. Además, se presentarán los diagramas de caso de uso, secuencia y actividad para visualizar el funcionamiento del sistema y la interacción de los usuarios con cada una de las actividades de este.

En el capítulo dos se abordará el diseño y desarrollo del proyecto. Aquí se diseñará la base de datos con las tablas necesarias para gestionar cada parte del sistema, como películas, clientes, listas, etc. También se creará un diccionario de datos y se diseñarán las pruebas necesarias para asegurar el correcto funcionamiento de la aplicación. Además, se realizará el maquetado de cada una de las interfaces.

Finalmente, el capítulo tres se centrará en la implementación y pruebas de la aplicación. Se documentará todo lo relacionado con las interfaces diseñadas en el capítulo dos y se llevarán a cabo las pruebas para garantizar el funcionamiento adecuado del sistema.

## OBJETIVOS
### Objetivo general
Desarrollar una aplicación multiplataforma innovadora, amigable, segura e intuitiva que permita a los clientes de Cinemas AJEM comprar y rentar las películas más recientes de su cartelera desde la comodidad de sus hogares. La aplicación proporcionará una experiencia de usuario única al ofrecer funcionalidades como la creación de listas de reproducción, acumulación de puntos para descuentos, y la opción de dejar opiniones sobre las películas. Con el objetivo de revertir la tendencia a la baja en ventas debido a la popularidad de las plataformas de streaming, esta aplicación se posicionará como una solución integral para incrementar significativamente las ventas del cine y atraer a los usuarios que no lograron ver las películas en el cine o desean volver a disfrutar de ellas en cualquier momento durante el período de renta.

### Objetivos específicos
- Realizar la base de datos que almacene la información relacionada con los administradores, clientes y el catálogo de películas, lo cual será fundamental para la codificación y elaboración de las interfaces.
- Diseñar las interfaces de los administradores y clientes con un diseño práctico y atractivo, para posteriormente llevar a cabo las pruebas.
- Probar la funcionalidad de las interfaces y registrar los errores que puedan ocurrir, con el objetivo de solucionarlos rápidamente y entregar un trabajo de calidad.

## PROGRAMA Y CRONOGRAMA
| **UNIVERSIDAD TECNOLÓGICA DE TECÁMAC DIVISIÓN TIC PROGRAMA DE ESTADÍAS PROFESIONALES** | ![uttect](img_doc/general/uttec.jpg) |
| - | - |
| **PROGRAMA DE TRABAJO** | *FECHA: dd/mm/aaaa* |

### DATOS DEL O DE LA ESTUDIANTE
| NOMBRE: | Domínguez Zenteno Andrea<br>Garcia Capote Emanuel<br>González Cruz Joel<br>Martínez de la Cruz José Julián<br>Rosales Murillo Jesús Miguel  |
| - | - |
| DIVISIÓN: | Tecnologías de la Información y Comunicación |
| CARRERA: | Técnico Superior Universitario en Tecnologías de la Información Área Desarrollo de Software Multiplataforma |
| MATRÍCULA: | 2523260004<br>2523260069<br>2523260021<br>2523260022<br>2523260068 |
| GENERACIÓN: | Enero 2023 – Diciembre 2024 |

### ASESORA ACADÉMICA
| NOMBRE: | Sandra Raquel López Arce Soroa |
| - | - |
| CARGO: | Profesora de Asignatura |

### DATOS DE LA ORGANIZACIÓN
| NOMBRE DE LA ORGANIZACIÓN: | Universidad Tecnológica de Tecámac |
| - | - |
| DEPARTAMENTO: | Tecnologías de la Información y Comunicación |
| ÁREA: | Desarrollo de Software Multiplataforma |
| DIRECCIÓN: | Carretera Federal México – Pachuca Km 37.5, 55749 Estado de México |
| TELÉFONO: | 55 6499 7632 |
| E-MAIL: | ditc@uttecamac.edu.mx |

### AESESORA DE LA ORGANIZACIÓN
| NOMBRE: | Moramay Ramírez Hernández |
| - | - |
| CARGO: | Profesora de Tiempo Completo |

### PERÍODO
| DURACIÓN: | 15 semanas |
| - | - |
| FECHA DE INICIO: | 01 de mayo de 2024 |
| FECHA DE TERMINACIÓN: | 15 de agosto de 2024 |
| HORARIO: | 10:00 am a 6:00 pm |

### PROYECTO
| NOMBRE: | BUTTERPOP |
| - | - | 
| DESCRIPCIÓN: | El presente proyecto consiste en la elaboración de una aplicación multiplataforma que sea auxiliar a la empresa Cinemas AJEM, con el fin de incrementar sus ventas y sea de alternativa a los clientes como una forma de ver películas en estreno. |
| OBJETIVO GENERAL: | Desarrollar una aplicación multiplataforma innovadora, amigable, segura e intuitiva que permita a los clientes de Cinemas AJEM comprar y rentar las películas más recientes de su cartelera desde la comodidad de sus hogares. La aplicación proporcionará una experiencia de usuario única al ofrecer funcionalidades como la creación de listas de reproducción, acumulación de puntos para descuentos, y la opción de dejar opiniones sobre las películas. Con el objetivo de revertir la tendencia a la baja en ventas debido a la popularidad de las plataformas de streaming, esta aplicación se posicionará como una solución integral para incrementar significativamente las ventas del cine y atraer a los usuarios que no lograron ver las películas en el cine o desean volver a disfrutar de ellas en cualquier momento durante el período de renta. |
| OBJETIVOS ESPECÍFICOS: | Realizar la base de datos que almacene la información relacionada con los administradores, clientes y el catálogo de películas, lo cual será fundamental para la codificación y elaboración de las interfaces.<br><br>Diseñar las interfaces de los administradores y clientes con un diseño práctico y atractivo, para posteriormente llevar a cabo las pruebas.<br><br>Probar la funcionalidad de las interfaces y registrar los errores que puedan ocurrir, con el objetivo de solucionarlos rápidamente y entregar un trabajo de calidad. |
| ALCANCE(S): | La aplicación podrá usarla administradores de Cinemas AJEM para la gestión de películas en estreno de temporada. De igual forma será adaptada a los usuarios que quieran una alternativa de rentar y/o comprar películas. |
| META(S): | La aplicación cumplirá en su totalidad con las expectativas del cliente, ayudando a la incrementación de sus ventas. |
| RECURSOS: | **Hardware:** Computadoras, memorias USB y router con conexión a internet.<br>**Software:** Android Studio, Visual Studio, PostgreSQL, Testlink, MantisBT. |

### PLAN DE TRABAJO
<table>
    <tr>
        <td colspan="2" rowspan="2">ACTIVIDAD</td>
        <td rowspan="2">DESCRIPCION</td>
        <td colspan="2">SEMANA</td>
        <td colspan="2">FECHAS</td>
    </tr>
    <tr>
        <td>INICIO</td>
        <td>TERMINO</td>
        <td>INICIO</td>
        <td>TERMINO</td>
    </tr>
    <tr>
        <td>1</td>
        <td></td>
        <td>Recolección de Refinamiento y Requisitos</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>1.1</td>
        <td>Requerimientos del cliente</td>
        <td>1</td>
        <td>1</td>
        <td>07/05/2024</td>
        <td>10/05/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.2</td>
        <td>Especificar el alcance del proyecto</td>
        <td>1</td>
        <td>1</td>
        <td>07/05/2024</td>
        <td>13//05/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.3</td>
        <td>Preparación de Hardware y Software</td>
        <td>1</td>
        <td>1</td>
        <td>07/05/2024</td>
        <td>14/05/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.4</td>
        <td>Especificación de casos de uso</td>
        <td>2</td>
        <td>2</td>
        <td>15/05/2024</td>
        <td>18/05/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.5</td>
        <td>Diagrama de casos de uso</td>
        <td>2</td>
        <td>3</td>
        <td>17/05/2024</td>
        <td>24/05/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.6</td>
        <td>Modelado de base de datos</td>
        <td>3</td>
        <td>4</td>
        <td>27/05/2024</td>
        <td>05/06/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.7</td>
        <td>Programación de aplicación</td>
        <td>5</td>
        <td>8</td>
        <td>10/06/2024</td>
        <td>21/06/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.8</td>
        <td>Diseño de interfaces</td>
        <td>8</td>
        <td>10</td>
        <td>22/06/2024</td>
        <td>06/07/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.9</td>
        <td>Estrategia de avance de proyecto</td>
        <td>13</td>
        <td>13</td>
        <td>07/07/2024</td>
        <td>10/07/2024</td>
    </tr>
    <tr>
        <td></td>
        <td>1.10</td>
        <td>Implementación y pruebas</td>
        <td>13</td>
        <td>14</td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td></td>
        <td>1.11</td>
        <td>Entrega de documentación final</td>
        <td>14</td>
        <td>15</td>
        <td></td>
        <td></td>
    </tr>
</table>

### CRONOGRAMA DE ACTIVIDADES (PROGRAMA)
<table>
    <tr>
        <td rowspan="2">#</td>
        <td rowspan="2">ACTIVIDADES</td>
        <td rowspan="2">CONTROL</td>
        <td colspan="5">Mes 1</td>
        <td colspan="4">Mes 2</td>
        <td colspan="4">Mes 3</td>
        <td colspan="2">Mes 4</td>
    </tr>
    <tr>
        <td>1</td>
        <td>2</td>
        <td>3</td>
        <td>4</td>
        <td>5</td>
        <td>6</td>
        <td>7</td>
        <td>8</td>
        <td>9</td>
        <td>10</td>
        <td>11</td>
        <td>12</td>
        <td>13</td>
        <td>14</td>
        <td>15</td>
    </tr>
    <tr>
        <td rowspan="2">1</td>
        <td rowspan="2">Exploración</td>
        <td>PROG.</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>REAL</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td rowspan="2">2</td>
        <td rowspan="2">Iniciación</td>
        <td>PROG.</td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>REAL</td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td rowspan="2">3</td>
        <td rowspan="2">Producto</td>
        <td>PROG.</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>REAL</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td rowspan="2">4</td>
        <td rowspan="2">Estabilización</td>
        <td>PROG.</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td>REAL</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
        <td></td>
        <td></td>
        <td></td>
    </tr>
    <tr>
        <td rowspan="2">5</td>
        <td rowspan="2">Pruebas</td>
        <td>PROG.</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
    </tr>
    <tr>
        <td>REAL</td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td>X</td>
        <td>X</td>
        <td>X</td>
    </tr>
</table>

### FIRMAS
<table>
    <tr>
        <td colspan="2">
            Dra. Moramay Ramírez Hernández<br>
            <em>ASESORA DE LA ORGANIZACIÓN</em>
        </td>
    </tr>
    <tr>
        <td>
            Andrea Domínguez Zenteno<br>
            Emanuel Garcia Capote<br>
            Jesús Miguel Rosales Murillo<br>
            Joel González Cruz<br>
            José Julián Martínez de la Cruz<br> 
            <em>ESTUDIANTE</em>
        </td>
        <td>
            Lda. Sandra Raquel López Arce Soroa 
            <em>ASESORA ACADÉMICA</em>
        </td>
    </tr>
</table>

## MARCO TEÓRICO
Una aplicación multiplataforma es una pieza de software diseñada para funcionar en múltiples sistemas operativos y dispositivos sin la necesidad de diseñar versiones diferentes para cada plataforma. Esto significa que el mismo código fuente puede ser usado en diferentes entornos, tales como: Android, iOS, Windows, macOS, Linux, entre otros.

En los años 90's, estas aplicaciones surgen como respuesta a la necesidad de las empresas de alcanzar una audiencia más amplia, reducir costos y tiempo de desarrollo. Algunas de las razones por las cuales se usan aplicaciones multiplataforma son:

- **Diversidad de dispositivos y sistemas operativos**<br>
Con la proliferación de dispositivos móviles y una amplia variedad de sistemas operativos, presenta el desafío de desarrollar aplicaciones nativas para cada una de las plataformas, lo que implica disponer de múltiples equipos de desarrollo, lo que significaba mayores costos y cantidad de tiempo para las empresas en desarrollar dicha aplicación para cada plataforma.

- **Eficiencia en el desarrollo**<br>
Desarrollar una aplicación para cada plataforma es costoso, lento e ineficiente. Las aplicaciones multiplataforma permiten escribir un único código fuente y reutilizarlo en múltiples entornos dependiendo de las necesidades y capacidades del dispositivo. Esto acelera en gran medida el desarrollo, facilita el mantenimiento y reduce los costos de la aplicación.

- **Tecnologías web y móviles**<br>
El desarrollo de lenguajes, frameworks y herramientas han hecho posible la creación de aplicaciones eficientes en diversas plataformas. estas tecnologías permiten a los desarrolladores acceder a características nativas de cada sistema operativo con un solo código fuente.

- **Demanda del mercado**<br>
Los consumidores esperan que las aplicaciones estén disponibles en sus dispositivos y estos mismos pueden variar de persona a persona. Las empresas desean llegar a audiencias cada vez más grandes, por lo que necesitan asegurarse de que sus aplicaciones estén disponibles para la mayor cantidad de dispositivos y plataformas posibles para así cumplir con los objetivos planteados por la propia empresa.

Para el desarrollo de este proyecto se utilizarán diversos lenguajes de programación y herramientas de diseño y prueba que permitirán la implementación de la lógica del cliente y las funcionalidades esenciales de la aplicación multiplataforma, entre las cuales se incluyen:

- **Visual Studio**

Microsoft Visual Studio es un entorno de desarrollo integrado (IDE, por sus siglas en inglés) para Windows y macOS. Es compatible con múltiples lenguajes de programación, tales como C++, C#, Fortran, Visual Basic .NET, F#, Java, Python, Ruby y PHP, al igual que entornos de desarrollo web, como ASP.NET MVC, Django, etc.
<br>Se hará uso de este entorno para desarrollar la aplicación, compilar y depurarla.

- **Xamarin**

Es un marco de interfaz de usuario de código abierto. Xamarin.froms permite a los desarrolladores compilar aplicaciones en Xamarin, Android y xamarin.ios y Windows desde un código base compartido. Xamarin.forms permite a los desarrolladores crear interfaces de usuario XAML con código subyacente en C#. Estas interfaces se representan como controles nativos con mejor rendimiento en cada plataforma.
<br>Se utilizará este Framework ya que es requisito que la aplicación sea multiplataforma, usando como entorno de desarrollo Android Studio para posteriormente ser compilada a diversos sistemas operativos móviles de manera sencilla, rápida y eficiente.

- **C#**

Es un lenguaje de programación multiparadigma desarrollado por Microsoft, que evoluciona de la familia de lenguajes C, toma lo mejor de los lenguajes C y C++, los cuales se asemejan mucho a lenguajes de alto nivel de abstracción como Java y JavaScript. Forma parte de la plataforma .NET de Microsoft.
<br>Se usará este lenguaje de programación para desarrollar un código general, el cual posteriormente será compilado por XAMARIN para Android e iOS.

- **XAML**

El lenguaje de marcado de aplicaciones extensible (XAML) es un lenguaje declarativo. En concreto, XAML puede inicializar objetos y establecer propiedades de objetos mediante una estructura de lenguaje que muestra relaciones jerárquicas entre varios objetos y una convención de tipo de respaldo que admite la extensión de tipos. Puedes crear elementos visibles de la interfaz de usuario en el marcado XAML declarativo. A continuación, puedes asociar un archivo de código subyacente distinto para cada archivo XAML que puede responder a eventos y manipular los objetos que originalmente declares en XAML.
<br>Se empleará este lenguaje de marcado para diseñar las interfaces de la aplicación.

- **Git**

Es un sistema de control de versiones distribuido, cada desarrollador tiene una copia integral del mismo. A diferencia de los sistemas de control de versiones centralizados los DVCS necesitan una conexión constante a un repositorio central. Git es un sistema de control de versiones distribuido más popular y se utiliza el desarrollo de proyectos de código abierto.
<br>Se hará uso de esta herramienta para facilitar y agilizar un flujo colaborativo para el equipo, además de mejorar el versionado del proyecto y aumentar la eficiencia de correcciones, implementaciones y reducir tiempos de desarrollo.

- **StarUML**

Es un sofisticado modelador de software destinado a soportar un modelado ágil y conciso.
<br>Se utilizará este programa para modelar diagramas de casos de uso, de secuencia, actividades, entre otros, para sustentar el desarrollo del proyecto.

- **Testlink**

Es un sistema de gestión de pruebas basado en la web que facilita el control de calidad del software. Ofrece soporte para casos de prueba, conjuntos de pruebas, planes de pruebas, proyectos de prueba y gestión de usuarios, así como diversos informes y estadísticas.
<br>Se usará este programa en la fase de pruebas para así garantizar la calidad, funcionabilidad y consistencia de comportamiento del proyecto, para así hacer las respectivas correcciones o robustecer el proyecto o ciertas partes de este.

- **MantisBT**

Es un software que constituye una solución completa para gestionar tareas en un equipo de trabajo. Es una aplicación OpenSource que se utiliza para probar soluciones automatizadas, llevando un registro histórico de las alteraciones y gestionando equipos de trabajo de forma remota.
<br>Se empleará este software para tener un control de las fallas que pueda presentar la aplicación y tener un registro de dichas fallas y como se podrían solucionar.

- **Figma**

Figma es un editor de gráficos vectoriales y una herramienta de generación de prototipos, principalmente basada en la web, con características offline adicionales habilitadas por aplicaciones de escritorio en macOS y Windows. Permite a los diseñadores colaborar en tiempo real, lo cual es ideal para equipos distribuidos geográficamente. Esta herramienta es conocida por su capacidad de mantener un flujo de trabajo eficiente gracias a sus funciones de coedición y comentarios en vivo. Además, Figma soporta la creación de componentes reutilizables, lo que facilita la consistencia en el diseño de la interfaz de usuario.
<br>Se usará este programa para realizar el maquetado del diseño de interfaces.

**`pendientes de confirmación`**<br>
- **JavaScript**

Es un lenguaje de programación ligero, interpretado, de dialecto del estándar ECMAScript con funciones de primera clase. Si bien es más conocido como un lenguaje de secuencias de comandos para páginas web, y es usado en muchos entornos fuera del navegador, es un lenguaje de programación basado en prototipos, multiparadigma, de un solo hilo, dinámico, con soporte para programación orientada a objetos, imperativo, declarativo, débilmente tipado y dinámico. 
<br>Se utilizará este lenguaje del lado del cliente para aportar un mayor dinamismo a la aplicación además de reducir costos de procesamiento y energéticos a o los servidores que se vayan a emplear.

- **JSP**

La tecnología Java Server Pages permite generar contenido Web dinámico como, por ejemplo, archivos HTML, DHTML, XHTML y XML, para incluirlos en una aplicación Web. Los archivos JSP son una forma de implementar contenido de páginas dinámico del lado del servidor. Los archivos JSP permiten a un servidor Web como, por ejemplo, Apache Tomcat, añadir contenido dinámicamente a las páginas HTML antes de enviarlas al navegador que las solicita.
<br>Cuando se despliega un archivo JSP en un servidor Web que proporciona un motor de servlets, se procesa previamente en un servlet que se ejecuta en el servidor. Esto contrasta con JavaScript™ en el lado del cliente (dentro de códigos <\SCRIPT>), que se ejecuta en un navegador. Una página JSP resulta ideal para tareas para tareas cuya ejecución es más adecuada en el servidor como, por ejemplo, acceder a bases de datos.

- **CSS3**

Hojas de Estilo en Cascada (del inglés Cascading Style Sheets) o CSS es el lenguaje de estilos utilizado para describir la presentación de documentos HTML o XML (incluyendo varios lenguajes basados en XML como SVG, MathML o XHTML). CSS describe cómo debe ser renderizado el elemento estructurado en la pantalla, en papel, en el habla o en otros medios. Es muy usado para establecer el diseño visual de los documentos web e interfaces de usuario escritas en HTML La última versión de este lenguaje, CSS3, incrementó significativamente el alcance de las especificaciones y el progreso de los diferentes módulos de CSS comenzó a mostrar varias diferencias, lo que hizo más efectivo desarrollar y publicar recomendaciones separadas por módulos.

- **PHP**

Es un lenguaje de programación de código abierto, ampliamente utilizado por desarrolladores web y es el fundamento de muchas plataformas robustas. Proporciona una forma eficiente y eficaz de desarrollar sitios web dinámicos e interactivos.
<br>Se utilizará este lenguaje en el lado del back-end debido a su tipado dinámico y rápida implementación en el mismo.

- **Node.js**

Es un entorno de ejecución de JavaScript que se utiliza para desarrollar aplicaciones de servidor. Impulsado por el motor V8 de Google, Node.js utiliza un modelo de programación orientado a eventos y entradas/salidas (I/O) no bloqueantes, lo que lo hace ligero y eficiente, perfecto para aplicaciones en tiempo real con intercambio intenso de datos a través de dispositivos distribuidos.
<br>Se utilizará este entorno de ejecución debido a que su sintaxis es idéntica a la de JavaScript por lo que su implementación en el lado del back-end o del servidor será rápida, eficiente y potente.

- **MongoBD**

Es una base de datos de documentos que ofrece una gran escalabilidad y flexibilidad y un modelo de consultas e indexación avanzada. 
<br>Se hará uso de este gestor de base de datos no relacional para poder almacenar grandes volúmenes de datos cuya información no sea sensible.

- **PostgreSQL**

Es potente sistema de base de datos relacional de objetos de código abierto con más de 35 datos de desarrollo activo que le ha ganado una sólida reputación por su confiabilidad solidez de funciones y rendimiento. 
<br>Se empleará este gestor de base de datos relacional para tener un control preciso de aquellos registros que requieran ser protegidos ya que estos pueden presentar información sensible.

## METODOLOGÍA
Dentro del ámbito del desarrollo de aplicaciones móviles, elegir una metodología se toma de gran importancia, debido a que el equipo se puede sincronizar y planificar las fases del proyecto con mayor facilidad.

La metodología implementada a este proyecto es Mobile-D dada la preferencia en aplicaciones móviles y que está enfocada a equipos de menor tamaño para lograr ciclos de desarrollo muy rápidos. En el proyecto, es conveniente tener este tipo de metodología ágil para lapsos de tiempo cortos.

Las fases de Mobile-D se basan en un modelo de planificación y entrega:

Fase de exploración: Aquí se define el alcance del proyecto con planificación y atención a los conceptos básicos del proyecto. Nuestra aplicación se enfoca al mundo del entretenimiento, por lo que conocer las funcionalidades cercanas a los usuarios no es complejo.

Fase de iniciación: En esta fase, se preparan los materiales, software y hardware para empezar el proyecto, teniendo un plazo de planificación y el resto de trabajo.

Fase de producto: De igual manera, se tiene un plazo de planeación como retroalimentación de lo anterior y definición de al menos una prueba que verifique el funcionamiento del proyecto. Seguido, se tiene un último plazo de trabajo enfocado en la implementación, equivalente al código y diseño de la aplicación por módulo.

Fase de estabilización: Se realiza la integración del proyecto, es decir, módulos separados que deben juntarse para tener una versión completa del proyecto. Así mismo, se entrega documentación del proyecto en donde se describan y exhiban los pasos y descripciones de todo el desarrollo de la aplicación.

Fase de pruebas: Una vez pasada una prueba general de la aplicación, se llega a un plazo de testeo hasta llegar a una versión adecuada a las necesidades del cliente y funcionalidades requeridas por el mismo. Se corrigen fallos, se documentan, pero no se agrega más funcionalidades.

---
## CAPÍTULO 1 RECOLECCIÓN Y REFINAMIENTO DE REQUISITOS
El primer capítulo contiene la definición y especificación de los usuarios que usarán la aplicación, así como los requisitos funcionales y no funcionales del mismo, además del software y hardware necesario para desarrollar dicha aplicación. También se especifican los procesos generales de cada caso de uso con su respectivo diagrama de secuencia en cada caso.

### 1.1 Nececidades del cliente
El departamento de ventas de Cinemas AJEM necesita una aplicación multiplataforma llamada "ButterPop" que abarque tanto la compra y renta de las películas más recientes de su cartelera, como la interacción con los usuarios, brindándoles una experiencia amigable. Por lo que proponen que la misma cuente con dos interfaces clave para lograr esto. 

La primera interfaz está destinada a administradores y superadministradores. Permite la gestión eficiente del catálogo de películas del cine. Los administradores pueden introducir información como la imagen relacionada a la película, el género, duración, título, clasificación, y precio.

La segunda interfaz está diseñada para mejorar la experiencia de los usuarios. Permitiéndoles registrarse, consultar el catálogo de películas, la compra/renta de estas, la creación de listas de reproducción o colecciones de sus películas favoritas o películas pendientes por ver, puntuar y comentar, así como permitirles la obtención de puntos.

El acceso a ambas interfaces depende de un mismo login, sin embargo, para acceder como administradores deben hacerlo por medio de usuarios previamente creados de manera manual por los superadministradores.

### 1.2 Identificación y definición de roles de usuario
Dentro de la aplicación "ButterPop" existen dos roles de usuario fundamentales para el correcto funcionamiento de esta.
- Cliente: Este usuario se tendrá que registrar por medio de correo electrónico y contraseña, e iniciar sesión para poder rentar, comentar, puntuar o guardar una película en alguna lista. Sobre las listas, el usuario podrá crear diferentes dependiendo de sus necesidades. Para poder rentar una película, el cliente tendrá que vincular una forma de pago para poder adquirir la película.
- Administrador: El administrador será el responsable de la gestión de la aplicación "pendiente" de manera que pueda manipular la base de datos para la gestión de películas, usuarios y las rentas que el usuario realice.

### 1.3 Requerimientos funcionales
Los requerimientos funcionales son aquellas descripciones del sistema que tienen una funcionalidad para satisfacer al usuario.
- Registro de clientes: El sistema deberá permitir el registro de clientes interesados con correo y contraseña como parte del registro.
- Inicio de sesión de clientes: El sistema deberá permitir el inicio de sesión de clientes con su correo y contraseña previamente registradas.
- Renta de películas: El sistema deberá permitir la renta de películas en estreno a usuarios registrados en la aplicación siempre y cuando vinculen un método de pago.
- Comentar y puntuar: El sistema deberá permitir a los usuarios con cuenta puntuar las películas, así como comentarlas.
- Gestionar listas: El sistema deberá permitir a los usuarios visualizar, crear, eliminar o actualizar listas personalizables en donde puedan guardar películas.
- Inicio de sesión de administradores: El sistema deberá permitir a los administradores iniciar sesión con un correo y contraseña previamente registrada en la base de datos.
- Gestionar películas: El sistema deberá permitir a los administradores agregar, actualizar y eliminar películas.

### 1.4 Requerimientos no funcionales
Los requerimientos no funcionales son aquellas descripciones que determinan como debe comportarse el sistema en cuestión de calidad y características.
- Encriptar datos: El sistema deberá encriptar datos sensibles tanto del administrador como el cliente, por ejemplo, contraseñas e información bancaria.
- Tiempo de respuesta: El sistema deberá tener un tiempo de respuesta entre cada actividad de máximo cinco segundos.
- Diferenciación administrador y cliente: El sistema deberá diferenciar el inicio de sesión entre un cliente y un administrador.
- Diseño: El sistema deberá tener un diseño responsivo, agradable a la vista del cliente en cuanto a color, tipografía y acorde a la aplicación.
- Usabilidad: El sistema deberá ser de fácil navegación a los usuarios.

### 1.5 Requerimientos de hardware
- Computadoras con mínimo de 16gb RAM y 1TB de almacenamiento. Con monitor de mínimo 22 pulgadas y procesador Intel Core i5 6ta Gen. Para uso general en el proyecto, programación, diseño y documentación.
- Memorias USB de mínimo 8gb de almacenamiento de la marca Kingston. Se utilizarán como medio de guardado de archivos móviles.
- Router o modem de cualquier compañía que ofrezca velocidad de internet de mínimo 61,82 Mb/s.

### 1.6 Requerimientos de software
- Conexión a internet por medio del router con mínima velocidad de 61,82 Mb/s.
- PostgreSQL: Será el gestor de base de datos del proyecto, dada la estructura que facilita a las bases de datos relacionales.
- Visual Studio: Para el desarrollo general de la aplicación, así como su compilación y depuración.
- Xamarin: Para la compilación de la aplicación en plataformas móviles como Android e iOS.
- Testlink: Gestor de casos de prueba en función de requisitos del cliente.
- MantisBT: Funcionará como gestor de reportes de errores o fallos de funcionalidad u ortográficos.

### 1.7 Diagrama general de casos de uso
*La figura 1.7.1 representa el diagrama general de casos de uso que muestran las gestiones principales de la aplicación.*
![diagrama general](img_doc/cap1/_7/DGeneral.jpg)

### 1.8 Especificación de los casos de uso
*La figura 1.8.1 muestra las secuencias del registro de un usuario.*
<table>
    <tr>
        <td>CU-0001</td>
        <td colspan="2">Registrar usuario</td>
    </tr>
    <tr>
        <td>Versión</td>
        <td colspan="2">1.0 (15/05/24)</td>
    </tr>
    <tr>
        <td>Autores</td>
        <td colspan="2">Martínez de la Cruz José Julián</td>
    </tr>
    <tr>
        <td>Actores</td>
        <td colspan="2">Cliente</td>
    </tr>
    <tr>
        <td>Rependencias</td>
        <td colspan="2">Ninguna</td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td colspan="2">El sistema deberá comportarse tal cual se describe en el siguiente caso de uso cuando el usuario registra una cuenta en la aplicación multiplataforma</td>
    </tr>
    <tr>
        <td>Precondición</td>
        <td colspan="2">El usuario deberá visualizar la pantalla principal y la aplicación debe estar activa</td>
    </tr>
    <tr>
        <td rowspan="9">Flujo normal</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>1</td>
        <td>El usuario da clic en el botón "Registrarse"</td>
    </tr>
    <tr>
        <td>2</td>
        <td>El sistema muestra el formulario de registro</td>
    </tr>
    <tr>
        <td>3</td>
        <td>El usuario ingresa su nombre</td>
    </tr>
    <tr>
        <td>4</td>
        <td>El usuario ingresa su correo electrónico</td>
    </tr>
    <tr>
        <td>5</td>
        <td>El usuario ingresa su contraseña</td>
    </tr>
    <tr>
        <td>6</td>
        <td>El usuario confirma su contraseña</td>
    </tr>
    <tr>
        <td>7</td>
        <td>El sistema valida los datos</td>
    </tr>
    <tr>
        <td>8</td>
        <td>El usuario da clic en el botón "Registrarme"</td>
    </tr>
    <tr>
        <td rowspan="2">Flujo alternativo</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>7.1</td>
        <td>Si existe falta de datos, invalidación de datos o el correo electrónico ya ha sido registrado anteriormente, el sistema muestra el mensaje "Tu cuenta no pudo crearse con éxito" y manda al usuario a la interfaz de registrar cuenta, a continuación, este caso de uso queda sin efecto.</td>
    </tr>
    <tr>
        <td>Postcondición</td>
        <td colspan="2">Se guardan los datos de la nueva cuenta en la base de datos y el sistema manda al usuario a la interfaz principal.</td>
    </tr>
</table>

---

*La figura 1.8.2 muestra las secuencias del inicio de sesión de un usuario.*
<table>
    <tr>
        <td>CU-0002</td>
        <td colspan="2">Iniciar sesión</td>
    </tr>
    <tr>
        <td>Versión</td>
        <td colspan="2">1.0 (15/05/24)</td>
    </tr>
    <tr>
        <td>Autores</td>
        <td colspan="2">Martínez de la Cruz José Julián</td>
    </tr>
    <tr>
        <td>Actores</td>
        <td colspan="2">Cliente, Administrador</td>
    </tr>
    <tr>
        <td>Rependencias</td>
        <td colspan="2">Ninguna</td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td colspan="2">El sistema deberá comportarse tal cual se describe en el siguiente caso de uso cuando el usuario inicia sesión en la aplicación multiplataforma.</td>
    </tr>
    <tr>
        <td>Precondición</td>
        <td colspan="2">El usuario debe contar con una cuenta previamente registrada.</td>
    </tr>
    <tr>
        <td rowspan="7">Flujo normal</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>1</td>
        <td>El usuario da clic en el botón "Iniciar sesión"</td>
    </tr>
    <tr>
        <td>2</td>
        <td>El sistema muestra el formulario de inicio de sesión</td>
    </tr>
    <tr>
        <td>3</td>
        <td>El usuario ingresa su correo electrónico</td>
    </tr>
    <tr>
        <td>4</td>
        <td>El usuario ingresa su contraseña</td>
    </tr>
    <tr>
        <td>5</td>
        <td>El sistema valida los datos</td>
    </tr>
    <tr>
        <td>6</td>
        <td>El usuario da clic en el botón "Acceder"</td>
    <tr>
        <td rowspan="3">Flujo alternativo</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>4.1</td>
        <td>Si el usuario ingresa datos no válidos, el sistema cancela el inicio de sesión, y muestra el mensaje "Correo electrónico o contraseña incorrectos", a continuación, este caso de uso queda sin efecto.</td>
    </tr>
    <tr>
        <td>6.1</td>
        <td>Si el sistema no encuentra una cuenta registrada, el sistema cancela su ingreso, y muestra el mensaje "Parece que la cuenta ingresada no existe. Vuelve a intentarlo" , a continuación, este caso de uso queda sin efecto.</td>
    </tr>
    <tr>
        <td>Postcondición</td>
        <td colspan="2">El sistema manda al usuario a la interfaz principal.</td>
    </tr>
</table>

---

*La figura 1.8.3 muestra las secuencias y gestión de rentar una película.*
<table>
    <tr>
        <td>CU-0003</td>
        <td colspan="2">Rentar película</td>
    </tr>
    <tr>
        <td>Versión</td>
        <td colspan="2">1.1 (30/05/24)</td>
    </tr>
    <tr>
        <td>Autores</td>
        <td colspan="2">González Cruz Joel</td>
    </tr>
    <tr>
        <td>Actores</td>
        <td colspan="2">Cliente</td>
    </tr>
    <tr>
        <td>Dependencias</td>
        <td colspan="2">Ninguna</td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td colspan="2">El sistema le permitirá al usuario rentar una o más películas de su elección durante 30 días para que el cliente pueda poseerlas durante ese tiempo, posterior al plazo, el acceso a la película se revocará.</td>
    </tr>
    <tr>
        <td>Precondición</td>
        <td colspan="2">El cliente deberá haber iniciado sesión.</td>
    </tr>
    <tr>
        <td rowspan="11">Flujo normal</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>1</td>
        <td>El usuario selecciona la película que desee rentar.</td>
    </tr>
    <tr>
        <td>2</td>
        <td>El sistema muestra la información de la película además del tráiler y costo de la renta.</td>
    </tr>
    <tr>
        <td>3</td>
        <td>El usuario da click en el botón "Rentar".</td>
    </tr>
    <tr>
        <td>4</td>
        <td>El sistema mostrará un formulario de método de pago para rentar la película.</td>
    </tr>
    <tr>
        <td>5</td>
        <td>El usuario llena la información con sus datos bancarios.</td>
    </tr>
    <tr>
        <td>6</td>
        <td>El sistema valida la información ingresada.</td>
    </tr>
    <tr>
        <td>7</td>
        <td>El sistema muestra un resumen de la película a rentar, bajo que cuenta se va a rentar y con que método de pago se hará la compra.</td>
    </tr>
    <tr>
        <td>8</td>
        <td>El usuario verificará la información y dará click en el botón "Rentar por 30 días"</td>
    </tr>
    <tr>
        <td>9</td>
        <td>El sistema realizará el cobro bajo el concepto "BUTTERPOP - renta - {nombre de la película}, 30 días"</td>
    </tr>
    <tr>
        <td>10</td>
        <td>El sistema mostrará un mensaje: "Transacción realizada exitosamente, revisa tu lista privada 'mis películas rentadas' o haz click aquí para ver la película que acabas de rentar".</td>
    </tr>
    <tr>
        <td rowspan="5">Flujo alternativo</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>5.1</td>
        <td>En caso de que algún campo este vacío el sistema mostrará que todos los campos son requeridos</td>
    </tr>
    <tr>
        <td>6.1</td>
        <td>En caso de los datos ingresados no se puedan validar mostrará un mensaje indicando que ocurrió un problema al verificar los datos</td>
    </tr>
    <tr>
        <td>9.1</td>
        <td>En caso de que el método de pago no posea con los fondos suficientes, el sistema cancelará la transacción y notificara al usuario de que sus fondos son insuficientes</td>
    </tr>
    <tr>
        <td>9.2</td>
        <td>En caso de que el sistema no pueda completar la transacción, mostrará al cliente un mensaje de error: "No se ha podido realizar la operación, comprueba el estado de tu método de pago"</td>
    </tr>
    <tr>
        <td>Postcondición</td>
        <td colspan="2">El link de la película se agregará a una lista privada de "mis películas rentadas" al cliente</td>
    </tr>
</table>

---

*La figura 1.8.4 muestra las secuencias y gestión de comentar una película.*
<table>
    <tr>
        <td>CU-0004</td>
        <td colspan="2">Comentar película</td>
    </tr>
    <tr>
        <td>Versión</td>
        <td colspan="2">1.1 (23/06/24)</td>
    </tr>
    <tr>
        <td>Autores</td>
        <td colspan="2">Rosales Murillo Jesús Miguel</td>
    </tr>
    <tr>
        <td>Actores</td>
        <td colspan="2">Cliente</td>
    </tr>
    <tr>
        <td>Dependencias</td>
        <td colspan="2">Ninguna</td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td colspan="2">El sistema deberá permitir a los usuarios comentar las películas que hayan visto en su respectiva sección y poder visualizar los comentarios de cada película.</td>
    </tr>
    <tr>
        <td>Precondición</td>
        <td colspan="2">El usuario deberá haber visto la película en cuestión previamente y encontrarse en el apartado de películas.</td>
    </tr>
    <tr>
        <td rowspan="19">Flujo normal</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>1</td>
        <td>El usuario deberá darle clic en el botón comentar.</td>
    </tr>
    <tr>
        <td>2</td>
        <td>El sistema muestra la interfaz del apartado comentar.</td>
    </tr>
    <tr>
        <td>3</td>
        <td>El usuario rellenará con sus palabras la caja de comentario.</td>
    </tr>
    <tr>
        <td>4</td>
        <td>El usuario deberá darle clic en guardar.</td>
    </tr>
    <tr>
        <td>5</td>
        <td>El sistema le mostrará el mensaje de comentario insertado.</td>
    </tr>
    <tr>
        <td colspan="2">Modificar comentario</td>
    </tr>
    <tr>
        <td>6</td>
        <td>El caso de uso comienza cuando el usuario clickea en la opción “Editar” en su comentario.</td>
    </tr>
    <tr>
        <td>7</td>
        <td>El sistema muestra la interfaz del apartado comentar con una caja para ingresar texto.</td>
    </tr>
    <tr>
        <td>8</td>
        <td>El usuario ingresará su nuevo comentario en la caja de comentario.</td>
    </tr>
    <tr>
        <td>9</td>
        <td>El usuario deberá darle clic en “Guardar”.</td>
    </tr>
    <tr>
        <td>10</td>
        <td>El sistema guarda el comentario modificado</td>
    </tr>
    <tr>
        <td>11</td>
        <td>El sistema muestra el comentario modificado.</td>
    </tr>
    <tr>
        <td colspan="2">Eliminar comentario</td>
    </tr>
    <tr>
        <td>12</td>
        <td>El caso de uso comienza cuando el usuario clickea en la opción “Borrar” en la sección “Editar” de su comentario.</td>
    </tr>
    <tr>
        <td>13</td>
        <td>El sistema muestra la interfaz de eliminar comentario, donde se le preguntará “¿Está seguro de querer borrar su comentario?”.</td>
    </tr>
    <tr>
        <td>14</td>
        <td>El usuario deberá seleccionar la opción “BORRAR”.</td>
    </tr>
    <tr>
        <td>15</td>
        <td>El sistema eliminará el comentario.</td>
    </tr>
    <tr>
        <td>16</td>
        <td>El sistema actualizará los comentarios.</td>
    </tr>
    <tr>
        <td rowspan="4">Flujo alternativo</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>6.1</td>
        <td>Si el usuario no ha visto la película, no podrá comentar respecto a ella, apareciéndose un mensaje de error “No es posible comentar si no has visto la película”.</td>
    </tr>
    <tr>
        <td>7.1</td>
        <td>Si el usuario selecciona “Cancelar”, no se realizarán cambios en su comentario.</td>
    </tr>
    <tr>
        <td>12.1</td>
        <td>Si el usuario selecciona “Cancelar”, no se borrará su comentario.</td>
    </tr>
    <tr>
        <td>Postcondición</td>
        <td colspan="2">Los comentarios ingresados se almacenan en la base de datos para que cualquiera pueda visualizarlos.</td>
    </tr>
</table>

---

*La figura 1.8.5 muestra las secuencias y gestión de puntuar una película.*
<table>
    <tr>
        <td>CU-0005</td>
        <td colspan="2">Puntuar película</td>
    </tr>
    <tr>
        <td>Versión</td>
        <td colspan="2">1.1 (23/06/24)</td>
    </tr>
    <tr>
        <td>Autores</td>
        <td colspan="2">Rosales Murillo Jesús Miguel</td>
    </tr>
    <tr>
        <td>Actores</td>
        <td colspan="2">Cliente</td>
    </tr>
    <tr>
        <td>Dependencias</td>
        <td colspan="2">Ninguna</td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td colspan="2">El sistema deberá permitir a los usuarios puntuar las películas que hayan visto en su respectiva sección y poder visualizar las puntuaciones de cada película.</td>
    </tr>
    <tr>
        <td>Precondición</td>
        <td colspan="2">El usuario deberá haber visto la película en cuestión previamente y encontrarse en el apartado de películas.</td>
    </tr>
    <tr>
        <td rowspan="14">Flujo normal</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>1</td>
        <td>El usuario deberá darle clic en el botón puntuar.</td>
    </tr>
    <tr>
        <td>2</td>
        <td>El sistema muestra la interfaz del apartado puntuar.</td>
    </tr>
    <tr>
        <td>3</td>
        <td>El usuario puntuará de acuerdo con su preferencia (De 0 a 3 estrellas).</td>
    </tr>
    <tr>
        <td>4</td>
        <td>El usuario deberá darle clic en guardar.</td>
    </tr>
    <tr>
        <td>5</td>
        <td>El sistema le mostrará el mensaje de puntuación guardada.</td>
    </tr>
    <tr>
        <td>6</td>
        <td>El sistema regresará al usuario a la interfaz de películas con su puntuación guardada.</td>
    </tr>
    <tr>
        <td colspan="2">Modificar puntuación</td>
    </tr>
    <tr>
        <td>7</td>
        <td>El caso de uso comienza cuando el usuario clickea en la opción “Editar” en su comentario.</td>
    </tr>
    <tr>
        <td>8</td>
        <td>El sistema muestra la interfaz del apartado comentar con una caja para ingresar su nueva puntuación.</td>
    </tr>
    <tr>
        <td>9</td>
        <td>El usuario ingresará su nueva puntuación en la caja de comentarios.</td>
    </tr>
    <tr>
        <td>10</td>
        <td>El usuario deberá darle clic en “Guardar”.</td>
    </tr>
    <tr>
        <td>11</td>
        <td>El sistema guarda la puntuación modificada</td>
    </tr>
    <tr>
        <td>12</td>
        <td>El sistema muestra la puntuación modificada</td>
    </tr>
    <tr>
        <td rowspan="2">Flujo alternativo</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>7.1</td>
        <td>Si el usuario no ha visto la película, no podrá dar su puntuación respecto a ella, apareciéndose un mensaje de error “No es posible puntuar si no has visto la película”.</td>
    </tr>
    <tr>
        <td>Postcondición</td>
        <td colspan="2">Las puntuaciones guardadas se almacenan en la base de datos para que cualquiera pueda visualizarlas.</td>
    </tr>
</table>

---

*La figura 1.8.6 muestra las secuencias y gestión una lista.*
<table>
    <tr>
        <td>CU-0006</td>
        <td colspan="2">Gestionar lista</td>
    </tr>
    <tr>
        <td>Versión</td>
        <td colspan="2">1.1 (15/05/24)</td>
    </tr>
    <tr>
        <td>Autores</td>
        <td colspan="2">Domínguez Zenteno Andrea</td>
    </tr>
    <tr>
        <td>Actores</td>
        <td colspan="2">Cliente</td>
    </tr>
    <tr>
        <td>Dependencias</td>
        <td colspan="2">Ninguna</td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td colspan="2">El sistema deberá comportarse tal cual se describe en el siguiente caso de uso cuando el usuario pueda ver, crear, eliminar una lista de reproducción.</td>
    </tr>
    <tr>
        <td>Precondición</td>
        <td colspan="2">El usuario deberá previamente iniciar sesión o estar en la interfaz de películas.</td>
    </tr>
    <tr>
        <td rowspan="20">Flujo normal</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>1</td>
        <td>El usuario da click en "Mis listas".</td>
    </tr>
    <tr>
        <td>2</td>
        <td>El sistema muestra la interfaz de "Mis listas".</td>
    </tr>
    <tr>
        <td>3</td>
        <td>El usuario da click en el icono "+".</td>
    </tr>
    <tr>
        <td>4</td>
        <td>El sistema despliega una pestaña para el nombre.</td>
    </tr>
    <tr>
        <td>5</td>
        <td>El usuario ingresa el nombre de su lista.</td>
    </tr>
    <tr>
        <td>6</td>
        <td>El usuario da click en "Crear".</td>
    </tr>
    <tr>
        <td>7</td>
        <td>El sistema sube el nombre de la lista.</td>
    </tr>
    <tr>
        <td>8</td>
        <td>El sistema muestra la interfaz de "Mis listas".</td>
    </tr>
    <tr>
        <td colspan="2">Actualizar Lista</td>
    </tr>
    <tr>
        <td>9</td>
        <td>El usuario da click en el icono de "Editar".</td>
    </tr>
    <tr>
        <td>10</td>
        <td>El sistema despliega una pestaña para actualizar el nombre.</td>
    </tr>
    <tr>
        <td>11</td>
        <td>El usuario ingresa el nuevo nombre de su lista.</td>
    </tr>
    <tr>
        <td>12</td>
        <td>El usuario da click en "Renombrar".</td>
    </tr>
    <tr>
        <td>13</td>
        <td>El sistema actualiza el nombre de la lista.</td>
    </tr>
    <tr>
        <td>14</td>
        <td>El sistema muestra la interfaz de "Mis listas".</td>
    </tr>
    <tr>
        <td colspan="2">Eliminar Lista</td>
    </tr>
    <tr>
        <td>15</td>
        <td>El usuario da click en el icono de "Basura".</td>
    </tr>
    <tr>
        <td>16</td>
        <td>El sistema muestra un mensaje de confirmación: "¿Estás seguro de eliminar esta lista?"</td>
    </tr>
    <tr>
        <td>17</td>
        <td>El usuario da click en "Confirmar".</td>
    </tr>
    <tr>
        <td rowspan="4">Flujo alternativo</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>6.1</td>
        <td>Si ya existe una lista con el mismo nombre, el sistema debe mandar un aviso: "Ya tienes una lista con ese nombre, prueba con otro".</td>
    </tr>
    <tr>
        <td>12.1</td>
        <td>Si el usuario da click en "Cancelar", no hay cambios en los datos de la lista.</td>
    </tr>
    <tr>
        <td>17.1</td>
        <td>Si el usuario da click en "Cancelar", no se elimina la lista.</td>
    </tr>
    <tr>
        <td>Postcondición</td>
        <td colspan="2">Se guardan los datos de la nueva lista en la base de datos y el sistema manda al usuario la interfaz "Mis listas".</td>
    </tr>
</table>

---

*La figura 1.8.7 muestra las secuencias y gestión de una película.*
<table>
    <tr>
        <td>CU-0007</td>
        <td colspan="2">Gestionar películas</td>
    </tr>
    <tr>
        <td>Versión</td>
        <td colspan="2">1.0 (15/05/24)</td>
    </tr>
    <tr>
        <td>Autores</td>
        <td colspan="2">Garcia Capote Emanuel</td>
    </tr>
    <tr>
        <td>Actores</td>
        <td colspan="2">Administrador</td>
    </tr>
    <tr>
        <td>Dependencias</td>
        <td colspan="2">Ninguna</td>
    </tr>
    <tr>
        <td>Descripción</td>
        <td colspan="2">El sistema permitirá a los administradores agregar, eliminar o actualizar una película.</td>
    </tr>
    <tr>
        <td>Precondición</td>
        <td colspan="2">El administrador deberá de iniciar sesión previamente.</td>
    </tr>
    <tr>
        <td rowspan="19">Flujo normal</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>1</td>
        <td>Administrador da click en "Películas".</td>
    </tr>
    <tr>
        <td>2</td>
        <td>El sistema muestra interfaz de películas.</td>
    </tr>
    <tr>
        <td>3</td>
        <td>El administrador da click en "+".</td>
    </tr>
    <tr>
        <td>4</td>
        <td>El sistema muestra un menú para ingresar datos de la película.</td>
    </tr>
    <tr>
        <td>5</td>
        <td>El administrador ingresa "Nombre de la película", "Descripción" y una "Imagen".</td>
    </tr>
    <tr>
        <td>6</td>
        <td>El administrador da click en "Agregar".</td>
    </tr>
    <tr>
        <td>7</td>
        <td>El sistema procesa los datos.</td>
    </tr>
    <tr>
        <td>8</td>
        <td>El sistema muestra la interfaz de "Películas".</td>
    </tr>
    <tr>
        <td>9</td>
        <td>El administrador da click en el icono de "Editar".</td>
    </tr>
    <tr>
        <td>10</td>
        <td>El sistema muestra un menú para ingresar datos de la película.</td>
    </tr>
    <tr>
        <td>11</td>
        <td>El administrador ingresa "Nombre de la película", "Descripción" o una "Imagen".</td>
    </tr>
    <tr>
        <td>12</td>
        <td>El administrador da click en "Confirmar".</td>
    </tr>
    <tr>
        <td>13</td>
        <td>El sistema actualiza la base de datos.</td>
    </tr>
    <tr>
        <td>14</td>
        <td>El sistema muestra la interfaz de "Películas" con la película actualizada.</td>
    </tr>
    <tr>
        <td>15</td>
        <td>El administrador da click en el icono de "Borrar".</td>
    </tr>
    <tr>
        <td>16</td>
        <td>El sistema muestra un mensaje de confirmación: "¿Estás seguro de eliminar la película?" con la película actualizada.</td>
    </tr>
    <tr>
        <td>17</td>
        <td>El administrador da click en "Confirmar".</td>
    </tr>
    <tr>
        <td>18</td>
        <td>El sistema muestra la interfaz de "Películas" con la película eliminada.</td>
    </tr>
    <tr>
        <td rowspan="5">Flujo alternativo</td>
        <td>Paso</td>
        <td>Acción</td>
    </tr>
    <tr>
        <td>6.1</td>
        <td>Si algún dato proporcionado por el administrador no corresponde al establecido, se cancela el proceso.</td>
    </tr>
    <tr>
        <td>6.2</td>
        <td>Si el administrador da click en "Cancelar" la información se descarta.</td>
    </tr>
    <tr>
        <td>12.1</td>
        <td>Si el administrador da click en "Cancelar" la información de la película queda igual.</td>
    </tr>
    <tr>
        <td>17.1</td>
        <td>Si el administrador da click en "Cancelar" la película se queda en la base de datos.</td>
    </tr>
    <tr>
        <td>Postcondición</td>
        <td colspan="2">Se guardan los datos en la base de datos y el sistema muestra los cambios hechos a clientes y administradores.</td>
    </tr>
</table>

#### Diseño de pruebas basado en casos de uso

### 1.9 Diagramas de secuencia
#### Inicio de sesión
*La figura 1.9.1 muestra el diagrama de secuencia del caso de uso “Iniciar sesión”*
![DS inicio de sesión](img_doc/cap1/_9/DSSesion.jpg)

#### Registrar usuarios
*La figura 1.9.2 muestra el diagrama de secuencia del caso de uso "Registrar usuario"*
![DS registrar usuario](img_doc/cap1/_9/DSRegistrar.jpg)

#### Rentar película
*La figura 1.9.3 muestra el diagrama de secuencia del caso de uso "Rentar película"*
![DS rentar película](img_doc/cap1/_9/DSRentar.jpg)

#### Gestionar lista
*La figura 1.9.4 muestra el diagrama de secuencia del caso de uso "Gestionar listas"*
![DS gestionar lista](img_doc/cap1/_9/DSListas.jpg)

#### Comentar película
*La figura 1.9.5 muestra el diagrama de secuencia del caso de uso "Gestionar comentarios"*
![DS comentar película](img_doc/cap1/_9/DSComentar.jpg)

#### Puntuar película
*La figura 1.9.6 muestra el diagrama de secuencia del caso de uso "Gestionar puntuación"*
![DS puntuar película](img_doc/cap1/_9/DSPuntuar.jpg)

### 1.10 Diagrama de actividades
*La figura 1.10.1 muestra el diagrama de actividades de la aplicación*
![diagrama de actividades](img_doc/cap1/_10/DActividades.jpg)

## CAPÍTULO 2 DISEÑO Y DESARROLLO DEL PROYECTO
El segundo capítulo contiene la especificación de la base de datos, tales como sus tablas y su respectivo diccionario de datos para cada tabla, además se plantea un plan de pruebas con cada caso de prueba, por último, también se presenta el diseño de interfaces que contiene la aplicación. 

### 2.1 Diagrama de la base de datos (relacional)
![diagrama relacional de la base de datos]()

### 2.2 Diccionario de datos
*La figura 2.2.1 muestra el diccionario de datos de la tabla "pelicula"*
<table>
    <tr>
        <td colspan="5">TB PELICULA</td>
    </tr>
    <tr>
        <td>Campo</td>
        <td>Tipo</td>
        <td>Extención</td>
        <td>Restricción</td>
        <td>Observaciones</td>
    </tr>
    <tr>
        <td>id_pelicula</td>
        <td>serial</td>
        <td>N/A</td>
        <td>PK</td>
        <td>Llave primaria de película</td>
    </tr>
    <tr>
        <td>correo_admin</td>
        <td>varchar</td>
        <td>30</td>
        <td>FK</td>
        <td>Llave foránea del administrador que gestiona la película de la tabla administrador</td>
    </tr>
    <tr>
        <td>titulo</td>
        <td>varchar</td>
        <td>50</td>
        <td>N/A</td>
        <td>Título de la película</td>
    </tr>
    <tr>
        <td>genero</td>
        <td>varchar</td>
        <td>30</td>
        <td>N/A</td>
        <td>Género de la película</td>
    </tr>
    <tr>
        <td>clasificacion</td>
        <td>varchar</td>
        <td>30</td>
        <td>N/A</td>
        <td>Clasificación de la película</td>
    </tr>
    <tr>
        <td>duracion</td>
        <td>float</td>
        <td>N/A</td>
        <td>N/A</td>
        <td>Duración de la película (HH.MM)</td>
    </tr>
    <tr>
        <td>archivo</td>
        <td>bytea</td>
        <td>N/A</td>
        <td>N/A</td>
        <td>Archivo de la película</td>
    </tr>
    <tr>
        <td>precio</td>
        <td>float</td>
        <td>N/A</td>
        <td>N/A</td>
        <td>Precio de la renta de la película</td>
    </tr>
    <tr>
        <td>portada</td>
        <td>bytea</td>
        <td>N/A</td>
        <td>N/A</td>
        <td>Portada de la película</td>
    </tr>
</table>

---

*La figura 2.2.2 muestra el diccionario de datos de la tabla "renta"*
<table>
    <tr>
        <td colspan="5">TB RENTA</td>
    </tr>
    <tr>
        <td>Campo</td>
        <td>Tipo</td>
        <td>Extención</td>
        <td>Restricción</td>
        <td>Observaciones</td>
    </tr>
    <tr>
        <td>id_renta</td>
        <td>serial</td>
        <td>N/A</td>
        <td>PK</td>
        <td>Llave primaria de renta</td>
    </tr>
    <tr>
        <td>correo_cliente</td>
        <td>varchar</td>
        <td>50</td>
        <td>FK</td>
        <td>Llave foránea del cliente que renta la película de la tabla cliente</td>
    </tr>
    <tr>
        <td>id_pelicula</td>
        <td>int</td>
        <td>N/A</td>
        <td>FK</td>
        <td>Llave foránea de la película de la tabla pelicula</td>
    </tr>
    <tr>
        <td>fecha_renta</td>
        <td>timestamp</td>
        <td>N/A</td>
        <td>N/A</td>
        <td>Fecha y hora en la que se registra la renta</td>
    </tr>
</table>

---

*La figura 2.2.3 muestra el diccionario de datos de la tabla "comentar"*
<table>
    <tr>
        <td colspan="5">TB COMENTAR</td>
    </tr>
    <tr>
        <td>Campo</td>
        <td>Tipo</td>
        <td>Extención</td>
        <td>Restricción</td>
        <td>Observaciones</td>
    </tr>
    <tr>
        <td>id_comentario</td>
        <td>serial</td>
        <td>N/A</td>
        <td>PK</td>
        <td>Llave primaria de comentar</td>
    </tr>
    <tr>
        <td>correo_cliente</td>
        <td>varchar</td>
        <td>50</td>
        <td>FK</td>
        <td>Llave foránea del cliente de la tabla cliente</td>
    </tr>
    <tr>
        <td>comentario</td>
        <td>varchar</td>
        <td>100</td>
        <td>N/A</td>
        <td>Contenido del comentario</td>
    </tr>
    <tr>
        <td>puntuacion</td>
        <td>float</td>
        <td>N/A</td>
        <td>N/A</td>
        <td>Puntuación de la película (0.0 - 5.0)</td>
    </tr>
</table>

---

*La figura 2.2.4 muestra el diccionario de datos de la tabla "contiene"*
<table>
    <tr>
        <td colspan="5">TB CONTIENE</td>
    </tr>
    <tr>
        <td>Campo</td>
        <td>Tipo</td>
        <td>Extención</td>
        <td>Restricción</td>
        <td>Observaciones</td>
    </tr>
    <tr>
        <td>id_contiene</td>
        <td>serial</td>
        <td>N/A</td>
        <td>PK</td>
        <td>Llave primaria de contiene</td>
    </tr>
    <tr>
        <td>id_lista</td>
        <td>int</td>
        <td>N/A</td>
        <td>FK</td>
        <td>Llave foránea de la lista de la tabla lista</td>
    </tr>
    <tr>
        <td>id_pelicula</td>
        <td>int</td>
        <td>N/A</td>
        <td>FK</td>
        <td>Llave foránea de la pelicula de la tabla pelicula</td>
    </tr>
</table>

---

*La figura 2.2.5 muestra el diccionario de datos de la tabla "cliente"*
<table>
    <tr>
        <td colspan="5">TB CLIENTE</td>
    </tr>
    <tr>
        <td>Campo</td>
        <td>Tipo</td>
        <td>Extención</td>
        <td>Restricción</td>
        <td>Observaciones</td>
    </tr>
    <tr>
        <td>correo_cliente</td>
        <td>varchar</td>
        <td>50</td>
        <td>PK</td>
        <td>Llave primaria del cliente</td>
    </tr>
    <tr>
        <td>contrasena</td>
        <td>varchar</td>
        <td>20</td>
        <td>N/A</td>
        <td>Hash de la contraseña del cliente</td>
    </tr>
    <tr>
        <td>usuario</td>
        <td>varchar</td>
        <td>30</td>
        <td>N/A</td>
        <td>Nombre de usuario del cliente</td>
    </tr>
    <tr>
        <td>no_cuenta</td>
        <td>varchar</td>
        <td>16</td>
        <td>N/A</td>
        <td>Número de cuenta bancario del cliente</td>
    </tr>
</table>

---

*La figura 2.2.6 muestra el diccionario de datos de la tabla "lista"*
<table>
    <tr>
        <td colspan="5">TB LISTA</td>
    </tr>
    <tr>
        <td>Campo</td>
        <td>Tipo</td>
        <td>Extención</td>
        <td>Restricción</td>
        <td>Observaciones</td>
    </tr>
    <tr>
        <td>id_lista</td>
        <td>serial</td>
        <td>N/A</td>
        <td>PK</td>
        <td>Llave primaria de lista</td>
    </tr>
    <tr>
        <td>correo_cliente</td>
        <td>varchar</td>
        <td>50</td>
        <td>FK</td>
        <td>Llave foránea del cliente de tabla cliente</td>
    </tr>
    <tr>
        <td>nombre</td>
        <td>varchar</td>
        <td>30</td>
        <td>N/A</td>
        <td>Nombre de la lista</td>
    </tr>
    <tr>
        <td>descripcion</td>
        <td>varchar</td>
        <td>100</td>
        <td>N/A</td>
        <td>Descripción de la lista</td>
    </tr>
    <tr>
        <td>imagen</td>
        <td>bytea</td>
        <td>N/A</td>
        <td>N/A</td>
        <td>Imagen de la lista</td>
    </tr>
</table>

---

*La figura 2.2.7 muestra el diccionario de datos de la tabla "administrador"*
<table>
    <tr>
        <td colspan="5">TB ADMINISTRADOR</td>
    </tr>
    <tr>
        <td>Campo</td>
        <td>Tipo</td>
        <td>Extención</td>
        <td>Restricción</td>
        <td>Observaciones</td>
    </tr>
    <tr>
        <td>correo_admin</td>
        <td>serial</td>
        <td>N/A</td>
        <td>PK</td>
        <td>Llave primaria del administrador</td>
    </tr>
    <tr>
        <td>contrasena</td>
        <td>varchar</td>
        <td>20</td>
        <td>N/A</td>
        <td>Hash de la contraseña del administrador</td>
    </tr>
</table>

### 2.3 Diseño de pruebas
Diseño de pruebas por partición de equivalencia es una técnica utilizada en pruebas de software para dividir el dominio de entrada de un programa en clases de equivalencia. Cada clase representa un conjunto de valores de entrada que se espera que el software trate de manera similar. Las pruebas se realizan seleccionando al menos un valor de cada clase, con el objetivo de reducir el número de casos de prueba necesarios mientras se mantiene una cobertura efectiva del comportamiento del sistema.

#### INICIAR SESIÓN / REGISTRARSE
##### TABLAS DE CONSIGNACIÓN

<table>
    <tr>
        <td>CONDICIONES DE ENTRADA</td>
        <td>REGLA EUCARÍSTICA</td>
        <td>CLASES VÁLIDAS</td>
        <td>CLASES NO VÁLIDAS</td>
    </tr>
    <tr>
        <td rowspan="9">CREDENCIALES DE INICIO DE SESIÓN</td>
        <td rowspan="2">VALOR ESPECÍFICO</td>
        <td rowspan="2">1. CONTRASEÑA = 8 CARACTERES</td>
        <td>2. CONTRASEÑA > 8 CARACTERES</td>
    </tr>
    <tr>
        <td>3. CONTRASEÑA < 8 CARACTERES</td>
    </tr>
    <tr>
        <td rowspan = "4">CONJUNTO</td>
        <td>4. AL MENOS UN NÚMERO</td>
        <td>5. SIN NÚMEROS</td>
    </tr>
    <tr>
        <td>6. AL MENOS UNA MINUSCULA</td>
        <td>7. SIN MINUSCULAS</td>
    </tr>
    <tr>
        <td>8. AL MENOS UNA MAYUSCULA</td>
        <td>9. SIN MAYUSCULAS</td>
    </tr>
    <tr>
        <td>10. UN SÍMBOLO</td>
        <td>11. SIN SÍMBOLO</td>
    </tr>
    <tr>
        <td rowspan="3">BOOLEANO</td>
        <td>12. CORREO VÁLIDO</td>
        <td>13. CORREO INVÁLIDO</td>
    </tr>
    <tr>
        <td>14. EXISTE EN BD</td>
        <td>15. NO EXISTE EN BD</td>
    </tr>
    <tr>
        <td>16. CONTRASEÑA CORRECTA</td>
        <td>17. CONTRASEÑA INCORRECTA</td>
    </tr>
</table>

##### CLASES VÁLIDAS
| NO. CASO | CREDENCIALES DE INICIO | CLASES VÁLIDAS |
| - | - | - |
| 1 | **Correo:** Jjulianmtz321@gmail.com **Contraseña:** juLian@1 | 1, 4, 6, 8, 10, 12, 14, 16 |

##### CLASES NO VÁLIDAS
| NO. CASO | CREDENCIALES DE INICIO | CLASES INVÁLIDAS |
| - | - | - |
| 2 | **Correo:** Jjulianmtz321@gmail.com **Contraseña:** Juli@n789 | 2, 4, 6, 8, 10, 12, 14, 17 |
| 3 | **Correo:** alanfugas@gmail.com **Contraseña:** Al@n4 | 3, 4, 6, 8, 10, 12, 14, 17 |
| 4 | **Correo:** elvale@gmail.com **Contraseña:** Val@ntin | 1, 5, 6, 8, 10, 12, 14, 17 |
| 5 | **Correo:** elvale@gmail.com **Contraseña:** VAL@NT1N | 1, 4, 7, 8, 10, 12, 14, 17 |
| 6 | **Correo:** elvale@gmail.com **Contraseña:** val@nt1n | 1, 4, 6, 9, 10, 12, 14, 17 |
| 7 | **Correo:** elvale@gmail.com **Contraseña:** Valent1n | 1, 4, 6, 8, 11, 12, 14, 17 |
| 8 | **Correo:** elvale@gmail.com **Contraseña:** 12345678 | 1, 4, 7, 9, 11, 12, 14, 17 |
| 9 | **Correo:** elvalegmail.com **Contraseña:** Juli@n7 | 1, 4, 6, 8, 10, 13, 15, 17 |
| 10 | **Correo:** elvale1@gmail.com **Contraseña:** Juli@n7 | 1, 4, 6, 8, 10, 15, 17 |
| 11 | **Correo:** Jjulianmtz321@gmail.com **Contraseña:** Juli@n7 | 1, 4, 6, 8, 10, 14, 17 |

##### CASOS DE PRUEBA
| NO. CASO | CREDENCIALES DE INICIO | RESULTADOS ESPERADOS | RESULTADOS REALES |
| - | - | - | - |
| 1 | **Correo:** Jjulianmtz321@gmail.com **Contraseña:** juLian@1 | El sistema verifica las credenciales de inicio de sesión y manda al usuario a la interfaz principal | |
| 2 | **Correo:** Jjulianmtz321@gmail.com **Contraseña:** Juli@n789 | El sistema muestra mensaje "Contraseña no cumple con los requisitos" y regresa al usuario a la interfaz de inicio de sesión | |
| 3 | **Correo:** alanfugas@gmail.com **Contraseña:** Al@n4 | El sistema muestra mensaje "Contraseña no cumple con los requisitos" y regresa al usuario a la interfaz de inicio de sesión | |
| 4 | **Correo:** elvale@gmail.com **Contraseña:** Val@ntin | El sistema muestra mensaje "Contraseña no cumple con los requisitos" y regresa al usuario a la interfaz de inicio de sesión | |
| 5 | **Correo:** elvale@gmail.com **Contraseña:** VAL@NT1N | El sistema muestra mensaje "Contraseña no cumple con los requisitos" y regresa al usuario a la interfaz de inicio de sesión | |
| 6 | **Correo:** elvale@gmail.com **Contraseña:** val@nt1n | El sistema muestra mensaje "Contraseña no cumple con los requisitos" y regresa al usuario a la interfaz de inicio de sesión | |
| 7 | **Correo:** elvale@gmail.com **Contraseña:** Valent1n | El sistema muestra mensaje "Contraseña no cumple con los requisitos" y regresa al usuario a la interfaz de inicio de sesión | |
| 8 | **Correo:** elvale@gmail.com **Contraseña:** 12345678 | El sistema muestra mensaje "Contraseña no cumple con los requisitos" y regresa al usuario a la interfaz de inicio de sesión | |
| 9 | **Correo:** elvalegmail.com **Contraseña:** Juli@n7 | El sistema muestra mensaje "El correo ingresado no es un correo valido" y regresa al usuario a la interfaz de inicio de sesión | |
| 10 | **Correo:** elvale1@gmail.com **Contraseña:** Juli@n7 | El sistema muestra mensaje "No se pudo localizar la cuenta ingresada" y regresa al usuario a la interfaz de inicio de sesión | |
| 11 | **Correo:** Jjulianmtz321@gmail.com **Contraseña:** Juli@n7 | El sistema muestra mensaje "Contraseña incorrecta" y regresa al usuario a la interfaz de inicio de sesión | |

---

#### RENTAR PELÍCULA
##### TABLAS DE CONSIGNACIÓN

<table>
    <tr>
        <td>CONDICIONES DE ENTRADA</td>
        <td>REGLA EUCARÍSTICA</td>
        <td>CLASES VÁLIDAS</td>
        <td>CLASES NO VÁLIDAS</td>
    </tr>
    <tr>
        <td rowspan="2">Número de la tarjeta</td>
        <td rowspan="2">Valor específico</td>
        <td rowspan="2">1. Número de caracteres de la tarjeta = 16</td>
        <td>2. Caracteres de la tarjeta > 16</td>
    </tr>
    <tr>
        <td>3. Caracteres de la tarjeta < 16</td>
    </tr>
    <tr>
        <td>Fecha de expiración</td>
        <td>Booleano</td>
        <td>4. Fecha de expiración vigente</td>
        <td>5. Fecha de expiración no vigente</td>
    </tr>
    <tr>
        <td>Clave de seguridad</td>
        <td>Booleano</td>
        <td>6. Clave de seguridad válida</td>
        <td>7. Clave de seguridad inválida</td>
    </tr>
    <tr>
        <td>Fondos de la tarjeta</td>
        <td>Booleano</td>
        <td>8. Fondos de la tarjeta suficientes</td>
        <td>9. Fondos de la tarheta insuficientes</td>
    </tr>
</table>

##### CLASES VÁLIDAS
| No. Caso | Valores ingresados | Clases válidas |
| - | - | - |
| 1 | **Número de tarjeta:** 6754 6785 2345 9800 **Fecha de expiración:** 06/28 **Clave de seguridad:** 347 **Fondos de la tarjeta:** Suficientes | 1, 4, 6, 8 |

##### CLASES NO VÁLIDAS
| No. Caso | Valores ingresados | Clases no válidas |
| - | - | - |
| 2 | **Número de tarjeta:** 5630 4585 4762 5987 **Fecha de expiración:** 07/25 **Clave de seguridad:** 478 **Fondos de la tarjeta:** Insuficientes | 1, 4, 6, 9 |
| 3 | **Número de tarjeta:** 4576 7589 3485 0054 **Fecha de expiración:** 06/30 **Clave de seguridad:** 04 **Fondos de la tarjeta:** Suficientes | 1, 4, 7, 8 |
| 4 | **Número de tarjeta:** 3287 2098 2683 5983 **Fecha de expiración:** 02/27 **Clave de seguridad:** 22 **Fondos de la tarjeta:** Insuficientes | 1, 4, 7, 9 |
| 5 | **Número de tarjeta:** 4327 8523 5932 3478 **Fecha de expiración:** 03/22 **Clave de seguridad:** 349 **Fondos de la tarjeta:** Suficientes | 1, 5, 6, 8 |
| 6 | **Número de tarjeta:** 2348 7475 6385 8043 **Fecha de expiración:** 12/12 **Clave de seguridad:** 584 **Fondos de la tarjeta:** Insuficientes | 1, 5, 6, 9 |
| 7 | **Número de tarjeta:** 1295 9230 9572 9054 **Fecha de expiración:** 09/28 **Clave de seguridad:** 01 **Fondos de la tarjeta:** Suficientes | 1, 5, 7, 8 |
| 8 | **Número de tarjeta:** 7823 4782 3579 0121 **Fecha de expiración:** 05/24 **Clave de seguridad:** -457 **Fondos de la tarjeta:** Insuficientes | 1, 5, 7, 9 |
| 9 | **Número de tarjeta:** 1295 2467 3468 2476 3498 54 **Fecha de expiración:** 07/28 **Clave de seguridad:** 789 **Fondos de la tarjeta:** Suficientes | 2, 4, 6, 8 |
| 10 | **Número de tarjeta:** 4567 4577 4564 1209 12 **Fecha de expiración:** 04/25 **Clave de seguridad:** 456 **Fondos de la tarjeta:** Insuficientes | 2, 4, 6, 9 |
| 11 | **Número de tarjeta:** 3456 5678 7980 7987 6 **Fecha de expiración:** 05/27 **Clave de seguridad:** 4253 **Fondos de la tarjeta:** Suficientes | 2, 4, 7, 8 |
| 12 | **Número de tarjeta:** 1234 5678 9012 3456 7890 **Fecha de expiración:** 07/27 **Clave de seguridad:** 0727 **Fondos de la tarjeta:** Insuficientes | 2, 4, 7, 9 |
| 13 | **Número de tarjeta:** 7463 2655 4654 3732 64 **Fecha de expiración:** 01/01 **Clave de seguridad:** 956 **Fondos de la tarjeta:** Suficientes | 2, 5, 6, 8 |
| 14 | **Número de tarjeta:** 4563 5683 5845 6365 8378 546 **Fecha de expiración:** 07/08 **Clave de seguridad:** 094 **Fondos de la tarjeta:** Insuficientes | 2, 5, 6, 9 |
| 15 | **Número de tarjeta:** 8734 6582 3745 6275 4273 852 3 **Fecha de expiración:** 10/23 **Clave de seguridad:** 5587456347 **Fondos de la tarjeta:** Suficientes | 2, 5, 7, 8 |
| 16 | **Número de tarjeta:** 1111 2222 3333 4444 5555 **Fecha de expiración:** 11/22 **Clave de seguridad:** 3456 **Fondos de la tarjeta:** Insuficientes | 2, 5, 7, 9 |
| 17 | **Número de tarjeta:** 1234 5678 90 **Fecha de expiración:** 05/29 **Clave de seguridad:** 848 **Fondos de la tarjeta:** Suficientes | 3, 4, 6, 8 |
| 18 | **Número de tarjeta:** 5534 9873 66 **Fecha de expiración:** 12/30 **Clave de seguridad:** 672 **Fondos de la tarjeta:** Insuficientes | 3, 4, 6, 9 |
| 19 | **Número de tarjeta:** 095 **Fecha de expiración:** 09/26 **Clave de seguridad:** 2346 4576 9038 2759 **Fondos de la tarjeta:** Suficientes | 3, 4, 7, 8 |
| 20 | **Número de tarjeta:** 4587 3482 1039 439 **Fecha de expiración:** 03/31 **Clave de seguridad:** 4053 **Fondos de la tarjeta:** Insuficientes | 3, 4, 7, 9 |
| 21 | **Número de tarjeta:** 3568 04 **Fecha de expiración:** 01/24 **Clave de seguridad:** 987 **Fondos de la tarjeta:** Suficientes | 3, 5, 6, 8 |
| 22 | **Número de tarjeta:** 0112 3581 3471 123 **Fecha de expiración:** 10/07 **Clave de seguridad:** 278 **Fondos de la tarjeta:** Insuficientes | 3, 5, 6, 9 |
| 23 | **Número de tarjeta:** 3738 2538 746 **Fecha de expiración:** 08/22 **Clave de seguridad:** -000 **Fondos de la tarjeta:** Suficientes | 3, 5, 7, 8 |
| 24 | **Número de tarjeta:** 3845 7247 38 **Fecha de expiración:** 07/00 **Clave de seguridad:** 123456 **Fondos de la tarjeta:** Insuficientes | 3, 5, 7, 9 |

##### CASOS DE PRUEBA
| No. Caso | Información de la tarjeta | Resultados esperados | Resultados reales |
| - | - | - | - |
| 1 | **Número de tarjeta:** 6754 6785 2345 9800 **Fecha de expiración:** 06/28 **Clave de seguridad:** 347 **Fondos de la tarjeta:** Suficientes | El sistema realiza el cobro y muestra un mensaje de operación exitosa |  |
| 2 | **Número de tarjeta:** 5630 4585 4762 5987 **Fecha de expiración:** 07/25 **Clave de seguridad:** 478 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje indicando que los fondos de la tarjeta son insuficientes |  |
| 3 | **Número de tarjeta:** 4576 7589 3485 0054 **Fecha de expiración:** 06/30 **Clave de seguridad:** 04 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 4 | **Número de tarjeta:** 3287 2098 2683 5983 **Fecha de expiración:** 02/27 **Clave de seguridad:** 22 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 5 | **Número de tarjeta:** 4327 8523 5932 3478 **Fecha de expiración:** 03/22 **Clave de seguridad:** 349 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 6 | **Número de tarjeta:** 2348 7475 6385 8043 **Fecha de expiración:** 12/12 **Clave de seguridad:** 584 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 7 | **Número de tarjeta:** 1295 9230 9572 9054 **Fecha de expiración:** 09/28 **Clave de seguridad:** 01 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 8 | **Número de tarjeta:** 7823 4782 3579 0121 **Fecha de expiración:** 05/24 **Clave de seguridad:** -457 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 9 | **Número de tarjeta:** 1295 2467 3468 2476 3498 54 **Fecha de expiración:** 07/28 **Clave de seguridad:** 789 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 10 | **Número de tarjeta:** 4567 4577 4564 1209 12 **Fecha de expiración:** 04/25 **Clave de seguridad:** 456 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 11 | **Número de tarjeta:** 3456 5678 7980 7987 6 **Fecha de expiración:** 05/27 **Clave de seguridad:** 4253 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 12 | **Número de tarjeta:** 1234 5678 9012 3456 7890 **Fecha de expiración:** 07/27 **Clave de seguridad:** 0727 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 13 | **Número de tarjeta:** 7463 2655 4654 3732 64 **Fecha de expiración:** 01/01 **Clave de seguridad:** 956 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 14 | **Número de tarjeta:** 4563 5683 5845 6365 8378 546 **Fecha de expiración:** 07/08 **Clave de seguridad:** 094 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 15 | **Número de tarjeta:** 8734 6582 3745 6275 4273 852 3 **Fecha de expiración:** 10/23 **Clave de seguridad:** 5587456347 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 16 | **Número de tarjeta:** 1111 2222 3333 4444 5555 **Fecha de expiración:** 11/22 **Clave de seguridad:** 3456 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 17 | **Número de tarjeta:** 1234 5678 90 **Fecha de expiración:** 05/29 **Clave de seguridad:** 848 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 18 | **Número de tarjeta:** 5534 9873 66 **Fecha de expiración:** 12/30 **Clave de seguridad:** 672 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 19 | **Número de tarjeta:** 095 **Fecha de expiración:** 09/26 **Clave de seguridad:** 2346 4576 9038 2759 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 20 | **Número de tarjeta:** 4587 3482 1039 439 **Fecha de expiración:** 03/31 **Clave de seguridad:** 4053 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 21 | **Número de tarjeta:** 3568 04 **Fecha de expiración:** 01/24 **Clave de seguridad:** 987 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 22 | **Número de tarjeta:** 0112 3581 3471 123 **Fecha de expiración:** 10/07 **Clave de seguridad:** 278 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 23 | **Número de tarjeta:** 3738 2538 746 **Fecha de expiración:** 08/22 **Clave de seguridad:** -000 **Fondos de la tarjeta:** Suficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |
| 24 | **Número de tarjeta:** 3845 7247 38 **Fecha de expiración:** 07/00 **Clave de seguridad:** 123456 **Fondos de la tarjeta:** Insuficientes | El sistema muestra un mensaje diciendo que ocurrió un problema al realizar el cobro |  |

---

#### COMENTAR / PUNTUAR
##### TABLAS DE CONSIGNACIÓN
<table>
    <tr>
        <td>CONDICIONES DE ENTRADA</td>
        <td>REGLA HEURÍSTICA</td>
        <td>CLASES VÁLIDAS</td>
        <td>CLASES NO VÁLIDAS</td>
    </tr>
    <tr>
        <td rowspan="2">COMENTAR Y DAR PUNTUACIÓN</td>
        <td rowspan="2">VALOR ESPECÍFICO</td>
        <td>1. COMENTARIO <= 100 CARACTERES</td>
        <td rowspan="2">2. COMENTARIO < 100 CARACTERES</td>
    </tr>
    <tr>
        <td>3. PUNTUACION = 0-3</td>
    </tr>
    <tr>
        <td>RENTA</td>
        <td>Booleano</td>
        <td>4. Película rentada</td>
        <td>5. Película no rentada</td>
    </tr>
</table>

##### CLASES VÁLIDAS
| NO. CASO | COMENTAR / PUNTUAR | CLASES VÁLIDAS |
| - | - | - |
| 1 | **Comentario:** “¡Excelente película, muero de ganas de poder volver a verla!” **Puntuación:** 3 Estrellas. | 1, 3, 4 |

##### CLASES NO VÁLIDAS
| NO. CASO | COMENTAR / PUNTUAR | CLASES INVÁLIDAS |
| - | - | - |
| 2 | **Comentario:** (Si supera los 100 caracteres) |2, 5|

##### CASOS DE PRUEBA
| NO. CASO | COMENTAR / PUNTUAR | RESULTADOS ESPERADOS | RESULTADOS REALES |
| - | - | - | - |
| 1 | **Comentario:** (De <= 100 caracteres) **Puntuación:** 1 estrella | El sistema verifica la cantidad de caracteres que no sobrepase los 100, verifica la puntuación ingresada y actualiza los comentarios una vez ingresado el comentario. | |
| 2 | **Comentario:** (De = 100 caracteres) **Puntuación:** 2 estrellas | El sistema verifica la cantidad de caracteres que no sobrepase los 100, verifica la puntuación ingresada y actualiza los comentarios una vez ingresado el comentario. | |
| 3 | **Comentario:** (De > 100 caracteres) **Puntuación:** 3 estrellas | El sistema muestra mensaje “Comentario excede la cantidad permitida  de carácteres” y lo regresa a la caja de comentarios. | |

---

#### ELIMINAR LISTA
##### TABLAS DE CONSIGNACIÓN
| Condiciones de entrada | Regla heurística | Clases válidas | Clases no válidas |
| - | - | - | - |
| Listas | Booleano | 1. Lista en la base de datos | 2. No está en la base de datos |

##### CLASES VÁLIDAS
| No. Caso | Lista | Clases válidas |
| - | - | - |
| 1 | **Lista:** Está en la base de datos | 1 |

##### CLASES NO VÁLIDAS
| No. Caso | Lista | Clases inválidas |
| - | - | - |
| 2 | **Lista:** No está en la base de datos | 2 |

##### CASOS DE PRUEBA
| No. Caso | Lista | Resultados esperados | Resultados reales |
| - | - | - | - |
| 1 | Lista "Mis favoritos" (Base de datos) | Se elimina la lista de la interfaz del usuario y de la base de datos | |
| 2 | Lista "Para ver con la familia" (No está en la base de datos) | Manda mensaje de error | |

---

### 2.4 Diseño de las interfaces (maquetas)
*La figura 2.4.1 muestra la interfaz de bienvenida a la aplicación*

![interfaz de bienvenida a la aplicacion](img_doc/cap2/_4/bienvenida.jpg)
<br>Interfaz de bienvenida a la aplicación

---

*La figura 2.4.2 muestra la interfaz de inicio de sesión*

![interfaz de inicio de sesion](img_doc/cap2/_4/inicioSesion.jpg)
<br>Interfaz de inicio de sesión

---

*La figura 2.4.3 muestra la interfaz de registrar cuenta*

![interfaz de resgitro de usuario](img_doc/cap2/_4/registrar.jpg)
<br>Interfaz de resgitro de usuario

---

*La figura 2.4.4 muestra la interfaz de principal (cartelera)*

![interfaz principal (cartelera)](img_doc/cap2/_4/cartelera.jpg)
<br>Interfaz principal (cartelera)

---

*La figura 2.4.5 muestra la interfaz de selección de película*

![interfaz seleccion de pelicula](img_doc/cap2/_4/seleccionPelicula.jpg)
<br>Interfaz selección de película

---

*La figura 2.4.6 muestra la interfaz de renta de película*

![interfaz renta de pelicula](img_doc/cap2/_4/renta.jpg)
<br>Interfaz renta de película

---

*La figura 2.4.7 muestra la interfaz de "mis películas"*

![interfaz del perfil (mis peliculas)](img_doc/cap2/_4/misPeliculas.jpg)
<br>Interfaz del perfil (mis películas)

---

*La figura 2.4.8 muestra la interfaz de película rentada*

![interfaz pelicula rentada](img_doc/cap2/_4/peliculaRentada.jpg)
<br>Interfaz película rentada

---

*La figura 2.4.9 muestra la interfaz de "mis listas"*

![interfaz mis listas](img_doc/cap2/_4/misListas.jpg)
<br>Interfaz mis listas

---

*La figura 2.4.10 muestra la interfaz de crear lista*

![interfaz crear lista](img_doc/cap2/_4/crearLista.jpg)
<br>Interfaz crear lista

---

*La figura 2.4.11 muestra la interfaz de lista creada*

![interfaz lista creada](img_doc/cap2/_4/listaCreada.jpg)
<br>Interfaz lista creada

---

*La figura 2.4.12 muestra la interfaz de editar lista*

![interfaz editar lista](img_doc/cap2/_4/editarLista.jpg)
<br>Interfaz editar lista

---

*La figura 2.4.13 muestra la interfaz de eliminar lista*

![interfaz eliminar lista](img_doc/cap2/_4/eliminarLista.jpg)
<br>Interfaz eliminar lista

---

*La figura 2.4.14 muestra la interfaz de "mi perfil"*

![interfaz de mi perfil](img_doc/cap2/_4/perfil.jpg)
<br>Interfaz de mi perfil