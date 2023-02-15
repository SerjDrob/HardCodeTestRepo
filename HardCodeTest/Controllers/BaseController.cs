using AutoMapper;
using HardCodeTest.Data;
using Microsoft.AspNetCore.Mvc;

namespace HardCodeTest.Controllers
{
    public class BaseController : ControllerBase
    {
        protected readonly HardCodeDbContext _db;
        protected readonly IMapper _mapper;

        public BaseController(HardCodeDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
    }
}
/*
 1. Страница категории товара.
На странице категорий товара должен выводится список категорий, с возможностью добавлять новую или удалить существующую категорию.
При добавлении категории нужно добавить возможность добавлять дополнительные поля для товара этой категории, например, цвет, вес, размер и т.д.
 */