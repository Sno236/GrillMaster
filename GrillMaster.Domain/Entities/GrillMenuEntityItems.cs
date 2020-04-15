using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Domain
{
    /// <summary>
    ///  JSON equivalent class for sub list with additional fields for reporting
    /// </summary>
    public class GrillMenuEntityItems
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Breadth { get; set; }
        public string Duration { get; set; }
        public int Quantity { get; set; }                
        public int MenuArea { get; set; } /* to set area occupied by each individual menu item*/


    }
}
