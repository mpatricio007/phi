using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.IO;

namespace Medusa.BLL
{
    public class Upload
    {
        public HttpPostedFile file { get; set; }

        public string where_upload { get; set; }

        public string fileName { get; set; }

        public string fileExtension 
        {
            get
            {
                if (file != null)
                    return Path.GetExtension(file.FileName.ToLower());
                else
                    return String.Empty;
            }
            
        }

        public bool Do()
        {
            bool rt = false;
            if (file.ContentLength > 0)
            {
                string StrFileExtension = Path.GetExtension(file.FileName.ToLower());

                string StrFileType = file.ContentType;

                int IntFileSize = file.ContentLength;

                if ((IntFileSize <= 0) & (IntFileSize > 25600)) // menor q 25mb
                    rt = false;
                else
                {
                    file.SaveAs(where_upload + fileName + StrFileExtension);
                    rt = true;
                }
            }
            return rt;
        }
    }
}