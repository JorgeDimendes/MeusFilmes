# 🎬 MeusFilmes API

API RESTful desenvolvida com **ASP.NET Core Web API** para gerenciamento de filmes e categorias, com autenticação e autorização via **JWT**.

O projeto foi construído com arquitetura em camadas, separando responsabilidades entre controllers, services, repositories e DTOs, seguindo boas práticas de organização e manutenção de código.

## 📋 Funcionalidades

- CRUD completo de **Filmes** e **Categorias**
- Relacionamento entre Filme e Categoria (uma categoria possui vários filmes)
- Registro e login de usuários
- Autenticação com **JWT (Bearer Token)**
- Autorização por perfil (roles) nos endpoints protegidos
- Mapeamento entre entidades e DTOs com **AutoMapper**
- Persistência de dados com **Entity Framework Core** e **SQLite**
- Documentação interativa com **Swagger**

## 🛠️ Tecnologias

| Tecnologia | Uso |
|---|---|
| C# / .NET | Linguagem e plataforma |
| ASP.NET Core Web API | Construção da API REST |
| Entity Framework Core | ORM e migrations |
| SQLite | Banco de dados |
| AutoMapper | Mapeamento Model ↔ DTO |
| JWT (JSON Web Token) | Autenticação e autorização |
| Swagger / OpenAPI | Documentação e testes dos endpoints |

---

## 🏗️ Arquitetura

O projeto segue uma arquitetura em camadas:

```
Controller  →  Service  →  Repository  →  Banco de dados (SQLite)
                  ↑
           Regras de negócio
```

- **Controllers:** recebem as requisições HTTP e retornam as respostas.
- **Services:** concentram as regras de negócio e usam o AutoMapper para converter entre Models e DTOs.
- **Repositories:** isolam o acesso a dados (Entity Framework Core).
- **DTOs:** definem quais dados entram e saem da API, sem expor diretamente as entidades.
- **Models:** representam as entidades do domínio.

## 👨‍💻 Autor

**Seu Nome**
Desenvolvedor Backend Júnior | C# | .NET | ASP.NET Core

[LinkedIn](https://linkedin.com/in/jorgemenezess) • [GitHub](https://github.com/JorgeDimendes)
