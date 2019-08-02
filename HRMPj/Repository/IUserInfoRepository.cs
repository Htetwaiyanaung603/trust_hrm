using HRMPj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRMPj.Repository
{
  public  interface IUserInfoRepository
    {
        Task Save(UserInfo ee);
        Task Update(UserInfo ee);
        List<UserInfo> GetUserInfoList();
    }
}
