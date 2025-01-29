# Desafio de Codigo HackerRank  - Elas são Tech Ifood
 Este repositório contém a solução para um desafio de código proposto pelo iFood para o programa elas são tech. O objetivo era implementar um sistema de gerenciamento de livros com um cache eficiente para otimizar a recuperação de informações.
## Descrição do Problema
O desafio consistia em criar uma classe BookManager capaz de armazenar e recuperar informações sobre livros, garantindo que as consultas fossem otimizadas através de um mecanismo de cache. Além disso, o sistema deveria permitir a atualização dos livros e manter a consistência dos dados.
## Solução Proposta
A solução foi desenvolvida em C# e inclui:
## Sistema de Cache
 * Um Dictionary`<int, Info>` para armazenar os livros em cache.
 * Uma `Queue<int>` para controlar a ordem de acesso e remover os itens menos utilizados quando o cache atinge o limite.
##  Banco de Dados Simulado
  * Um Dictionary`<int, Info>` para representar um banco de dados local.
##  Otimização de Consultas
  * Antes de buscar um livro no banco de dados, o sistema verifica se ele já está em cache.
  * Se um livro for atualizado, o cache também é atualizado para refletir a mudança.
## 🛠️ Tecnologias Utilizadas
  * Linguagem: C#
  * Paradigma: Programação Orientada a Objetos (POO)
  * Estruturas de Dados: Dicionários `(Dictionary)` e Filas `(Queue)` para gerenciamento do cache.


## Aprendizados

Este desafio reforçou a importância de um cache eficiente para otimizar consultas em sistemas que lidam com grandes volumes de dados. A solução implementada segue boas práticas de estruturação de código e utiliza estruturas de dados apropriadas para um melhor desempenho.
