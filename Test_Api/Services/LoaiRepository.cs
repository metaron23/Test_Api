using Test_Api.Data;
using Test_Api.Models;

namespace Test_Api.Services
{
    public class LoaiRepository : ILoaiRepository
    {
        private MyDBContext _context;

        public LoaiRepository(MyDBContext context)
        {
            _context = context;
        }

        public LoaiVM CreateNew(LoaiModel model)
        {
            var loai = new Loai
            {
                TenLoai = model.TenLoai
            };
            _context.Add(loai);
            _context.SaveChanges();
            return new LoaiVM
            {
                MaLoai = loai.MaLoai,
                TenLoai = loai.TenLoai,
            };
        }

        public void Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                _context.Remove(loai);
                _context.SaveChanges();
            }
        }

        public List<LoaiVM> GetAll()
        {
            var loais = _context.Loais.Select(lo => new LoaiVM
            {
                MaLoai = lo.MaLoai,
                TenLoai = lo.TenLoai,
            }).ToList();
            return loais;
        }

        public LoaiVM GetById(int id)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == id);
            if (loai != null)
            {
                return new LoaiVM()
                {
                    MaLoai = loai.MaLoai,
                    TenLoai = loai.TenLoai,
                };
            }
            else
            {
                return null!;
            }
        }

        public void Update(LoaiVM model)
        {
            var loai = _context.Loais.SingleOrDefault(lo => lo.MaLoai == model.MaLoai);
            if (loai != null)
            {
                if (loai.MaLoai == model.MaLoai)
                {
                    loai.TenLoai = model.TenLoai;
                    _context.Update(loai);
                    _context.SaveChanges();
                }
            }            
        }
    }
}
