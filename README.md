# Desafio para candidatos à vaga de desenvolvedor Full Stack

A idéia deste desafio é nos permitir avaliar melhor as habilidades de candidatos à vagas de programador, de vários níveis.
Este desafio deve ser feito por você em sua casa. Gaste o tempo que você quiser, porém normalmente você não deve precisar de mais do que algumas horas.

## Instruções de entrega do desafio
1. Primeiro, faça um fork deste projeto para sua conta no Github (crie uma se você não possuir).
2. Em seguida, implemente o projeto tal qual descrito abaixo, em seu próprio fork.
3. Crie as instruções de instalação e execução do aplicativo em seu readme.md.
4. Por fim, envie o link do seu repositorio para avaliarmos seu código.

## Descrição do projeto
O desafio é criar tanto uma API REST quanto uma interface Angular@5+ que listas os personagens filtrando por espécie, será possivel para os usuários registrados dependendo do perfil ver mais detalhes do personagem.

A aplicacao deverá lidar com 2 tipos de perfil de acesso: Anonimo e Jedi.
1. Anonimo: Usuarios acessando de forma anonima a aplicacao poderao listar os personagens por especie, mas nao poderao visualizar os detalhes.
2. Jedi: Usuarios registrados e logados com o perfil Jedi possuirá todas as permissoes do perfil anonimo e podera visualizar o Nome do planeta natal do personagen.

> Os servicos de consulta de personagens, planetas e especies e fornecido pelo The Star Wars API, a documentacao pode ser acessada nesse link [https://swapi.co/documentation](https://swapi.co/documentation).

## Sua aplicação DEVE:
* Utilizar o padrão de autenticacao OAuth2 tanto no front quanto na api;
* Deve utilizar o padrao de autenticacao OAuth2;
* Deve autenticar o acesso aos metodos anonimos utilizado OAuth2 Client credentials;
* Deve autenticar o acesso aos metodos privados com OAuth2 Authorization code;
* No filtro de especies utilizar um componente de Typeahead;
* Utilizar .Net Framework 4+ ou .NET Core 1.1+;
* Utilizar Angular@5+;
* Utilizar SQL Server (pode ser express);
* Deve possuir um registro de usuário do perfil JEDI, o acesso ao registro pode ser feito por qualquer pessoa.

## Sua aplicação NÃO DEVE:
* Nao deve importar pacotes de auxilio do swapi.co.

## Avaliação
Seu projeto será avaliado de acordo com os seguintes critérios. 

1. Sua aplicação atende funcionalmente o que foi pedido;
2. Você documentou a maneira de configurar o ambiente e rodar sua aplicação na maquina do avaliador utilizando o README.md;
3. Você seguiu as instruções enviadas;
4. Voce segue as boas práticas de programação e entrega para o Cliente;
5. O código escrito é facil de entender e manter;
6. Você se preocupa com o uso do aplicativo pelo Usuário;

> Tentaremos verificar a sua familiarização com as bibliotecas padrões (standard libs), bem como sua experiência com programação orientada a objetos a partir da estrutura de seu projeto, preucupação com o objetivo da aplicação e do seu uso pelo usuário, suporte e manutenção do código por outros desenvolvedores.
