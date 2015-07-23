using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Linq.Expressions;

namespace Medusa.DAL
{
    public static class DbSetExtensionsMethods
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> source, string sortExpression, string sortDirection)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "it");

            string[] properties = sortExpression.Split('.');
            Expression body = Expression.PropertyOrField(parameterExpression, properties[0]);

            for (int i = 1; i < properties.Length; i++)
                body = Expression.Property(body, properties[i]);

            Type tipo = typeof(T);

            string[] Properties = sortExpression.Split('.');
            foreach (var Property in Properties)
                tipo = tipo.GetProperty(Property).PropertyType;
            body = Expression.Convert(body, tipo);

            if (tipo == typeof(string))
            {
                var expression = Expression.Lambda<Func<T, string>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(int))
            {
                var expression = Expression.Lambda<Func<T, int>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(int?))
            {
                var expression = Expression.Lambda<Func<T, int?>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(decimal))
            {
                var expression = Expression.Lambda<Func<T, decimal>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(decimal?))
            {
                var expression = Expression.Lambda<Func<T, decimal?>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }

            else if (tipo == typeof(DateTime))
            {
                var expression = Expression.Lambda<Func<T, DateTime>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(DateTime?))
            {
                var expression = Expression.Lambda<Func<T, DateTime?>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }

            else if (tipo == typeof(bool))
            {
                var expression = Expression.Lambda<Func<T, bool>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(bool?))
            {
                var expression = Expression.Lambda<Func<T, bool?>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(TimeSpan))
            {
                var expression = Expression.Lambda<Func<T, TimeSpan>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else if (tipo == typeof(TimeSpan?))
            {
                var expression = Expression.Lambda<Func<T, TimeSpan?>>(body, new[] { parameterExpression });
                return (sortDirection == "ASC") ? source.OrderBy(expression) : source.OrderByDescending(expression);
            }
            else return null;
        }
      
        

        public static IQueryable<T> Where<T>(this IQueryable<T> source, object obj, string strProperty, string strMode)
        {
            try
            {
                ParameterExpression entity = Expression.Parameter(typeof(T), "it");
                string[] properties = strProperty.Split('.');
                Expression keyValue = Expression.PropertyOrField(entity, properties[0]);

                for (int i = 1; i < properties.Length; i++)
                    keyValue = Expression.Property(keyValue, properties[i]);
                

                int inteiro;
                decimal valor;
                DateTime dt;
                bool bl;
                Expression pkValue;
                Expression body;
                if (!keyValue.Type.Name.ToLower().Contains("string"))
                {
                    if (int.TryParse(obj.ToString(), out inteiro))
                        pkValue = Expression.Constant(inteiro, keyValue.Type);
                    else if (DateTime.TryParse(obj.ToString(), out dt))
                        pkValue = Expression.Constant(dt, keyValue.Type);
                    else if (decimal.TryParse(obj.ToString(), out valor))
                        pkValue = Expression.Constant(valor, keyValue.Type);
                    else if (bool.TryParse(obj.ToString(), out bl))
                        pkValue = Expression.Constant(bl, keyValue.Type);
                    else pkValue = Expression.Constant(obj, keyValue.Type);
                    body = Filter.Expressions[strMode](keyValue, pkValue);
                }
                else
                {
                    pkValue = Expression.Constant(obj, keyValue.Type);
                    MethodInfo method = keyValue.Type.GetMethod(strMode, new[] { keyValue.Type });
                    body = Expression.Call(keyValue, method, pkValue);
                }               

                var expression = Expression.Lambda<Func<T, bool>>(body, entity);
                return source.Where(expression).AsQueryable<T>();
            }
            catch (Exception)
            {
                return source.AsQueryable<T>();
            }

        }

        public static IQueryable<T> Where<T>(this IQueryable<T> source, List<Filter> lstFiltros)
        {
            try
            {
                int inteiro;
                decimal valor;
                DateTime dt;
                bool bl;
                Expression pkValue;
                Expression body;
                Expression exp = null;
                ParameterExpression entity = Expression.Parameter(typeof(T), "it");

                for (int i=0; i<lstFiltros.Count();i++)
                {
                    
                    string[] properties = lstFiltros[i].property.Split('.');
                    Expression keyValue = Expression.PropertyOrField(entity, properties[0]);

                    for (int j = 1; j < properties.Length; j++)
                        keyValue = Expression.Property(keyValue, properties[j]);


                    if (!keyValue.Type.Name.ToLower().Contains("string"))
                    {
                        if (int.TryParse(lstFiltros[i].value.ToString(), out inteiro))
                            pkValue = Expression.Constant(inteiro, keyValue.Type);
                        else if (DateTime.TryParse(lstFiltros[i].value.ToString(), out dt))
                            pkValue = Expression.Constant(dt, keyValue.Type);
                        else if (decimal.TryParse(lstFiltros[i].value.ToString(), out valor))
                            pkValue = Expression.Constant(valor, keyValue.Type);
                        else if (bool.TryParse(lstFiltros[i].value.ToString(), out bl))
                            pkValue = Expression.Constant(bl, keyValue.Type);
                        else pkValue = Expression.Constant(lstFiltros[i].value, keyValue.Type);
                        body = Filter.Expressions[lstFiltros[i].mode](keyValue, pkValue);
                    }
                    else
                    {
                        pkValue = Expression.Constant(lstFiltros[i].value, keyValue.Type);
                        MethodInfo method = keyValue.Type.GetMethod(lstFiltros[i].mode, new[] { keyValue.Type });
                        body = Expression.Call(keyValue, method, pkValue);
                    }
                    exp = (i != 0) ? Expression.And(exp, body) : body;    
                }

                var expression = Expression.Lambda<Func<T, bool>>(exp, entity);
                return source.Where(expression).AsQueryable<T>();
            }
            catch (Exception)
            {
                return source.AsQueryable<T>();
            }

        }
    }
}