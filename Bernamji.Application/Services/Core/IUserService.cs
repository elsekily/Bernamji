﻿using bernamji.Core.Entities;
using Bernamji.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.Application.Services.Core;
public interface IUserService
{
    Task<LoginResponseResource> CheckUserCredentials(UserResource userResource);
}
