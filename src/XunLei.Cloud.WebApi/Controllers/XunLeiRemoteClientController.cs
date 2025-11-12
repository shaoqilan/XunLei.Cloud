using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using XunLei.Cloud.IServices;
using XunLei.Cloud.Services;

namespace XunLei.Cloud.WebApi.Controllers
{
    /// <summary>
    /// 迅雷远程客户端控制器
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class XunLeiRemoteClientController : ControllerBase
    {
        private readonly IRemoteManageService remoteManageService;
        private readonly IManageService manageService;
        public XunLeiRemoteClientController(IRemoteManageService remoteManageService, IManageService manageService)
        {
            this.remoteManageService = remoteManageService;
            this.manageService = manageService;
        }
        /// <summary>
        /// 获取客户端列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<object> GetClientList()
        {
            var result = await remoteManageService.GetClientList();
            return result;
        }
        /// <summary>
        /// 获取指定客户端的路径信息
        /// </summary>
        /// <param name="target"></param>
        /// <param name="parent_id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> GetClientPath([FromForm] string target, [FromForm] string parent_id = "")
        {
            //获取指定客户端可用的api地址
            var apis= await remoteManageService.GetClientApi(target);
            //获取客户端的下载路径信息
            var result = await manageService.GetClientPath(apis.FirstOrDefault(), target, parent_id);
            return result;
        }
        /// <summary>
        /// 添加一个下载任务到远程客户端
        /// </summary>
        /// <param name="target">目标客户端编号</param>
        /// <param name="url">文件下载地址</param>
        /// <param name="folder_id">存储的目录ID</param>
        /// <param name="file_range">需要下载的文件序号范围格式:x,x-x</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> AddDownloadTask([FromForm]string target, [FromForm] string url, [FromForm] string folder_id, [FromForm] string file_range)
        {
            var result = await remoteManageService.AddDownloadTask(target,url,folder_id,file_range);
            return result;
        }
    }
}
