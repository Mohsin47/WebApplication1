using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Books> AddBooks(Books books)
        {
            if(books!=null)
            {
                 _db.Books.Add(books);
                await _db.SaveChangesAsync();
            }
            return books;
        }

        public async Task<Books> Delete(int id)
        {
            var delet = await _db.Books.Where(m => m.Id == id).FirstOrDefaultAsync();

            _db.Remove(delet);
            await _db.SaveChangesAsync();
            return delet;
        }

        public async Task<Books> Edit(Books books)
        {
            if(books!=null)
            {
                var check = await _db.Books.Where
                    (m => m.Id == books.Id).FirstOrDefaultAsync();
               if(check !=null)
                {
                    check.Id = books.Id;
                    check.Name = books.Name;
                    check.Description = books.Description;
                    await _db.SaveChangesAsync();
                    return check;
                }
            }
            return books;
        }

        public async Task<IEnumerable<Books>> GeTAllBooks()
        {
            var list =  await _db.Books.ToListAsync();
            return list;
        }

        public async Task<Books> GetSingleBook(int id)
        {
            return await _db.Books.Where(m => m.Id == id).FirstOrDefaultAsync(); 
        }
    }
}
