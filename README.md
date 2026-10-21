# TaskFlow — Gerenciador de Tarefas

O **TaskFlow** é uma aplicação web desenvolvida para facilitar a organização e o gerenciamento de tarefas do dia a dia. O projeto foi criado com o objetivo de praticar conceitos de desenvolvimento web, programação em C# e persistência de dados, utilizando uma interface simples, moderna e intuitiva.

## 🎯 Objetivo do projeto

O objetivo do TaskFlow é permitir que o usuário organize suas atividades, acompanhe o andamento das tarefas e identifique quais precisam de mais atenção, por meio de um dashboard com indicadores e ferramentas de pesquisa e filtragem.

## ✨ Funcionalidades

- **Dashboard:** visualização de indicadores com o total de tarefas, tarefas pendentes, concluídas e tarefas de prioridade alta.
- **Criar tarefas:** cadastro de novas atividades.
- **Editar tarefas:** alteração das informações de uma tarefa existente.
- **Excluir tarefas:** remoção de tarefas cadastradas.
- **Concluir e reabrir tarefas:** atualização do status das atividades.
- **Prioridades:** classificação das tarefas em baixa, média e alta.
- **Pesquisa:** busca de tarefas pelo título.
- **Filtros:** organização por prioridade e situação.
- **Paginação:** navegação entre páginas para facilitar a visualização de listas maiores.
- **Interface responsiva:** adaptação dos elementos visuais para diferentes tamanhos de tela, conforme os estilos implementados.

## 🛠️ Tecnologias utilizadas

- **C#** — linguagem principal da aplicação.
- **ASP.NET Core MVC** — estrutura para organização entre Models, Views e Controllers.
- **Entity Framework Core** — acesso e manipulação dos dados.
- **SQLite** — banco de dados utilizado para armazenar as tarefas.
- **HTML5** — estrutura das páginas.
- **CSS3** — estilização e identidade visual.
- **JavaScript** — suporte a interações da interface, quando necessário.
- **Git e GitHub** — versionamento e hospedagem do código-fonte.

## 🧠 Organização do projeto

O projeto segue o padrão arquitetural MVC (*Model-View-Controller*), separando as responsabilidades da aplicação:

- **Models:** representam as entidades e regras relacionadas aos dados, como as tarefas e suas prioridades.
- **Views:** contêm as páginas e os elementos visuais apresentados ao usuário.
- **Controllers:** recebem as requisições, executam as operações e conectam as Views aos dados.
- **Data:** contém a configuração do contexto do banco de dados.
- **wwwroot:** armazena arquivos estáticos, como CSS, JavaScript e outros recursos visuais.

## 🤖 Uso de Inteligência Artificial

O desenvolvimento do TaskFlow contou com o auxílio de ferramentas de **Inteligência Artificial (IA)** como apoio ao processo de aprendizagem e desenvolvimento.

A IA foi utilizada para auxiliar na compreensão de conceitos, na resolução de dúvidas, na identificação de possíveis erros, na organização do código e na implementação de funcionalidades. As sugestões foram utilizadas como suporte durante o desenvolvimento, com o objetivo de compreender melhor as tecnologias empregadas e evoluir minhas habilidades de programação.

A utilização de IA fez parte do processo de aprendizagem, sem substituir a importância de estudar, testar, revisar e compreender o funcionamento da aplicação.

## 🚀 Como executar o projeto

### Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download)
- Editor de código, como o [Visual Studio Code](https://code.visualstudio.com/)
- Git, caso deseje clonar o repositório

### Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/MarcoAntonioRD/TaskFlowWeb.git
   ```

2. Entre na pasta do projeto:

   ```bash
   cd TaskFlowWeb
   ```

3. Restaure as dependências:

   ```bash
   dotnet restore
   ```

4. Execute as migrações do banco de dados, se necessário e conforme a configuração do projeto:

   ```bash
   dotnet ef database update
   ```

5. Inicie a aplicação:

   ```bash
   dotnet run
   ```

6. Acesse o endereço local informado no terminal.

> **Observação:** o comando de migração requer a ferramenta `dotnet-ef` e as dependências correspondentes instaladas. Caso o banco já esteja configurado, siga as instruções específicas do projeto.

## 📚 Aprendizados

O desenvolvimento do TaskFlow proporcionou a oportunidade de praticar:

- Desenvolvimento de aplicações web com ASP.NET Core MVC.
- Operações CRUD (criar, consultar, atualizar e excluir).
- Integração entre aplicação e banco de dados com Entity Framework Core.
- Utilização de consultas e filtros com LINQ.
- Organização de código utilizando o padrão MVC.
- Construção e estilização de interfaces com HTML e CSS.
- Uso de Git e GitHub para versionamento.
- Utilização responsável de Inteligência Artificial como ferramenta de apoio ao aprendizado.

## 🔮 Melhorias futuras

Algumas funcionalidades que podem ser implementadas em versões futuras:

- Autenticação e contas de usuário.
- Datas de vencimento e lembretes.
- Categorias personalizadas para tarefas.
- Ordenação por data, prioridade ou status.
- Testes automatizados.
- Melhorias contínuas de acessibilidade e responsividade.

## 👨‍💻 Autor

**Marco Antonio**

GitHub: [MarcoAntonioRD](https://github.com/MarcoAntonioRD)

---

Este projeto foi desenvolvido para fins de estudo e prática, com foco no aprendizado de desenvolvimento web, organização de código e construção de aplicações utilizando tecnologias do ecossistema .NET.
