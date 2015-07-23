using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace Medusa.Controles
{
    public partial class MultiFileUpload : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //String UpPath;
            //UpPath = "C:\\UploadedUserFiles";            
            //if (!Directory.Exists(UpPath))
            //{
            //    Directory.CreateDirectory("C:\\UploadedUserFiles\\");
            //}
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //HttpFileCollection uploads = HttpContext.Current.Request.Files;
            //for (int i = 0; i < uploads.Count; i++)
            //{
            //    HttpPostedFile upload = uploads[i];

            //    if (upload.ContentLength == 0)
            //        continue;

            //    string c = System.IO.Path.GetFileName(upload.FileName); // We don't need the path, just the name.

            //    try
            //    {
            //        upload.SaveAs("C:\\UploadedUserFiles\\" + c);
            //        Span1.InnerHtml = "Upload(s) Successful.";
            //    }
            //    catch (Exception Exp)
            //    {
            //        Span1.InnerHtml = "Upload(s) FAILED.";
            //    }
            //}
        }
    }
}