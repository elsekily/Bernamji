using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.Shared.Services.Core;
public interface ISecurityService
{
    string HashPassword(string password);
    bool CheckPassword(string password, string hashedPasswordWithSalt);
}
