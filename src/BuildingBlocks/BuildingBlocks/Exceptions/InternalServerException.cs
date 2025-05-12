using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.Exceptions;
public class InternalServerException : Exception
{
    public InternalServerException(string? message) : base(message)
    {
        Details = string.Empty;
    }

    public InternalServerException(string? message, string? details) : base(message)
    {
        Details = details ?? string.Empty;
    }
    public string? Details { get; }
}
