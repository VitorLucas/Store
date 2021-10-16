using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Interface;
using Repository.Filter;
using Repository.Helpers;
using Repository.Insterface;
using Repository.Wrapper;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.EFCore
{
    public abstract class EfCoreRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private readonly TContext context;
        private readonly IUriService uriService;
        private ILogger log;
        public EfCoreRepository(TContext context, 
                                IUriService uriService, 
                                ILogger<TEntity> log)
        {
            this.context = context;
            this.uriService = uriService;
            this.log = log;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().Add(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                log.LogError("EfCoreRepository Add: " + ex.Message);
                return entity;
            }
        }

        public async Task<TEntity> Delete(int id)
        {
            try
            {
                var entity = await context.Set<TEntity>().FindAsync(id);
                if (entity == null)
                {
                    return entity;
                }

                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                log.LogError("EfCoreRepository Delete: " + ex.Message);
                return null;
            }           
        }

        public async Task<TEntity> Get(int id)
        {
            try
            {
                return await context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {
                log.LogError("EfCoreRepository Get: " + ex.Message);
                return null;
            }    
        }

        public async Task<PagedResponse<List<TEntity>>> GetAll(PaginationFilter filter, 
                                                                string route)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);
            var pagedData = await context.Set<TEntity>()
                .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
                .Take(validFilter.PageSize)
                .ToListAsync();

            var totalRecords = await context.Set<TEntity>().CountAsync();
            var pagedReponse = PaginationHelper.CreatePagedReponse<TEntity>(pagedData, 
                                                                            validFilter, 
                                                                            totalRecords, 
                                                                            uriService, 
                                                                            route);

            return pagedReponse;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
