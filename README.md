# DIO - Trilha .NET - Programação orientada a objetos
www.dio.me

## Desafio de projeto
Para este desafio, você precisará usar seus conhecimentos adquiridos no módulo de orientação a objetos, da trilha .NET da DIO.

## Contexto
Você é responsável por modelar um sistema que trabalha com celulares. Para isso, foi solicitado que você faça uma abstração de um celular e disponibilize maneiras de diferentes marcas e modelos terem seu próprio comportamento, possibilitando um maior reuso de código e usando a orientação a objetos.

## Proposta
Você precisa criar um sistema em .NET, do tipo console, mapeando uma classe abstrata e classes específicas para dois tipos de celulares: Nokia e iPhone. 
Você deve criar as suas classes de acordo com o diagrama abaixo:

![Diagrama classes](Imagens/diagrama.png)

## Regras e validações
1. A classe **Smartphone** deve ser abstrata, não permitindo instanciar e servindo apenas como modelo.
2. A classe **Nokia** e **Iphone** devem ser classes filhas de Smartphone.
3. O método **InstalarAplicativo** deve ser sobrescrito na classe Nokia e iPhone, pois ambos possuem diferentes maneiras de instalar um aplicativo.

## Solução
O código está pela metade, e você deverá dar continuidade obedecendo as regras descritas acima, para que no final, tenhamos um programa funcional. Procure pela palavra comentada "TODO" no código, em seguida, implemente conforme as regras acima.


## Contribuição
Indo um pouco além no projeto e deixando o projeto com o meu estilo.

Utilizei algumas coisas a mais, foram elas:

- **ASCII Art**
- **Tupla**
- **Web Scraping**
- **Chamada de API**
- **LINQ**
- **Json**
- **[HtmlAgilityPack](https://html-agility-pack.net)**
- **[iTunes Search API](https://developer.apple.com/library/archive/documentation/AudioVideo/Conceptual/iTuneSearchAPI/Searching.html#//apple_ref/doc/uid/TP40017632-CH5-SW1)**

Pretendo adicionar:

- **Thread**
- **ConsoleColor**

### Web Scraping e API para Verificar a Existência de Aplicativos nas Lojas Virtuais

Web Scraping? API? _Sim, isso mesmo!_

Minha ideia foi verificar se o nome do aplicativo existe na **Google Play Store** e na **App Store (Apple)**.

Não encontrei API oficial para fazer essas buscas no **Google Play Store**. Por isso, escolhi primeiramente o Web Scraping para extrair informações da página HTML da **Google Play Store**, utilizando o **[HtmlAgilityPack](https://html-agility-pack.net)**.

Como nem tudo são flores... Tentei executar o mesmo para a **App Store (Apple)**, o que não funcionou, pois eles renderizam tudo dinamicamente via JavaScript, criando uma barreira para utilizar o **[HtmlAgilityPack](https://html-agility-pack.net)**.

Foi com isso que encontrei uma API que conseguia me trazer dados relevantes, incluindo nome e tamanho do aplicativo. O nome da API utilizada foi **[iTunes Search API](https://developer.apple.com/library/archive/documentation/AudioVideo/Conceptual/iTuneSearchAPI/Searching.html#//apple_ref/doc/uid/TP40017632-CH5-SW1)**.

Ao fazer chamadas na API, ela retorna um **Json**. Manipulei ele selecionando os dados que iria utilizar e filtrei utilizando **LINQ**.

Além de verificar se existe nas Stores, é possível o usuário escolher qual aplicativo irá instalar caso haja mais de uma opção de aplicativo disponível nos dados filtrados.




_Develop By RKzeraa🔌_
