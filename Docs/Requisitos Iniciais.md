# Definições do E-commerce PopLume

Este projeto visa a construção de um e-commerce para a loja Poplume, especializada em produtos de impressão 3D.
Seu layout deve seguir as regras:

- Abordagem responsiva para celular, tablet e desktop. Contendo acessibilidade e navegação por teclado
- Feedback ao adicionar itens ao carrinho
- Paginação e / ou carregamento progressivo
- Consentimento e tratamento de dados conforme a LGPD
- Uma identidade mais sofisticada e divertida

## Sobre a referência visual
#### As cores principais:
| Nome | Hexadecimal |
|---|---:|
| Verde-menta | #7FE7C4 |
| Verde-petróleo | #0F5F63 |
| Lilás | #C9B6FF |
| Roxo | #7A4DFF |
| Preto | #111111 |

#### Textos:
**Títulos** em Poppins Bold
**Subtítulos** em Poppins Medium
**Corpo** em Inter Regular

A combinação transmite bem produtos criativos, personalizados e impressão 3D. O preto e o verde-petróleo dão estrutura, enquanto o roxo e o menta funcionam bem como cores de destaque.

# Particularidades da loja

No MVP, a única variação comercial do produto será a cor. Tamanho, material e demais características não poderão ser escolhidos pelo cliente.

Um produto será cadastrado uma única vez e poderá possuir uma ou mais variações comerciais de cor. Não deverão ser criados cadastros duplicados do mesmo produto para representar cores diferentes.

Cada variação:

- Pertencerá a um único produto.
- Terá um nome de cor apresentado ao cliente.
- Poderá ser ativada ou inativada.
- Estará associada a um ou mais filamentos.
- Informará a quantidade em gramas de cada filamento utilizado.
- Poderá informar um percentual de perda para cada filamento.
- Poderá possuir imagens próprias.
- Terá seu custo calculado de acordo com os filamentos utilizados.
- Será tratada como um item distinto no carrinho.

Os filamentos de uma variação representam a receita de fabricação daquela opção comercial. Um produto de uma única cor poderá ter variações alternativas, como preto, azul ou verde. Uma variação também poderá utilizar vários filamentos simultaneamente em produtos multicoloridos.

A escolha da variação será obrigatória antes de adicionar o produto ao carrinho. A precificação será realizada para uma variação específica.

O cliente não poderá enviar arquivos. Caso ele queira algum produto personalizado, deverá entrar em contato conosco a partir dos dados de contato informados na home page.

Haverá um módulo de formação de preço, disponível para funcionário e administrador. O usuário selecionará o produto, sua variação, o equipamento, a margem, a quantidade produzida e, opcionalmente, o marketplace. O preço será calculado automaticamente.

Os filamentos não serão selecionados durante a precificação. O sistema carregará automaticamente os filamentos, quantidades e percentuais de perda vinculados à variação escolhida.

Filamentos serão utilizados na produção e na composição do custo do produto. O custo por grama será calculado dividindo o valor de compra pelo peso líquido do filamento.

Marketplaces servirão apenas para registrar canais de venda. No futuro, poderá ser considerada uma integração, mas ela não fará parte do MVP.

## Escopo do MVP

O MVP será um catálogo digital de produtos. O cliente poderá navegar pelo
catálogo, pesquisar produtos, aplicar filtros, consultar os detalhes e
adicionar produtos ao carrinho.

O carrinho funcionará como uma lista de interesse. A conclusão da compra não
será realizada diretamente pela aplicação. Ao finalizar, o cliente será
direcionado para um canal de atendimento da loja, inicialmente o WhatsApp,
com a relação dos produtos e quantidades selecionados.

O MVP não terá pagamento online, cálculo de frete, criação de pedidos pelo
cliente, acompanhamento de pedidos ou integração com marketplaces.

Essas funcionalidades poderão ser adicionadas em evoluções futuras.

## Perfis e permissões

Abaixo uma tabela contendo os perfis e o que cada um pode fazer nesta etapa do projeto.

| Recurso | Cliente | Funcionário | Administrador | MVP |
|---|---:|---:|---:|---:|
| Editar a própria conta | Sim | Sim | Sim | Sim |
| Consultar pedidos próprios | Sim | Não | Sim | Não |
| Gerenciar produtos | Não | Sim | Sim | Sim |
| Gerenciar clientes | Não | Não, apenas envio de link para trocar senha | Sim | Sim |
| Gerenciar funcionários | Não | Não | Sim | Sim |
| Acessar relatórios | Não | Sim | Sim | Não |
| Gerenciar Equipamentos | Não | Não | Sim |  Sim |
| Gerenciar Filamentos | Não | Sim | Sim | Sim |
| Gerenciar Marketplaces | Não | Não | Sim | Sim |
| Gerenciar Formação de Preço | Não | Sim | Sim | Sim |
| Gerenciar Insumos | Não | Sim | Sim | Sim |
| Gerenciar Tarifas de Energia | Não | Não | Sim | Sim |
| Gerenciar Custos de Mão de Obra | Não | Não | Sim | Sim |
| Consultar Histórico de Precificações | Não | Sim | Sim | Sim |
| Gerenciar Banners (carrossel home) | Não | Sim | Sim | Sim |
| Gerenciar Pedidos | Não | Sim | Sim | Não |
| Gerenciar Newsletter | Não | Sim | Sim| Sim |
| Gerenciar Categorias | Não | Sim | Sim | Sim |


O perfil funcionário não pode ser um cliente simultaneamente. Para isto, ele precisa ter uma conta com perfil de cliente e uma conta com perfil de funcionário.

O perfil funcionário, ao gerenciar clientes, ele só conseguirá listar os clientes e clicar em um botão na própria listagem de clientes que enviará um e-mail com o link para o usuário trocar a sua senha.

O perfil Cliente pode solicitar a troca de senha, com isto, ele recebera um e-mail com um link que redicionará para um formulário onde conseguirá alterar a sua senha.

## Fluxo público do MVP

O MVP terá:

- Home
- Catálogo e categorias
- Busca e filtros
- Página de detalhes do produto
- Carrinho como lista de interesse
- Redirecionamento para o canal de atendimento
- Login, cadastro e recuperação de senha
- Edição dos dados da conta
- Política de privacidade e termos de uso
- Políticas de troca e devolução aplicáveis à compra online

## Evoluções futuras do fluxo público

Não fazem parte do MVP:

- Checkout dentro da aplicação
- Cadastro de endereços de entrega
- Cálculo de frete
- Pagamento online
- Confirmação de pedido
- Histórico e acompanhamento de pedidos

## Regras do Carrinho:

- O carrinho estará disponível sem autenticação.
- A quantidade exibida no cabeçalho representará a soma das unidades adicionadas.
- O carrinho anônimo será preservado durante a navegação.
- O cliente poderá navegar, adicionar produtos e editar o carrinho sem autenticação.
- Para enviar a lista de interesse, será necessário estar autenticado.
- Caso não esteja autenticado, o cliente será direcionado ao login.
- Após o login, retornará ao carrinho com os itens preservados.
- Nome, telefone e e-mail serão obtidos da conta autenticada.
- Ao concluir, o cliente será direcionado para o WhatsApp da loja com uma
  mensagem contendo seu nome, telefone, e-mail, os produtos, quantidades e links correspondentes.
  - Deverá ser enviado também uma cópia da lista de interesse para o e-mail da loja (vendas@poplume.com.br) 
- O carrinho não criará um pedido na aplicação.
- O carrinho não terá um campo para observação
- Caso um produto fique inativo e ele existe em algum carrinho, não acontece nada. Pois o mesmo pode ser re-impresso para atender aquela solicitação.
  - Produto inativo não aparece no catálogo, mas seleções anteriores ainda podem ser enviadas
- O carrinho será mantido enquanto a aba do navegador permanecer aberta e será
apagado quando ela for encerrada.

### Importante!

Antes de enviar o e-mail e abrir o WhatsApp, a API deverá validar os produtos, cores, quantidades e preços atuais. Os preços enviados serão sempre os preços vigentes no momento da solicitação.

### Fluxo do Carrinho:

```
Cliente autenticado confirma a lista
        ↓
Frontend envia a solicitação para a API
        ↓
API valida produtos, cores, quantidades e preços
        ↓
API tenta enviar a cópia por e-mail
        ↓
Frontend abre o WhatsApp com a mensagem preenchida
```
A API não armazenará a lista nem os dados enviados, apenas tentará enviar o e-mail e registrará erros técnicos. Em caso de falha, a API registra via Log o problema que aconteceu. O cliente não deve ser afetado por esta falha. Ou seja, o fluxo continua.

Os dados de Nome, e-mail e telefone serão obtido através dos dados do cliente logado no sistema. Estes dados não vão ficar fixos no código.

## Home

A home terá os seguintes elementos:

- Cabeçalho com logomarca, menu, botão de busca de produtos, botão para acessar o menu de usuário logado e botão do carrinho que irá conter a quantidade de produtos colocados no carrinho pelo usuário.
- Um banner grande com texto e alguns exemplos de produtos que a loja faz
- Vitrine dos novos produtos em destaque
- Rodapé  com 5 colunas sendo:
  - Logomarca
  - Menu sobre a empresa
  - Menu sobre ajuda
  - Dados de contato como telefone, links para rede social
  - Banner para o usuário cadastrar seu e-mail para newsletter


A home fornecerá acesso ao catálogo, às categorias, aos detalhes dos produtos, ao carrinho, à autenticação, à conta do cliente e às páginas institucionais.

Regras da home page:

- O botão de usuário na área deslogada deve abrir login/cadastro.
- O botão de usuário na área deslogada, após login, deve abrir:
  - Formulário de edição de dados de usuário
  - Formulário para troca de senha
  - Botão Sair (efetuar logoff)
- A quantidade de itens no carrinho ficará disponível mesmo sem autenticação, quando o usuário avançar para finalizar a compra, ele deve estar logado. Caso contrário, direcioná-lo para efetuar login e após login, volta para o carrinho.
  - Pois desta forma, os dados do cliente como Nome, Telefone e e-mail serão enviados junto à lista de interesse por Whatsapp e e-mail. (vide [Regras do Carrinho](#regras-do-carrinho))
- O carrinho anônimo será preservado ao fazer login
- Inicialmente as categorias que aparecerão no menu são:
  - Decoração
  - Utilitários
  - Presentes
  - Área Pet
  - Personalizados
- O carrinho não cria um pedido
- Os produtos em destaque serão administráveis. Existe uma flag no cadastro do produto que informará se ele é destaque ou não.
- O banner principal será carrossel e gerenciado pelo sistema. Vamos ter um cadastro de banner para ser usado no carrossel.
- Redes sociais também ficarão dentro da coluna de contato, chegando então às cinco pretendidas.


## Área administrativa

Os primeiros módulos do sistema serão produtos, categorias de produtos, banners, equipamentos, filamentos, insumos, marketplaces e suas faixas de taxas, tarifas de energia, custos de mão de obra, formação de preço, histórico de precificações, clientes e Newsletter contendo:

- Listagem
- Busca e filtros
- Cadastro com máscaras e validações dos formulários
- Edição
- Visualização
- Ativação/inativação
- Paginação
- Confirmação de operações
- Estados de carregamento, erro, vazio e indisponibilidade

O único módulo vendável é o de produtos. Os demais são cadastros para controle interno e montagem de preço de venda.

## Módulo Cadastro de cliente

O MVP será preparado para evolução mesmo o cliente não efetuando compras direto no sistema. Com isto, vamos manter o cadastro, login e edição de perfil, mesmo com utilidade inicial limitada.

## Módulo Cadastro de produto

Validar se o domínio de `Produto` contem todos os campos abaixo, caso não tenha, precisamos alterar a API para receber estas informações.

- Nome
- Descrição curta e completa
- Categoria
- Preço visível
- Produto ativo
- Produto em destaque
- Slug da página
- Prazo estimado de produção
- Código interno
- Cores disponíveis
  - Filamento associado
  - Quantidade utilizada em gramas
  - Percentual de perda
  - Custo calculado automaticamente
  - Uma ou mais imagens associadas
  - A primeira imagem adicionada, será a destaque

### Ficha técnica e composição do produto

O cadastro administrativo do produto deverá permitir definir sua ficha técnica de produção, contendo:

- Equipamento padrão, quando aplicável.
- Tempo de impressão em minutos.
- Tempo de mão de obra em minutos.
- Uma ou mais variações comerciais de cor.
- Um ou mais filamentos por variação.
- Quantidade consumida em gramas para cada filamento.
- Percentual de perda para cada filamento.
- Um ou mais insumos e suas quantidades consumidas.
- Um ou mais produtos componentes, suas variações e quantidades.

Os relacionamentos terão os seguintes significados:

- `ProdutoVariacao`: opção comercial de cor do produto.
- `ProdutoVariacaoFilamento`: matéria-prima utilizada para fabricar uma variação.
- `ProdutoInsumo`: material comprado e consumido durante a produção ou embalagem.
- `ProdutoComposicao`: outro produto e uma de suas variações que fazem parte do produto atual.

Exemplos de insumos incluem argola, fita, plástico-bolha, sacola, caixa, tag e cola.

Um produto composto poderá representar um kit, como um Kit Dia dos Pais formado por um chaveiro, um porta-retrato e um porta-celular.

Um produto não poderá conter a si próprio, possuir a mesma variação de componente duplicada ou criar ciclos diretos ou indiretos de composição. A quantidade de um componente deverá ser maior que zero. Para ser utilizada no cálculo de outro produto, a variação do produto componente deverá possuir preço de custo previamente calculado.

## Módulo Formação de Preço

O módulo de formação de preço faz parte do MVP e será utilizado por funcionários e administradores. Seu objetivo será calcular o custo de produção e sugerir um preço de venda com base na ficha técnica da variação do produto, nos custos vigentes e no canal de venda.

### Pré-requisitos

Antes de realizar uma precificação:

- O produto e sua variação deverão estar cadastrados.
- O equipamento deverá estar cadastrado.
- Os filamentos utilizados deverão estar vinculados à variação.
- Os insumos utilizados deverão estar vinculados ao produto.
- As variações dos produtos componentes deverão possuir preço de custo calculado.
- Deverá existir uma tarifa de energia vigente.
- Deverá existir um custo de mão de obra vigente.
- Caso seja uma venda por marketplace, suas faixas de taxas deverão estar cadastradas.

### Informações selecionadas na precificação

O funcionário ou administrador deverá:

- Selecionar o produto.
- Selecionar a variação comercial de cor.
- Selecionar o equipamento.
- Informar a margem percentual desejada.
- Informar a quantidade produzida no lote.
- Selecionar opcionalmente o marketplace.

Os filamentos não serão selecionados durante a precificação. O sistema utilizará automaticamente os filamentos e quantidades definidos na variação escolhida.

### Componentes do custo

O cálculo deverá considerar:

- Custo dos filamentos da variação.
- Percentual de perda dos filamentos.
- Custo dos insumos.
- Custo dos produtos componentes.
- Custo de energia.
- Custo de depreciação do equipamento.
- Custo de mão de obra.
- Quantidade produzida no lote.
- Margem desejada.
- Comissão percentual do marketplace.
- Taxa fixa do marketplace.

### Custo dos filamentos

O custo por grama será calculado por:

`Custo por grama = Valor de compra do filamento / Peso líquido em gramas`

O custo de cada filamento na variação será:

`Quantidade com perda = Quantidade em gramas × (1 + Percentual de perda / 100)`

`Custo do filamento = Quantidade com perda × Custo por grama`

O custo total dos filamentos será a soma dos custos de todos os filamentos vinculados à variação.

### Custo dos insumos

Cada insumo deverá possuir valor da compra, quantidade comprada e unidade de medida.

`Custo unitário do insumo = Valor da compra / Quantidade comprada`

`Custo utilizado = Quantidade utilizada × Custo unitário`

A unidade utilizada no produto deverá ser compatível com a unidade cadastrada no insumo.

### Custo de energia

A potência do equipamento será armazenada em watts e o tempo de impressão em minutos.

`Horas de impressão = Tempo de impressão em minutos / 60`

`Consumo em kWh = Potência em watts × Horas de impressão / 1.000`

`Custo de energia = Consumo em kWh × Valor vigente do kWh`

As tarifas de energia deverão possuir período de vigência. Não poderão existir períodos sobrepostos.

### Custo do equipamento

A vida útil do equipamento será armazenada em horas.

`Custo de depreciação por hora = Valor de compra / Vida útil em horas`

`Custo do equipamento = Horas de impressão × Custo de depreciação por hora`

O custo de depreciação não representa o consumo de energia.

### Custo de mão de obra

O tempo de mão de obra será independente do tempo de impressão.

`Horas de mão de obra = Tempo de mão de obra em minutos / 60`

`Custo de mão de obra = Horas de mão de obra × Valor vigente da mão de obra por hora`

Os valores de mão de obra deverão possuir período de vigência. Não poderão existir períodos sobrepostos.

### Produtos componentes

`Custo dos componentes = Soma da quantidade de cada componente × preço de custo vigente da variação selecionada`

A variação de um produto componente deverá possuir preço de custo calculado antes de ser utilizada na precificação do produto pai. O sistema deverá impedir composições cíclicas, incluindo ciclos diretos e indiretos.

### Produção em lote

`Custo unitário = Custo total do lote / Quantidade produzida`

A quantidade produzida deverá ser maior que zero.

### Marketplace

A seleção de marketplace será opcional. Quando nenhum marketplace for selecionado, a comissão e a taxa fixa serão zero.

Cada marketplace poderá possuir faixas contendo valor inicial, valor final opcional, comissão percentual e taxa fixa. Um valor final nulo representará uma faixa sem limite superior. As faixas de um mesmo marketplace não poderão se sobrepor.

O sistema deverá calcular o preço com cada faixa candidata e selecionar aquela que contenha o preço final resultante.

### Fórmula do preço de venda

Para venda sem marketplace:

`Preço de venda = Custo unitário / (1 - Margem)`

Para venda com marketplace:

`Preço de venda = (Custo unitário + Taxa fixa) / (1 - Margem - Comissão)`

Margem e comissão serão informadas como percentuais entre 0 e 100. A soma da margem e da comissão deverá ser menor que 100%.

### Resultado

A precificação deverá apresentar:

- Variação precificada.
- Custo dos filamentos.
- Custo dos insumos.
- Custo dos produtos componentes.
- Custo de energia.
- Custo do equipamento.
- Custo de mão de obra.
- Custo total do lote.
- Custo unitário.
- Comissão do marketplace.
- Taxa fixa.
- Lucro unitário.
- Preço de venda sugerido.

Os custos intermediários deverão preservar precisão decimal. O preço final será arredondado para duas casas decimais.

### Simulação e confirmação

O usuário poderá simular uma precificação antes de confirmá-la. A simulação não atualizará o produto, não atualizará a variação e não criará histórico.

Após a simulação, o sistema deverá solicitar confirmação. Quando confirmada, a precificação:

- Criará uma ficha de precificação.
- Armazenará os dados e valores utilizados.
- Atualizará o preço de custo vigente da variação.
- Manterá o preço de venda na ficha de precificação.

### Histórico

Cada precificação confirmada deverá gerar uma ficha histórica imutável, associada ao produto e à variação precificada.

A ficha deverá armazenar produto, variação, equipamento, tarifa de energia, custo de mão de obra, marketplace e faixa utilizados, data e hora do cálculo, margem, quantidade produzida, custos detalhados, custo unitário, comissão, taxa fixa, lucro unitário e preço de venda.

Alterações posteriores nos cadastros não deverão alterar fichas anteriores. O histórico de precificações deverá estar disponível para consulta por funcionários e administradores.

### Importante!

O módulo de formação de preço faz parte do MVP.

O preço de custo da variação não será informado manualmente. Ele será atualizado somente após a confirmação de uma precificação.

As cores e quantidades de filamento utilizadas na produção serão cadastradas na variação do produto. O custo correspondente será calculado automaticamente a partir do valor por grama de cada filamento.

O preço de venda calculado será armazenado na ficha de precificação, pois poderá variar conforme a margem, o marketplace e as taxas aplicáveis.

## Módulo Newsletter e LGPD

Criar uma página para consentimento explicíto, política de privacidade.
Sobre a Newsletter, criar uma rota na API para poder armazenar os e-mails dos clientes, data e origem do consentimento. E uma outra rota para remover o e-mail do cliente, cancelando sua inscrição na newsletter.

# Evoluções Futuras

## Módulo de pedidos

Este módulo é responsável por todo o ciclo de vida do pedido. Quando implementado, o módulo terá inicialmente os seguintes recursos:

- Listagem e detalhes dos pedidos
- Alteração de situação
- Cancelamento
- Registro de pagamento

Após este módulo for implementado, na home page será necessário adicionar a seguinte regra:
- O botão de usuário na área deslogada, após login, deve abrir:
  - Página de histórico de pedidos
- A quantidade de itens no carrinho ficará disponível mesmo sem autenticação, mas quando o usuário avançar para finalizar a compra, ele deve estar logado. Caso contrário, direcioná-lo para efetuar login e após login, volta para o carrinho.
- O carrinho cria um pedido

Os passos seguintes, ficarão para evolução do módulo. São eles:

- Acompanhamento de produção
- Código de rastreamento
- Histórico das mudanças

## Módulo de Pagamento

As regras deste módulo ficarão para evolução do sistema. Mas a previsão será:

- Formas de pagamento via Pix ou cartão
- Integração com Gateway de pagamento
- Integração com sistema de correios para cálculo de frete
- Correios ou transportadora
- Prazo de produção separado do prazo de entrega

## Relatórios

Os relatórios não fazem parte do MVP de catálogo. Quando o sistema passar a
registrar vendas e pedidos, estão previstos:

- Vendas por período
- Pedidos por situação
- Clientes
- Vendas por marketplace

# Fora de Escopo do MVP

Características do sistema:

- No MVP não haverá controle de estoque. Essa é uma funcionalidade futura
