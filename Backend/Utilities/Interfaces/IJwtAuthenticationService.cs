using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Interfaces
{
    public interface IJwtAuthenticationService
    {
        string Authenticate(string user, string password);

        string EncryptMD5(string password);
    }
}
