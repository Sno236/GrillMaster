using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Domain
{
    /// <summary>
    /// Imapper interface to map list of generic type to any other generic type
    /// </summary>
    /// <typeparam name="S"></typeparam>
    /// <typeparam name="T"></typeparam>
    public interface IMapper<S, T> where T : class
        where S : class
    {
        List<T> MapFrom(List<S> source, List<T> destination);
    }
}
