using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Data
{
    /// <summary>
    /// API interface
    /// </summary>
   public interface IApi
    {
        List<GrillMenuData> GetGrillMenuData();
    }
}
