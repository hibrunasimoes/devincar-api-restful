# DEVinCar

Projeto avaliativo **DEVinHouse** desenvolvido com ASP.NET 6 com EntityFramework Core 6, em C#, conectando em base SQL Server.

## Sobre

O projeto desenvolve uma API para vendas de carros. Separados em 3 m�dulos:
1. M�dulo de Cadastro: Respons�vel por manter e gerir o cadastro de usu�rios e produtos; 
2. M�dulo de Vendas: Respons�vel por gerir as vendas de carros e as entregas;
3. M�dulo de Geo-Posicionamento: Respons�vel por gerir o cadastro de cidades, estados e endere�os.


## Como executar

Baixe o projeto para sua m�quina com `git clone https://github.com/DEVin-NDD/M2P2-DEVinCar` ent�o conecte a sua m�quina com um SQL Server local e atualize-o rodando no diret�rio do projeto o comando `dotnet ef database update`. A� voc� ter� o SQL Server atualizado e o projeto est� pronto para ser executado com `dotnet run`. Por padr�o a rota ser�: `https://localhost:7019/` e para acessar o swaggerUI `https://localhost:7019/swagger/index.html`.

## Como ele foi feito

A aplica��o foi desenvolvida em 3 squads distribu�das para os 3 m�dulos, cada squad continha um PO (Product Owner) que era respons�vel por distribuir o desenvolvimento das funcionalidades do sistema entre os integrantes das squads. Cada funcionalidade foi desenvolvida em uma branch separada da Develop e quando pronta enviada para o PO resolver o Pull Request. Al�m disso tamb�m foi utilizado a metodologia Kanban utilizando o Trello como quadro. 

## Squads

### Squad 1

**PO**: Gabriel @get-Friday

**Tema**: M�dulo de Cadastro

Integrantes:

    * Edmilson Gomes Dos Santos
    * Gabriel Elias Thomas
    * Ernesto Procopio Campos De Ara�jo
    * Rodrigo Costa Da Rosa
    * Vitor Serr�o
    * Webert Sousa Silva
    * Angelo Sarto Neto
    * Lucas Pinheiro Martins
    * Davi Felipe Borges
    * Maximiliano Neves Bairros
    * Edenilson Nascimento Lima

### Squad 2

**PO**: Erlon @lelonerlon

**Tema**: M�dulo de Vendas

Integrantes:

    * Eliane De Lima Henriqueta
    * Erlon Ressurrei��o De Jesus
    * Camila Padua Cassimiro
    * Ana Ciochetta
    * Fernando Henrique Madruga Baroni
    * Raul C�sar Mulerschat
    * Leandro Fortes Santos
    * Bruna Sim�es Moita
    * Andr� Lu�s Knapik
    * Joao Victor Loiola Bittencourt
    * Angelo Almeida Carniel Filho
    * Vicente Campos De S�

### Squad 3

**PO**: Natanael @NatanVieira

**Tema**: M�dulo de Geo-Posicionamento

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