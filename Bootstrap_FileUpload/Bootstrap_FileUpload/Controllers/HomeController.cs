using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap_FileUpload.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index2()
        {
            return View();
        }


        public JsonResult Update()
        {

       
       

            try
            {
             var oFile = Request.Files["txt_file"];
            var oFilePath = "App_Data/" + DateTime.Now.ToString("yyyyMMdd") + "/";
            var filePath = Server.MapPath(oFilePath); //路径
            if (oFile == null)
                return null;

            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            string fileName = DateTime.Now.ToString("yyyyMMddHHmmssss") + "_" + Path.GetFileName(oFile.FileName);// 原e始文件名称

            var oStream = oFile.InputStream;
              
                oFile.SaveAs(filePath + fileName);//保存文件
                                                  //后台TODO

                return Json(new { }, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
      
        }
    }
}