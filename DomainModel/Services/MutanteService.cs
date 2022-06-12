using DomainModel.DataTransfer;
using DomainModel.Entities;
using DomainModel.Interfaces.Services;
using DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Services
{
    public class MutanteService: ServiceBase, IMutanteService
    {
        private int _cantColumnas = 0;
        private int _cantFilas = 0;
        private String[,] _adns ;
        private const string _caracteresValidos = "ATCG";

        /// <summary>
        /// Funcion que define si es un mutante
        /// </summary>
        /// <param name="dnaEntrada"></param>
        /// <returns></returns>
        public async Task<bool> esMutante(Dna dnaEntrada) 
        {

            this._cantFilas = dnaEntrada.dna.Length;
            this._cantColumnas = dnaEntrada.dna[0].Length;
            int contadorFilas = 0;
            int contadorColumnas = 0;
            string[,] adns = new string[this._cantFilas, this._cantColumnas];
            Adn adn = new Adn();
            int fila = 0;
            int columna = 0;          
            this._adns = adns;
            StringBuilder codigoAdn= new StringBuilder();
            IList<Adn> adnsExiste = new List<Adn>();

            //toma los datos en el formato de entreda de la peticion y lo convierte en una matriz 
            foreach (string dnaMutante in dnaEntrada.dna)
            {
                contadorColumnas = 0;
                codigoAdn.Append(dnaMutante);
                foreach (char letra in dnaMutante)
                {
                    if (_caracteresValidos.IndexOf(letra) != -1)
                    { 
                        adns[contadorFilas, contadorColumnas] = letra.ToString();
                        contadorColumnas++;
                    }
                    else
                    {
                        //si no pertenece al grupo de caracteres valido
                        return false;
                    }
                }
                contadorFilas++;
            }


            //rrecorre las filas de la matriz en busca de genes mutante
            while (fila < this._cantFilas) 
            {
                columna = 0;
                //rrecorre las columnas de la matriz por cada fila em busqueda de genes mutantes
                while (columna < this._cantColumnas)
                {
                    if (esMutantePosicion( adns[fila,columna],fila,columna ) ) 
                    {
                        //solo se registra un codigo genetico unico
                        adnsExiste = _AdnRepository.GetAll(adn => adn.CodigoAdn == codigoAdn.ToString(), "");

                        if (adnsExiste.Count == 0)
                        {                            
                            adn.EsMutante = true;
                            adn.CodigoAdn = codigoAdn.ToString();
                            _AdnRepository.Add(adn);
                            _AdnRepository.SaveChanges();
                        }
                        return true;
                    }
                    columna++;
                }

                fila++;
            }

            //solo se registra un codigo genetico unico
            adnsExiste = _AdnRepository.GetAll(adn => adn.CodigoAdn == codigoAdn.ToString(), "");

            if (adnsExiste.Count == 0)
            {
                adn.EsMutante = false;
                adn.CodigoAdn = codigoAdn.ToString();
                _AdnRepository.Add(adn);
                _AdnRepository.SaveChanges();
            }
            return false;
        }

        public bool esMutantePosicion(string valor, int fila,int columna )            
        {
           return  esMutantePosicionHorizontal(valor, fila,columna)?true:esMutantePosicionVertical(valor, fila, columna)?true: esMutantePosicionOblicua(valor, fila, columna) ;               
        }

        public bool esMutantePosicionHorizontal(string valor, int fila, int columna)
        {
            int contadorColumna = columna + 1 ;
            int contadorGenes = 0;
            //recorre las columnas de la fila actual verificando si tiene letras consecutivas
            while ( contadorColumna < this._cantColumnas ) 
            {
                if (this._adns[fila,contadorColumna].Equals(valor) ) 
                {
                    contadorGenes++;
                    
                    if (contadorGenes == 3) 
                    {
                        return true;
                    }
                }
                else 
                {
                    return false;
                }
                contadorColumna++;
            }
 
            return false;
        }

        public bool esMutantePosicionVertical(string valor, int fila, int columna)
        {
            int contadorFila = fila + 1;
            int contadorGenes = 0;
            //recorre las columnas de la matriz actual verificando si tiene letras consecutivas
            while (contadorFila < this._cantFilas )
            {
                if (this._adns[contadorFila, columna ].Equals(valor))
                {
                    contadorGenes++;

                    if (contadorGenes == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
                contadorFila++;
            }

            return false;
        }

        public bool esMutantePosicionOblicua(string valor, int fila, int columna) 
        {
            return esMutantePosicionOblicuaDerecha(valor, fila, columna)?true:esMutantePosicionOblicuaIzquierda(valor, fila, columna);
        }

        /// <summary>
        /// determina si es mutante verificando diagonal a la derecha de la posicion actual de la matriz
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public bool esMutantePosicionOblicuaDerecha(string valor, int fila, int columna)
        {
            int contadorFila = fila;
            int contadorColumna = columna;
            int contadoriteraciones = 0;
            int contadorGenes = 0 ;
            int iteraciones = this._cantColumnas - columna ;
            

            //recorre las columnas de la matriz actual verificando si tiene letras consecutivas
            while (contadoriteraciones < iteraciones )
            {
                //incremente en uno fila y columna conformando la secuencia horizontal a la derecha
                contadorFila++;
                contadorColumna++;

                if (contadorFila < this._cantFilas && contadorColumna < this._cantColumnas && this._adns[contadorFila, contadorColumna].Equals(valor) )
                {
                    contadorGenes++;

                    if (contadorGenes == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

                contadoriteraciones++;
            }

            return false;
        }

        /// <summary>
        /// determina si es mutante verificando diagonal a la derecha de la posicion actual de la matriz
        /// </summary>
        /// <param name="valor"></param>
        /// <param name="fila"></param>
        /// <param name="columna"></param>
        /// <returns></returns>
        public bool esMutantePosicionOblicuaIzquierda(string valor, int fila, int columna)
        {
            int contadorFila = fila;
            int contadorColumna = columna;
            int contadoriteraciones = 0;
            int contadorGenes = 0;
           


            //recorre las columnas de la matriz actual verificando si tiene letras consecutivas
            while (contadoriteraciones < columna )
            {
                //incremente en uno fila y columna conformando la secuencia horizontal a la derecha
                contadorFila++;
                contadorColumna--;

                if (contadorFila < this._cantFilas &&  contadorColumna < this._cantColumnas && this._adns[contadorFila, contadorColumna].Equals(valor))
                {
                    contadorGenes++;

                    if (contadorGenes == 3)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }

                contadoriteraciones++;
            }

            return false;
        }

        /// <summary>
        /// obtiene datos de la base de datos y calcula estadisticas
        /// </summary>
        /// <returns></returns>
        public Stats estadisticas() 
        {
            Stats estadisticas = new Stats();
            int cantidadMutantes = 0;
            int cantidadHumanos = 0;
            double ratio = 0;

            cantidadMutantes = _AdnRepository.GetAll(adn => adn.EsMutante.Equals(true) , "").Count;
            cantidadHumanos = _AdnRepository.GetAll(adn => adn.EsMutante.Equals(false), "").Count;
            ratio = cantidadHumanos == 0 ? 0 : cantidadMutantes == 0 ? 0 : cantidadMutantes % cantidadHumanos;

            estadisticas.Count_human_dna = cantidadHumanos;
            estadisticas.Count_mutant_dna = cantidadMutantes;
            estadisticas.Ratio = ratio;

            return estadisticas;

        }

    }
}
