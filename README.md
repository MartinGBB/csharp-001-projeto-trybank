## Projeto Trybank
Este projeto é um exercício em C# fornecido pela trybe, que implementa funcionalidades básicas para a gestão de contas bancárias. As funcionalidades incluem o registro de contas, login, logout, consulta de saldo, depósito, saque e transferência de dinheiro entre contas.
O objetivo do projeto é a manipulação de dados e passagem de parametros entre metodos e classes.
## Estrutura do Projeto
O projeto é composto por duas partes principais:

1. Trybank.Lib: Contém a lógica de negócio da aplicação bancária.
2. Trybank.App: Contém a aplicação console que interage com o usuário.

## Execução do Projeto
Para executar o projeto, siga os passos abaixo:

1. Clone o repositório:
  ``` zsh
  git clone https://github.com/tu-repositorio/trybank.git
  cd trybank
  ```

2. Restaure os pacotes NuGet necessários:
  ``` zsh
  dotnet restore
  ```
3. Compile e execute a aplicação:
  ```sh
  Copy code
  dotnet run --project Trybank.App
  ```

## Funcionalidades Implementadas
- Registrar Conta: Registra uma nova conta bancária.
- Login: Permite o acesso à conta com número, agência e senha.
- Logout: Encerra a sessão do usuário.
- Consultar Saldo: Verifica o saldo atual da conta.
- Depósito: Adiciona um valor ao saldo da conta.
- Saque: Retira um valor do saldo da conta.
- Transferência: Transfere um valor para outra conta.