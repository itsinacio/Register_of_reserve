# 🏢 Meeting Rooms API - Gestão de Espaços Corporativos

Este projeto é uma **API RESTful** desenvolvida em C# e .NET, focada na gestão eficiente de salas de reunião e espaços corporativos. O objetivo principal do sistema é organizar a agenda do escritório, garantindo que os funcionários encontrem o espaço ideal para suas necessidades e eliminando completamente o caos de horários sobrepostos.

A aplicação foi desenhada com um forte foco nas regras de negócio do mundo real, lidando desde o cadastro de pequenas cabines de foco até a reserva de grandes auditórios, controlando capacidades, recursos físicos e bloqueios para manutenção.

## 🚀 Tecnologias e Arquitetura
- **Linguagem & Framework:** C# 12, .NET 10, ASP.NET Core
- **Banco de Dados & ORM:** SQL Server, Entity Framework Core, Migrations
- **Padrões de Projeto:** Arquitetura em Camadas (Layered Architecture), Generic Repository Pattern, DTOs (Data Transfer Objects) para blindagem de dados e Tratamento Global de Exceções.

## ⚙️ Regras de Negócio e Funcionalidades

O coração desta API reside nas validações de negócio, garantindo que o sistema reflita exatamente o comportamento esperado de um escritório organizado:

- **A Regra de Negócios Principal(Prevenção de Conflitos):** Validação estrita de concorrência de horários. O sistema consulta o banco de dados e impede, em qualquer circunstância, que uma nova reserva seja sobreposta a uma reunião já agendada para a mesma sala e período.
- **Catálogo Inteligente de Salas:** Cadastro de espaços com especificações claras (capacidade máxima e presença de projetores/TVs). Uma sala não pode ser criada com capacidade zero ou negativa.
- **Gestão de Indisponibilidade:** Salas podem ser temporariamente bloqueadas (ex: para manutenção ou reforma), exigindo obrigatoriamente o registro do motivo da indisponibilidade.
- **Reserva Baseada em Requisitos:** Ao solicitar uma reserva, o funcionário informa o que precisa. O sistema barra automaticamente a solicitação se a sala escolhida for menor que a capacidade exigida ou se a reunião precisar de um projetor e a sala não possuir.
- **Ciclo de Vida e Cancelamentos:** Reuniões possuem status definidos (Ativa, Cancelada, Concluída). Um funcionário pode cancelar uma reserva para liberar espaço para outros colegas. Por segurança, o sistema só permite a exclusão definitiva de registros que já estejam cancelados ou concluídos.
- **Histórico e Agenda:** Consultas otimizadas e paginadas para visualizar a ocupação do escritório, permitindo buscar as reservas do dia, de um período específico ou o histórico de uma sala específica.

## 💻 Como Rodar o Projeto

1. Clone o repositório:
    ```bash
    git clone https://github.com/itsinacio/Register_of_reserve.git
    ```
2. Restaure as dependências do projeto:
    ```bash
    dotnet restore
    ```
3. Configure a string de conexão do SQL Server no arquivo appsettings.json:
    ```json
    "MSSQLServerSQLConnection": {
    "MSSQLServerSQLConnectionString": "SuaStringDeConexão"
    }
    ```
4. Aplique as migrations para criar as tabelas e popular o banco de dados:
    ```bash
    dotnet ef database update
    ```
5. Inicialize a aplicação:
    ```bash
    dotnet run
    ```
---
*Projeto desenvolvido para fins de estudo e aprimoramento de engenharia de software.*