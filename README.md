# SuppliesWebApplication

# О проекте
backend часть и frontend сделаны отдельными проектами

# Про backend
Использованные технологии: C#, ASP.NET, MS SQL.
Использованне библиотеки: EnityFramework, CSharpFunctionalExtensions.

Для получения строки подключения я использовал пользовательские секреты secrets.json, содержание которого

`
{
  "ConnectionStrings": { 
  "Database": "Server=(localdb)\\mssqllocaldb;Database=projectDatabase;Trusted_Connection=True;"
  },
}
`
Сам проект запускается через проект SuppliesWebApplication.API

# Про frontend
React js + TypeScript

В проекте нужно в файле api2.ts поставить API_URL на котором запустится backend проект

Сам проект запускается через проект supplieswebapplication.client.react
