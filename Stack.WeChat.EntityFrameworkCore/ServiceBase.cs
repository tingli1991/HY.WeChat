using Microsoft.EntityFrameworkCore;
using Stack.WeChat.DataContract.Result;
using Stack.WeChat.EntityFrameworkCore.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stack.WeChat.EntityFrameworkCore
{
    /// <summary>
    /// 服务基类实现
    /// </summary>
    public class ServiceBase : IServiceBase
    {
        /// <summary>
        /// 数据库上下文
        /// </summary>
        public DbContext Context { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context"></param>
        public ServiceBase(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// 获取查询构造器
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IQueryable<T> GetQueryable<T>() where T : class
        {
            return Context.Set<T>().AsQueryable();
        }

        #region Get操作
        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public T FirstOrDefault<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return Context.Set<T>().FirstOrDefault(where);
            }
            return Context.Set<T>().FirstOrDefault();
        }

        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<T> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return await Context.Set<T>().FirstOrDefaultAsync(where);
            }
            return await Context.Set<T>().FirstOrDefaultAsync();
        }

        /// <summary>
        /// 获取第一条数据
        /// 如果查不数据直接报错，建议try起来
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public T First<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                try
                {
                    return Context.Set<T>().First(where);
                }
                catch
                {
                    return default(T);
                }
            }
            return Context.Set<T>().First();
        }

        /// <summary>
        /// 获取第一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<T> FirstAsync<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                try
                {
                    return await Context.Set<T>().FirstAsync(where);
                }
                catch
                {
                    return default(T);
                }
            }
            return await Context.Set<T>().FirstAsync();
        }

        /// <summary>
        /// 获取第最后一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public T LastOrDefault<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return Context.Set<T>().LastOrDefault(where);
            }
            return Context.Set<T>().LastOrDefault();
        }

        /// <summary>
        /// 获取第最后一条数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<T> LastOrDefaultAsync<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return await Context.Set<T>().LastOrDefaultAsync(where);
            }
            return await Context.Set<T>().LastOrDefaultAsync();
        }

        /// <summary>
        /// 查询多条集合数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public List<T> GetList<T>(Expression<Func<T, bool>> where = null, bool isTracking = true) where T : class
        {
            IQueryable<T> query = Context.Set<T>().AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            if (where == null)
            {
                return query.ToList();
            }
            else
            {
                return query.Where(where).ToList();
            }
        }

        /// <summary>
        /// 查询多条集合数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <param name="isTracking"></param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>> where = null, bool isTracking = true) where T : class
        {
            IQueryable<T> query = Context.Set<T>().AsQueryable();
            if (!isTracking)
            {
                query = query.AsNoTracking();
            }
            if (where == null)
            {
                return await query.ToListAsync();
            }
            else
            {
                return await query.Where(where).ToListAsync();
            }
        }

        /// <summary>
        /// 根据主键获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyVaules"></param>
        /// <returns></returns>
        public T GetByKey<T>(params object[] keyVaules) where T : class
        {
            return Context.Set<T>().Find(keyVaules);
        }

        /// <summary>
        /// 根据主键获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keyVaules"></param>
        /// <returns></returns>
        public async Task<T> GetByKeyAsync<T>(params object[] keyVaules) where T : class
        {
            return await Context.Set<T>().FindAsync(keyVaules);
        }
        #endregion

        #region 新增实体
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual int Insert<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return Context.Insert(entity);
            }
            return 0;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<long> InsertAsync<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return await Context.InsertAsync(entity);
            }
            return 0;
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Insert<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                return Context.Insert<T>(entities);
            }
            return 0;
        }

        /// <summary>
        /// 批量添加实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<long> InsertAsync<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                return await Context.InsertAsync<T>(entities);
            }
            return 0;
        }
        #endregion

        #region 删除实体
        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Delete<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return Context.Delete(entity);
            }
            return 0;
        }

        /// <summary>
        /// 删除一个实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<long> DeleteAsync<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return await Context.DeleteAsync(entity);
            }
            return 0;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Delete<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                return Context.Delete(entities);
            }
            return 0;
        }

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<long> DeleteAsync<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                return await Context.DeleteAsync(entities);
            }
            return 0;
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Delete<T>(Expression<Func<T, bool>> where) where T : class
        {
            return Context.Delete(where);
        }

        /// <summary>
        /// 根据条件删除
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<long> DeleteAsync<T>(Expression<Func<T, bool>> where) where T : class
        {
            return await Context.DeleteAsync(where);
        }
        #endregion

        #region 修改实体
        /// <summary>
        /// 根据实体修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int Update<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return Context.Modifiy(entity);
            }
            return 0;
        }

        /// <summary>
        /// 根据实体修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            if (entity != null)
            {
                return await Context.ModifiyAsync(entity);
            }
            return 0;
        }

        /// <summary>
        /// 根据实体修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public int Update<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                return Context.Modifiy(entities);
            }
            return 0;
        }

        /// <summary>
        /// 根据实体修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync<T>(List<T> entities) where T : class
        {
            if (entities != null && entities.Count > 0)
            {
                return await Context.ModifiyAsync(entities);
            }
            return 0;
        }

        /// <summary>
        /// 根据条件查出实体后修改
        /// </summary>
        /// <param name="where"></param>
        /// <param name="updateExpression"></param>
        /// <returns></returns>
        public int Update<T>(Expression<Func<T, bool>> where) where T : class
        {
            return Context.Modifiy(where);
        }

        /// <summary>
        /// 根据条件查出实体后修改
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<int> UpdateAsync<T>(Expression<Func<T, bool>> where) where T : class
        {
            return await Context.ModifiyAsync(where);
        }
        #endregion

        #region 聚合函数
        /// <summary>
        /// 计算Count值 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public int Count<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return Context.Set<T>().Count(where);
            }
            return Context.Set<T>().Count();
        }

        /// <summary>
        /// 计算Count值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<int> CountAsync<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return await Context.Set<T>().CountAsync(where);
            }
            return await Context.Set<T>().CountAsync();
        }

        /// <summary>
        /// 计算LongCount值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public long LongCount<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return Context.Set<T>().LongCount(where);
            }
            return Context.Set<T>().LongCount();
        }

        /// <summary>
        /// 计算LongCount值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="where"></param>
        /// <returns></returns>
        public async Task<long> LongCountAsync<T>(Expression<Func<T, bool>> where = null) where T : class
        {
            if (where != null)
            {
                return await Context.Set<T>().LongCountAsync(where);
            }
            return await Context.Set<T>().LongCountAsync();
        }
        #endregion

        #region 分页函数
        /// <summary>
        /// 执行分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R">返回对象实体</typeparam>
        /// <param name="where">where条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页条数</param>
        /// <returns></returns>
        public ContractPageResult<T> GetPageList<T>(Expression<Func<T, bool>> where = null, int pageIndex = 1, int pageSize = 10) where T : class
        {
            return Context.GetPageList(where, pageIndex, pageSize);
        }

        /// <summary>
        /// 执行分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="R">返回对象实体</typeparam>
        /// <param name="where">where条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">分页条数</param>
        /// <returns></returns>
        public async Task<ContractPageResult<T>> GetPageListAsync<T>(Expression<Func<T, bool>> where = null, int pageIndex = 1, int pageSize = 10) where T : class
        {
            return await Context.GetPageListAsync(where, pageIndex, pageSize);
        }
        #endregion

        /// <summary>
        /// 析构函数
        /// </summary>
        ~ServiceBase()
        {
            if (Context != null)
            {
                Context.Dispose();
            }
        }
    }
}