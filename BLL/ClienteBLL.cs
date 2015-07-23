using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Medusa.DAL;
using System.IO;

namespace Medusa.BLL
{
    public class ClienteBLL : AbstractCrudWithLog<Cliente>
    {

        public Upload up { get; set; }

        public override void Add()
        {
            ObjEF.data_cadastro = DateTime.Now;
            ObjEF.id_usuario = SecurityBLL.GetCurrentId_usuario();
            ObjEF.ra = _dbSet.Max(it => it.ra) + 1;
            base.Add();
            if (up.file != null)
            {
                if (base.SaveChanges())
                {
                    saveFile();
                    base.Update();
                }
            }
        }

        public override void Delete()
        {
            deleteFile();
            base.Delete();
        }

        public override void Update()
        {
            if (up.file != null)
            {
                deleteFile();
                saveFile();
            }
            base.Update();
        }

        protected void saveFile()
        {

            up.where_upload = System.Web.HttpContext.Current.Server.MapPath("\\fotos\\");
            up.fileName = String.Format("foto{0}", ObjEF.id_cliente);
            if (up.Do())
                ObjEF.foto = String.Format(@"../../fotos/{0}{1}", up.fileName, up.fileExtension);
        }

        protected void deleteFile()
        {
            if (!String.IsNullOrEmpty(ObjEF.foto))
            {

                string[] files = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("\\fotos\\")).
                    Where(it => it.Contains(Convert.ToString(ObjEF.id_cliente))).ToArray();
                foreach (string f in files)
                    File.Delete(f);
            }
        }

        public List<StatusContrato> GetStatus()
        {
            var lstStatus = new List<StatusContrato>();

            if (ObjEF.dtNascto.DayOfYear == DateTime.Now.DayOfYear)
            {
                var stAniver = new StatusContrato();
                stAniver.plano = "Feliz Aniversário!";
                //stAniver.status = StatusFrequencia.LIBERAR
                lstStatus.Add(stAniver);
            }

            if (!ObjEF.Contratos.Any())
            {
                var sc = new StatusContrato()
                {
                    plano = "Nenhum contrato cadastrado!",
                    status = StatusFrequencia.BLOQUEAR
                };

                lstStatus.Add(sc);
            }
            else
                lstStatus.AddRange(ObjEF.Contratos.OrderBy(it => it.termino).Select(i => new StatusContrato(i)));


            return lstStatus;
        }


        public List<StatusContrato> GetServicos()
        {
            var lstStatus = new List<StatusContrato>();

            if (!ObjEF.Servicos.Any())
            {
                var sc = new StatusContrato()
                {
                    plano = "Nenhum contrato cadastrado!",
                    status = StatusFrequencia.BLOQUEAR
                };

                lstStatus.Add(sc);
            }
            else
                lstStatus.AddRange(ObjEF.Servicos.Where(it => it.data_termino.GetValueOrDefault() > DateTime.Now.AddMonths(-1)).
                    OrderBy(k => k.data_termino).Select(k => new StatusContrato(k)));



            return lstStatus;
        }

        public void GetPorRa(int ra)
        {
            ObjEF = _dbSet.SingleOrDefault(it => it.ra == ra);
        }

    }

    public class StatusContrato
    {
        private Dictionary<StatusFrequencia, System.Drawing.Color> _dicColor = new Dictionary<StatusFrequencia, System.Drawing.Color>
        {
            {StatusFrequencia.LIBERAR , System.Drawing.Color.Green},
           {StatusFrequencia.AVISAR , System.Drawing.Color.Yellow},
           {StatusFrequencia.BLOQUEAR , System.Drawing.Color.Red},
           {StatusFrequencia.TERMINADO , System.Drawing.Color.Red}
        };

        public string plano { get; set; }

        public StatusFrequencia status { get; set; }

        public string motivo { get; set; }

        public System.Drawing.Color color
        {
            get { return _dicColor[status]; }
        }


        public StatusContrato()
        {

        }


        public StatusContrato(Contrato c)
        {
            var hoje = DateTime.Today;
            plano = c.Plano.nome;
            if (c.status)
            {
                //if ((c.inicio <= hoje & c.termino >= hoje))
                if (c.termino > hoje)
                {
                    if (c.Pagamentos != null && c.Pagamentos.Any(it => it.data_vencto < hoje & it.data_pagto == null))
                    {
                        status = StatusFrequencia.BLOQUEAR;
                        motivo = "Pagamento(s) em atraso!";
                    }
                    else if (c.Plano.acessos != 0)
                    {
                        var dtMes = c.inicio;
                        while (dtMes <= hoje.AddMonths(-1))
                            dtMes = dtMes.AddMonths(1);


                        if (c.Plano.acessos <= c.Cliente.Frequencias.Where(it => it.data >= dtMes & it.data <= hoje).Count())
                        {
                            status = StatusFrequencia.BLOQUEAR;
                            motivo = "Quantidade de acessos acima do plano contratado!";
                        }
                        else
                        {
                            status = StatusFrequencia.LIBERAR;
                        }
                    }
                    else if (hoje.TimeOfDay <= c.Plano.inicio || hoje.TimeOfDay >= c.Plano.termino)
                    {
                        status = StatusFrequencia.BLOQUEAR;
                        motivo = "Horário fora do plano contratado!";
                    }
                    else
                    {
                        status = StatusFrequencia.LIBERAR;
                    }
                }
                else
                {
                    status = StatusFrequencia.TERMINADO;
                    motivo = String.Format("Contrato vencido em {0}", c.termino.ToShortDateString());
                }
            }
            else
            {
                status = StatusFrequencia.BLOQUEAR;
                motivo = "Contrato bloqueado!";
            }
        }


        public StatusContrato(ServicoCliente sc)
        {
            var hoje = DateTime.Today;
            plano = sc.Servico.descricao;

            if (sc.data_termino > hoje)
            {
                status = StatusFrequencia.LIBERAR;
            }
            else
            {
                status = StatusFrequencia.TERMINADO;
                motivo = String.Format("Serviço vencido em {0:d}", sc.data_termino.GetValueOrDefault());
            }

        }
    }
}
