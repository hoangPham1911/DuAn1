using _2_BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_BUS.IService
{
    public interface IChatLieuServices
    {
        string add(ChatLieuViewModels chatlieu);
        string remove(ChatLieuViewModels chatlieu);
        string update(ChatLieuViewModels chatlieu);
        public Guid IdChatLieu(ChatLieuViewModels CL);
        List<ChatLieuViewModels> GetChatLieu();
    }
}
