using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Medusa.LIB;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Medusa.DAL
{
    public abstract class Abstract_Crud<T> : IBaseCrud where T : class,new()
    {
        protected readonly IDbSet<T> _dbSet;
        protected readonly Contexto _dbContext;

        protected  T objEF;

        public virtual T ObjEF
        {
            get
            {
                if (objEF == null)
                    objEF = new T();

                return objEF;
            }
            set { objEF = value; }
        }

        public Abstract_Crud()
        {
            _dbContext = new Contexto();
            _dbSet = _dbContext.Set<T>();
            
        }

        #region IRepository<T> Members

        public virtual void Add()
        {
            _dbSet.Add(objEF);
        }

        public virtual void Delete()
        {
            _dbSet.Remove(objEF);
        }

        public void Get(object Id)
        {
            ObjEF = _dbSet.Find(Id);            
        }

        public virtual void Update()
        {
           _dbContext.Entry<T>(ObjEF).State = EntityState.Modified;
        }

        public virtual IEnumerable GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual IEnumerable GetAll(string sortExpression)
        {
            return _dbSet.OrderBy(sortExpression, "ASC").ToList();
        }

        public virtual bool SaveChanges()
        {            
            //return _dbContext.SaveChanges() > 0;
            try
            {
                return _dbContext.SaveChanges() > 0;
            }
            catch (Exception)
            {
                string w = "";
                foreach (System.Data.Entity.Validation.DbEntityValidationResult erro in _dbContext.GetValidationErrors())
                {
                    foreach (System.Data.Entity.Validation.DbValidationError msg in erro.ValidationErrors)
                        w = msg.ErrorMessage;
                }
                return false;
            }
            
        }

        public IEnumerable Find(List<Filter> lstFilters,string sortExpression, string sortDirection, int top)
        {
            if (top == 0)
                return _dbSet.Where(lstFilters).OrderBy(sortExpression, sortDirection).ToList();
            else
                return _dbSet.Where(lstFilters).OrderBy(sortExpression, sortDirection).Take(top).ToList();
        }

        public IEnumerable Find(string strContent, string strProperty, string strMode, string sortExpression, string sortDirection, int top)
        {
            if (top == 0)
                return _dbSet.Where(strContent, strProperty, strMode).OrderBy(sortExpression, sortDirection).ToList();
            else
                return _dbSet.Where(strContent, strProperty, strMode).OrderBy(sortExpression, sortDirection).Take(top).ToList();
        }

        public IEnumerable Find(string strContent, string strProperty, string strMode, string sortExpression, string sortDirection, int top, string strContentDefault, string strPropertyDefault, string strModeDefault)
        {            
            
            if(top == 0)
                return _dbSet.Where(strContent, strProperty, strMode).Where(strContentDefault, strPropertyDefault, strModeDefault).OrderBy(sortExpression, sortDirection).ToList();
            else
                return _dbSet.Where(strContent, strProperty, strMode).Where(strContentDefault, strPropertyDefault, strModeDefault).OrderBy(sortExpression, sortDirection).Take(top).ToList();
        }

        public IEnumerable<T> Find(Expression<System.Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }

    
        public Type GetPropertyType(string propertyName)
        {
            Type tipoCampo = typeof(T);
            string[] Properties = propertyName.Split('.');
            foreach (var Property in Properties)
                tipoCampo = tipoCampo.GetProperty(Property).PropertyType;
            return tipoCampo;
        }
        #endregion
    }    
}
