using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repositories
{
    /// <summary>
    /// manejo de los metodos para realizar operaciones sobre las entidades hacia la base de datos.
    /// Basado en el patron repository, establece tipo de entidad generico que permite utilizar la plantilla de repositorio
    /// y evitar tener un repositorio por cada entidad.
    /// este es un puerti para implemetar adaptador hacias la base de datos
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository <T> where T : class
    {
        /// <summary>
        /// Adiciona un registro de entidad
        /// </summary>
        /// <param name="modelo">tipo generico de una entidad</param>
        void Add(T modelo);

        /// <summary>
        /// Elimina un registro de una entidad
        /// </summary>
        /// <param name="modelo"></param>
        void Remove(T modelo);

        /// <summary>
        /// obtiene un registro de una entidad
        /// </summary>
        /// <param name="id">id unico de la entidad a obtener la data</param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Obtiene un unico registro asi la condicion where filtre varios registros. 
        /// </summary>
        /// <param name="whereCondition">expression lamda para obtencion de datos</param>
        /// <param name="include">Incluye tablas hijas para evitar carga perezosa</param>
        /// <returns></returns>
        T GetSingle(Expression<Func<T, bool>> whereCondition, string include = "");

        /// <summary>
        /// Obtiene todos los registros de la entidad.
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        List<T> GetAll(string include = "");

        /// <summary>
        /// Obtiene registro de una entidad basado en una condicion where
        /// </summary>
        /// <param name="whereCondition">expression lamda para obtencion de datos</param>
        /// <param name="include"></param>
        /// <returns></returns>
        List<T> GetAll(Expression<Func<T, bool>> whereCondition, string include = "");

        /// <summary>
        /// Guardar los datos en la base de datos
        /// </summary>
        void SaveChanges();

    }
}
