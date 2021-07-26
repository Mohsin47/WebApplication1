using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public ValuesController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult>Get()
        {
            try
            {
                return Ok(await _bookRepository.GeTAllBooks());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }
           
        }

        [HttpGet("{id:int}")]

        public async Task<IActionResult>GetsingleData(int id)
        {
            try
            {
                var detail = await _bookRepository.GetSingleBook(id);
                if(detail==null)
                {
                    return NotFound();
                }
                return Ok(detail);

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }
        }


        [HttpPost]

        public async Task<IActionResult> Add(Books books)
        {
            try
            {
                if(books!=null)
                {
                    await _bookRepository.AddBooks(books);
                    return Ok(books);
                }
                return null;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status203NonAuthoritative);

            }

        }

        //[HttpPut]
        [HttpPut("{id:int}")]

        public async Task<IActionResult> AddData(int id , Books books)
        {
            try
            {
                if(id!=books.Id)
                {
                    return NotFound();

                }
                var edit = await _bookRepository.Edit(books);
                
                return Ok(edit);
                

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }

        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                
                    var del = await _bookRepository.Delete(id);
                    return Ok();
                
                
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status204NoContent);
            }
          
        }

    }
}
