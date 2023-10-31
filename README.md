# QuerUmLivro?!

QuerUmLivro é um projeto desenvolvido como proposta para entrega do Tech Challenge Fase 1.

Esse é um projeto de um portal para doação de livros.
O portal oferece a possibilidade de cadastrar livros para doação, para que posteriormente os interessados pelos livros manifestem interesse nesses livros. 
Quando um usuário cadastra um livro, ele passa a ser o doador desse livro.
Os usuários cadastrados podem manifestar interesse nos livros. Após a manifestação de interesse nos livros, os usuários doadores conseguem escolher para quem será destinada a doação dos livros através de uma aprovação de interesses.


## Critérios de Aceite

Os critérios de aceite desse projeto se encontram na raiz desse projeto, ou no link: [./Levantamento de Requisitos.docx](https://github.com/jorgelodev/QuerUmLivro/blob/4edb0f46d13c3db6fa80d3d37b17b814d32a4131/Levantamento%20de%20Requisitos.docx)

## Desenvolvimento 

Para rodar esse projeto você pode usar o Visual Studio. E seguir os passos abaixo:

* Abra o projeto no Visual Studio.
* Abra o Package Manager Console, em "Default project:" selecione o projeto QuerUmLivro.Infra.Data
* Execute o comando Update-Database
* Após o término da execução do comando, rode o projeto da API.

### Banco de Dados

Esse projeto está usando SQL Server, você pode utilizar uma instância que tem instalado na sua máquina.

### API

Essa API foi desenvolvida utilizando utilizando as boas práticas do DDD, com todas as camadas e suas responsabilidades, a partir do template do .NET na versão 7 com C#.

### Swagger

Esta API fornece documentação Swagger para seus endpoints.

## Grupo 33
Jorge - RM351049

