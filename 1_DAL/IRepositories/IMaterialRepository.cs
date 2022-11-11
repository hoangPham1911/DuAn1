using _1_DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_DAL.IRepostiories
{
    public interface IMaterialRepository
    {
        bool addMaterial(ChatLieu material);
        bool updateMaterial(ChatLieu material);
        bool deleteMaterial(ChatLieu material);
        List<ChatLieu> getMaterialFromDB();
    }
}
