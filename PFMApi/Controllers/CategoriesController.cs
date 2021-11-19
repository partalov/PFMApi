using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCsvParser;
using TinyCsvParser.Mapping;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFMApi.Database.Entity.TransactionsE;
using PFMApi.Services.Contracts;
using PFMApi.Helpers;
using PFMApi.Dto;
using PFMApi.Helpers.Params;

namespace PFMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesService categoriesService, IMapper mapper)
        {
            _categoriesService = categoriesService;
            _mapper = mapper;
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> Import()
        {
            var request = HttpContext.Request;
            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }

            var status = await _categoriesService.AddCategories(request);
            if (status) return StatusCode(201);

            return BadRequest("Error while inserting the categories");
        }

    }
}
