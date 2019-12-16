using Dul.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace AssetHistoryApp.Models
{
    public class AssetHistoryRepository : IAssetHistoryRepository
    {
        private readonly AssetHistoryDbContext _context;

        public AssetHistoryRepository(AssetHistoryDbContext context)
        {
            this._context = context;
        }

        public async Task<AssetHistory> AddAsync(AssetHistory model)
        {
            _context.AssetsHistories.Add(model);
            await _context.SaveChangesAsync();
            return model; 
        }

        public async Task<PagingResult<AssetHistory>> GetAllAsync(int pageIndex, int pageSize)
        {
            var totalRecords = await _context.AssetsHistories.CountAsync();
            var models = await _context.AssetsHistories
                .OrderByDescending(m => m.Id)
                .Skip(pageIndex * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagingResult<AssetHistory>(models, totalRecords); 
        }

        public async Task<AssetHistory> GetByIdAsync(int id)
        {
            return await _context.AssetsHistories.Where(m => m.Id == id).SingleOrDefaultAsync(); 
        }

        public async Task<AssetHistory> EditAsync(AssetHistory model)
        {
            _context.Entry(model).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return model; 
        }

        public async Task DeleteAsync(int id)
        {
            var model = _context.AssetsHistories.Where(m => m.Id == id).SingleOrDefault();
            if (model != null)
            {
                _context.AssetsHistories.Remove(model);
                await _context.SaveChangesAsync(); 
            }
        }
    }
}
