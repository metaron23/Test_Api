using Test_Api.Data;
using Test_Api.Models;

namespace Test_Api.Services
{
    public interface ILoaiRepository
    {
        List<LoaiVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM CreateNew(LoaiModel loai);
        void Update(LoaiVM loai);
        void Delete(int id);
    }
}
