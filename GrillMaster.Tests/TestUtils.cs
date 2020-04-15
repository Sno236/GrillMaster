using System;
using System.Collections.Generic;
using System.Text;
using GrillMaster.Data;
using GrillMaster.Domain;

namespace GrillMaster.Tests
{
    public static class TestUtils
    {
        public static List<GrillMenuData> TestGrillMenuData => new List<GrillMenuData>()
        {
            new GrillMenuData
            {
            Id = "4",
            Menu = "Menu 4",
            GrillMenuItemsList = new List<GrillMenuItems>()
            {
                new GrillMenuItems
                {
                    Id = "5e600aad-5bcf-4739-8272-0bf14f9cc8f1",
                    Name = "Rumpsteak",
                    Length = 15,
                    Width = 7,
                    Duration = "00:08:00",
                    Quantity= 1
                }
            }
            }
        };

        public static List<GrillMenuEntity> TestGrillMenuEntity => new List<GrillMenuEntity>()
        {
            new GrillMenuEntity
            {
            Id = "4",
            menu = "Menu 4",
            items = new List<GrillMenuEntityItems>()
            {
                new GrillMenuEntityItems
                {
                    Id = "5e600aad-5bcf-4739-8272-0bf14f9cc8f1",
                    Name = "Rumpsteak",
                    Length = 15,
                    Width = 7,
                    Duration = "00:08:00",
                    Quantity= 1
                }
            }
            }
        };
    }
}
