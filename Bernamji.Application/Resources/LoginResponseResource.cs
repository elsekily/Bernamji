using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.Application.Resources;
public class LoginResponseResource : ApiResponse
{
    public string UserName { get; set; }
}