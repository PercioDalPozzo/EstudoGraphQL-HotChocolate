# Estudo GraphQL com utilização do HotChocolate

## Sobre o Projeto
**EstudoGraphQL-HotChocolate** é uma API simples com interações para cadastrar e recuperar registros de Pessoa. O objetivo é utilizar o GraphQL, explorando as funcionalidades da tecnologia HotChocolate. Documentação oficial: [HotChocolate Docs](https://chillicream.com/docs/hotchocolate/v14).

## Tecnologias Utilizadas
- **Rider** com **ASP.NET Core (SDK .NET 6.0)**
- **HotChocolate** versão 14.0.0
- **Bogus** para geração de dados fictícios para provisionamento da base para teste
- **Entity Framework Core** versão 6.0.33 com banco de dados **InMemory**
- API **RESTful**
- **Swagger** para testes e documentação da API

## Arquitetura
O projeto segue a arquitetura **CQRS** (Command Query Responsibility Segregation), organizada em três camadas principais:
- **API**
- **Domain**
- **Repository**

## Funcionalidades

### Pessoa
- Buscar todos os registros cadastrados
- Buscar pessoas cadastradas por Id
- Registro de novas pessoas

## Como Rodar o Projeto
1. Clone este repositório e abra-o no Rider (ou Visual Studio).
2. Defina o projeto **Api** como o projeto de inicialização.

## Como Testar a API
Ao pressionar **F5**, o sistema será compilado e o Swagger será carregado automaticamente no navegador. Você pode testar as funcionalidades da API diretamente pelo Swagger ou utilizar outra ferramenta, como o **Postman**. Para fins didáticos, foram mantidas as possibilidades de interação tanto pelo controller quanto pelo GraphQL.

### Testar as Funcionalidades pelo Controller
1. **Listar pessoas**
   - **Endpoint:** `GET https://localhost:7052/api/Pessoa`

2. **Listar pessoa por Id**
   - **Endpoint:** `GET https://localhost:7052/api/Pessoa?id=d011a6cd-4878-4520-89be-17facc3c3ff1`

3. **Cadastrar uma nova pessoa**
   - **Endpoint:** `POST https://localhost:7052/api/Pessoa`
   - **Payload:**
     ```json
     {
       "nome": "Pércio",
       "nascimento": "2000-10-29"
     }
     ```

### Testar as Funcionalidades pelo GraphQL
  - Para acessar o portal para envio das requisições, basta acessar a URL da API com `/graphql` (`https://localhost:7052/graphql/`).
  - As consultas abaixo têm como objetivo retornar apenas Id e Nome. Nas consultas teremos a propriedade **origemConsulta**, criado apenas para evidenciar as consultas "A" e "B".
  - O cadastro de Pessoa fará a inclusão e retornará apenas o Id.

1. **Query A - Trazendo todos os registros**
```graphql
query {
 pessoaA() {    
   origemConsulta
   records { 
     id  
     nome      
   }    
 }
}
```

2. **Query A trazendo os dados por Id**
```
query {
  pessoaA(id : "89e4808c-fe30-4444-8357-a99a7371a4d6") {    
    origemConsulta
    records { 
      id  
      nome      
    }    
  }
}
```      
   
3. **Query B trazendo os dados por Id**
```
query {
  pessoaB(id : "7c1b54c0-47d2-45d1-a540-2ed5dd150f7d") {    
    origemConsulta
    records { 
      id  
      nome      
    }    
  }  
}
```

4. **Mutation para cadastrar uma nova pessoa**
```
mutation {
    createPessoa(input: { nome: "Pércio", nascimento: "1992-05-15T00:00:00Z" }) {
        id
    }
}
```
