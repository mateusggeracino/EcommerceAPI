# EcommerceAPI

## Build Status
[![Build status](https://ci.appveyor.com/api/projects/status/gu2updv7xxv6v95w/branch/master?svg=true)](https://ci.appveyor.com/project/mateusggeracino/ecommerceapi/branch/master)

## Regras de Negócio

# Price

Pode-se setar um flag de promoção, alterando-se assim o valor promocional, sem sobrescrever o valor regular do produto.

# Shopping Cart

O carrinho de compras deve ser criado com uma data de criação e uma data de expiração e devem ser criados com status inicial 1.  
No campo status do carrinho temos:  
0 - Cancelado/Expirado  
1 - Ativo  
x - Número do pedido relacionado ao carrinho (preenchido quando da criação de um pedido).  
Ao finalizar um carrinho (exceto por expiração), será criado um pedido de compras.  
O preço unitário fechado para cada produto deve ser salvo no repositório de dados.  

# Order

Os pedidos de compras devem ser criados com data de criação e expiração e devem ser criados com status inicial 1. Deve também ser criado com o valor total do pedido. O respectivo carrinho de compras deve ser atualizado com o número do pedido.  
No campo status do pedido temos:  
0 - Cancelado/Expirado  
1 - Aguardando Pagamento  
2 - Pagamento finalizado  
3 - Pagamento não autorizado  
Ao finalizar um pedido (exceto por expiração), será criado um novo pagamento com a forma de pagamento selecionada pelo cliente.

# Payment

Os pagamentos devem ser autorizados por integração com empresa terceira.  
Após a resposta da integração, é necessário alterar o status do pagamento e o status do pedido relacionado ao pagamento.
