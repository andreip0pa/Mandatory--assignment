using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BookClassLib;

namespace BookRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
      public  static IEnumerable<Book> bookList;
        // GET: api/Book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return bookList;
        }

        // GET: api/Book/5
        [HttpGet("{isbn}", Name = "Get")]
        public Book Get(string isbn)
        {
            try
            {
                return bookList.First(x => x.Isbn13 == isbn);
            }
            catch
            {
                return null;
            }
        }

        // POST: api/Book
        [HttpPost]
       
        public void Post([FromBody] Book book)
        {
           
                
                ((List<Book>)bookList).Add(book);

            
            
            

        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(string isbn13, [FromBody] Book value)
        {
            try
            {
                Book c = bookList.First<Book>(x => (x.Isbn13 == isbn13));

                if (c != null)
                {
                    ((List<Book>)bookList).Remove(c);
                    c = value;
                   
                    ((List<Book>)bookList).Add(c);



                }
                else
                {
                    ((List<Book>)bookList).Add(value);
                }
            }
            catch
            {

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn13}")]
        public void Delete(string isbn13)
        {
            ((List<Book>)bookList).Remove(bookList.First<Book>(x => (x.Isbn13 == isbn13)));
        }
    }
}
