using CompanyApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CompanyApp.Core.DataAccess
{
    /// <summary>
    /// Definitions of methods required for database operations.
    /// </summary>
    /// <remarks>
    ///  This interface, which has a generic structure, organizes methods according to the given parameter.
    /// </remarks>
    /// <typeparam name="T">The type used in the methods must be an BaseEntity.</typeparam>
    public interface IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Adds data of type T to the database.
        /// </summary>
        /// <param name="entity">The data to be added to the database.</param>
        /// <returns>Data added to the database.</returns>
        T Add(T entity);

        /// <summary>
        /// Updates data in database.
        /// </summary>
        /// <param name="entity">The data to be updated in the database.</param>
        /// <returns>Updated data in database.</returns>
        T Update(T entity);

        /// <summary>
        /// Delete data in database.
        /// </summary>
        /// <param name="entity">The data to be deleted in the database.</param>
        /// <returns>Deleted data in database.</returns>
        T Delete(T entity);


        /// <summary>
        /// Lists all data of type T in the database.
        /// </summary>
        /// <remarks>
        /// If a filter is used, it lists the data according to the specified filter.
        /// </remarks>
        /// <param name="filter">The filter to be specified when listing the data.</param>
        /// <returns>Data listed in type T.</returns>
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// Lists data of type T according to specific situations.
        /// </summary>
        /// <remarks>
        /// It lists the data coming from the database according to the determined filter. 
        /// Features such as sorting and including other objects can be used during listing.
        /// </remarks>
        /// <param name="predicate">The filter to be specified when listing the data.</param>
        /// <param name="noTracking">Data tracking status.</param>
        /// <param name="orderBy">Sorting the data.</param>
        /// <param name="includes">Include objects in the list.</param>
        /// <returns>Data listed in type T.</returns>
        List<T> GetList(Expression<Func<T, bool>> predicate, bool noTracking = true, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Get T type data from database.
        /// </summary>
        /// <remarks>
        /// Get a data based on a given filter and with included object.
        /// </remarks>
        /// <param name="predicate">Bir veri istenirken belirtilecek filtre.</param>
        /// <param name="noTracking">Data tracking status.</param>
        /// <param name="includes">Include objects in a data.</param>
        /// <returns></returns>
        T Get(Expression<Func<T, bool>> predicate, bool noTracking = true, params Expression<Func<T, object>>[] includes);
    }
}
