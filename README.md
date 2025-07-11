# 🎓 MyEvents - Sistema de Gerenciamento de Eventos Acadêmicos

## Visão Geral
MyEvents é um sistema web robusto e escalável para gerenciamento completo de eventos acadêmicos. Permite o cadastro e organização de eventos, atividades, inscrições, certificados, avaliações e muito mais.

## 🛠️ Tecnologias Utilizadas
- .NET 8.0 (ASP.NET Core)
- Clean Architecture
- Unit of Work
- PostgreSQL
- EntityFramework
- FluentMigrator
- FluentValidator
- JWT (JSON Web Tokens)


## Estrura do Projeto
```text
├── Library/
│   ├── Http/
│   └── Utils/
│
├── Source/
    ├── Core/
    │   ├── Application/
    │   └── Domain/
    │ 
    ├── Infrastructure/
    │   ├── DAO/
    │   └── IoC/
    │
    └── Presenter/
       └── API/

```