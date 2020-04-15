using System;
using GrillMaster.Domain;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace GrillMaster.Data
{
    public class GrillDataEntityMapper : IMapper<GrillMenuData, GrillMenuEntity>
    {
        /// <summary>
        /// Maps list of type GrillMenuData to GrillMenuEntity.Calculation of area occupied by each menu item 
        /// in a menu is done here itself to avoid overhead of this calculation in GrillMenuRepository.cs.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        /// <returns></returns>
        public List<GrillMenuEntity> MapFrom(List<GrillMenuData> source, List<GrillMenuEntity> destination)
        {
            var entity = source.Select(r => new GrillMenuEntity
            {
                Id = r.Id,
                menu = r.Menu,
                items = r.GrillMenuItemsList.Select(
                    x => new GrillMenuEntityItems
                    {
                        Id = x.Id,
                        Duration = x.Duration,
                        Length = x.Length,
                        Name = x.Name,
                        Quantity = x.Quantity,
                        Breadth = x.Width,
                        MenuArea = (x.Length * x.Width * x.Quantity)
                    }).ToList()
            });


            return entity.ToList();
        }


    }
}

