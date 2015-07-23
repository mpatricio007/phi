using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Collections;

namespace Medusa.DAL
{
    public interface IBaseCrud
    {
        void Add();

        void Delete();

        void Get(object id);

        void Update();

        IEnumerable GetAll();

        IEnumerable GetAll(string sortExpression);

        IEnumerable Find(string strContent, string strProperty, string strMode, string sortExpression, string sortDirection, int top);

        IEnumerable Find(List<Filter> lstFilters,string sortExpression, string sortDirection, int top);

        IEnumerable Find(string strContent, string strProperty, string strMode, string sortExpression, string sortDirection, int top, string strContentDefault, string strPropertyDefault, string strModeDefault);

        bool SaveChanges();

        Type GetPropertyType(string propertyName);
    }
}

