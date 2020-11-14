using BlazorNetConfPuebla.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorNetConfPuebla.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrosController : ControllerBase
    {
        Context dbContext;
        public RegistrosController( Context context)
        {
            dbContext = context;
        }
        [HttpPost("Add")]
        public async Task<Registros> Add(Registros toAdd)
        {
            var a = await dbContext.AddAsync<Registros>(toAdd);
            await dbContext.SaveChangesAsync();
            return a.Entity;
        }
        [HttpGet("GetRegistros")]
        public async Task<List<Registros>> GetRegistros()
        {
            return await dbContext.Registros.ToListAsync();
        }
    }
}
