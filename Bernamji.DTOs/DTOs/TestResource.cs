using Bernamji.DTOs.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bernamji.DTOs.DTOs;
public class TestResource
{
    [NationalId]
    public string NationalId { get; set; }
}
