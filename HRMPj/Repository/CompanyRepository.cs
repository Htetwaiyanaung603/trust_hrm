using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMPj.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext context;

        public CompanyRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public async  Task Delete(Company sa)
        {
            context.Remove(sa);
            await context.SaveChangesAsync();
        }

        public Company GetCompany(long? Id)
        {
            try
            {
                var com = context.Companies.Find(Id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Company> GetCompanyList()
        {
            List<Company> cList = context.Companies.ToList();
            return cList;
        }

        public async Task<List<CompanyViewModel>> GetCompanyListc()
        {

            var comList = await (from c in context.Companies select new CompanyViewModel() { Id = c.Id, CompanyName = c.CompanyName, CreatedDate = c.CreatedDate }).ToAsyncEnumerable<CompanyViewModel>().ToList();
            return comList;
        }

        public Company GetDelete(long id)
        {
            try
            {
                var com = context.Companies.Find(id);
                return com;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Company> GetDetail(long? id)
        {
            Company dd = await context.Companies
                           .FirstOrDefaultAsync(m => m.Id == id);
            return dd;
        }

        public bool GetExit(long id)
        {
           var dd= context.Companies.Any(e => e.Id == id);
            return dd;
            
        }

        public List<Company> GetList(long? id)
        {
            List<Company> cList = context.Companies.ToList();
            return cList;
        }

        public List<Company> GetSearchList(string value)
        {
            List<Company> blist = context.Companies.Where(b =>b.CompanyName.StartsWith(value) ).ToList();
            return blist;
        }

        public async Task SaveCompany(Company c)
        {
            context.Add(c);
            await context.SaveChangesAsync();
        }

        public async Task Update(Company s)
        {
            context.Update(s);
            await context.SaveChangesAsync();
        }
    }
}
