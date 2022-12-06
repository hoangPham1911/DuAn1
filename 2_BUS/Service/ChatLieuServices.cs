using _1_DAL.IRepositories;
using _1_DAL.Models;
using _1_DAL.Repositores;
using _2_BUS.IService;
using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.Service
{
    public class ChatLieuServices : IChatLieuServices
    {
        private IChatLieuRepository chatLieurp;
        private List<ChatLieuViewModels> lstChatLieu;

        public ChatLieuServices()
        {
            chatLieurp = new ChatLieuRepositores();
            lstChatLieu = new List<ChatLieuViewModels>();
        }
        public string add(ChatLieuViewModels CL)
        {
            if (CL == null) return "Không Thành Công";
            var temp = chatLieurp.getAll().FirstOrDefault(c => c.Ma == CL.Ma);
            ChatLieu x = new ChatLieu()
            {
                Id = CL.Id,
                Ma = CL.Ma,
                Ten = CL.Ten,
                TrangThai = CL.TrangThai
            };
            if (temp == null)
            {
                if (CL.Ma != "")
                {
                    if (chatLieurp.add(x)) return "Thêm Thành Công";
                    return "Không Thành Công";
                }
                else return "Chưa nhập mã";
            }
            else { return "Trùng mã rồi"; }
        }
        public Guid IdChatLieu(ChatLieuViewModels CL)
        {
            ChatLieu x = new ChatLieu()
            {
                Id = CL.Id,
                Ma = CL.Ma,
                Ten = CL.Ten,
                TrangThai = CL.TrangThai
            };
            if (chatLieurp.add(x)) return x.Id;
            else return Guid.Empty;
        }
        public List<ChatLieuViewModels> GetChatLieu()
        {
            lstChatLieu = (from cl in chatLieurp.getAll()
                          select new ChatLieuViewModels
                          {
                              Id = cl.Id,
                              Ma = cl.Ma,
                              Ten = cl.Ten,
                              TrangThai = cl.TrangThai,
                          }).OrderBy(c => c.Ma).ToList();
            return lstChatLieu;
        }

        public string remove(ChatLieuViewModels CL)
        {
            if (CL == null) return "Không Thành Công";
            int a = 0;
            var x = new ChatLieu()
            {
                Id = CL.Id
            };
            var list = chatLieurp.getAll();
            foreach (var i in list)
            {
                if (CL.Id == i.Id) a++;
            }
            if (chatLieurp.remove(x)) return "Xóa Thành Công";
            return "Không Thành Công";
        }

        public string update(ChatLieuViewModels CL)
        {
            if (CL == null) return "Không Thành Công";
            var temp = chatLieurp.getAll().FirstOrDefault(c => c.Id == CL.Id);
            ChatLieu x = new ChatLieu()
            {
                Id = CL.Id,
                Ma = CL.Ma,
                Ten = CL.Ten,
                TrangThai = CL.TrangThai
            };
            if (CL.Ma != "")
            {
                if (temp == null)
                {
                    if (chatLieurp.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else if (CL.Id == x.Id)
                {
                    if (chatLieurp.update(x)) return "Sửa Thành Công";
                    return "Không Thành Công";
                }
                else { return "Trùng rồi kìa"; }
            }
            else return "Vui lòng đủ thông tin";
        }

    }
}

