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
        int _rows = 0;
        int _rounds = 0;
        int _totalRounds = 0;
        int _remainingSpaceInCurrentRow = 0;
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
        /// Gets the JSON data,sorts the list with menu items with maximum length
        /// calculates the rounds required by each menu,computes total rounds required for full grill menu
        /// </summary>
        /// <returns></returns>
        public List<GrillMenuEntity> GetGrillMenu()
        {
            List<GrillMenuEntity> menuEntityList = new List<GrillMenuEntity>();

            var menuDataList = _api.GetGrillMenuData().ToList();
            var mappedItems = _mapper.MapFrom(menuDataList, menuEntityList);

            /*Items are arranged with maximum height first */
            var menus = SortByDescendingLength(mappedItems);

            int quantity = 0;
            foreach (var menu in menus)
            {
                _rounds = 0;
                foreach (var menuItem in menu.items)
                {
                    _rows = 0;

                    /* we are arranging items in the menu left-> right and then top -> bottom.
                     * so we are calculating maximum no. of rows required per item*/
                    int approxRowsNeeded = _barbequeBreadth / menuItem.Length;

                    quantity = menuItem.Quantity;

                    /* updates the quantity of items based on available space if any in the previous row wise grill-run*/
                    if (_remainingSpaceInCurrentRow > 0 && _remainingSpaceInCurrentRow > menuItem.Breadth)
                    {
                        quantity = menuItem.Quantity - (_remainingSpaceInCurrentRow / menuItem.Breadth);
                    }

                    Recursive(menuItem.Breadth, quantity);
                    CalculateRoundsPerMenu(approxRowsNeeded);
                }
                _totalRounds += _rounds;
                Console.WriteLine($"{menu.menu} : {_rounds} rounds");
            }

            Console.WriteLine($"Total rounds :  {_totalRounds} ");
            return mappedItems;
        }

        /// <summary>
        /// sort the menu items in descending order based on length in each MENU.We need this to 
        /// start arranging items with max length first as we are going to arrange items height wise
        /// </summary>
        /// <param name="entitylist"></param>
        /// <returns></returns>
        public List<GrillMenuEntity> SortByDescendingLength(List<GrillMenuEntity> entitylist)
        {

            foreach (var menu in entitylist)
            {
                menu.items = menu.items.OrderByDescending(x => x.Length).ToList();
            }
            return entitylist.OrderBy(x => x.menu).ToList();
        }

        /// <summary>
        /// This recursive function is arranging items left to right row wise.
        /// Also calculates remaining space in a row,if any
        /// </summary>
        /// <param name="menuItemBreadth"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public int Recursive(int menuItemBreadth, int quantity)
        {
            if (quantity <= 0)
            {
                return 0;
            }
            else
            {
                _rows++;
                int noOfItemPerRow = _barbequeLength / menuItemBreadth;
                int remaingItemsToAllocate = quantity - noOfItemPerRow;
                if (remaingItemsToAllocate < noOfItemPerRow)
                {
                    CalculateRemainingSpace(remaingItemsToAllocate, menuItemBreadth);
                }
                return Recursive(menuItemBreadth, remaingItemsToAllocate);
            }
        }

        /// <summary>
        /// This method calculates remaining space in a row which can be used to add new item,if it fits in there
        /// </summary>
        /// <param name="remainingSpace"></param>
        /// <param name="actualbreadth"></param>
        public void CalculateRemainingSpace(int remainingSpace, int actualbreadth)
        {
            _remainingSpaceInCurrentRow = _barbequeLength - (remainingSpace * actualbreadth);
        }

        /// <summary>
        /// calculates total no.of rounds required per menu. _rows is populated in the recursive function .Based on _rows and 
        /// approxRowsNeeded value calculated in the previous steps,we can determine the rounds needed iteratively if applicable.
        /// </summary>
        /// <param name="approxRowsNeeded"></param>
        public void CalculateRoundsPerMenu(int approxRowsNeeded)
        {
            if (_rows > approxRowsNeeded)
            {
                if (_rows % approxRowsNeeded != 0)
                {
                    _rounds += (_rows / approxRowsNeeded) + 1;
                }
                else if (_rows % approxRowsNeeded == 0)
                {
                    _rounds += (_rows / approxRowsNeeded);
                }
            }
            else
            {
                _rounds++;
            }

        }



        #endregion
    }
}
