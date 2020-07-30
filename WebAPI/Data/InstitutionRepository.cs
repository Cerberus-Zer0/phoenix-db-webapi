using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class InstitutionRepository : IInstitution
    {
        private readonly WebAPIContext _context;

        public InstitutionRepository(WebAPIContext context)
        {
            _context = context;
        }

        public void CreateInstitution(Institution institution)
        {
            if (institution == null) {
                throw new ArgumentNullException(nameof(institution));
            }

            _context.Institutions.Add(institution);
        }

        public void DeleteInstitution(Institution institution)
        {
            if (institution == null) 
            {
                throw new ArgumentNullException(nameof(institution));
            }
            _context.Institutions.Remove(institution);
        }

        public IEnumerable<Institution> GetAllInstitutions()
        {
            return _context.Institutions.ToList();
        }

        public Institution GetInstitutionById(int id)
        {
            return _context.Institutions.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateInstitution(Institution institution)
        {
            // Nothing
        }
    }
}
