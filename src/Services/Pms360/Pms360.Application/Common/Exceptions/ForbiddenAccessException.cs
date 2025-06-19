using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pms360.Application.Common.Exceptions;
public class ForbiddenAccessException : Exception
{
    public ForbiddenAccessException() : base() { }
}
