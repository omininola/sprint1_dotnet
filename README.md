# Sprint .NET - API

## Integrantes

| Nome                   |   RM   |
| :--------------------- | :----: |
| Otavio Miklos Nogueira | 554513 |
| Luciayla Yumi Kawakami | 557987 |

---

## Descrição

O projeto é uma api rest implementada em .NET conectada com o banco de dados da Oracle, permitindo assim o CRUD completo das entidades Filial e Area, onde cada filial pode ter várias áreas designadas para diferentes situações e status de motos, melhorando assim a organização geral do pátio

---

## Rotas

URL Base -> **http://localhost:5115/**

### Filiais

| Método | Rota | Query | Descrição |
| :----: | :--- | :---: | :-------- |
| POST   | [/api/filial](localhost:5115/api/filial) | x | Cria uma nova instância de filial |
| GET    | [/api/filial](localhost:5115/api/filial) | x | Retorna todas as filiais |
| GET    | [/api/filial/{id}](localhost:5115/api/filial/1) | x | Retorna a filial com o id fornecido |
| GET    | [/api/filial/search](localhost:5115/api/filial/search?nome=Filial1) | nome: string | Retorna todas as filiais que tem o nome passado na query |
| PUT    | [/api/filial/{id}](localhost:5115/api/filial/1) | x | Atualiza a filial com o id fornecido |
| DELETE | [/api/filial/{id}](localhost:5115/api/filial/1) | x | Deleta a filial com o id fornecido |

#### JSON de uma filial

```javascript
{
    "Nome": string,
    "Endereco": string
}
```

### Areas

| Método | Rota | Query | Descrição |
| :----: | :--- | :---: | :-------- |
| POST   | [/api/area](localhost:5115/api/area) | x | Cria uma nova instância de area |
| GET    | [/api/area](localhost:5115/api/area) | x | Retorna todas as areas |
| GET    | [/api/area/{id}](localhost:5115/api/area/1) | x | Retorna a area com o id fornecido |
| GET    | [/api/area/search](localhost:5115/api/area/search?filial=Osasco&status=Conserto) | filial: string, status: string | Retorna todas as areas que pertencem a filial e que possuem o mesmo status das queries |
| PUT    | [/api/area/{id}](localhost:5115/api/area/1) | x | Atualiza a area com o id fornecido |
| DELETE | [/api/area/{id}](localhost:5115/api/area/1) | x | Deleta a area com o id fornecido |

#### JSON de uma area

```javascript
{
    "Status": string,
    "FilialId": number
}
```

---

## Instalação

1. Clone o repositório `git clone https://github.com/omininola/sprint1_dotnet.git`
2. Entre na pasta do projeto `cd sprint1_dotnet\webapi`
3. Rode o comando `dotnet restore`
4. E por fim rode o projeto `dotnet run` 