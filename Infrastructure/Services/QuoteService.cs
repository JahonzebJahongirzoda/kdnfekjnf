using System.Net;
using System.Runtime.Intrinsics.X86;
using Dapper;
using Domain.Entities;
using Npgsql;
using Domain.Wrapper;

namespace Infrastructure.Services;
public class QuoteServices
{
    private string _connectionString;
    private object result;

    public QuoteServices()
    {
        _connectionString = "Server=127.0.0.1;Port=5432;Database=examapi;User Id=postgres;Password=11111111;";
    }



    public async Task<Response<string>> GetQuote()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            try
            {
                var sql = "Select * from Quote";
                var res = await connection.QueryAsync<Quote>(sql);

                return new Response<string>("Success");
            }
            catch (System.Exception ex)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }

    public async Task<Response<string>> AddQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            try
            {
                string sql = $"INSERT INTO Quote (Categoryid, Author,QuoteText) VALUES ({quote.Categoryid}, '{quote.Author}', '{quote.QuoteText}')";
                var response = await connection.ExecuteAsync(sql);
                return new Response<string>("Success");
            }
            catch (System.Exception ex)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

    }


    public async Task<Response<string>> Getbyrand()
    {
        using (var connection = new NpgsqlConnection(_connectionString))

        {
            try
            {
                var sql = "select * from Quote order by random() limit 1";
                var res = await connection.QueryAsync<Quote>(sql);
                return new Response<string>("Success");

            }
            catch (System.Exception ex)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);

            }

        }
    }


    public async Task<Response<string>> UpdateQuote(Quote quote)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {
            try
            {
                string sql = $"UPDATE Quote SET author = '{quote.Author}', quotetext = '{quote.QuoteText}', categoryid = '{quote.Categoryid}' WHERE id = '{quote.id}'; ";
                var response = await connection.ExecuteAsync(sql);
                return new Response<string>("Success");
            }
            catch (System.Exception ex)
            {
                return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);

            }


        }

    }



    public async Task<Response<string>> DeleteQuote(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            try
            {
                string sql = $"delete from quote where id ={id}";
                var response = await connection.ExecuteAsync(sql);
                return new Response<string>("Success");
            }
            catch (System.Exception ex)
            {

                return new Response<string>(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

    }


    public async Task<Response<List<GetQuoteWithCategoryDto>>> GetQuoteWithCategory(int id)
    {

        using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
        {

            var sql = $"select q.id, q.author , q.quotetext , c.name  as CategoryName from quote as q join category as c on q.categoryid  = c.id;";
            var response = await connection.QueryAsync<GetQuoteWithCategoryDto>(sql);

            return new Response<List<GetQuoteWithCategoryDto>>(response.ToList());





        }






    }
}

