using Test_Api.Models;

namespace Test_Api.Services
{
    public interface IHangHoaRepository
    {
        Task<List<HangHoaModel>> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1);

        Data.HangHoa GetById(string id);
    }
}
