using Note.IDAL;
using Note.Model;
using System;
using System.Collections.Generic;

namespace Note.BLL
{
    public class UserBll 
    {
        //private UserDal _userDal = new UserDal(); //X
        private readonly IUserDal _userDal; //O

        public UserBll(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public User GetUser(int userNo)
        {
            return _userDal.GetUser(userNo);
        }

        public List<User> GetUserList()
        {
            throw new NotImplementedException();
        }
    }
}
