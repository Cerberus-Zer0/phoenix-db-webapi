using System.Collections.Generic;
using WebAPI.Models;

namespace WebAPI.Data
{
    public interface IInstitution
    {
        bool SaveChanges();
        
        void CreateInstitution(Institution institution);
        IEnumerable<Institution> GetAllInstitutions();
        Institution GetInstitutionById(int id);
        void UpdateInstitution(Institution institution);
        void DeleteInstitution(Institution institution);
    }
}