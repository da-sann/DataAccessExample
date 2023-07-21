using System;

namespace DataAccessExample.Interfaces
{
    public interface IRequest<out TResponse> { }
}
