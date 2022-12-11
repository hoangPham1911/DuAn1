using _1.DAL.DALServices;
using _1.DAL.IDALServices;
using _1.DAL.IRepositories;
using _1.DAL.Repostiores;
using _1_DAL.Models;
using _2_BUS.IServices;
using _2_BUS.ViewModels;

namespace _2_BUS.Services
{
    public class HoaDonService : IHoaDonService
    {

        IreceiptRepository HoaDonRepos;
        ISfattRepository SfatttRepository;

        public HoaDonService()
        {
            HoaDonRepos = new ReceiptRepositores();
            SfatttRepository = new SfattRepositores();
        }
        public List<SuaHoaDonModels> GetAllHoaDonDB()
        {
            return (from a in HoaDonRepos.getAllReceipt()
                    select
                    new SuaHoaDonModels
                    {
                        IdHoaDon = a.Id,
                        IdKh = a.IdKh,
                        IdNv = a.IdNv,
                        Ma = a.Ma,
                        NgayNhan = a.NgayNhan,
                        NgayShip = a.NgayShip,
                        NgayTao = a.NgayTao,
                        NgayThanhToan = a.NgayThanhToan,
                        TinhTrang = a.TinhTrang,
                        SDTShip = a.SDTShip,
                        TenShip = a.TenShip,
                        SoTienQuyDoi = a.SoTienQuyDoi,
                        SoDiemSuDung = a.SoDiemSuDung,

                        MaGiamGia = a.MaGiamGia,

                    }).ToList();


        }
        public List<SuaHoaDonModels> Get()
        {
            return (from a in HoaDonRepos.getAllReceipt()
                    join b in SfatttRepository.GetAll() on a.IdNv equals b.Id
                    select
                    new SuaHoaDonModels
                    {
                        IdHoaDon = a.Id,
                        IdNv = a.IdNv,
                        Ma = a.Ma,
                        NgayNhan = a.NgayNhan,
                        NgayShip = a.NgayShip,
                        NgayTao = a.NgayTao,
                        NgayThanhToan = a.NgayThanhToan,
                        TinhTrang = a.TinhTrang,
                        SDTShip = a.SDTShip,
                        TenShip = a.TenShip,
                        SoTienQuyDoi = a.SoTienQuyDoi,
                        SoDiemSuDung = a.SoDiemSuDung,
                        TongSoTienTrongCa = a.TongTienNvTrongCa

                    }).ToList();

        }

        public Guid GetIdHoaDon(ThemHoaDonModels IdHoaDon)
        {
            var hoaDon = new HoaDon();
            hoaDon.IdKh = IdHoaDon.IdKh;
            hoaDon.IdNv = IdHoaDon.IdNv;
            hoaDon.Ma = IdHoaDon.Ma;
            hoaDon.NgayTao = IdHoaDon.NgayTao;
            hoaDon.NgayThanhToan = IdHoaDon.NgayThanhToan;
            hoaDon.NgayShip = IdHoaDon.NgayShip;
            hoaDon.NgayNhan = IdHoaDon.NgayNhan;
            hoaDon.TinhTrang = IdHoaDon.TinhTrang;
            if (HoaDonRepos.addReceipt(hoaDon)) return hoaDon.Id;
            return Guid.Parse(null);
        }

        public string SuaHoaDon(SuaHoaDonModels Hoadonold)
        {

            if (Hoadonold != null)
            {
                var hoaDon = HoaDonRepos.getAllReceipt().FirstOrDefault(p => p.Id == Hoadonold.IdHoaDon);
                hoaDon.SDTShip = Hoadonold.SDTShip;
                hoaDon.TinhTrang = Hoadonold.TinhTrang;
                hoaDon.IdKh = Hoadonold.IdKh;
                hoaDon.IdNv = Hoadonold.IdNv;
                hoaDon.NgayTao = Hoadonold.NgayTao;
                hoaDon.NgayNhan = Hoadonold.NgayNhan;
                hoaDon.NgayThanhToan = Hoadonold.NgayThanhToan;
                hoaDon.NgayShip = Hoadonold.NgayShip;
                hoaDon.TinhTrang = Hoadonold.TinhTrang;
                hoaDon.TenShip = Hoadonold.TenShip;
                hoaDon.SoDiemSuDung = Hoadonold.SoDiemSuDung;
                hoaDon.SoTienQuyDoi = Hoadonold.SoTienQuyDoi;
                hoaDon.TongTienNvTrongCa = Hoadonold.TongSoTienTrongCa;
                hoaDon.MaGiamGia = Hoadonold.MaGiamGia;
                HoaDonRepos.updateReceipt(hoaDon);
                return "thanh cong";
            }
            return "thất bại";

        }
        public string UpdateSoTienNvTrongCa(SuaHoaDonModels Hoadonold)
        {
            if (Hoadonold == null) return "that bai";
            else
            {
                var hoaDon = HoaDonRepos.getAllReceipt().FirstOrDefault(p => p.Id == Hoadonold.IdHoaDon);
                hoaDon.IdNv = Hoadonold.IdNv;
                hoaDon.TongTienNvTrongCa = Hoadonold.TongSoTienTrongCa;
                HoaDonRepos.updateReceipt(hoaDon);
                return "thanh cong";
            }
        }
        public string ThemHoaDon(ThemHoaDonModels Hoadonnew)
        {
            if (Hoadonnew == null) return "that bai";
            else
            {
                HoaDon hd = new HoaDon()
                {
                    Id = Guid.NewGuid(),
                    IdKh = Hoadonnew.IdKh,
                    IdNv = Hoadonnew.IdNv,
                    Ma = Hoadonnew.Ma,
                    NgayTao = Hoadonnew.NgayTao,
                    NgayThanhToan = Hoadonnew.NgayThanhToan,
                    NgayShip = Hoadonnew.NgayShip,
                    NgayNhan = Hoadonnew.NgayNhan,
                    TinhTrang = Hoadonnew.TinhTrang,
                };
                HoaDonRepos.addReceipt(hd);
                return "thanh cong";

            }
        }

        public List<HoaDon> timkiemHoadonTheoMa(string MaHoaDon)
        {
            return HoaDonRepos.TimKiemTheomaHd(MaHoaDon);
        }

        public string XoaHoaDon(Guid SuaHD)
        {
            if (HoaDonRepos.removeReceipt(SuaHD))
                return "thanh cong xoa";
            return "That Bai";
        }
    }
}
