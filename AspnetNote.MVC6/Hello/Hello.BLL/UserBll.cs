using Hello.IDAL;
using Hello.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hello.BLL
{
    public class UserBll 
    {
        private readonly IUserDal _userDal;

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public List<User> GetUserList()
        {
            return _userDal.GetUserList();
        }

        public User GetUser(int userNo)
        {
            if (userNo < 0)
            {
                throw new ArgumentException(); //threw된 내용이 mvc로 넘어감
            }

            return _userDal.GetUser(userNo);
        }
             
        public bool SaveUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            return _userDal.SaveUser(user);
        }
    }
}
