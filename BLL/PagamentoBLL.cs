using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medusa.DAL;
using System.IO;

namespace Medusa.BLL
{
    public class PagamentoBLL : AbstractCrudWithLog<Pagamento>
    {
        public override void Add()
        {
            ObjEF.id_usuario_lancto = SecurityBLL.GetCurrentId_usuario();
            base.Add();
        }

        public override void Update()
        {
            ObjEF.id_usuario_lancto = SecurityBLL.GetCurrentId_usuario();
            base.Update();
        }

        public bool BaixaPagto()
        {
            ObjEF.id_usuario_baixa = SecurityBLL.GetCurrentId_usuario();

            if ((!ObjEF.data_pagto.HasValue)||( ObjEF.Contrato.status ))
                return SaveChanges();
            else
                return false;
        }

        public bool CancelarBaixa()
        {
            ObjEF.id_usuario_baixa = SecurityBLL.GetCurrentId_usuario();
            ObjEF.data_pagto = null;
            ObjEF.id_forma = null;
            ObjEF.num = null;
            if ((ObjEF.data_pagto.HasValue) || (ObjEF.Contrato.status))
                return SaveChanges();
            else
                return false;
        }


        public List<Pagamento> GetPagamentos(int id_cliente)
        {
            return _dbSet.Where(it => it.Contrato.id_cliente == id_cliente).ToList();
        }
    }
}
