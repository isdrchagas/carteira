## Carteira

### TRABALHO AVALIATIVO 1
GRUPOS: **1 ou 2 alunos;**

ENTREGA: **Link do GitHub + Apresentação Em Aula (apenas para o professor – não criar ppt)**

Utilizando uma tecnologia compatível com Mobile (Nativo,Framework,PWA , SPA ou outros)
para desenvolver um software com interface gráfica para Carteira de valores monetários
conforme Especificado:

1. Funcionalidade Administrativa:
  - Exibir Todas as Carteira e Saldo
  - Alterar Data e Hora do Sistema
  - Gerar Cobrança de Tarifa( Máximo uma por vez Mês – Valor:R$19,90)

2. Funcionalidade de uso:

  - Cadastrar Nova Carteira:
    - Requisitos da Carteira:
      - **Propriedade:**
      NumeroDaConta, Nome, Saldo, CPF, LimiteConta, Tarifa
      - **Métodos:**
      Sacar, Depositar, Transferir, CobrarTarifa
    
  - Regra:
    - Ao criar conta o Limite da conta vai ser igual a 10% do valor do Primeiro Deposito (OBS:
    para criar conta é obrigatorio realizar um deposito)

- Deposito: usuário deve poder realizar operações de deposito somente com valores positivos
no horário comercial das 08:00 as 18:00

- Saque: usuário deve poder realizar operações de saque somente no horário comercial das
08:00 as 18:00, respeitando saldo disponível e limite da sua conta.
D Transferência: transferência de valores entre usuários respeitando saldo. Caso transação
seja de valor maior que 1000 pedir para verificar os primeiros 3 dígitos do CPF para liberar a
transação