using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Repository
{
     public interface IBookRepository
    {

        Task<IEnumerable<Books>>GeTAllBooks();
        Task<Books> GetSingleBook(int id);
        Task<Books> AddBooks(Books books);
        Task<Books> Edit(Books books);


        Task<Books> Delete(int id);
    }
}
