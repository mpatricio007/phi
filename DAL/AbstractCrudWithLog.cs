using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using Medusa.BLL;
using Medusa.LIB;

namespace Medusa.DAL
{
    public class AbstractCrudWithLog<T> : Abstract_Crud<T> where T : class, new()
    {
        public override bool SaveChanges()
        {
            var logDAL = new LogSistemaBLL();
            
            var rt = false;            

            try
            {
                var db = _dbContext.Entry<T>(ObjEF);
                var index = ObjEF.GetType().Name.LastIndexOf("_", StringComparison.Ordinal); 
                logDAL.ObjEF.entidade = index == -1 ? ObjEF.GetType().Name : ObjEF.GetType().Name.Substring(0,index );
                logDAL.ObjEF.acao = Util.TranslateAction(db.State.ToString());

                var property = _dbContext.Entry<T>(ObjEF).State == EntityState.Added ? db.CurrentValues.PropertyNames.First() :
                   db.OriginalValues.PropertyNames.FirstOrDefault();
                var ds = _dbContext.Entry<T>(ObjEF).Property(property);

                if ((int)ds.CurrentValue != 0)
                {
                    logDAL.ObjEF.id_entidade = Convert.ToInt32(ds.CurrentValue);
                    rt = base.SaveChanges();
                }
                else
                {
                    rt = base.SaveChanges();
                    logDAL.ObjEF.id_entidade = Convert.ToInt32(ds.CurrentValue);
                }
            }
            catch (Exception ex)
            {
                logDAL.ObjEF.acao = "erro banco de dados";
                logDAL.ObjEF.descricao = ex.InnerException.InnerException.Message;
            }
            finally
            {
                logDAL.Add();
                logDAL.SaveChanges();
            }
            return rt;
        }
    }
}