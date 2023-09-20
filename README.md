# ClimaApi
Api para exibir e registrar clima de cidades e aeroportos, e que consuma dados da Brasil API ( https://brasilapi.com.br/docs ), 
que retornará um determinado clima para uma cidade ou aeroporto informada na rota da API, 
que mostre no console os dados a cada requisição realizada.

Requitos:
1. Ao menos uma rota para o clima da cidade
2. Ao menos uma rota para o clima do aeroporto 
3. Persistir esses dados no Sql Server a cada requisição
4. Salvar logs no Sql Server caso aconteça algum erro de processamento de dados
5. Documentar a API através do Swagger 

Foi utilizamos C# (.Net 6+ / Dapper) e SqlServer. 
