# Trabalho Prático de Banco de Dados

## Projeto Individual
Este projeto consiste num CRUD de usuário seguindo o parâmetro estabelecido pelo professor:

    {
	"cpf": "inteiro",
	"nome": "string",
	"data_nascimento": "data"
	}
Os endpoints feito nesse projeto foram apenas o de cadastrar usuário (POST) e o de exibir os usuários cadastrados (GET).

## Tecnologias utilizadas

- .Net 6;
- MySQL;

## Observações
- O projeto possui documentação no Swagger;
- Ao iniciar a API, o Swagger será iniciado também;
- Ao tentar cadastrar um usuário com CPF que se inicia em "0" (zero), será preciso digitar o CPF sem os 0 (zeros) iniciais;


