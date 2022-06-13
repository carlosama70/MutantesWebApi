# MutantesWebApi
#Este proyecto esta desarrollado para trabajar con Mocrosoft.Net core 6.0.5 y una base de datos Sql server.
#Trabajar preferiblemente con Visual estudio 2022
#Instalar el Framework Mocrosoft.Net core 6.0.5
#instalar sql server puede ser la version express Edition.
#instalar un cliente de administraicon de Sql server puede ser Microsoft sql server management studio
#restaurar la base de datos que se encuentra en la ruta del repositorio:  /BasedeDatos/MUTANTE.bak
# ajustar la cadena de conexion de la base de datos donde se restauro la base de datos.
# ejecutar el archivo PropertyWebApi.sln con visual studio 2022
# desde visual estudio ejecutar el proyecto PropertyWebApi
# desde Postman o una herramienta similar para realizar peticiones a servicios y realizar ingreso de mutantes o humanos a la url: https://localhost:"aqui puerto de si host local"/api/Mutante/mutant
# desde Postman o una herramienta similar para realizar peticiones a servicios y realizar consulta de estadisticas a la url: https://localhost:"aqui puerto de si host local"/api/Mutante/stats
#el formato para ingreso de mutantes es: { "dna":["ATGCGA","CAGTGC","TTATGT","AGAAGG","CCCCTA","TCACTG"] }
#LA API TAMBIEN ESTA DESPONIBLE COMO UN SERVICIO EN AZURE CLOUD EN LAS SIGUIENTES URls:
#para el registro de mutantes y humanos median post : https://propertywebapi20220612202042.azurewebsites.net/api/Mutante/mutant
#para consulta de estadisticas:  https://propertywebapi20220612202042.azurewebsites.net/api/Mutante/stats
#el proyecto viene con un proyecto de pruebas unitarias ejecutadas al 100%
#NOTA:
#Cuando se registra un mutante la API api guarda en la base de datos y retorna status code 200, sin registros repetidos.
#Cuando se registra un humano la API guearda en la base de datos sin repetidos  y retorna error 500 asi como para cualquier cotra validacion que no permita el registro. 
