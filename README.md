# 📦 XunLei.Cloud

一个用于管理迅雷远程客户端的 .NET SDK，支持任务查询、添加下载任务、控制客户端行为等操作，助你轻松构建自动化下载管理系统。

---

## 🚀 功能特性

- 📥 添加磁力链接、BT种子、普通下载任务
- 📊 查询任务列表、下载进度、任务状态

---

## 📦 安装方式

使用 NuGet 包管理器：

```bash
dotnet add package XunLei.Cloud
```

---

## 📦 配置信息
```csharp
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