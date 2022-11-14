# DEVinCar

Projeto avaliativo **DEVinHouse** desenvolvido com ASP.NET 6 com EntityFramework Core 6, em C#, conectando em base SQL Server.

## Sobre

O projeto desenvolve uma API para vendas de carros. Separados em 3 módulos:
1. Módulo de Cadastro: Responsável por manter e gerir o cadastro de usuários e produtos; 
2. Módulo de Vendas: Responsável por gerir as vendas de carros e as entregas;
3. Módulo de Geo-Posicionamento: Responsável por gerir o cadastro de cidades, estados e endereços.


## Como executar

Baixe o projeto para sua máquina com `git clone https://github.com/DEVin-NDD/M2P2-DEVinCar` então conecte a sua máquina com um SQL Server local e atualize-o rodando no diretório do projeto o comando `dotnet ef database update`. Aí você terá o SQL Server atualizado e o projeto está pronto para ser executado com `dotnet run`. Por padrão a rota será: `https://localhost:7019/` e para acessar o swaggerUI `https://localhost:7019/swagger/index.html`.

## Como ele foi feito

A aplicação foi desenvolvida em 3 squads distribuídas para os 3 módulos, cada squad continha um PO (Product Owner) que era responsável por distribuir o desenvolvimento das funcionalidades do sistema entre os integrantes das squads. Cada funcionalidade foi desenvolvida em uma branch separada da Develop e quando pronta enviada para o PO resolver o Pull Request. Além disso também foi utilizado a metodologia Kanban utilizando o Trello como quadro. 

## Squads

### Squad 1

**PO**: Gabriel @get-Friday

**Tema**: Módulo de Cadastro

Integrantes:

    * Edmilson Gomes Dos Santos
    * Gabriel Elias Thomas
    * Ernesto Procopio Campos De Araújo
    * Rodrigo Costa Da Rosa
    * Vitor Serrão
    * Webert Sousa Silva
    * Angelo Sarto Neto
    * Lucas Pinheiro Martins
    * Davi Felipe Borges
    * Maximiliano Neves Bairros
    * Edenilson Nascimento Lima

### Squad 2

**PO**: Erlon @lelonerlon

**Tema**: Módulo de Vendas

Integrantes:

    * Eliane De Lima Henriqueta
    * Erlon Ressurreição De Jesus
    * Camila Padua Cassimiro
    * Ana Ciochetta
    * Fernando Henrique Madruga Baroni
    * Raul César Mulerschat
    * Leandro Fortes Santos
    * Bruna Simões Moita
    * André Luís Knapik
    * Joao Victor Loiola Bittencourt
    * Angelo Almeida Carniel Filho
    * Vicente Campos De Sá

### Squad 3

**PO**: Natanael @NatanVieira

**Tema**: Módulo de Geo-Posicionamento

Integrantes:

    * Natanael Vieira
    * Fabiano Da Silva Lima
    * Dayane Barros De Oliveira Rocha
    * Conrado Fortunato
    * Cleiton Ricardo Spagnol
    * Bruno Dos Santos Coelho
    * Lucas De Jesus Da Silva
    * Patricia Dayane Bispo Da Silva
    * Alexandre Lochetti Gutther Freitas
    * Gabriel Fonteles De Albuquerque
    * Lucas Lucindo
    * Elias Silva De Sousa