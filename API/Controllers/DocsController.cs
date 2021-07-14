using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocsController : ControllerBase
    {
        private readonly DataContext _context;
        public DocsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Documents>>> GetDocuments()
        {
           return await _context.Docs.ToListAsync();
           
        }

        [HttpGet("{Id}")]

        public async Task<ActionResult<Documents>> GetDocument(int Id)
        {
            return await _context.Docs.FindAsync(Id);
            
        }
    }
}