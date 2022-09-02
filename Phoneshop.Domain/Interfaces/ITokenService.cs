using System.Collections.Generic;
using System.Security.Claims;

namespace Phoneshop.Domain.Interfaces
{
    public interface ITokenService
    {
        string Generate(List<Claim> claims);
    }
}
