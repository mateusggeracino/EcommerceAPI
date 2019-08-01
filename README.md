# EcommerceAPI

## Build Status
[![Build status](https://ci.appveyor.com/api/projects/status/gu2updv7xxv6v95w/branch/master?svg=true)](https://ci.appveyor.com/project/mateusggeracino/ecommerceapi/branch/master)

# Funcionamento do Sistema

## Customer

[CustomerType] - Tipo de Cliente  
F - Pessoa Física  
J - Pessoa Jurídica  
[CustomerDocument] - Número do documento do cliente (CPF ou CNPJ)  
[CustomerName] - Nome do cliente ou razão social  
[CustomerGender] - Gênero do cliente  
M - Masculino  
F - Feminino  
NI - Não Informado  
[CustomerAddress] - Endereço do cliente  
[CustomerTelephone] - Número de telefone do cliente  
[CustomerEmail] - E-mail do cliente  

## Store

[StoreName] - Nome da loja  
[StoreAddress] - Endereço da loja  
[StoreTelephone] - Número de Telefone da loja  

## Product

[ProductType] - Tipo de Produto  
[ProductDescription] - Descrição do Produto  
[Brand] - Marca do Produto  
[ProductSpecs] - Especificações do produto. ex: caixa 15 unidades, 500 gramas  
[ProductStatus] - Estado do produto:  
0 - Inativo  
1 - Ativo  
[ProductDeptId] - Opcional. Pode-se setar um código de departamento para o produto.

## Price

[PriceStoreId] - Código da loja relacionada ao preço.
[PriceProductId] - Código do produto relacionado ao preço.
[Promotion] - Flag de promoção. Caso ativo, o sistema apresentará o PromotionalPrice, caso contrário, o sistema mostrará o RegularPrice.  
0 - Inativo  
1 - Ativo  
[RegularPrice] - Preço normal do produto.  
[PromotionalPrice] - Preço Promocional do produto.  
[PriceGroup] - Pode-se setar um grupo de preços. Assim, na versão completa, pode-se alterar o preço de todos os produtos do mesmo grupo de uma só vez.  

## Stock

[StockStoreId] - Código da loja relacionada ao estoque.  
[StockProductId] - Código do produto relacionado ao estoque.  
[RealStock] - Estoque físico da loja.  
[VirtualStock] - Estoque da loja decrescido dos itens vinculados à ordens ainda não finalizadas.

## Shopping Cart

[CartCustomerId] - Código do cliente  
[CartStoreId] - Código da loja  
[CartProductId] - Código do Produto  
[Quantity] - Quantidade do produto adcionado ao carrinho  
[CartCreation] - Data de criação do carrinho  
[CartExpiring] - Data de validade do carrinho  
[CartStatus] - Estado do carrinho de compras  
0 - Cancelado/Expirado  
1 - Ativo  
x - Número do pedido relacionado ao carrinho (preenchido quando da criação de um pedido).  
[CartUnitPrice] - Preço unitário do produto no momento da finalização do carrinho (Preço unitário efetivo).  
Ao finalizar um carrinho (exceto por expiração), será criado um pedido de compras.  
O preço unitário fechado para cada produto deve ser salvo no repositório de dados.  

## Order

[OrderCartId] - Código do Carrinho de compras relacionado ao pedido  
[OrderCreation] - Data de criação do pedido  
[OrderExpiring] - Data de validade do pedido  
[OrderStatus] - Estado do pedido  
0 - Cancelado/Expirado  
1 - Aguardando Pagamento  
2 - Pagamento finalizado  
3 - Pagamento não autorizado  
[OrderTotalValue] - Valor total do pedido  
Os pedidos de compras devem ser criados com status inicial 1.  
Deve também ser criado com o valor total do pedido.  
O respectivo carrinho de compras deve ser atualizado com o número do pedido.  
Ao finalizar um pedido (exceto por expiração), será criado um novo pagamento com a forma de pagamento selecionada pelo cliente.

## Payment

[OrderId] - Código do pedido relacionado ao pagamento.  
[PayPMId] - Código da forma de pagamento.  
[PayStatus] - Estado do pagamento.  
0 - Sem resposta  
1 - Autorizado  
2 - Não autorizado  
3 - Aguardando Validação do Pagamento  
[PayTransactionId] - ID da transação gerado pela integração.  
Os pagamentos devem ser autorizados por integração com empresa terceira.  
Após a resposta da integração, é necessário alterar o status do pagamento e o status do pedido relacionado ao pagamento.

## Payment Method

[Type] - Forma de pagamento  
[SupplierId] - Código do fornecedor do sistema de integração relacionado ao pagamento.  
[EndPointName] - Nome do EndPoint solicitado pelo sistema de integração do fornecedor.

## Payment Supplier

[PSName] - Nome do fornecedor (apelido ou razão social).  
[PSDocumentId] - CNPJ do fornecedor.  
[IntegrationMethod] - Método de integração. ex: API  
[ConnectionString] - String de conexão com a Integração.  
