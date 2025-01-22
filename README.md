# WinForms Application Template

一个基于 .NET 8.0 的 WinForms 应用程序模板，采用分层架构设计。

## 项目结构

```
YourSolution/
├── YourSolution.Model/        # 数据模型层
├── YourSolution.DAL/          # 数据访问层
├── YourSolution.BLL/          # 业务逻辑层
└── YourSolution.WinForm/      # 表现层（UI）
```

## 技术栈

- .NET 8.0
- Windows Forms
- Microsoft.Extensions.DependencyInjection (9.0.1)
- Serilog (3.1.1)
  - Serilog.Sinks.File
  - Serilog.Sinks.Console
  - Serilog.Sinks.SQLite
- Microsoft.EntityFrameworkCore.Sqlite (9.0.1)

## 功能特性

### 1. 分层架构
- Model: 数据模型定义
- DAL: 数据访问实现
- BLL: 业务逻辑处理
- WinForm: 用户界面

### 2. 用户管理
- 用户登录
- 用户信息管理（CRUD操作）
- 用户状态管理

### 3. 日志系统
- 结构化日志记录
- 多目标输出（控制台、文件、SQLite）
- 日志查看器
  - 按日期范围查询
  - 按日志级别筛选
  - 关键字搜索
  - 实时日志查看

### 4. 系统特性
- 依赖注入支持
- 全局异常处理
- MDI 窗体设计

## 快速开始

1. 克隆仓库

## 开发环境要求

- Visual Studio 2022 或更高版本
- .NET 8.0 SDK
- Windows 7 或更高版本

## 配置说明

### 日志配置
日志文件存储在应用程序目录的 `Logs` 文件夹下：
- 文本日志：`Logs/log-{Date}.txt`
- SQLite数据库：`Logs/logs.db`
- 错误日志：`Logs/Error/log-{Date}.txt`

## 贡献指南

1. Fork 项目
2. 创建特性分支 (`git checkout -b feature/AmazingFeature`)
3. 提交更改 (`git commit -m 'Add some AmazingFeature'`)
4. 推送到分支 (`git push origin feature/AmazingFeature`)
5. 创建 Pull Request

## 许可证

[MIT License](LICENSE)

## 联系方式

- 项目维护者：[dong]
- Email：[1749492810@qq.com]

## 更新日志

### [1.0.0] - 2025-01-22
- 初始版本发布
- 实现基础用户管理功能
- 集成结构化日志系统