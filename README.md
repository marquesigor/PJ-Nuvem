# PJ-Nuvem
Projeto de cadastro de Processos Jurídicos para processo seletivo.

WebApi 2.0, criada na modelagem DDD (Domain Driven Development) utilizando a linguagem c#.


* Utilizando o code first, adicionar migration LevantamentoDaBase no Package Manager Console.
	-> Abra o Package Manager Console.
	-> Selecione o projeto de infra.
	-> Rodar o comando Add-Migration CriacaoDaBasePJNuvem
	-> Rodar o comando Update-Database após a criação do script feito pelo Add-Migration

* Rodar script "Criacao-Usuario.sql" para criar o usuário padrão.
* Rodar script "Criação da procedure.sql" para criar a procedure usada no retorno das varas.
* Utilizar o endpoint caminhoLocalhost/api/security/token para autenticar o usuário
	-> grant_type: password
	-> username: admin@outlook.com
	-> password: admin1234
* Rodar a api e usar o swagger para facilitar o teste.
	-> basta colocar caminhoLocalhost/swagger

* OBS: É necessário a utilização do TOKEN de autenticação para realização da autorização...
	ex: "bearer TOKEN GERADO"