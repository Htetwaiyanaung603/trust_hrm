
using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface ICompanyRepository
    {
        Task SaveCompany(Company c);
        List<Company> GetCompanyList();
        Task<List<CompanyViewModel>> GetCompanyListc();
        List<Company> GetList(long? id);
        Company GetCompany(long? Id);
        Task Update(Company s);
        Company GetDelete(long id);
        Task Delete(Company sa);
        bool GetExit(long id);
        List<Company> GetSearchList(string value);
    }
}
