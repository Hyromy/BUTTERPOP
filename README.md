![uttec](https://becas.news/wp-content/uploads/logo-universidad-tecnologica-de-tecamac.webp)

# <mark>[NOMBRE AÚN POR DEFINIR]</mark><br>INTEGRAGORA II<br>REPORTE TÉCNICO
## TÉCNICO SUPERIOR UNIVERSITARIO EN TECNOLOGÍAS DE LA INFORMACIÓN ÁREA DESARROLLO DE SOFTWARE MULTIPLATAFORMA

*P R E S E N T A*

**ANDREA DOMÍNGEZ ZENTENO**

**EMMANUEL GARCIA CAPOTE**

**JESÚS MÍGUEL ROSALES MURILLO**

**JOEL GONZÁLEZ CRUZ**

**JOSÉ JULÁN MARTÍNEZ DE LA CRUZ**

---

ASESORA DE LA ORGANIZACIÓN: DRA. MORAMAY RAMÍREZ HERNÁNDEZ

ASESORA ACADÉMICA: MTRA. SILVIA MURILLO PAZARÁN

ORGANIZACIÓN: "[AÚN POR DEFINIR]"

GENERACIÓN: ENERO 2023-DICIEMBRE 2023

CUATRIMESTRE DE TÉRMINO: SEPTIEMBRE-DICIEMBRE 2024

---
## ÍNDICE

## INTRODUCCIÓN
El área de gestión de cines se ocupa de administrar todos los aspectos relacionados con la operación y funcionamiento de los cines, como el registro de las películas que se transmitirán, y la programación de horarios. Además, se encarga de gestionar la venta de boletos, garantizando un control eficiente de la cantidad de asientos disponibles en cada sala.

Respecto a estas operaciones, existe un problema relacionado con la falta de un sistema que integre y automatice de manera simple y eficiente la gestión de todas las actividades en un cine. La implementación de una aplicación multiplataforma estable y fácil de usar podría simplificar considerablemente el trabajo en los cines.

Debido a la necesidad de desarrollar una aplicación multiplataforma sencilla para gestionar eficientemente los cines, la participación de desarrolladores técnicos universitarios en el área de desarrollo de software multiplataforma será la adecuada, ya que poseen los conocimientos necesarios en diseño, codificación, almacenamiento y manejo de datos para desarrollar la aplicación de manera efectiva y brindar una solución a la manera en que los cinemas gestionan sus servicios.

El presente documento tiene como objetivo mostrar, explicar, y analizar el proceso de realización de la app. Está dividido en tres capítulos de gran importancia, ya que cada uno proporciona información detallada sobre cómo se desarrollará la aplicación multiplataforma.

El capítulo uno se enfoca en la recolección y refinamiento de los requisitos sugeridos por el cliente. Esto incluye identificar y comprender sus necesidades, establecer los roles de usuario para la aplicación, y definir los requerimientos funcionales y no funcionales del sistema. Esta sección servirá como base para determinar los requerimientos de software y hardware necesarios para la realización de la aplicación. Además, se presentarán los diagramas de caso de uso, secuencia y actividad para visualizar el funcionamiento del sistema y la interacción de los usuarios con cada una de las actividades de este.

En el capítulo dos se aborda el diseño y desarrollo del proyecto. Aquí se diseñará la base de datos con las tablas necesarias para gestionar cada parte del cinema, como películas, clientes, funciones, salas, administradores, etc. También se creará un diccionario de datos y se diseñarán las pruebas necesarias para asegurar el correcto funcionamiento del sistema. Además, se realizará el maquetado de cada una de las interfaces.

Finalmente, el capítulo tres se centra en la implementación y pruebas de la aplicación. Se documentará todo lo relacionado con las interfaces diseñadas en el capítulo dos y se llevarán a cabo las pruebas para garantizar el funcionamiento adecuado del sistema.

## OBJETIVOS

## PROGRAMA Y CRONOGRAMA

## MARCO TEÓRICO

## METODOLOGÍA

### CAPITULO 1 RECOLECCIÓN Y REFINAMIENTO DE REQUISITOS
#### 1.1 Nececidades del cliente
Los cines necesitan una aplicación multiplataforma que abarque tanto la gestión interna como la interacción con los usuarios. Por lo que proponen que la misma cuente con dos interfaces clave para lograr esto. 

La primera interfaz está destinada a administradores y superadministradores. Permite la gestión eficiente de las actividades del cine, incluyendo la cartelera de películas. Los administradores pueden introducir información como la imagen relacionada a la película, el género, duración, título, clasificación, y programación de horarios. También gestionan las salas y la disponibilidad de asientos, controlando los boletos vendidos para asegurar un adecuado manejo de la capacidad de las salas. Los boletos contienen el titulo de la película, sala, hora y precio.

La segunda interfaz está diseñada para mejorar la experiencia de los usuarios. Permitiéndoles registrarse, consultar la cartelera de películas, los horarios de proyección, y la compra de boletos en línea de manera fácil y conveniente.

El acceso a ambas interfaces dependen de un mismo login, sin embargo, para acceder como administradores deben hacerlo por medio de usuarios previamente creados de manera manual por los superadministradores. 