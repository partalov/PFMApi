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
using PFMApi.Services;

namespace PFMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
      private readonly ITransactionsService _transactionsService;
      private readonly IMapper _mapper;


        public TransactionsController(ITransactionsService transactionsService, IMapper mapper)
        {
            _transactionsService = transactionsService;
            _mapper = mapper;
        }

        // api/transactions/import
        [HttpPost("[action]")]
        public async Task<IActionResult> Import()
        {
            var request = HttpContext.Request;
            if (!request.Body.CanSeek)
            {
                request.EnableBuffering();
            }

            var status = await _transactionsService.AddTransactions(request);
            if (status) return StatusCode(201);

            return BadRequest("Error while inserting the transactions");
        }


        //pi/transaction/GetTransactions/
        [HttpGet("[action]")]
        public async Task<IActionResult> GetTransactions([FromQuery] QueryParams TransactionsParams)
        {
            var status = await _transactionsService.GetPagedListTransactions(TransactionsParams);


            Response.AddPagination(status.CurrentPage, status.PageSize, status.TotalCount, status.TotalPages);

            return Ok(_mapper.Map<List<TransactionsDto>>(status));
        }
    }
}
