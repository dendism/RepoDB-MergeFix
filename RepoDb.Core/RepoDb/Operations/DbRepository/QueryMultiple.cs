﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace RepoDb
{
    public partial class DbRepository<TDbConnection> : IDisposable
        where TDbConnection : DbConnection, new()
    {
        #region QueryMultiple<TEntity>

        #region T1, T2

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(object what1,
            object what2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(what1: what1,
                    what2: what2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(QueryField where1,
            QueryField where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(QueryGroup where1,
            QueryGroup where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(object what1,
            object what2,
            object what3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(what1: what1,
                    what2: what2,
                    what3: what3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(QueryField where1,
            QueryField where2,
            QueryField where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(object what1,
            object what2,
            object what3,
            object what4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(object what1,
            object what2,
            object what3,
            object what4,
            object what5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    what5: what5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            Expression<Func<T5, bool>> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            QueryField where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<QueryField> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            QueryGroup where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(object what1,
            object what2,
            object what3,
            object what4,
            object what5,
            object what6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    what5: what5,
                    what6: what6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            Expression<Func<T5, bool>> where5,
            Expression<Func<T6, bool>> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            QueryField where5,
            QueryField where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<QueryField> where5,
            IEnumerable<QueryField> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            QueryGroup where5,
            QueryGroup where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6, T7

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="what7">The dynamic query expression or the key value to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(object what1,
            object what2,
            object what3,
            object what4,
            object what5,
            object what6,
            object what7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    what5: what5,
                    what6: what6,
                    what7: what7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            Expression<Func<T5, bool>> where5,
            Expression<Func<T6, bool>> where6,
            Expression<Func<T7, bool>> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            QueryField where5,
            QueryField where6,
            QueryField where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<QueryField> where5,
            IEnumerable<QueryField> where6,
            IEnumerable<QueryField> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            QueryGroup where5,
            QueryGroup where6,
            QueryGroup where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #endregion

        #region QueryMultipleAsync<TEntity>

        #region T1, T2

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(object what1,
            object what2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(what1: what1,
                    what2: what2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(QueryField where1,
            QueryField where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(QueryGroup where1,
            QueryGroup where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(where1: where1,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(object what1,
            object what2,
            object what3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(what1: what1,
                    what2: what2,
                    what3: what3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(QueryField where1,
            QueryField where2,
            QueryField where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(where1: where1,
                    where2: where2,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(object what1,
            object what2,
            object what3,
            object what4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(object what1,
            object what2,
            object what3,
            object what4,
            object what5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    what5: what5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            Expression<Func<T5, bool>> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            QueryField where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<QueryField> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            QueryGroup where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(object what1,
            object what2,
            object what3,
            object what4,
            object what5,
            object what6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    what5: what5,
                    what6: what6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            Expression<Func<T5, bool>> where5,
            Expression<Func<T6, bool>> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            QueryField where5,
            QueryField where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<QueryField> where5,
            IEnumerable<QueryField> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            QueryGroup where5,
            QueryGroup where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6, T7

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="what7">The dynamic query expression or the key value to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(object what1,
            object what2,
            object what3,
            object what4,
            object what5,
            object what6,
            object what7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(what1: what1,
                    what2: what2,
                    what3: what3,
                    what4: what4,
                    what5: what5,
                    what6: what6,
                    what7: what7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(Expression<Func<T1, bool>> where1,
            Expression<Func<T2, bool>> where2,
            Expression<Func<T3, bool>> where3,
            Expression<Func<T4, bool>> where4,
            Expression<Func<T5, bool>> where5,
            Expression<Func<T6, bool>> where6,
            Expression<Func<T7, bool>> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(QueryField where1,
            QueryField where2,
            QueryField where3,
            QueryField where4,
            QueryField where5,
            QueryField where6,
            QueryField where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(IEnumerable<QueryField> where1,
            IEnumerable<QueryField> where2,
            IEnumerable<QueryField> where3,
            IEnumerable<QueryField> where4,
            IEnumerable<QueryField> where5,
            IEnumerable<QueryField> where6,
            IEnumerable<QueryField> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(QueryGroup where1,
            QueryGroup where2,
            QueryGroup where3,
            QueryGroup where4,
            QueryGroup where5,
            QueryGroup where6,
            QueryGroup where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(where1: where1,
                    where2: where2,
                    where3: where3,
                    where4: where4,
                    where5: where5,
                    where6: where6,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #endregion

        #region QueryMultiple(TableName)

        #region TEntity

        #region T1, T2

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
        /// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
        /// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>> QueryMultiple<T1, T2>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>> QueryMultiple<T1, T2, T3>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>
            QueryMultiple<T1, T2, T3, T4>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            string tableName5,
            object what5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    tableName5: tableName5,
                    what5: what5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            string tableName5,
            Expression<Func<T5, bool>> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            string tableName5,
            QueryField where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            string tableName5,
            IEnumerable<QueryField> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>
            QueryMultiple<T1, T2, T3, T4, T5>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            string tableName5,
            QueryGroup where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            string tableName5,
            object what5,
            string tableName6,
            object what6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    tableName5: tableName5,
                    what5: what5,
                    tableName6: tableName6,
                    what6: what6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            string tableName5,
            Expression<Func<T5, bool>> where5,
            string tableName6,
            Expression<Func<T6, bool>> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            string tableName5,
            QueryField where5,
            string tableName6,
            QueryField where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            string tableName5,
            IEnumerable<QueryField> where5,
            string tableName6,
            IEnumerable<QueryField> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>
            QueryMultiple<T1, T2, T3, T4, T5, T6>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            string tableName5,
            QueryGroup where5,
            string tableName6,
            QueryGroup where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6, T7

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="what7">The dynamic query expression or the key value to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            string tableName5,
            object what5,
            string tableName6,
            object what6,
            string tableName7,
            object what7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    tableName5: tableName5,
                    what5: what5,
                    tableName6: tableName6,
                    what6: what6,
                    tableName7: tableName7,
                    what7: what7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            string tableName5,
            Expression<Func<T5, bool>> where5,
            string tableName6,
            Expression<Func<T6, bool>> where6,
            string tableName7,
            Expression<Func<T7, bool>> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            string tableName5,
            QueryField where5,
            string tableName6,
            QueryField where6,
            string tableName7,
            QueryField where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            string tableName5,
            IEnumerable<QueryField> where5,
            string tableName6,
            IEnumerable<QueryField> where6,
            string tableName7,
            IEnumerable<QueryField> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>
            QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            string tableName5,
            QueryGroup where5,
            string tableName6,
            QueryGroup where6,
            string tableName7,
            QueryGroup where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return connection.QueryMultiple<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #endregion

        #region Dynamic

        #endregion

        #endregion

        #region QueryMultipleAsync(TableName)

        #region TEntity

        #region T1, T2

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
        /// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
        /// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
        /// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
        /// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 2 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 2 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>>> QueryMultipleAsync<T1, T2>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            int? top2 = 0,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            string hints2 = null,
            string cacheKey2 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    top2: top2,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 3 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 3 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>>> QueryMultipleAsync<T1, T2, T3>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 4 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 4 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>>>
            QueryMultipleAsync<T1, T2, T3, T4>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            string tableName5,
            object what5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    tableName5: tableName5,
                    what5: what5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            string tableName5,
            Expression<Func<T5, bool>> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            string tableName5,
            QueryField where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            string tableName5,
            IEnumerable<QueryField> where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 5 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 5 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            string tableName5,
            QueryGroup where5,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            string tableName5,
            object what5,
            string tableName6,
            object what6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    tableName5: tableName5,
                    what5: what5,
                    tableName6: tableName6,
                    what6: what6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            string tableName5,
            Expression<Func<T5, bool>> where5,
            string tableName6,
            Expression<Func<T6, bool>> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            string tableName5,
            QueryField where5,
            string tableName6,
            QueryField where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            string tableName5,
            IEnumerable<QueryField> where5,
            string tableName6,
            IEnumerable<QueryField> where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 6 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 6 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            string tableName5,
            QueryGroup where5,
            string tableName6,
            QueryGroup where6,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #region T1, T2, T3, T4, T5, T6, T7

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="what1">The dynamic query expression or the key value to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="what2">The dynamic query expression or the key value to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="what3">The dynamic query expression or the key value to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="what4">The dynamic query expression or the key value to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="what5">The dynamic query expression or the key value to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="what6">The dynamic query expression or the key value to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="what7">The dynamic query expression or the key value to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            object what1,
            string tableName2,
            object what2,
            string tableName3,
            object what3,
            string tableName4,
            object what4,
            string tableName5,
            object what5,
            string tableName6,
            object what6,
            string tableName7,
            object what7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                    what1: what1,
                    tableName2: tableName2,
                    what2: what2,
                    tableName3: tableName3,
                    what3: what3,
                    tableName4: tableName4,
                    what4: what4,
                    tableName5: tableName5,
                    what5: what5,
                    tableName6: tableName6,
                    what6: what6,
                    tableName7: tableName7,
                    what7: what7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            Expression<Func<T1, bool>> where1,
            string tableName2,
            Expression<Func<T2, bool>> where2,
            string tableName3,
            Expression<Func<T3, bool>> where3,
            string tableName4,
            Expression<Func<T4, bool>> where4,
            string tableName5,
            Expression<Func<T5, bool>> where5,
            string tableName6,
            Expression<Func<T6, bool>> where6,
            string tableName7,
            Expression<Func<T7, bool>> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            QueryField where1,
            string tableName2,
            QueryField where2,
            string tableName3,
            QueryField where3,
            string tableName4,
            QueryField where4,
            string tableName5,
            QueryField where5,
            string tableName6,
            QueryField where6,
            string tableName7,
            QueryField where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            IEnumerable<QueryField> where1,
            string tableName2,
            IEnumerable<QueryField> where2,
            string tableName3,
            IEnumerable<QueryField> where3,
            string tableName4,
            IEnumerable<QueryField> where4,
            string tableName5,
            IEnumerable<QueryField> where5,
            string tableName6,
            IEnumerable<QueryField> where6,
            string tableName7,
            IEnumerable<QueryField> where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        /// <summary>
        /// Query the data as multiple resultsets from the table based on the given 7 target types in an asynchronous way.
        /// </summary>
        /// <typeparam name="T1">The first target type.</typeparam>
        /// <typeparam name="T2">The second target type.</typeparam>
        /// <typeparam name="T3">The third target type.</typeparam>
        /// <typeparam name="T4">The fourth target type.</typeparam>
        /// <typeparam name="T5">The fifth target type.</typeparam>
        /// <typeparam name="T6">The sixth target type.</typeparam>
        /// <typeparam name="T7">The seventh target type.</typeparam>
        /// <param name="tableName1">The name of the target table (for T1).</param>
		/// <param name="where1">The query expression to be used (for T1).</param>
        /// <param name="tableName2">The name of the target table (for T2).</param>
		/// <param name="where2">The query expression to be used (for T2).</param>
        /// <param name="tableName3">The name of the target table (for T3).</param>
		/// <param name="where3">The query expression to be used (for T3).</param>
        /// <param name="tableName4">The name of the target table (for T4).</param>
		/// <param name="where4">The query expression to be used (for T4).</param>
        /// <param name="tableName5">The name of the target table (for T5).</param>
		/// <param name="where5">The query expression to be used (for T5).</param>
        /// <param name="tableName6">The name of the target table (for T6).</param>
		/// <param name="where6">The query expression to be used (for T6).</param>
        /// <param name="tableName7">The name of the target table (for T7).</param>
		/// <param name="where7">The query expression to be used (for T7).</param>
        /// <param name="fields1">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy1">The order definition of the fields to be used (for T1).</param>
        /// <param name="top1">The number of rows to be returned (for T1).</param>
        /// <param name="hints1">The table hints to be used (for T1).</param>
        /// <param name="cacheKey1">The key to the cache item 1. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields2">The mapping list of <see cref="Field"/> objects to be used (for T1).</param>
		/// <param name="orderBy2">The order definition of the fields to be used (for T2).</param>
        /// <param name="top2">The number of rows to be returned (for T2).</param>
        /// <param name="hints2">The table hints to be used (for T2).</param>
        /// <param name="cacheKey2">The key to the cache item 2. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields3">The mapping list of <see cref="Field"/> objects to be used (for T3).</param>
		/// <param name="orderBy3">The order definition of the fields to be used (for T3).</param>
        /// <param name="top3">The number of rows to be returned (for T3).</param>
        /// <param name="hints3">The table hints to be used (for T3).</param>
        /// <param name="cacheKey3">The key to the cache item 3. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields4">The mapping list of <see cref="Field"/> objects to be used (for T4).</param>
		/// <param name="orderBy4">The order definition of the fields to be used (for T4).</param>
        /// <param name="top4">The number of rows to be returned (for T4).</param>
        /// <param name="hints4">The table hints to be used (for T4).</param>
        /// <param name="cacheKey4">The key to the cache item 4. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields5">The mapping list of <see cref="Field"/> objects to be used (for T5).</param>
		/// <param name="orderBy5">The order definition of the fields to be used (for T5).</param>
        /// <param name="top5">The number of rows to be returned (for T5).</param>
        /// <param name="hints5">The table hints to be used (for T5).</param>
        /// <param name="cacheKey5">The key to the cache item 5. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields6">The mapping list of <see cref="Field"/> objects to be used (for T6).</param>
		/// <param name="orderBy6">The order definition of the fields to be used (for T6).</param>
        /// <param name="top6">The number of rows to be returned (for T6).</param>
        /// <param name="hints6">The table hints to be used (for T6).</param>
        /// <param name="cacheKey6">The key to the cache item 6. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="fields7">The mapping list of <see cref="Field"/> objects to be used (for T7).</param>
		/// <param name="orderBy7">The order definition of the fields to be used (for T7).</param>
        /// <param name="top7">The number of rows to be returned (for T7).</param>
        /// <param name="hints7">The table hints to be used (for T7).</param>
        /// <param name="cacheKey7">The key to the cache item 7. By setting this argument, it will return the item from the cache if present, otherwise it will query the database. This will only work if the 'cache' argument is set.</param>
        /// <param name="transaction">The transaction to be used.</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> object to be used during the asynchronous operation.</param>
        /// <returns>A tuple of 7 enumerable target data entity types.</returns>
        public async Task<Tuple<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>, IEnumerable<T7>>>
            QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(string tableName1,
            QueryGroup where1,
            string tableName2,
            QueryGroup where2,
            string tableName3,
            QueryGroup where3,
            string tableName4,
            QueryGroup where4,
            string tableName5,
            QueryGroup where5,
            string tableName6,
            QueryGroup where6,
            string tableName7,
            QueryGroup where7,
            IEnumerable<Field> fields1 = null,
            IEnumerable<OrderField> orderBy1 = null,
            int? top1 = 0,
            string hints1 = null,
            string cacheKey1 = null,
            IEnumerable<Field> fields2 = null,
            IEnumerable<OrderField> orderBy2 = null,
            int? top2 = 0,
            string hints2 = null,
            string cacheKey2 = null,
            IEnumerable<Field> fields3 = null,
            IEnumerable<OrderField> orderBy3 = null,
            int? top3 = 0,
            string hints3 = null,
            string cacheKey3 = null,
            IEnumerable<Field> fields4 = null,
            IEnumerable<OrderField> orderBy4 = null,
            int? top4 = 0,
            string hints4 = null,
            string cacheKey4 = null,
            IEnumerable<Field> fields5 = null,
            IEnumerable<OrderField> orderBy5 = null,
            int? top5 = 0,
            string hints5 = null,
            string cacheKey5 = null,
            IEnumerable<Field> fields6 = null,
            IEnumerable<OrderField> orderBy6 = null,
            int? top6 = 0,
            string hints6 = null,
            string cacheKey6 = null,
            IEnumerable<Field> fields7 = null,
            IEnumerable<OrderField> orderBy7 = null,
            int? top7 = 0,
            string hints7 = null,
            string cacheKey7 = null,
            IDbTransaction transaction = null,
            CancellationToken cancellationToken = default)
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
            where T5 : class
            where T6 : class
            where T7 : class
        {
            // Create a connection
            var connection = (transaction?.Connection ?? CreateConnection());

            try
            {
                // Call the method
                return await connection.QueryMultipleAsync<T1, T2, T3, T4, T5, T6, T7>(tableName1: tableName1,
                    where1: where1,
                    tableName2: tableName2,
                    where2: where2,
                    tableName3: tableName3,
                    where3: where3,
                    tableName4: tableName4,
                    where4: where4,
                    tableName5: tableName5,
                    where5: where5,
                    tableName6: tableName6,
                    where6: where6,
                    tableName7: tableName7,
                    where7: where7,
                    fields1: fields1,
                    orderBy1: orderBy1,
                    top1: top1,
                    hints1: hints1,
                    cacheKey1: cacheKey1,
                    fields2: fields2,
                    orderBy2: orderBy2,
                    top2: top2,
                    hints2: hints2,
                    cacheKey2: cacheKey2,
                    fields3: fields3,
                    orderBy3: orderBy3,
                    top3: top3,
                    hints3: hints3,
                    cacheKey3: cacheKey3,
                    fields4: fields4,
                    orderBy4: orderBy4,
                    top4: top4,
                    hints4: hints4,
                    cacheKey4: cacheKey4,
                    fields5: fields5,
                    orderBy5: orderBy5,
                    top5: top5,
                    hints5: hints5,
                    cacheKey5: cacheKey5,
                    fields6: fields6,
                    orderBy6: orderBy6,
                    top6: top6,
                    hints6: hints6,
                    cacheKey6: cacheKey6,
                    fields7: fields7,
                    orderBy7: orderBy7,
                    top7: top7,
                    hints7: hints7,
                    cacheKey7: cacheKey7,
                    cacheItemExpiration: CacheItemExpiration,
                    commandTimeout: CommandTimeout,
                    transaction: transaction,
                    cache: Cache,
                    trace: Trace,
                    statementBuilder: StatementBuilder,
                    cancellationToken: cancellationToken);
            }
            finally
            {
                // Dispose the connection
                DisposeConnectionForPerCall(connection, transaction);
            }
        }

        #endregion

        #endregion

        #region Dynamic

        #endregion

        #endregion
    }
}
