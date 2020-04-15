using System.Collections;
using System.Collections.Generic;

namespace GrillMaster.Domain
{
    /// <summary>
    /// Use case interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface IRequestHandler<T>
    {
        List<T> Handle();
    }
}
