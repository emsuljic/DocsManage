using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DocumentsRepository : IDocumentsRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public DocumentsRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;

        }

        public async Task<Documents> GetDocByIdAsync(int id)
        {
            return await _context.Docs.FindAsync(id);
        }

        public async Task<IEnumerable<Documents>> GetDocsAsync()
        {
            return await _context.Docs.ToListAsync();
            //.Include(u => u.Users)
            
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Documents docs)
        {
            _context.Entry(docs).State = EntityState.Modified;
        }
    }
}