using Ionic.Zip;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Services;

namespace APPComponentService
{
    /// <summary>
    ///ZipFileService 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class ZipFileService : System.Web.Services.WebService
    {
        /// <summary>
        /// 檔案壓縮作業
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <param name="strTargetPath"></param>
        /// <returns></returns>
        [WebMethod]
        public string GetZipFile(string strFilePath, string strTargetPath)
        {
            List<string> listFilePath = JsonConvert.DeserializeObject<List<string>>(strFilePath);

            //壓縮檔名
            string strFileName = string.Format(@"{0}.zip", DateTime.Now.ToString("yyyyMMddHHmmssfff"));

            //壓縮作業
            using (ZipFile zip = new ZipFile(strTargetPath + strFileName, System.Text.Encoding.Default))
            {
                foreach (string file in listFilePath)
                {
                    zip.AddFile(file);
                }
                zip.Save();
            }

            return strFileName;
        }
    }
}