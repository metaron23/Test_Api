using Microsoft.EntityFrameworkCore;
using Test_Api.Data;
using Test_Api.Models;

namespace Test_Api.Services
{
    public class HangHoaRepository : IHangHoaRepository
    {
        private MyDBContext _context;
        public static int PAGE_SIZE { get; set; } = 1;

        public HangHoaRepository(MyDBContext context)
        {
            _context = context;
        }

        public async Task<List<HangHoaModel>> GetAll(string? search, double? from, double? to, string? sortBy, int page = 1)
        {
            var allProducts = _context.HangHoas.AsQueryable();

            #region Filter
            if (!String.IsNullOrEmpty(search))
            {
                allProducts = _context.HangHoas.Where(hh => hh.TenHh.Contains(search));
            }
            if (from.HasValue)
            {
                allProducts = _context.HangHoas.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProducts = _context.HangHoas.Where(hh => hh.DonGia <= to);
            }
            #endregion

            #region Sort
            allProducts = allProducts.OrderBy( h=>h.TenHh);
            if (!String.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "tenhh_desc":
                        allProducts = allProducts.OrderByDescending(h => h.TenHh);
                        break;
                    case "dongia_desc":
                        allProducts = allProducts.OrderByDescending(h => h.DonGia);
                        break;
                    case "dongia_asc":
                        allProducts = allProducts.OrderBy(h => h.DonGia);
                        break;
                };
            }
            #endregion

            #region Paging
            var result = await PaginatedList<Test_Api.Data.HangHoa>.CreateAsync(allProducts.Include(hh=>hh.Loai), page, PAGE_SIZE);
            #endregion

            var a  = result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHh,
                TenHangHoa = hh.TenHh,
                DonGia = hh.DonGia,
                TenLoai = hh.Loai.TenLoai
            });

            return a.ToList();
        }

        public Data.HangHoa GetById(string id)
        {
            var hh = _context.HangHoas.Include(hh=>hh.Loai).SingleOrDefault(hh => hh.MaHh == Guid.Parse(id));
            return hh;
        }
    }
}
