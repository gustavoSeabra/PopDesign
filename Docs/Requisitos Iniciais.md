# Definições do E-commerce PopLume

Este projeto visa a construção de um e-commerce para a loja Poplume, especializada em produtos de impressão 3D.
Seu layout deve seguir as regras:

- Abordagem responsiva para celular, tablet e desktop. Contendo acessibilidade e navegação por teclado
- Feedback ao adicionar itens ao carrinho
- Paginação e / ou carregamento progressivo
- Consentimento e tratamento de dados conforme a LGPD
- Uma identidade visual mais sofisticada e divertida
- Vamos chamar de MVP a primeira versão do sistema

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

## Escopo do MVP

O MVP será um catálogo digital de produtos. O cliente poderá navegar pelo
catálogo, pesquisar produtos, aplicar filtros, consultar os detalhes e
adicionar produtos ao carrinho.

O carrinho funcionará como uma lista de interesse. A conclusão da compra não
será realizada diretamente pela aplicação. Ao finalizar, o cliente será
direcionado para um canal de atendimento da loja, inicialmente o WhatsApp,
com a relação dos produtos e quantidades selecionados.

O MVP não terá pagamento online, cálculo de frete, criação de pedidos pelo
cliente, acompanhamento de pedidos ou integrações com marketplaces.

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
- Edição dos dados da conta de usuário (Cliente)
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

---
<br/>

# Particularidades da loja

No MVP, o cliente poderá escolher o produto e uma de suas variações comerciais disponíveis. O cliente não poderá alterar tamanho, filamentos, demais insumos ou qualquer outra característica da ficha técnica do produto.

Cada produto poderá possuir uma ou mais variações comerciais, inclusive variações de uma única cor ou multicoloridas. As regras de cadastro e composição dessas variações estão descritas no [Módulo Cadastro de produto](#módulo-cadastro-de-produto).

A escolha da variação será obrigatória antes de adicionar o produto ao carrinho. As regras aplicáveis estão descritas em [Regras do Carrinho](#regras-do-carrinho).

O custo e o preço de venda serão calculados para uma variação específica, conforme definido no [Módulo Formação de Preço](#módulo-formação-de-preço).

O cliente não poderá enviar arquivos. Caso ele queira algum produto personalizado, deverá entrar em contato conosco a partir dos dados de contato informados na home page.

Marketplaces servirão apenas para registrar canais de venda. No futuro, poderá ser considerada uma integração, mas ela não fará parte do MVP.

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

## Regras do Carrinho:

- O carrinho estará disponível sem autenticação.
- A quantidade exibida no cabeçalho representará a soma das unidades adicionadas.
- O carrinho anônimo será preservado durante a navegação.
- O cliente poderá navegar, adicionar produtos e editar o carrinho sem autenticação.
- Antes de adicionar um produto ao carrinho, deverá existir uma variação ativa selecionada.
- Quando houver mais de uma variação ativa, o cliente deverá escolher uma delas.
- Cada variação será tratada como um item vendável distinto no carrinho.
- Variações diferentes do mesmo produto ocuparão itens separados no carrinho.
- O cliente não poderá alterar filamentos, insumos ou outras características da ficha técnica.
- Para enviar a lista de interesse, será necessário estar autenticado.
- Caso não esteja autenticado, o cliente será direcionado ao login.
- Após o login, retornará ao carrinho com os itens preservados.
- Nome, telefone e e-mail serão obtidos da conta autenticada.
- Ao concluir, o cliente será direcionado para o WhatsApp da loja com uma
  mensagem contendo seu nome, telefone, e-mail, os produtos, quantidades e links correspondentes.
  - Deverá ser enviado também uma cópia da lista de interesse para o e-mail da loja (vendas@poplume.com.br) 
- O carrinho não criará um pedido na aplicação.
- O carrinho não terá um campo para observação
- Produtos e variações inativos não poderão ser adicionados novamente ao carrinho.
- Produtos e variações adicionados antes da inativação permanecerão no carrinho.
- Antes do envio da lista de interesse, a API validará se o item ainda existe e possui preço de venda vigente.
- A inativação, por si só, não impedirá o envio de uma seleção realizada anteriormente.
- O carrinho será mantido enquanto a aba do navegador permanecer aberta e será
apagado quando ela for encerrada.

### Importante!

Antes de enviar o e-mail e abrir o WhatsApp, a API deverá validar os produtos, as variações de cor, as quantidades e os preços de venda atuais. O preço utilizado será sempre o preço de venda atual da variação no catálogo no momento da solicitação, independentemente do valor anteriormente exibido ou mantido no carrinho. Caso o preço tenha sido alterado, o carrinho deverá ser atualizado e o novo preço deverá ser informado ao usuário. Os preços definidos para marketplaces não serão utilizados nesse fluxo.

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

Os dados de Nome, e-mail e telefone serão obtidos através dos dados do cliente logado no sistema. Estes dados não vão ficar fixos no código.



## Módulo Cadastro de cliente

O MVP será preparado para evolução mesmo o cliente não efetuando compras direto no sistema. Com isto, vamos manter o cadastro, login e edição de perfil, mesmo com utilidade inicial limitada.

## Módulo Cadastro de produto

O módulo permitirá que funcionários e administradores criem, consultem, editem, ativem e inativem os produtos comercializados pela loja.

Um produto poderá ser salvo como inativo mesmo que seu cadastro ainda esteja incompleto. Para ser ativado e disponibilizado no catálogo, deverá atender aos critérios definidos na seção [Ativação, inativação e publicação no catálogo](#ativação-inativação-e-publicação-no-catálogo).

### Dados do produto

O produto deverá possuir:

- Código interno único.
- Nome.
- Descrição curta.
- Descrição completa.
- Categoria.
- Estado ativo ou inativo.
- Indicador de produto em destaque.
- Slug único para sua página no catálogo.
- Prazo estimado de produção.
- Margem de lucro percentual.
- Uma ou mais variações comerciais.
- Ficha técnica de produção.

### Margem de lucro do produto

Cada produto possuirá sua própria margem de lucro percentual, compartilhada por todas as suas variações comerciais.

Ao cadastrar um produto, o sistema preencherá inicialmente a margem com o valor padrão de 60%. Durante o cadastro inicial, o administrador poderá manter esse valor ou informar uma margem diferente para o produto.

O funcionário poderá visualizar a margem, mas não poderá modificá-la.

Após o produto possuir uma precificação confirmada, sua margem somente poderá ser alterada permanentemente pela confirmação de uma nova precificação realizada por um administrador. Essa alteração deverá executar a reprecificação em lote de todas as variações e canais do produto.

A margem deverá ser maior ou igual a 0% e menor que 100%.

O código interno e o slug não poderão ser utilizados por outro produto.

O nome do produto não será considerado único. Produtos diferentes poderão possuir nomes semelhantes, desde que tenham códigos internos diferentes.

Não deverão ser criados produtos diferentes apenas para representar opções de cor. As opções de cor deverão ser cadastradas como variações comerciais do mesmo produto.

### Variações comerciais

No MVP, uma variação comercial representará exclusivamente uma opção de cor ou uma composição multicolorida do produto. Tamanho, material, acabamento e outras características não serão opções selecionáveis pelo cliente.

Cada variação pertencerá a um único produto e deverá possuir:

- Nome comercial apresentado ao cliente.
- Estado ativo ou inativo.
- Um ou mais filamentos associados.
- Quantidade consumida em gramas para cada filamento.
- Percentual de perda para cada filamento.
- Uma ou mais imagens.
- Preço de custo vigente.
- Preço de venda atual no catálogo.
- Preços de venda atuais por marketplace, quando aplicável.

O nome comercial da variação deverá ser único dentro do mesmo produto.

Uma variação poderá representar uma única cor, como "Preto", "Azul" ou "Verde", ou uma composição multicolorida, como "Preto e Branco" ou "Verde e Amarelo".

Uma variação multicolorida poderá utilizar mais de um filamento simultaneamente.

O mesmo filamento não poderá ser associado mais de uma vez à mesma variação.

Para cada filamento associado:

- A quantidade consumida deverá ser informada em gramas.
- A quantidade consumida deverá ser maior que zero.
- O percentual de perda será opcional.
- Quando não informado, o percentual de perda será considerado zero.
- Quando informado, o percentual de perda deverá ser maior ou igual a zero e menor ou igual a 100%.

A ativação ou inativação de uma variação não alterará o estado das demais variações do produto.

### Imagens da variação

Cada imagem pertencerá a uma única variação.

A primeira imagem adicionada será definida inicialmente como imagem de destaque. O usuário administrativo poderá alterar a imagem de destaque e reordenar as imagens.

Cada variação poderá possuir somente uma imagem de destaque.

Caso a imagem de destaque seja removida, a primeira imagem restante será definida como a nova imagem de destaque.

Os formatos, tamanhos máximos e quantidade máxima de imagens deverão ser definidos antes da implementação.

### Ficha técnica e composição do produto

As informações necessárias para fabricar e precificar o produto deverão ser registradas em sua ficha técnica.

A ficha técnica básica pertencerá ao produto e será compartilhada por todas as suas variações, exceto pela composição de filamentos, que será específica de cada variação.

A ficha técnica do produto poderá conter:

- Equipamento padrão.
- Tempo de impressão em minutos.
- Tempo de mão de obra em minutos.
- Um ou mais insumos e suas quantidades consumidas.
- Um ou mais produtos componentes, suas variações e quantidades.

O equipamento padrão será utilizado como sugestão inicial durante a formação de preço e poderá ser alterado na precificação quando o perfil do usuário possuir permissão.

Os tempos de impressão e de mão de obra deverão ser maiores ou iguais a zero.

### Filamentos da variação

Os filamentos representam as matérias-primas utilizadas especificamente para fabricar cada variação comercial.

Cada associação entre uma variação e um filamento deverá armazenar:

- Filamento utilizado.
- Quantidade consumida em gramas.
- Percentual de perda.

### Insumos do produto

Os insumos representam materiais comprados e consumidos na fabricação ou embalagem do produto, como argola, fita, plástico-bolha, sacola, caixa, tag e cola.

Cada associação entre um produto e um insumo deverá armazenar:

- Insumo utilizado.
- Quantidade consumida.
- Unidade de medida.

A quantidade consumida deverá ser maior que zero.

O mesmo insumo não poderá ser associado mais de uma vez ao mesmo produto.

### Composição de produtos

Um produto poderá ser composto por outros produtos, como um kit formado por diferentes itens.

Cada componente deverá informar:

- Produto componente.
- Variação do produto componente.
- Quantidade utilizada.

A quantidade do componente deverá ser maior que zero.

O mesmo produto e a mesma variação não poderão ser adicionados mais de uma vez à composição.

Um produto:

- Não poderá conter a si próprio.
- Não poderá criar ciclos diretos ou indiretos de composição.
- Somente poderá utilizar uma variação componente que possua preço de custo vigente.

Exemplo: um Kit Dia dos Pais poderá ser composto por um chaveiro, um porta-retrato e um porta-celular.

### Ativação, inativação e publicação no catálogo

Um produto inativo poderá ser salvo com o cadastro incompleto e não será exibido no catálogo.

#### Ativação do produto

Para ativar um produto, será obrigatório possuir:

- Código interno único.
- Nome.
- Descrição curta.
- Descrição completa.
- Categoria ativa.
- Slug único.
- Prazo estimado de produção.
- Pelo menos uma variação ativa.

Para ser ativada, uma variação deverá possuir:

- Nome comercial.
- Pelo menos um filamento ativo associado.
- Quantidades de filamento válidas.
- Pelo menos uma imagem.
- Preço de venda vigente para o catálogo.

Todas as variações ativas deverão atender aos requisitos obrigatórios acima.

O sistema deverá impedir a ativação do produto quando nenhuma de suas variações estiver ativa.

O sistema também deverá impedir a ativação de uma variação que não possua pelo menos uma imagem, um preço de venda vigente para o catálogo ou uma composição válida de filamentos.

Quando a ativação for impedida, o sistema deverá informar quais dados obrigatórios estão ausentes ou inválidos.

#### Inativação do produto

Ao inativar um produto, o sistema deverá inativar automaticamente todas as suas variações.

O produto e suas variações deixarão de ser exibidos no catálogo e não poderão ser adicionados novamente ao carrinho.

A inativação das variações será mantida mesmo que o produto seja posteriormente reativado. O sistema não deverá reativar automaticamente todas as variações anteriores.

#### Reativação do produto

Para reativar um produto, o usuário administrativo deverá primeiro selecionar e ativar uma ou mais variações válidas.

Enquanto o produto permanecer inativo, suas variações poderão ser preparadas e marcadas como ativas na área administrativa, mas não serão exibidas no catálogo.

Após existir pelo menos uma variação ativa e válida, o produto poderá ser reativado.

Ao reativar o produto:

- Somente as variações previamente marcadas como ativas serão disponibilizadas no catálogo.
- As demais variações permanecerão inativas.
- O sistema não reativará variações automaticamente.
- O produto será exibido no catálogo somente se possuir pelo menos uma variação ativa.

Não poderá existir um produto ativo sem pelo menos uma variação ativa.

## Módulo Formação de Preço

O módulo de formação de preço faz parte do MVP e será utilizado por funcionários e administradores. Seu objetivo será calcular o custo de produção e sugerir um preço de venda tanto para uma variação específica de um produto cadastrado quanto para um orçamento avulso, com base nos dados de produção, nos custos vigentes e no canal de venda.

Os preços vigentes pertencerão à variação e não à ficha histórica de precificação.

Cada variação poderá possuir:

- Um preço de custo vigente.
- Um preço de venda vigente para o catálogo.
- Um preço de venda vigente para cada marketplace no qual for comercializada.
- Uma ou mais fichas históricas de precificação.

Cada precificação confirmada gerará uma ou mais fichas históricas imutáveis, conforme as regras da seção [Simulação e confirmação](#simulação-e-confirmação).

Quando a precificação for confirmada, o sistema atualizará os preços vigentes aplicáveis conforme as regras da seção [Simulação e confirmação](#simulação-e-confirmação).

Na precificação de um produto cadastrado, os filamentos, as quantidades consumidas e os percentuais de perda serão obtidos automaticamente da variação selecionada.

Nessa modalidade, os insumos, produtos componentes, tempos e demais dados de produção serão obtidos da ficha técnica do produto.

### Margem de lucro

A margem de lucro representa o percentual do preço de venda restante após a dedução dos custos considerados na precificação.

Cada produto possuirá sua própria margem de lucro. A margem padrão para novos produtos será de 60%, mas o administrador poderá definir uma margem diferente para cada produto.

A margem será apresentada como percentual entre 0 e 100 e convertida para valor decimal antes do cálculo:

`Margem decimal = Margem percentual / 100`

A margem deverá ser maior ou igual a 0% e menor que 100%.

Quando houver comissão de marketplace, a soma da margem com a comissão deverá ser menor que 100%.

#### Margem na precificação de produto cadastrado

Ao selecionar um produto, o sistema carregará automaticamente sua margem de lucro.

O funcionário utilizará obrigatoriamente a margem cadastrada no produto e não poderá alterá-la durante a precificação.

O administrador poderá informar uma margem diferente durante a simulação.

Enquanto a simulação não for confirmada, a margem cadastrada no produto permanecerá inalterada.

Quando o administrador confirmar uma margem diferente, o sistema deverá aplicar as regras de reprecificação em lote definidas na seção [Simulação e confirmação](#simulação-e-confirmação).

#### Margem no orçamento avulso

Como o orçamento avulso não está associado a um produto, o sistema preencherá inicialmente a margem com o valor padrão de 60%.

Tanto o funcionário quanto o administrador poderão alterar a margem do orçamento avulso.

A margem informada será utilizada somente na simulação atual.

Como o orçamento avulso não atualiza cadastros nem gera histórico, a margem utilizada será descartada ao sair da tela.

### Orçamento avulso

O orçamento avulso permitirá calcular o custo de produção e sugerir um preço de venda sem exigir o cadastro prévio de um produto ou de uma variação comercial.

O orçamento avulso será utilizado exclusivamente para simulação. Ele não criará um produto, não criará uma variação, não atualizará preços vigentes e não gerará uma ficha no histórico de precificações.

Para realizar um orçamento avulso, o usuário deverá informar:

- Uma identificação ou descrição do item.
- Equipamento utilizado.
- Tempo de impressão em minutos.
- Tempo de mão de obra em minutos.
- Pelo menos um filamento.
- Quantidade consumida em gramas para cada filamento.
- Percentual de perda de cada filamento, quando aplicável.
- Quantidade que será produzida.
- Marketplace, opcionalmente.
- Margem percentual, preenchida inicialmente com 60% e alterável pelo funcionário ou administrador.

O sistema utilizará automaticamente:

- O custo vigente por grama de cada filamento selecionado.
- A tarifa de energia vigente.
- O custo de mão de obra vigente.
- O valor de compra e a vida útil do equipamento selecionado.
- As taxas vigentes do marketplace selecionado, quando aplicável.

O orçamento avulso poderá incluir, opcionalmente:

- Um ou mais insumos e suas quantidades consumidas.
- Um ou mais produtos componentes, suas variações e quantidades.

Quando um insumo for incluído, o sistema utilizará seu custo unitário vigente.

Quando um produto componente for incluído, sua variação deverá possuir preço de custo vigente.

As seguintes validações serão aplicadas:

- O tempo de impressão deverá ser maior que zero.
- O tempo de mão de obra deverá ser maior ou igual a zero.
- A quantidade produzida deverá ser maior que zero.
- Deverá existir pelo menos um filamento.
- A quantidade de cada filamento deverá ser maior que zero.
- O percentual de perda deverá estar entre 0% e 100%.
- A soma da margem com a comissão do marketplace deverá ser menor que 100%.
- O equipamento, os filamentos e os insumos selecionados deverão estar ativos.
- Deverá existir uma tarifa de energia vigente.
- Deverá existir um custo de mão de obra vigente.
- Quando um marketplace for selecionado, deverá existir uma faixa de taxas aplicável.

O resultado do orçamento avulso deverá apresentar:

- Identificação ou descrição informada.
- Custo dos filamentos.
- Custo dos insumos, quando utilizados.
- Custo dos produtos componentes, quando utilizados.
- Custo de energia.
- Custo de depreciação do equipamento.
- Custo de mão de obra.
- Custo total da produção.
- Custo unitário.
- Margem utilizada.
- Comissão e taxa fixa do marketplace, quando aplicáveis.
- Lucro unitário.
- Preço de venda sugerido.

O usuário poderá alterar os dados informados e recalcular o orçamento quantas vezes forem necessárias.

Os dados informados e o resultado calculado existirão somente durante a simulação e serão descartados ao sair da tela.

### Pré-requisitos

Antes de realizar uma formação de preço:

#### Para orçamento avulso

- O equipamento deverá estar cadastrado e ativo.
- Pelo menos um filamento deverá estar cadastrado e ativo.
- Deverá existir uma tarifa de energia vigente.
- Deverá existir um custo de mão de obra vigente.
- Quando utilizado, o marketplace deverá estar ativo e possuir faixas de taxas cadastradas.

#### Para precificação de produto cadastrado

- O produto e sua variação deverão estar cadastrados.
- O equipamento deverá estar cadastrado e ativo.
- Os filamentos utilizados deverão estar vinculados à variação.
- Os insumos utilizados deverão estar vinculados ao produto.
- As variações dos produtos componentes deverão possuir preço de custo vigente.
- Deverá existir uma tarifa de energia vigente.
- Deverá existir um custo de mão de obra vigente.
- Quando utilizado, o marketplace deverá estar ativo e possuir faixas de taxas cadastradas.

### Informações selecionadas na formação de preço

#### Para orçamento avulso

O funcionário ou administrador deverá informar manualmente os dados definidos na seção [Orçamento avulso](#orçamento-avulso).

O funcionário ou administrador poderá manter a margem padrão de 60% ou informar outra margem válida para a simulação.

#### Para produto cadastrado

O funcionário ou administrador deverá:

- Selecionar o produto.
- Selecionar a variação comercial.
- Selecionar o equipamento.
- Informar a quantidade produzida no lote.
- Selecionar opcionalmente o marketplace.

O sistema carregará automaticamente a margem cadastrada no produto.

O administrador poderá informar uma margem diferente durante a simulação. O funcionário não poderá alterar a margem carregada.

Os filamentos não serão selecionados durante a precificação de um produto cadastrado. O sistema utilizará automaticamente os filamentos, as quantidades e os percentuais de perda definidos na variação escolhida.

Os insumos, produtos componentes e tempos de produção serão obtidos automaticamente da ficha técnica do produto.

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

A quantidade de cada produto componente registrada na ficha técnica representará o consumo necessário para produzir uma unidade do produto pai.

O custo unitário dos componentes será calculado por:

`Custo unitário dos componentes = Soma da quantidade de cada componente × preço de custo vigente da variação selecionada`

O custo dos componentes para o lote será calculado por:

`Custo dos componentes do lote = Custo unitário dos componentes × Quantidade produzida`

A variação de um produto componente deverá possuir preço de custo vigente antes de ser utilizada na precificação do produto pai. O sistema deverá impedir composições cíclicas, incluindo ciclos diretos e indiretos.

### Produção em lote

As quantidades e os tempos registrados na ficha técnica representarão o consumo necessário para produzir uma unidade do produto.

Serão considerados valores por unidade:

- Quantidade de cada filamento.
- Quantidade de cada insumo.
- Quantidade de cada produto componente.
- Tempo de impressão.
- Tempo de mão de obra.

O custo unitário de produção será calculado por:

`Custo unitário = Custo dos filamentos + Custo dos insumos + Custo dos componentes + Custo de energia + Custo do equipamento + Custo de mão de obra`

O custo total do lote será calculado por:

`Custo total do lote = Custo unitário × Quantidade produzida`

A quantidade produzida deverá ser um número inteiro maior que zero.

O custo total dos filamentos, insumos, componentes, energia, equipamento e mão de obra do lote será obtido multiplicando o respectivo custo unitário pela quantidade produzida.

A quantidade produzida não alterará o custo unitário antes da aplicação da margem, comissão ou taxa fixa do marketplace.

### Marketplace

A seleção de marketplace será opcional. Quando nenhum marketplace for selecionado, a comissão e a taxa fixa serão zero.

Cada marketplace poderá possuir faixas contendo valor inicial, valor final opcional, comissão percentual e taxa fixa. Um valor final nulo representará uma faixa sem limite superior. As faixas de um mesmo marketplace não poderão se sobrepor.

O sistema deverá calcular o preço com cada faixa candidata e selecionar aquela que contenha o preço final resultante.

### Fórmula do preço de venda

Margem e comissão serão apresentadas como percentuais entre 0 e 100 e convertidas para valores decimais antes do cálculo.

`Margem decimal = Margem percentual / 100`

`Comissão decimal = Comissão percentual / 100`

Para venda sem marketplace:

`Preço de venda = Custo unitário / (1 - Margem decimal)`

Para venda com marketplace:

`Preço de venda = (Custo unitário + Taxa fixa) / (1 - Margem decimal - Comissão decimal)`

A soma da margem percentual com a comissão percentual deverá ser menor que 100%.

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

Quando nenhum marketplace for selecionado, o preço de venda sugerido corresponderá ao preço sugerido para o catálogo.

Quando um marketplace for selecionado, o preço de venda sugerido corresponderá ao preço sugerido para a variação naquele marketplace.

### Simulação e confirmação

O usuário poderá simular uma precificação antes de confirmá-la. A simulação não atualizará o produto, não atualizará os preços da variação e não criará histórico.

Um orçamento avulso será sempre uma simulação e não poderá ser confirmado como precificação de produto.

O orçamento avulso:

- Não atualizará preços vigentes.
- Não criará ficha no histórico de precificações.
- Não criará automaticamente produto, variação ou ficha técnica.
- Não será associado a um produto existente.

As regras de confirmação e atualização de preços serão aplicáveis somente à precificação de produtos cadastrados.

Após a simulação de uma precificação de produto cadastrado, o sistema deverá solicitar confirmação.

#### Confirmação sem alteração da margem do produto

Quando a margem utilizada for igual à margem atualmente cadastrada no produto, somente a variação e o canal selecionados serão atualizados.

Toda precificação confirmada sem alteração da margem:

- Criará uma ficha histórica de precificação.
- Armazenará os dados e valores utilizados.
- Atualizará o preço de custo vigente da variação selecionada.
- Manterá o preço de venda calculado na ficha histórica.

Quando a precificação confirmada não possuir marketplace:

- O preço de venda calculado será definido como o preço de venda atual da variação no catálogo.

Quando a precificação confirmada possuir marketplace:

- O preço de venda atual da variação no catálogo não será alterado.
- O preço de venda calculado será definido como o preço atual da variação no marketplace selecionado.
- Os preços registrados para os demais marketplaces não serão alterados.

#### Confirmação com alteração da margem do produto

Quando o administrador confirmar uma precificação utilizando uma margem diferente da margem atual do produto:

- A nova margem substituirá permanentemente a margem cadastrada no produto.
- Todas as variações do produto serão recalculadas imediatamente com a nova margem.
- O preço de custo vigente de cada variação será atualizado.
- O preço de venda vigente no catálogo de cada variação será atualizado.
- Os preços vigentes de cada variação nos marketplaces em que ela for comercializada serão atualizados.
- Será criada uma ficha histórica de precificação para cada variação e canal recalculado.
- Cada ficha histórica armazenará a margem utilizada e todos os dados considerados no respectivo cálculo.

A nova margem será aplicada às variações ativas e inativas do produto.

A alteração da margem e a reprecificação das variações deverão ocorrer em uma única operação transacional.

Caso alguma variação não possa ser recalculada, o sistema deverá:

- Cancelar toda a operação.
- Manter a margem anterior do produto.
- Manter todos os preços vigentes anteriores.
- Não criar fichas históricas parciais.
- Informar ao usuário quais variações impediram a confirmação.

Uma variação impedirá a reprecificação quando:

- Não possuir uma composição válida de filamentos.
- Utilizar filamento, insumo ou equipamento indisponível para o cálculo.
- Possuir produto componente sem preço de custo vigente.
- Não existir tarifa de energia vigente.
- Não existir custo de mão de obra vigente.
- Não for possível determinar uma faixa válida para algum marketplace aplicável.

#### Parâmetros da reprecificação em lote

Para recalcular todas as variações após uma alteração de margem, o sistema utilizará:

- A ficha técnica atual do produto.
- A composição de filamentos de cada variação.
- O equipamento padrão cadastrado na ficha técnica.
- Os custos vigentes dos filamentos e insumos.
- Os preços de custo vigentes dos produtos componentes.
- A tarifa de energia vigente.
- O custo de mão de obra vigente.
- A nova margem do produto.
- As faixas e taxas vigentes de cada marketplace.
- A quantidade produzida informada na precificação que iniciou a alteração da margem.

O equipamento selecionado somente para a variação originalmente precificada não será aplicado automaticamente às demais variações. Para a reprecificação em lote, será utilizado o equipamento padrão da ficha técnica do produto.

### Histórico

Cada precificação confirmada deverá gerar uma ficha histórica imutável, associada ao produto e à variação precificada.

A ficha deverá armazenar produto, variação, equipamento, tarifa de energia, custo de mão de obra, marketplace e faixa utilizados, data e hora do cálculo, margem, quantidade produzida, custos detalhados, custo unitário, comissão, taxa fixa, lucro unitário e preço de venda.

Alterações posteriores nos cadastros não deverão alterar fichas anteriores. O histórico de precificações deverá estar disponível para consulta por funcionários e administradores.

### Importante!

O módulo de formação de preço faz parte do MVP.

O preço de custo da variação não será informado manualmente. Ele será atualizado somente após a confirmação de uma precificação.

As cores e quantidades de filamento utilizadas na produção serão cadastradas na variação do produto. O custo correspondente será calculado automaticamente a partir do valor por grama de cada filamento.

O preço de venda calculado será armazenado na ficha de precificação, pois poderá variar conforme a margem, o marketplace e as taxas aplicáveis.

Na consulta administrativa do produto, cada variação deverá apresentar separadamente:

- O preço de custo vigente.
- O preço de venda atual no catálogo.
- O preço de venda atual em cada marketplace no qual a variação será comercializada.

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
