using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medusa.DAL;

namespace Medusa.BLL
{
    public class CidadeBLL : AbstractCrudWithLog<Cidade>
    {
        public IEnumerable<Cidade> GetCidadesPorUF(string strUF)
        {
            return (from c in _dbContext.Cidades
                    where c.uf == strUF
                    orderby c.cidade
                    select c).ToList();
        }
    }
}
