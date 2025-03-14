﻿using Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext) => this.RepositoryContext = repositoryContext;

        public void Create(T entity) => this.RepositoryContext.Set<T>().Add(entity);
        public void Delete(T entity) => this.RepositoryContext.Set<T>().Remove(entity);

        public IQueryable<T> FindAll(bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().AsNoTracking() : RepositoryContext.Set<T>();



        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges) =>
            !trackChanges ? RepositoryContext.Set<T>().Where(expression).AsNoTracking() : RepositoryContext.Set<T>().Where(expression);

        public void Update(T entity) => this.RepositoryContext.Set<T>().Update(entity);


    }
}
