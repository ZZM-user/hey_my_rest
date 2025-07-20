# hey_my_rest 护眼提醒应用

## 项目简介

`hey_my_rest` 是一个基于 Avalonia 跨平台 UI 框架开发的桌面护眼提醒工具，支持 Windows、Linux、macOS。适合长期用电脑的用户，定时弹窗提醒你休息眼睛，保护视力健康。

## 主要功能

- 定时弹窗提醒休息，防止用眼过度
- 支持自定义提醒间隔、持续时间
- 支持自定义提醒话术
- 可设置每日提醒的时间区间（如 09:00~18:00）
- 支持选择每周哪些天进行提醒（如仅工作日）
- 弹窗倒计时动态显示，自动关闭
- 健康温和的界面风格

## 运行环境

- .NET 7.0 及以上（推荐 .NET 8/9）
- Avalonia 11.x
- Windows、Linux、macOS 均可运行

## 安装依赖

1. 安装 [.NET SDK](https://dotnet.microsoft.com/download)
2. 进入项目目录，执行：
   ```bash
   dotnet restore
   ```

## 运行方法

在项目根目录下执行：
```bash
dotnet run --project hey_my_rest/hey_my_rest.csproj
```

或用 Visual Studio / Rider 直接打开解决方案并运行。

## 主要界面说明

- 顶部为应用标题和温馨提示
- 可配置提醒间隔、持续时间、提醒话术
- 可选择提醒的时间段（如 09:00~18:00）
- 可多选每周提醒的星期（如周一至周五）
- 点击“开始提醒”后，应用将在设定时间段和星期内定时弹窗提醒

## 依赖包

- [Avalonia](https://github.com/AvaloniaUI/Avalonia)
- [CommunityToolkit.Mvvm](https://github.com/CommunityToolkit/dotnet)

## 截图预览

> 可在运行后自行体验，界面简洁温和，适合日常办公环境。

---

如有建议或问题，欢迎反馈！
