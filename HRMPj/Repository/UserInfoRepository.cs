using HRMPj.Data;
using HRMPj.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
    public class UserInfoRepository  : IUserInfoRepository
    {
        private readonly ApplicationDbContext context;

        public UserInfoRepository(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        public List<UserInfo> GetUserInfoList()
        {
            string sql = @"select u.UserName as UserName,u.Email as Email,e.EmployeeName as EmployeeName,d.Name as DepartmentName,de.Name as DesignationName from AspNetUsers u join EmployeeInfo e on e.UserId=u.Id join Department d on d.Id=e.DepartmentId join Designation de on de.Id=e.DesignationId";
            List<UserInfo> kk = context.Query<UserInfo>().FromSql(sql).ToList<UserInfo>();
            return kk;
        }

        public async Task Save(UserInfo ee)
        {
            context.Add(ee);
            await context.SaveChangesAsync();
        }

        public async Task Update(UserInfo ee)
        {
            context.Update(ee);
            await context.SaveChangesAsync();
        }
    }
}
