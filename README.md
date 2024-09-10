# Projeto ASP.NET Core - Gerador de Arquivos Excel

![Licença](https://img.shields.io/badge/Licen%C3%A7a-MIT-green) ![Versão .NET](https://img.shields.io/badge/.NET-7.0-blue)

## Descrição

Este é um projeto ASP.NET Core MVC que permite aos usuários se cadastrar e autenticar na aplicação. Após o login, o usuário pode gerar arquivos Excel contendo dados fictícios e enviá-los por e-mail. A aplicação é construída com tecnologias modernas e utiliza bibliotecas avançadas para geração de dados e manipulação de arquivos.

## Funcionalidades

- **Cadastro e Autenticação:** Os usuários podem se registrar e fazer login para acessar funcionalidades restritas.
- **Geração de Arquivos Excel:** Crie arquivos Excel com dados fictícios baseados em uma quantidade especificada pelo usuário.
- **Envio de E-mail:** Envie os arquivos Excel gerados diretamente para o e-mail do usuário.

## Tecnologias Utilizadas

- **ASP.NET Core MVC:** Framework para desenvolvimento web.
- **Entity Framework Core:** ORM para acesso e manipulação de dados no banco de dados.
- **Biblioteca [Bogus](https://github.com/bchavez/Bogus):** Para geração de dados fictícios.
- **Biblioteca [EPPlus](https://github.com/EPPlusSoftware/EPPlus):** Para criação e manipulação de arquivos Excel.
- **SMTP:** Para envio de e-mails com o arquivo gerado.

## Requisitos

- .NET 7.0 SDK ou superior
- SQL Server (ou SQL Server Express)
- Visual Studio 2022 ou Visual Studio Code
- Conta de e-mail configurada para envio via SMTP

## Configuração

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/seu-usuario/gerador-de-arquivos-excel.git
   cd gerador-de-arquivos-excel
Passo a Passo para Executar o Projeto
1. Clonar o Repositório
Primeiro, você precisa clonar o repositório do projeto. Abra o terminal (ou prompt de comando) e execute o seguinte comando:
git clone https://github.com/seu-usuario/gerador-de-arquivos-excel.git
Substitua seu-usuario pelo seu nome de usuário no GitHub.

2. Navegar para o Diretório do Projeto
Depois de clonar o repositório, navegue para o diretório do projeto:
cd gerador-de-arquivos-excel

3. Configurar o Banco de Dados
Abra o arquivo appsettings.json no diretório do projeto e configure a string de conexão para o banco de dados. Substitua os valores pelos dados da sua configuração:
"ConnectionStrings": {
  "DefaultConnection": "Server=seu-servidor;Database=nome-do-banco;User Id=seu-usuario;Password=sua-senha;TrustServerCertificate=True;"
}

4. Configurar as Opções de E-mail
Ainda no arquivo appsettings.json, configure as opções de e-mail para o envio dos arquivos:
"EmailSettings": {
  "SmtpServer": "smtp.seu-email.com",
  "SmtpPort": 587,
  "SmtpUser": "seu-email@dominio.com",
  "SmtpPass": "sua-senha"
}

5. Instalar as Dependências
Certifique-se de que você tenha o .NET SDK instalado. Em seguida, no terminal, execute o comando para restaurar as dependências do projeto:
dotnet restore

6. Aplicar Migrações ao Banco de Dados
Para criar as tabelas no banco de dados, aplique as migrações com o seguinte comando:
dotnet ef database update
e você encontrar algum erro relacionado à ferramenta dotnet-ef, certifique-se de que o pacote Microsoft.EntityFrameworkCore.Tools está instalado e atualizado no seu projeto.

7. Iniciar o Projeto
Inicie o projeto com o comando:
dotnet run

Isso irá compilar o projeto e iniciar o servidor local. A aplicação estará disponível no endereço https://localhost:5001 (ou outro, conforme configurado).

8. Acessar a Aplicação
Abra seu navegador e acesse o endereço fornecido para ver a aplicação em execução.

9. Registro e Login
Registro: Navegue até a página de registro e crie um novo usuário.
Login: Após o registro, faça login com suas credenciais.
10. Gerar e Enviar Arquivos Excel
Gerar Arquivo: Na página de geração de arquivos, informe a quantidade de registros e clique em Gerar Arquivo.
Enviar por E-mail: Após gerar o arquivo, clique em Enviar por E-mail para enviá-lo ao seu e-mail cadastrado.
