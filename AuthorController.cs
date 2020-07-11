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
    public class AuthorController : ControllerBase
    {
        // GET: api/Author
        [HttpGet]
        public IEnumerable<Author> Get()
        {
            SqlConnection cnn = null;
            try
            {
                string select = "select * from Author";
                cnn = DBConnection.GetConnection();
                var author = cnn.Query<Author>(select).ToList();
                cnn.Close();
                return author;
            }catch(Exception ex)
            {
                if (cnn != null)
                {
                    if (cnn.State == ConnectionState.Open)
                        cnn.Close();
                }
                return null;
            }

        }

        // GET: api/Author/5
        [HttpGet("{id}", Name = "GetAuthor")]
        public IEnumerable<Author> Get(int id)
        {
            SqlConnection cnn = null;
            try
            {
                string select = "select * from Author where ID = @ID";
                cnn = DBConnection.GetConnection();
                var author = cnn.Query<Author>(select, new { ID=id }).ToList();
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

        // POST: api/Author
        [HttpPost]
        public void Post([FromBody] Author value)
        {
            SqlConnection cnn = null;
            try
            {
                string insert= "insert into Author (AuthorName, AuthorVorname, Strasse, PLZ, Stadt) values (@AuthorName, @AuthorVorname, @Strasse, @PLZ, @Stadt)" ;
                cnn = DBConnection.GetConnection();
                var affectedRows = cnn.Execute(insert, new { AuthorName=value.AuthorName, AuthorVorname=value.AuthorVorname, Strasse=value.Strasse, PLZ=value.PLZ, Stadt=value.Stadt });
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

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Author value)
        {
            SqlConnection cnn = null;
            try
            {
                string update = "update Author set AuthorName = @AuthorName, AuthorVorname=@AuthorVorname, Strasse=@Strasse, PLZ= @PLZ, Stadt=@Stadt where ID=@ID ";
                cnn = DBConnection.GetConnection();
                var affectedRows = cnn.Execute(update, new { AuthorName = value.AuthorName, AuthorVorname = value.AuthorVorname, Strasse = value.Strasse, PLZ = value.PLZ, Stadt = value.Stadt ,ID=id});
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
                string delete = "delete from Author where ID=@ID ";
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
