using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model;

namespace WebApplication1.Helper
{
    public class ApplicationMapper:Profile
    {

        public ApplicationMapper()
        {
            CreateMap<Books, BooksModel>().ReverseMap();
        }
    }
}
