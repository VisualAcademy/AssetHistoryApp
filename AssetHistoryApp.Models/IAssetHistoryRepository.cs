using Dul.Domain.Common;
using System.Threading.Tasks;

namespace AssetHistoryApp.Models
{
    public interface IAssetHistoryRepository
    {
        Task<AssetHistory> AddAsync(AssetHistory model);         // 입력
        Task<PagingResult<AssetHistory>> GetAllAsync(int pageIndex, int pageSize); // 출력
        Task<AssetHistory> GetByIdAsync(int id);              // 상세
        Task<AssetHistory> EditAsync(AssetHistory model);        // 수정
        Task DeleteAsync(int id);                         // 삭제
    }
}
