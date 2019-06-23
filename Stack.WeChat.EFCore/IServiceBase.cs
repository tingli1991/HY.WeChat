using Stack.WeChat.DataContract.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stack.WeChat.EFCore
{
    /// <summary>
    /// 服务处理基类
    /// </summary>
    public interface IServiceBase
    {
        IQueryable<T> GetQueryable<T>() where T : class;
        T FirstOrDefault<T>(Expression<Func<T, bool>> where = null) where T : class;
        Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> where = null) where T : class;
        T First<T>(Expression<Func<T, bool>> where = null) where T : class;
        Task<T> FirstAsync<T>(Expression<Func<T, bool>> where = null) where T : class;
        T LastOrDefault<T>(Expression<Func<T, bool>> where = null) where T : class;
        Task<T> LastOrDefaultAsync<T>(Expression<Func<T, bool>> where = null) where T : class;
        List<T> GetList<T>(Expression<Func<T, bool>> where = null, bool isTracking = true) where T : class;
        Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> where = null, bool isTracking = true) where T : class;
        T GetByKey<T>(params object[] keyVaules) where T : class;
        Task<T> GetByKeyAsync<T>(params object[] keyVaules) where T : class;

        int Insert<T>(T entity) where T : class;
        Task<long> InsertAsync<T>(T entity) where T : class;
        int Insert<T>(List<T> entities) where T : class;
        Task<long> InsertAsync<T>(List<T> entities) where T : class;

        int Delete<T>(T entity) where T : class;
        Task<long> DeleteAsync<T>(T entity) where T : class;
        int Delete<T>(List<T> entities) where T : class;
        Task<long> DeleteAsync<T>(List<T> entities) where T : class;
        int Delete<T>(Expression<Func<T, bool>> where) where T : class;
        Task<long> DeleteAsync<T>(Expression<Func<T, bool>> where) where T : class;

        int Update<T>(T entity) where T : class;
        Task<int> UpdateAsync<T>(T entity) where T : class;
        int Update<T>(List<T> entities) where T : class;
        Task<int> UpdateAsync<T>(List<T> entities) where T : class;
        int Update<T>(Expression<Func<T, bool>> where) where T : class;
        Task<int> UpdateAsync<T>(Expression<Func<T, bool>> where) where T : class;

        int Count<T>(Expression<Func<T, bool>> where = null) where T : class;
        Task<int> CountAsync<T>(Expression<Func<T, bool>> where = null) where T : class;
        long LongCount<T>(Expression<Func<T, bool>> where = null) where T : class;
        Task<long> LongCountAsync<T>(Expression<Func<T, bool>> where = null) where T : class;

        ContractPageResult<T> GetPageList<T>(Expression<Func<T, bool>> where = null, int pageIndex = 1, int pageSize = 10) where T : class;
        Task<ContractPageResult<T>> GetPageListAsync<T>(Expression<Func<T, bool>> where = null, int pageIndex = 1, int pageSize = 10) where T : class;
    }
}