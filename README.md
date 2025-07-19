# SuppliesWebApplication

# О проекте
backend часть и frontend сделаны отдельными проектами

# О запуске backend
Для получения строки подключения я использовал пользовательские секреты secrets.json, содержание которого

`
{
  "ConnectionStrings": { 
  "Database": "Server=(localdb)\\mssqllocaldb;Database=projectDatabase;Trusted_Connection=True;"
  },
}
`
Сам проект запускается через проект SuppliesWebApplication.API

# О запуске frontend
В проекте нужно в файле api2.ts поставить API_URL на котором запустится backend проект

Сам проект запускается через проект supplieswebapplication.client.react
