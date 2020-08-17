using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitmentAPI.Models;

namespace RecruitmentAPI.Repository
{
    public interface IFactoryMaster
    {
        bool Save(object req);
        bool Update(object req);
        bool Remove(int id);
        List<ListItem> GetDetails();

    }
}