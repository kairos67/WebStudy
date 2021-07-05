using Hello.IDAL;
using Hello.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.Oracle.DAL
{
    public class UserDal : IUserDal
    {
        public User GetUser(int userNo)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }

        public bool SaveUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
