using System;
using System.Collections.Generic;
using System.Linq;
using GrillMaster.Domain;


namespace GrillMaster.Data
{
    public class GrillMenuRepository : IRepository
    {
        #region Variables
        private readonly IApi _api;
        private readonly IMapper<GrillMenuData, GrillMenuEntity> _mapper;
        private int _barbequeLength = 20;
        private int _barbequeBreadth = 30;
        #endregion

        #region Constructor
        public GrillMenuRepository(IApi api, IMapper<GrillMenuData, GrillMenuEntity> mapper)
        {
            _api = api ?? throw new ArgumentNullException(nameof(api));
            _mapper = mapper;
        }
        #endregion

        #region Interface Method Implementations

        /// <summary>
        /// Gets the JSON data,sorts the list with menu items occupying largest area on the BBQ,
        /// calculates the rounds requiered by each menu,computes total rounds required for full grill menu
        /// </summary>
        /// <returns></returns>
        public List<GrillMenuEntity> GetGrillMenu()
        {
            List<GrillMenuEntity> menuEntityList = new List<GrillMenuEntity>();

            int totalBBQArea = GetDefaultBarbequeArea();

            var menuDataList = _api.GetGrillMenuData().ToList();
            var mappedItems = _mapper.MapFrom(menuDataList, menuEntityList);

            var sortedList = SumAndSortByLargestArea(mappedItems);

            sortedList.ForEach(x => x.BarbequeRounds = CalculateRoundsPerMenu(totalBBQArea, x.TotalMenuArea));

            sortedList.ForEach(x => x.TotalBarbequeRounds = ReportTotalRounds(sortedList));

            return sortedList;
        }

        /// <summary>
        /// total menu area sum(length*breadth* qty) per menu is compared with bbq area( 20*30 = 600).
        /// eg if menu 1 has x items  so [sum(area(x items)) compared with bbq area] until the last one fits.this is on menu level.
        /// Rounds are calculated using the highest area occupied first
        /// </summary>
        /// <param name="barbequeArea"></param>
        /// <param name="totalMenuItemArea"></param>
        /// <returns></returns>
        public int CalculateRoundsPerMenu(int barbequeArea, int totalMenuItemArea)
        {
            int rounds = 0;
            do
            {
                totalMenuItemArea -= barbequeArea;
                rounds++;
            }
            while (totalMenuItemArea > 0);
            return rounds;
        }       

        /// <summary>
        /// sums up all the barbeque rounds
        /// </summary>
        /// <param name="listWithIndividualRounds"></param>
        /// <returns></returns>
        public int ReportTotalRounds(List<GrillMenuEntity> listWithIndividualRounds)
        {
            return listWithIndividualRounds.Sum(x => x.BarbequeRounds);
        }

        /// <summary>
        /// calculates the default barbeque area in this case 20*30 = 600
        /// </summary>
        /// <returns></returns>
        public int GetDefaultBarbequeArea()
        {
            return _barbequeLength * _barbequeBreadth;
        }

        /// <summary>
        /// sum the areas of each menu item on  menu level.eg menu 1 has x items so menu 1 area = sum(area of x items).
        /// sort the area in descending.highest occupancy considered first
        /// </summary>
        /// <param name="listWithArea"></param>
        /// <returns></returns>
        public List<GrillMenuEntity> SumAndSortByLargestArea(List<GrillMenuEntity> listWithArea)
        {
            int total = 0;
            foreach (GrillMenuEntity menu in listWithArea)
            {
                total = 0;
                foreach (GrillMenuEntityItems menuItem in menu.items)
                {
                    total += menuItem.MenuArea;
                }
                menu.TotalMenuArea = total;
            }

            return listWithArea.OrderByDescending(x => x.TotalMenuArea).ToList();
        }
        #endregion
    }
}
