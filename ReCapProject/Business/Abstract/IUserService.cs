using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IBaseBusinessService<User>
    {
        IDataResult<User> GetByUserId(int userId);     
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
    }
}
