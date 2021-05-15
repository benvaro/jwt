
using JwtDemo.DataAccess.Entities;

namespace JwtDemo.Domain.Abstraction
{
    public interface IJwtTokenService
    {
        /// <summary>
        /// Method will generate token for user
        /// </summary>
        /// <param name="user">User for payload</param>
        /// <returns></returns>
        string CreateToken(User user);
    }
}
