using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Domain
{
    /// <summary>
    /// Main repository interface where all the business logic is implemented
    /// </summary>
    public interface IRepository
    {
        List<GrillMenuEntity> GetGrillMenu();

        void CalculateRemainingSpace(int remainingSpace, int actualbreadth);
        int Recursive(int menuItemBreadth, int quantity);
        void CalculateRoundsPerMenu(int attempts);
        List<GrillMenuEntity> SortByDescendingLength(List<GrillMenuEntity> menuEntities);

    }
}
