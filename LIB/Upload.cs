using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.IO;
using System.Web.UI.WebControls;

namespace Medusa.LIB
{   
    public class Upload
    {
        private string[] extensoes = new string[]
        {
            ".doc",
            ".docx",
            ".xls",
            ".xlsx",
            ".pdf",
        };

        private int max = 25000000;
        private Dictionary<FileUpload, string> dicArquivos = new Dictionary<FileUpload, string>();

        public string Add(FileUpload file)
        {
            if (file.HasFile)
            {
                if (file.PostedFile.ContentLength <= max)
                {
                    if (extensoes.Contains(Path.GetExtension(file.PostedFile.FileName).ToLower()))
                    {
                        dicArquivos.Add(file, file.PostedFile.FileName);
                        return "arquivo adicionado";
                    }
                    else
                        return "extensão de arquivo não suportado!";
                }
                else
                    return "tamanho do arquivo maior que 25MB!";
            }
            else
                return "selecione um arquivo!";
        }

        public string Add(FileUpload file, string fileName)
        {
            if (file.HasFile)
            {
                if (file.PostedFile.ContentLength <= max)
                {
                    if (extensoes.Contains(Path.GetExtension(file.PostedFile.FileName).ToLower()))
                    {                       
                        dicArquivos.Add(file, fileName);
                        return "arquivo adicionado";
                    }
                    else
                        return "extensão de arquivo não suportado!";
                }
                else
                    return "tamanho do arquivo maior que 25MB!";
            }
            else
                return "selecione um arquivo!";
        }

        public string Remove(int index)
        {
            FileUpload file = dicArquivos.Keys.ToArray()[index];
            dicArquivos.Remove(file);            
            return "arquivo removido com sucesso!";
        }

        public string UploadArquivos(string caminho)
        {
            if (dicArquivos.Count > 0)
            {
                foreach (FileUpload iFile in dicArquivos.Keys)                
                    iFile.PostedFile.SaveAs(caminho + dicArquivos[iFile] + Path.GetExtension(iFile.PostedFile.FileName.ToLower()));
                
                return String.Format("Upload de: {0} arquivo(s) realizado(s) com sucesso!", dicArquivos.Count.ToString());
            }
            else
                return "adicione ao menos um arquivo!";
        }

        public IEnumerable GetAll()
        {   
            var ds = from f in dicArquivos
                     select new
                     {
                         arquivo = f.Key.PostedFile.FileName
                     };
            return ds;
        }

        public void Clear()
        {
            dicArquivos.Clear();            
        }
    }
}