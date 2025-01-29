using System;
using System.Collections.Generic;
using System.IO;

class BookManager
{
    public record Info(int Id, string Author, string Title, float Price, DateTime ReleasedOn);

    private Dictionary<int, Info> _cache = new(); // Cache para armazenar os livros
    private Queue<int> _cacheOrder = new(); // Fila para rastrear a ordem de inserção no cache
    private const int CACHE_LIMIT = 3; // Definindo um limite para o cache 
    private Dictionary<int, Info> _database = new(); // Simulando um banco de dados

    // Simula a busca de um livro no banco de dados
    private Info? FetchFromDatabase(int id)
    {
        return _database.ContainsKey(id) ? _database[id] : null;
    }

    public void UpdateBookInfo(Info bookInfo)
    {
        // Atualiza os dados no "banco de dados"
        _database[bookInfo.Id] = bookInfo;

        // Atualiza também no cache se o livro já estiver armazenado
        if (_cache.ContainsKey(bookInfo.Id))
        {
            _cache[bookInfo.Id] = bookInfo;
        }
        else
        {
            // Se o cache atingiu o limite, remove o item mais antigo
            if (_cache.Count >= CACHE_LIMIT)
            {
                int oldestId = _cacheOrder.Dequeue(); // Remove o mais antigo da fila
                _cache.Remove(oldestId); // Remove do cache
            }

            // Adiciona o novo livro ao cache
            _cache[bookInfo.Id] = bookInfo;
            _cacheOrder.Enqueue(bookInfo.Id);
        }
    }

    public Info? GetBookInfo(int id)
    {
        // Verifica se o livro já está no cache
        if (_cache.ContainsKey(id))
        {
            return _cache[id];
        }

        // Caso contrário, busca no "banco de dados"
        Info? bookInfo = FetchFromDatabase(id);

        if (bookInfo != null)
        {
            // Se o cache estiver cheio, remove o item mais antigo
            if (_cache.Count >= CACHE_LIMIT)
            {
                int oldestId = _cacheOrder.Dequeue(); // Remove da fila
                _cache.Remove(oldestId); // Remove do cache
            }

            // Adiciona o novo livro ao cache
            _cache[id] = bookInfo;
            _cacheOrder.Enqueue(id);
        }

        return bookInfo;
    }
}

public class Solution
{
    public static void Main(string[] args)
    {
        using var bufferedWriter = new StreamWriter(Console.OpenStandardOutput());

        var infos = new BookManager.Info[]
        {
            new BookManager.Info(1, "João Silva", "A Vida no Campo", 19.99f, new DateTime(2020, 1, 15)),
            new BookManager.Info(2, "Maria Oliveira", "Culinária Caipira", 29.99f, new DateTime(2021, 6, 30)),
            new BookManager.Info(6, "Carla Nunes", "Guia do Pescador", 22.50f, new DateTime(2018, 4, 14)),
            new BookManager.Info(18, "Veronica Almeida", "Economia Doméstica", 21.10f, new DateTime(2021, 12, 30)),
            new BookManager.Info(19, "Marcelo Teixeira", "Saúde e Bem-Estar Rural", 26.75f, new DateTime(2019, 8, 15)),
            new BookManager.Info(20, "Patrícia Fernandes", "História e Cultura Caipira", 32.50f, new DateTime(2022, 11, 8))
        };

        var bookManager = new BookManager();

        foreach (var bookInfo in infos)
        {
            bookManager.UpdateBookInfo(bookInfo);
        }

        var lastBook = bookManager.GetBookInfo(20);

        if (lastBook != null && lastBook.Id == 20 && lastBook.Price == 32.50f)
        {
            bookManager.UpdateBookInfo(new BookManager.Info(20, "Patrícia Fernandes", "História e Cultura Caipira do Brasil", 12.50f, new DateTime(2022, 11, 8)));

            var result = bookManager.GetBookInfo(20);

            bufferedWriter.WriteLine(InfoToString(result));
        }
    }

    static string InfoToString(BookManager.Info bookInfo)
    {
        return $"{bookInfo.Id} {bookInfo.Author} {bookInfo.Title} R${bookInfo.Price}";
    }
}

