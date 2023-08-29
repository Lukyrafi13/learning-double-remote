using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NewLMS.UMKM.Data;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
namespace NewLMS.UMKM.Common.GenericRespository
{
    public class GenericRepository<TC, TContext> : IGenericRepository<TC>
        where TC : class
        where TContext : DbContext
    {
        protected readonly TContext Context;
        internal readonly DbSet<TC> DbSet;
        protected GenericRepository()
        {
            DbSet = Context.Set<TC>();
        }
        public IQueryable<TC> All => Context.Set<TC>();
        public void Add(TC entity)
        {
            Context.Add(entity);
        }

        public IQueryable<TC> AllIncluding(params Expression<Func<TC, object>>[] includeProperties)
        {
            return GetAllIncluding(includeProperties);
        }

        //public async Task<IEnumerable<TC>> AllIncludingAsync(params Expression<Func<TC, object>>[] includeProperties)
        //{
        //    var query = GetAllIncluding(includeProperties);
        //    IEnumerable<TC> results = await query.ToListAsync();
        //    return results;
        //}

        public IQueryable<TC> FindByInclude(Expression<Func<TC, bool>> predicate, params Expression<Func<TC, object>>[] includeProperties)
        {
            var query = GetAllIncluding(includeProperties);
            return query.Where(predicate);
        }

        //public async Task<IEnumerable<TC>> FindByIncludeAsync(Expression<Func<TC, bool>> predicate, params Expression<Func<TC, object>>[] includeProperties)
        //{
        //    var query = GetAllIncluding(includeProperties);
        //    IEnumerable<TC> results = await query.Where(predicate).ToListAsync();
        //    return results;
        //}

        //public  IQueryable<TC> FindByInclude(Expression<Func<TC, bool>> predicate, params Expression<Func<TC, object>>[] includeProperties)
        //{
        //    var query = GetAllIncluding(includeProperties);
        //    return query.Where(predicate);
        //}

        public IQueryable<TC> FindBy(Expression<Func<TC, bool>> predicate)
        {
            IQueryable<TC> queryable = DbSet.AsNoTracking();
            return queryable.Where(predicate);
        }

        //public IQueryable<TC> FindOnly(Expression<Func<TC, bool>> predicate)
        //{
        //    IQueryable<TC> queryable = DbSet.AsNoTracking();
        //    return queryable.Where(predicate);
        //}

        //public async Task<IEnumerable<TC>> FindByAsync(Expression<Func<TC, bool>> predicate)
        //{
        //    IQueryable<TC> queryable = DbSet.AsNoTracking();
        //    IEnumerable<TC> results = await queryable.Where(predicate).ToListAsync();
        //    return results;
        //}

        private IQueryable<TC> GetAllIncluding(params Expression<Func<TC, object>>[] includeProperties)
        {
            IQueryable<TC> queryable = DbSet.AsNoTracking();

            return includeProperties.Aggregate
              (queryable, (current, includeProperty) => current.Include(includeProperty));
        }
        public TC Find(Guid id)
        {
            return Context.Set<TC>().Find(id);
        }

        public async Task<TC> FindAsync(Guid id)
        {
            return await Context.Set<TC>().FindAsync(id);
        }

        public virtual void Update(TC entity)
        {
            Context.Update(entity);
        }
        public virtual void UpdateRange(List<TC> entities)
        {
            Context.UpdateRange(entities);
        }

        public void RemoveRange(IEnumerable<TC> lstEntities)
        {
            Context.Set<TC>().RemoveRange(lstEntities);
        }

        public void AddRange(IEnumerable<TC> lstEntities)
        {
            Context.Set<TC>().AddRange(lstEntities);
        }

        public void InsertUpdateGraph(TC entity)
        {
            Context.Set<TC>().Add(entity);
            //Context.ApplyStateChanges(user);
        }
        public virtual void Delete(Guid id)
        {
            var entity = Context.Set<TC>().Find(id) as BaseEntity;
            if (entity != null)
            {
                entity.IsDeleted = true;
                Context.Update(entity);
            }
        }
        public virtual void Delete(TC entityData)
        {
            var entity = entityData as BaseEntity;
            entity.IsDeleted = true;
            Context.Update(entity);
        }
        public virtual void Remove(TC entity)
        {
            Context.Remove(entity);
        }
        public void Dispose()
        {
            Context.Dispose();
        }

        public async Task<PagedRepositoryResponse<IReadOnlyList<TC>>> GetPagedReponseAsync(IRequestParameter request, string[] includes = null)
        {
            var data = Context.Set<TC>().AsQueryable();
            data = _Includes(data, includes);
            data = _Filters(data, request.Filters);

            PagedInfoRepositoryResponse info = new PagedInfoRepositoryResponse
            {
                CurrentPage = request.Page,
                Length = request.Length,
                TotalPage = await data.CountAsync()
            };
            data = _Orders(data, request.Orders, request.SortType);
            if (request.Page > 0 && request.Length > 0)
            {
                data = data
                .Skip((request.Page - 1) * request.Length)
                .Take(request.Length);
            }
            data = data.AsNoTracking();
            return new PagedRepositoryResponse<IReadOnlyList<TC>>
            {
                Results = await data.ToListAsync(),
                Info = info
            };
        }

        #region "Private Access"
        public string _GetComparisonOperator(string comparisonOperator)
        {
            var result = "";
            switch (comparisonOperator)
            {
                case "like":
                    result = ".Contains(";
                    break;
                case "not like":
                    result = ".Contains(";
                    break;
                case "!=":
                    result = "!=";
                    break;
                case "<":
                    result = " < ";
                    break;
                case ">":
                    result = " > ";
                    break;
                case "<=":
                    result = " <= ";
                    break;
                case ">=":
                    result = " >= ";
                    break;
                case "<>":
                    result = " <> ";
                    break;
                default:
                    result = "=";
                    break;

            }
            return result;
        }

        private string _GetClosedTagComparisonOperator(string comparisonOperator)
        {
            var result = "";
            switch (comparisonOperator)
            {
                case "like":
                    result = ")";
                    break;
                case "not like":
                    result = ") == false";
                    break;
            }
            return result;
        }
        private string _GetConverter(object value)
        {
            var result = "";
            switch (value)
            {
                case Guid:
                    result = ".ToString()";
                    break;
            }
            return result;
        }
        private object _GetValue(object value)
        {
            var result = value;
            switch (value)
            {
                case Enum:
                    result = (int)value;
                    break;
            }
            return result;
        }
        protected IQueryable<TC> _Includes(IQueryable<TC> query, string[] includes = null)
        {
            if (includes != null && includes.Length > 0)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
        private bool _IsUseDoubleQuote(object value)
        {
            switch (value)
            {
                case int:
                case Enum:
                    return false;
            }
            return true;
        }
        protected IQueryable<TC> _Filters(IQueryable<TC> query, List<RequestFilterParameter> filters)
        {
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    if (filter.Type != "raw")
                    {
                        query = query.Where(
                         string.Format(
                             "{0}{5}{1}{3}{2}{3}{4}"
                             , filter.Field
                             , _GetComparisonOperator(filter.ComparisonOperator)
                             , _GetValue(filter.GetFilterValue())
                             , _IsUseDoubleQuote(filter.GetFilterValue()) ? "\"" : ""
                             , _GetClosedTagComparisonOperator(filter.ComparisonOperator)
                             , _GetConverter(filter.GetFilterValue())
                             )
                         );
                    }
                    else
                    {
                        var predicate = string.Format(
                           "{0}{5}{1}{3}{2}{3}{4}"
                           , $"{filter.Field.Split(".")[1]}.{filter.Field.Split(".")[2]}"
                           , _GetComparisonOperator(filter.ComparisonOperator)
                           , _GetValue(filter.GetFilterValue())
                           , _IsUseDoubleQuote(filter.GetFilterValue()) ? "\"" : ""
                           , _GetClosedTagComparisonOperator(filter.ComparisonOperator)
                           , _GetConverter(filter.GetFilterValue())
                           );
                        query = query.Where($"{filter.Field.Split(".")[0]}.Any({predicate})");
                    }


                }
            }
            return query;
        }
        protected IQueryable<TC> _Orders(IQueryable<TC> query, List<string> orders, string sortType)
        {
            if (orders != null && orders.Count > 0)
            {
                query = query.OrderBy(
                        string.Format(
                            "{0} {1}"
                            , string.Join(",", orders)
                            , sortType
                            )
                        );
            }
            return query;
        }

        public async Task<List<TC>> GetListByPredicate(Expression<Func<TC, bool>> predicate, string[] includes = null)
        {
            var query = Context.Set<TC>().AsQueryable();
            query = _Includes(query, includes);
            query = query.Where(predicate);
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TC> GetByIdAsync(int id, string idFieldName = "Id", string[] includes = null)
        {
            var query = Context.Set<TC>().AsQueryable();
            query = _Includes(query, includes);
            query = query.Where(string.Format("{0}.Equals({1})", idFieldName, id));
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TC> GetByIdAsync(Guid id, string idFieldName = "Id", string[] includes = null)
        {
            var query = Context.Set<TC>().AsQueryable();
            query = _Includes(query, includes);
            query = query.Where(string.Format("{0}.ToString().Equals(\"{1}\")", idFieldName, id));
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<TC> GetByIdAsync(string id, string idFieldName = "Id", string[] includes = null)
        {
            var query = Context.Set<TC>().AsQueryable();
            query = _Includes(query, includes);
            query = query.Where(string.Format("{0}.Equals(\"{1}\")", idFieldName, id));
            return await query.AsNoTracking().FirstOrDefaultAsync();
        }
        #endregion
    }
}
