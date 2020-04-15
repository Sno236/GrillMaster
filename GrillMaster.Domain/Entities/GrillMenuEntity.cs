using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Domain
{

    /// <summary>
    /// JSON equivalent class for main list with additional fields for reporting
    /// </summary>
    public class GrillMenuEntity
    {        
        public string Id { get; set; }
        public string menu { get; set; }
        public int BarbequeRounds { get; set; } /* to set barbeque rounds per menu*/
        public int TotalBarbequeRounds { get; set; } /* to set sum of barbeque rounds for all menus*/
        public int TotalMenuArea { get; set; }/* to set sum of area occupied per menu*/
        public List<GrillMenuEntityItems> items { get; set; }
    }
}






