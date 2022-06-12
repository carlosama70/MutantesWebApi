using DomainModel.DataTransfer;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Interfaces.Services
{
   /// <summary>
   /// maneja la logica de negocio de la aplicacion y permite establecer un puerto para implementar un adaptador
   /// en arquitectura hexagonal.
   /// </summary>
    public interface IMutanteService
    {
        /// <summary>
        /// Identifica si adn es mutante
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
       Task<bool> esMutante(Dna dnaEntrada);
        /// <summary>
        /// identifica si es un mutante a partir de la posicion en la matriz
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
       bool esMutantePosicion(string valor, int fila, int columna);
        /// <summary>
        /// identifica si es un mutante en una fila de la matriz
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
       bool esMutantePosicionHorizontal(string valor, int fila, int columna);
        /// <summary>
        /// identifica si es un mutante en una columna de la matriz
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
       bool esMutantePosicionVertical(string valor, int fila, int columna);
        /// <summary>
        /// identifica si es un mutante en posicion oblicua de la matriz hacia la derecha
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        bool esMutantePosicionOblicuaDerecha(string valor, int fila, int columna);
        /// <summary>
        ///  /// identifica si es un mutante en posicion oblicua de la matriz hacia la ixquierda
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        bool esMutantePosicionOblicuaIzquierda(string valor, int fila, int columna);
        /// <summary>
        /// obtiene estadisticas mutantes.
        /// </summary>
        /// <returns></returns>
       Stats estadisticas();

    }    
}
