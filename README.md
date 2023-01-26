<h1 align="center">
   <p>DEVinCar - API RESTful de Vendas</p>
     Projeto desenvolvido para o curso DEVinHouse - turma NDD
</h1>

## 💻 Sobre o projeto

O projeto desenvolve uma API para vendas de carros,respeitando padrões Rest. Separadas em modulos de cadastro,vendas e geo-posicionamento.

## 🌱Aprendizados
- Atuar em projeto .Net com Entity Framework em C#, conectando em base SQL Server
- cache
- middleware
- content negotiation
- paginação 
- autenticacao jwt 

### Pré-requisitos

Para rodar o projeto em sua máquina, você vai precisar ter instalado as seguintes ferramentas:
[Git](https://git-scm.com) e [.NET 6.0](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
Além disto é importante ter um editor para trabalhar com o código, como [VisualStudio](https://visualstudio.microsoft.com/) e um sistema gerenciador de Banco de dados relacional, como o [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads).

#### 🎲 Rodando a Aplicação

<ol start="1">
<li>Clone o projeto </li>

```bash
$ git clone https://github.com/hibrunasimoes/devincar-api-restful.git
```

<li> Para Windowns, vá para o arquivo <b style="color:#7b9eeb">appsettings.json</b> e adicione a ConnectionString, seguindo o modelo abaixo: <br>

```bash
"ConnectionStrings": {
  "ServerConnection": "Server=YOURSERVER\\SQLEXPRESS;Database=BD_CONDOMINIODEVAPI;Trusted_Connection=True;"
  }
```
</li>
  <li> Para Mac, vá para o arquivo <b style="color:#7b9eeb">appsettings.json</b> e adicione a ConnectionString, seguindo o modelo abaixo: <br>

```bash
"ConnectionStrings": {
  "ServerConnection": "Server=localhost;Database=BD_CONDOMINIODEVAPI;User=SA;Password=yourpassword;"
  }
```
</li>

<li>Após o comando executado, atualize o Banco de Dados</li>

```bash
dotnet ef database update
```
<li>Pronto, sua aplicação está pronta para rodar</li>

```bash
dotnet watch run
```
## Autor
Bruna Simões
