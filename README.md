# Sistema de Eleição

Projeto desenvolvido em C# para a disciplina de Garantia da Qualidade de Software, utilizando testes unitários com xUnit.

## Funcionalidades

- Cadastro de candidatos com validação de números duplicados.
- Registro de eleitores com identificadores simulados.
- Registro de votos e prevenção de votos duplicados.
- Contabilização de votos brancos e nulos.
- Apuração dos votos e identificação do vencedor ou de empate.

## Tecnologias utilizadas

- C#
- .NET
- xUnit
- Git e GitHub

## Como executar

É necessário ter o SDK do .NET instalado.

Clone o repositório e acesse a pasta do projeto. Em seguida, execute:

```bash
dotnet restore
dotnet build
dotnet run --project SistemaEleicao.Console/SistemaEleicao.Console.csproj
```

## Como executar os testes

Na pasta principal do projeto, execute:

```bash
dotnet test
```

Os testes verificam as regras de cadastro de candidatos, registro de eleitores e votação.

## Disciplina

Garantia da Qualidade de Software — Gestão e Qualidade de Software

Professor: Daniel Henrique Matos de Paiva