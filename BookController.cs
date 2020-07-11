using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BookWebAPI.Model;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            SqlConnection cnn = null;
            try
            {
                string select = "select * from Book";
                cnn = DBConnection.GetConnection();
                var author = cnn.Query<Book>(select).ToList();
                cnn.Close();
                return author;
            }
            catch (Exception ex)
            {
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                }
                return null;
            }
        }

        // GET: api/Book/5
        [HttpGet("{id}", Name = "GetBook")]
        public IEnumerable<Book> Get(int id)
        {
            SqlConnection cnn = null;
            try
            {
                string select = "select * from Book where BookID = @ID";
                cnn = DBConnection.GetConnection();
                var book = cnn.Query<Book>(select, new { ID = id }).ToList();
                cnn.Close();
                return book;
            }
            catch (Exception ex)
            {
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                }
                return null;
            }

        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book value)
        {
            SqlConnection cnn = null;
            try
            {
                string insert = "insert into Book (BookTitle, BookPrice, AuthorId, BookVerlag, BookISDN) values (@BookTitle, @BookPrice, @AuthorId, @BookVerlag, @BookISDN)";
                cnn = DBConnection.GetConnection();
                var affectedRows = cnn.Execute(insert, new { BookTitle=value.BookTitle, BookPrice=value.BookPrice, AuthorId=value.AuthorID, BookVerlag=value.BookVerlag, BookISDN=value.BookISDN });
                cnn.Close();
            }
            catch (Exception ex)
            {
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                }

            }
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Book value)
        {
            SqlConnection cnn = null;
            try
            {
                string update = "update Book set BookTitle=@BookTitle, BookPrice=@BookPrice, AuthorId=@AuthorId, BookVerlag=@BookVerlag, BookISDN=@BookISDN where BookID=@ID ";
                cnn = DBConnection.GetConnection();
                var affectedRows = cnn.Execute(update, new { BookTitle = value.BookTitle, BookPrice = value.BookPrice, AuthorId = value.AuthorID, BookVerlag = value.BookVerlag, BookISDN = value.BookISDN,ID=id });
                cnn.Close();
            }
            catch (Exception ex)
            {
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                }

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            SqlConnection cnn = null;
          
            try
            {
                string delete = "delete from Book where BookID=@ID ";
                cnn = DBConnection.GetConnection();
                var affectedRows = cnn.Execute(delete, new { ID = id });
                cnn.Close();
            }
            catch (Exception ex)
            {
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                }

            }
        }
    }
}
