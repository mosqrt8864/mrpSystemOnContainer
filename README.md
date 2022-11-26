# 前言

此專案是小弟練習使用Layered Architecture來開發實作MRP系統，並且熟悉.Net Core的使用方式，實作WebApi CRUD，利用MVC網頁做簡單操作畫面，
功能如下：

* 料號CRU操作
* 請購單CRUD操作

## 技術

* ASP.NET Core 6
* Entity Framework Core
* AutoMapper
* NUnit

## 使用

WebApi服務啟動方法

```command line
dotnet run --project src/LayeredArchitecture
```

MRP系統(WebMVC)啟動方法

```command line
dotnet run --project src/Webs/WebMVC
```

開啟瀏覽器輸入

```url
http://localhost:5000/
```

Unit Test
```command line
    dotnet test src/LayeredArchitecture.Tests
```