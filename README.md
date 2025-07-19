# ?? filmes-api-csharp-crud-aspnetcore-swagger

Uma API RESTful desenvolvida em **C# com ASP.NET Core 8**, que realiza opera��es de CRUD sobre um cat�logo de filmes. O projeto utiliza boas pr�ticas como DTOs, AutoMapper, Entity Framework Core e documenta��o com Swagger.

---

## ?? Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **AutoMapper**
- **Swagger / Swashbuckle**
- **JSON Patch (para atualiza��es parciais)**

---

## ?? Funcionalidades da API

| M�todo | Endpoint           | Descri��o                              |
|--------|--------------------|----------------------------------------|
| POST   | `/filme`           | Adiciona um novo filme                 |
| GET    | `/filme`           | Lista todos os filmes (com pagina��o) |
| GET    | `/filme/{id}`      | Retorna um filme pelo ID              |
| PUT    | `/filme/{id}`      | Atualiza completamente um filme       |
| PATCH  | `/filme/{id}`      | Atualiza��o parcial com JSON Patch    |
| DELETE | `/filme/{id}`      | Remove um filme                       |

---

## ??? Como Executar Localmente

### Pr�-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local ou via Docker)

### Passos

```bash
# Clone o reposit�rio
git clone https://github.com/wotoss/filmes-api-csharp-crud-aspnetcore-swagger.git
cd filmes-api-csharp-crud-aspnetcore-swagger

# Restaure os pacotes
dotnet restore

# (Opcional) Configure a string de conex�o no appsettings.json

# Aplique a migra��o (caso necess�rio)
dotnet ef database update

# Execute o projeto
dotnet run
