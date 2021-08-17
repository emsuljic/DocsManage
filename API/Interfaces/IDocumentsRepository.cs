using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IDocumentsRepository
    {
        void Update(Documents docs);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<Documents>> GetDocsAsync();
        Task<Documents> GetDocByIdAsync(int id);

    }
}