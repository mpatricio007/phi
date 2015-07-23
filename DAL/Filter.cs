using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace Medusa.DAL
{
    [Serializable]
    public class Filter
    {
        public string property { get; set; }
        public string property_name { get; set; }
        public string value { get; set; }
        public string mode { get; set; }
        public string mode_name { get; set; }


        public static Dictionary<String, Func<Expression, Expression, Expression>> Expressions = new Dictionary<String, Func<Expression, Expression, Expression>>()
        {
            {"==", Expression.Equal                 },
            {">",  Expression.GreaterThan           },
            {"<",  Expression.LessThan              },
            {">=", Expression.GreaterThanOrEqual    },
            {"<=", Expression.LessThanOrEqual       }, 
            {"!=", Expression.NotEqual              },
            {"&&", Expression.And                   },
            {"||", Expression.Or                    }            
        };

        public static Dictionary<string, string> StrModes = new Dictionary<string, string>()
        {       
            {"Contains","que contém"                 },
            {"StartsWith" ,"começando com"           },
            {"EndsWith","terminando com"             },
            {"Equals","igual"                        },
      
        };

        public static Dictionary<string, string> Modes = new Dictionary<string, string>()
        {
                {"==","igual"               },
                {">","maior"                },     
                {"<","menor"                },
                {">=","maior que"           },
                {"<=","menor que"           },
                {"!=","diferente"           },
                
        };

        public static Dictionary<string, string> BoolModes = new Dictionary<string, string>()
        {
                {"==","igual"               },                
                {"!=","diferente"           },
                
        };

        public static Dictionary<Type, Dictionary<string, string>> SearchModes = new Dictionary<Type, Dictionary<string, string>>()
        {
            {typeof(string),StrModes      },     
            {typeof(int),Modes            },
            {typeof(DateTime),Modes       },
            {typeof(decimal),Modes        },
            {typeof(int?),Modes            },
            {typeof(DateTime?),Modes       },
            {typeof(decimal?),Modes        },
            {typeof(bool),BoolModes        },
            {typeof(bool?),BoolModes        },
        };


    }
}