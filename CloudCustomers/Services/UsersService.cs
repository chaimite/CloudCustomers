using System;
using CloudCustomers.API.Models;

namespace CloudCustomers.API.Services
{
	public class UsersService: IUserService
	{
	public Task<List<User>> GetAllUsers()
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserService
    {
        public Task<List<User>> GetAllUsers();
    }
}

