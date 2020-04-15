using System;
using System.Collections.Generic;
using System.Text;

namespace GrillMaster.Domain
{
    public class GetMenuInteractor : IRequestHandler<GrillMenuEntity>
    {
        private readonly IRepository _repository;
        public GetMenuInteractor(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        /// <summary>
        /// Use case method to handle all operations
        /// </summary>
        /// <returns></returns>
        public List<GrillMenuEntity> Handle()
        {
            return _repository.GetGrillMenu();
        }


    }
}
