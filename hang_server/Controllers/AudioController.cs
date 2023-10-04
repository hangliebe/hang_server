using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using hang_server.Models;
using System.Diagnostics;
using AudioModule;

namespace hang_server.Controllers
{
    public class AudioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]    //上传文件是 post 方式，这里加不加都可以
        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);       //统计所有文件的大小
            var filepath = Directory.GetCurrentDirectory() + "/wwwroot/files";  //存储文件的路径
            ViewBag.log = "日志内容为：";     //记录日志内容
            foreach (var item in files)     //上传选定的文件列表
            {
                if (item.Length > 0)        //文件大小 0 才上传
                {
                    var thispath = filepath + "/" + item.FileName;     //当前上传文件应存放的位置
                    if (System.IO.File.Exists(thispath) == true)        //如果文件已经存在,跳过此文件的上传
                    {
                        ViewBag.log += "\r\n文件已存在：" + thispath.ToString();
                        continue;
                    }
                    //上传文件
                    using (var stream = new FileStream(thispath, FileMode.Create))      //创建特定名称的文件流
                    {
                        try
                        {
                            await item.CopyToAsync(stream);     //上传文件
                        }
                        catch (Exception ex)        //上传异常处理
                        {
                            ViewBag.log += "\r\n" + ex.ToString();
                        }
                    }
                }
            }
            return RedirectToAction("Index", "Image");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
