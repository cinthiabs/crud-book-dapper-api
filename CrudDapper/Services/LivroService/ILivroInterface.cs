﻿using CrudDapper.Models;

namespace CrudDapper.Services.LivroService
{
    public interface ILivroInterface
    {
        //IEnummerble é uma lista  e task é assincrono 
        Task<IEnumerable<Livro>> GetAllLivros();
        Task<Livro> GetLivroById(int id);
        Task<IEnumerable<Livro>> CreateLivro(Livro livro);
        Task<IEnumerable<Livro>> UpdateLivro(Livro livro);
        Task<IEnumerable<Livro>> DeleteLivro(int id);
    }
}
