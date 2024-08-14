using InternshipApp.DTO;
using InternshipApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternshipApp.Repos.Interfaces
{
    public interface ISalesRepository
    {
        Task<bool> CreateSalesAsync(Sales sale);
        Task<IEnumerable<SalesDTO>> GetAllSalesAsync();
        Task<IEnumerable<SalesDTO>> GetSalesAsync(int? id);
        Task<bool> UpdateSalesAsync(int? id, Sales sale);
        Task<bool> DeleteSalesAsync(int? id);

    }
}
