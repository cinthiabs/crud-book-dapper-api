using CrudDapper.Models;
using Dapper;
using System.Data.SqlClient;

namespace CrudDapper.Services.LivroService
{
    public class LivroService :ILivroInterface
    {
        private readonly IConfiguration _configuration;
        private readonly string getConnection;
        public LivroService(IConfiguration configuration) 
        {
            _configuration = configuration;
            getConnection = _configuration.GetConnectionString("DefaultConnection");

        }
        public async Task<IEnumerable<Livro>> CreateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = $"insert into Livros(titulo,autor)values('{livro.Titulo}','{livro.Autor}')";
                await con.ExecuteAsync(sql, livro);
                
                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }

        public async Task<IEnumerable<Livro>> DeleteLivro(int id)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = $"delete from Livros where id = {id}";
                await con.ExecuteAsync(sql, id);
                
                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }

        public async Task<IEnumerable<Livro>> GetAllLivros()
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = "select * from Livros";
                return await con.QueryAsync<Livro>(sql);
            }
        }

        public async Task<Livro> GetLivroById(int id)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = $"select * from Livros where id = {id}";
                return await con.QueryFirstOrDefaultAsync<Livro>(sql);
            }
        }

        public  async Task<IEnumerable<Livro>> UpdateLivro(Livro livro)
        {
            using (var con = new SqlConnection(getConnection))
            {
                var sql = $"update livros set titulo='{livro.Titulo}', autor='{livro.Autor}' where id = {livro.Id}";
                await con.ExecuteAsync(sql, livro);
                return await con.QueryAsync<Livro>("select * from Livros");
            }
        }
    }
}
