# ?? filmes-api-csharp-crud-aspnetcore-swagger

Uma API RESTful desenvolvida em **C# com ASP.NET Core 8**, que realiza operações de CRUD sobre um catálogo de filmes. O projeto utiliza boas práticas como DTOs, AutoMapper, Entity Framework Core e documentação com Swagger.

---

## ?? Tecnologias Utilizadas

- **.NET 8**
- **ASP.NET Core Web API**
- **Entity Framework Core**
- **AutoMapper**
- **Swagger / Swashbuckle**
- **JSON Patch (para atualizações parciais)**

---

## ?? Funcionalidades da API

| Método | Endpoint           | Descrição                              |
|--------|--------------------|----------------------------------------|
| POST   | `/filme`           | Adiciona um novo filme                 |
| GET    | `/filme`           | Lista todos os filmes (com paginação) |
| GET    | `/filme/{id}`      | Retorna um filme pelo ID              |
| PUT    | `/filme/{id}`      | Atualiza completamente um filme       |
| PATCH  | `/filme/{id}`      | Atualização parcial com JSON Patch    |
| DELETE | `/filme/{id}`      | Remove um filme                       |

---

## ??? Como Executar Localmente

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (local ou via Docker)

### Passos

```bash
# Clone o repositório
git clone https://github.com/wotoss/filmes-api-csharp-crud-aspnetcore-swagger.git
cd filmes-api-csharp-crud-aspnetcore-swagger

# Restaure os pacotes
dotnet restore

# (Opcional) Configure a string de conexão no appsettings.json

# Aplique a migração (caso necessário)
dotnet ef database update

# Execute o projeto
dotnet run
