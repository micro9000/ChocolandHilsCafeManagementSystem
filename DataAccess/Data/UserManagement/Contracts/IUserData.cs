﻿using DapperGenericDataManager;
using DataAccess.Entities.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.User.Contacts
{
    public interface IUserData : IDataManagerCRUD<UserModel>
    {
        UserModel GetUserByUsername(string username);
    }
}