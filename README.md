# MyEvents - Sistema de Gerenciamento de Eventos Acadêmicos

## Visão Geral

O MyEvents é um sistema backend para gerenciamento completo de eventos acadêmicos, desenvolvido sobre a plataforma .NET 8. A aplicação foi estruturada segundo os princípios da Clean Architecture (Arquitetura Limpa), buscando desacoplamento entre regras de negócio, infraestrutura de acesso a dados e camada de apresentação HTTP.

O sistema atende a demandas relativas à organização de eventos, controle de atividades (palestras, minicursos, workshops), gestão de inscrições, confirmação de presença, avaliação de atividades por participantes, geração de certificados digitais e gerenciamento de patrocinadores.

---

## Arquitetura do Sistema

A solução está organizada em projetos modulares, estabelecendo limites claros de responsabilidade e fluxo de dependências unidirecional voltado ao núcleo de domínio.

```text
my-events.net/
├── Library/
│   ├── DTO/
│   ├── Enums/
│   ├── Exceptions/
│   ├── Http/
│   └── Utils/
└── Source/
    ├── Core/
    │   ├── Application/
    │   └── Domain/
    ├── Infrastructure/
    │   ├── DAO/
    │   └── IoC/
    └── Presenter/
        └── API/
```

### Detalhamento das Camadas

1. **Core / Domain (`Source/Core/Domain`)**
   - Contém as entidades centrais do sistema (`User`, `Event`, `Activity`, `Inscription`, `Attendance`, `Certificate`, `Sponsor`, `Evaluation`) e a entidade base (`BaseEntity`).
   - Define os contratos de repositórios segregados por responsabilidade de leitura e escrita (`IUserReadRepository`, `IUserWriteRepository`, etc.), aplicando o princípio da segregação de interfaces (ISP).

2. **Core / Application (`Source/Core/Application`)**
   - Implementa os casos de uso (Use Cases) do sistema de forma granular.
   - Contém os serviços de aplicação, como a criptografia de credenciais (`PasswordEncryptionService`) e a geração de certificados digitais (`CertificateGeneratorService`).
   - Mantém o mapeamento entre requisições HTTP, entidades de domínio e respostas.

3. **Infrastructure / DAO (`Source/Infrastructure/DAO`)**
   - Responsável pela persistência dos dados utilizando o Entity Framework Core 9 integrando-se ao PostgreSQL.
   - Implementa o padrão Unit of Work (`UnitOfWork`) e a implementação concreta dos repositórios de leitura e escrita.
   - Contém o versionamento e controle de schema do banco de dados através do FluentMigrator (`UsersTable`, `EventsTable`, `ActivitiesTable`, etc.).

4. **Infrastructure / IoC (`Source/Infrastructure/IoC`)**
   - Centraliza a configuração de Injeção de Dependência da aplicação (`PercistenceExtension`).
   - Mapeia o tempo de vida das dependências (Scoped, Singleton) para os repositórios, casos de uso, serviços de criptografia e fábrica de contexto do EF Core.

5. **Presenter / API (`Source/Presenter/API`)**
   - Ponto de entrada da aplicação ASP.NET Core Web API em .NET 8.
   - Expõe os controllers RESTful (`UserController`, `EventController`, `ActivityController`, etc.).
   - Configura autenticação JWT via chave assimétrica RSA, middlewares de segurança, suporte a CORS, redirecionamento HTTPS e Swagger para documentação OpenAPI.

6. **Library (`Library`)**
   - Camada transversal que encapsula DTOs, modelos de requisição (`Requests`) e resposta (`Responses`), tipos enumerados (`CertificateType`, `SponsorShipLevel`), auxiliares de autorização e uma hierarquia estruturada de exceções de domínio.

---

## Tecnologias e Bibliotecas

- **Linguagem e Runtime**: C# 12 / .NET 8.0 (ASP.NET Core Web API)
- **Banco de Dados**: PostgreSQL
- **Mapeador Objeto-Relacional (ORM)**: Entity Framework Core 9.0 (`Npgsql.EntityFrameworkCore.PostgreSQL`)
- **Migrações de Banco de Dados**: FluentMigrator (`FluentMigrator.Runner`, `FluentMigrator.Runner.Postgres`)
- **Segurança e Autenticação**: JWT (JSON Web Token) utilizando criptografia assimétrica RSA (`RsaSecurityKey`)
- **Documentação de API**: Swagger UI / OpenAPI (`Swashbuckle.AspNetCore`)
- **Monitoramento de Saúde**: Health Checks (`AspNetCore.HealthChecks.UI.Client`)

---

## Modelo de Domínio e Funcionalidades

### 1. Gestão de Usuários
- Cadastro, atualização, remoção e autenticação de usuários.
- Armazenamento seguro de senhas com serviço dedicado de criptografia (`PasswordEncryptionService`).
- Geração e validação de tokens JWT para rotas protegidas.

### 2. Gestão de Eventos
- Cadastro, atualização, exclusão e consulta de eventos acadêmicos.
- Suporte a filtros dinâmicos de busca (`EventFilter`) por parâmetros de localização, datas e organizadores.

### 3. Gestão de Atividades
- Organização de palestras, minicursos e workshops vinculados a eventos.
- Controle de capacidade de participantes, definição de horários e palestrantes.
- Consulta de atividades via filtros dinâmicos (`ActivityFilter`).

### 4. Inscrições e Frequência
- Registro e cancelamento de inscrições de usuários em eventos/atividades (`Inscription`).
- Confirmação e atualização do registro de presença física/digital (`Attendance`).

### 5. Avaliações
- Submissão de feedback e nota por parte dos participantes em relação às atividades concluídas (`Evaluation`).

### 6. Certificados Digitais
- Emissão automatizada de certificados acadêmicos para participantes e palestrantes (`CertificateGeneratorService`).
- Suporte a múltiplos tipos de certificados definidos pelo enum `CertificateType`.
- Consulta e recuperação de certificados por identificador.

### 7. Patrocinadores
- Cadastro e vínculo de patrocinadores aos eventos acadêmicos (`Sponsor`).
- Classificação por nível de patrocínio através do enum `SponsorShipLevel`.

---

## Tratamento de Exceções e Regras de Negócio

A aplicação utiliza uma estrutura padronizada de exceções estendidas a partir da classe base `ProjectException`:

- **Exceções de Não Encontrado (`NotFoundExceptions`)**: `UserNotFoundException`, `EventNotFoundException`, `ActivityNotFoundException`, `CertificateNotFoundException`, `AttendanceNotFoundException`, `SponsorNotFoundException`, `InscriptionNotFoundException`.
- **Exceções de Validação (`ValidationExceptions`)**: `InvalidDateException`, `EmailAlreadyRegisteredException`.
- **Exceções de Conflito (`ConflictExceptions`)**: `AlreadyRegisteredException`.
- **Exceções de Regra de Negócio (`BusinessRuleExceptions`)**: `AttendanceNotConfirmedException`, `SpeakerNotAssignedException`, `NotInscribedException`.
- **Exceções de Autorização (`AuthorizationExceptions`)**: Invasão de escopo ou permissões insuficientes.

---

## Principais Endpoints da API

| Módulo | Método HTTP | Rota | Descrição |
|---|---|---|---|
| **Usuários** | POST | `/User` | Realiza o cadastro de um novo usuário |
| **Usuários** | POST | `/User/login` | Autentica o usuário e retorna o Token JWT |
| **Usuários** | PUT | `/User/{id}` | Atualiza dados do usuário (Requer Autenticação) |
| **Usuários** | DELETE | `/User/{id}` | Remove a conta do usuário (Requer Autenticação) |
| **Eventos** | GET | `/Event` | Consulta eventos aplicando filtros dinâmicos |
| **Eventos** | GET | `/Event/{id}` | Consulta detalhes de um evento específico |
| **Eventos** | POST | `/Event` | Cadastra um novo evento acadêmico |
| **Eventos** | PUT | `/Event/{id}` | Atualiza informações de um evento |
| **Eventos** | DELETE | `/Event/{id}` | Remove um evento (Requer Autenticação) |
| **Atividades** | GET | `/Activity` | Lista atividades de acordo com os filtros informados |
| **Atividades** | POST | `/Activity` | Cadastra uma nova atividade em um evento |
| **Atividades** | PUT | `/Activity/{id}` | Atualiza os dados de uma atividade |
| **Atividades** | DELETE | `/Activity/{id}` | Remove uma atividade |
| **Inscrições** | POST | `/Inscription` | Inscreve o usuário em uma atividade/evento |
| **Inscrições** | DELETE | `/Inscription/{id}` | Cancela uma inscrição existente |
| **Presença** | POST | `/Attendance` | Registra a presença do participante |
| **Presença** | PUT | `/Attendance/{id}` | Atualiza dados de confirmação de presença |
| **Presença** | DELETE | `/Attendance/{id}` | Cancela a presença |
| **Avaliações**| POST | `/Evaluation` | Envia avaliação sobre uma atividade |
| **Avaliações**| PUT | `/Evaluation/{id}` | Atualiza uma avaliação previamente enviada |
| **Avaliações**| DELETE | `/Evaluation/{id}` | Exclui uma avaliação |
| **Certificados**| GET | `/Certificate/{id}` | Busca os dados do certificado gerado |
| **Patrocinadores**| POST | `/Sponsor` | Cadastra patrocinador para um evento |
| **Patrocinadores**| PUT | `/Sponsor/{id}` | Atualiza os dados do patrocinador |
| **Patrocinadores**| DELETE | `/Sponsor/{id}` | Exclui o registro de patrocínio |

---

## Configuração do Ambiente e Execução

### Pré-requisitos

- SDK .NET 8.0 instalado.
- Servidor de banco de dados PostgreSQL rodando na porta `5432` (ou ajustado conforme configuração).

### Configuração do Arquivo `appsettings.json`

Verifique as configurações de conexão e chaves de segurança presentes em `Source/Presenter/API/appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=myeventsDb;Username=postgres;Password=suasenha"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "EncryptionKey": "SuaChaveDeCriptografiaAqui"
}
```

### Passos para Execução

1. **Clonar o Repositório**:
   ```bash
   git clone <URL_DO_REPOSITORIO>
   cd my-events.net
   ```

2. **Restaurar Dependências**:
   ```bash
   dotnet restore
   ```

3. **Compilar a Solução**:
   ```bash
   dotnet build
   ```

4. **Executar a Aplicação Web API**:
   Ao iniciar o projeto de API, o FluentMigrator executará automaticamente as migrações no banco de dados PostgreSQL configurado.

   ```bash
   dotnet run --project Source/Presenter/API/API.csproj
   ```

5. **Acessar a Documentação Interativa (Swagger)**:
   Em ambiente de desenvolvimento, acesse o navegador no endereço:
   - `https://localhost:7272/swagger` ou `http://localhost:5000/swagger`