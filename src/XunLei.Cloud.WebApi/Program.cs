
namespace XunLei.Cloud.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddXunLeiCloud(p =>
            {
                //https://xluser-ssl.xunlei.com站点的clientid 详情见该站点F12请求内容中附带的值
                p.AccountClientID = "";
                //迅雷登陆手机号码 必须添加+86开头例如: +86 130xxxxxxxx
                p.LoginName = "";
                //迅雷登陆密码
                p.LoginPassword = "";
                //https://pan.xunlei.com/yc/home/站点的clientId 详情见该站点F12请求内容中附带的值
                p.ClientID = "";
                //https://pan.xunlei.com/yc/home/站点的deviceId 详情见该站点F12请求内容中附带的值
                p.DeviceID = "";
                //版本号 固定2.9.0
                p.ClientVersion = "2.9.0";
                /// <summary>
                /// 签名算法（用于签名的算法）
                /// https://pan.xunlei.com/yc/home/
                /// 固定的 Algorithms 参数，在网站的 webpack:///src/api/algorithms.ts 文件里面可以找到
                /// </summary>
                p.Algorithms = "";
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
