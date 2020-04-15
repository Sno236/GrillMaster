using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Ninject.Modules;
using GrillMaster.Domain;
using GrillMaster.Data;
using AutoMapper;

namespace GrillMaster.Presentation
{
   public  class GrillModule : NinjectModule
    {
        /// <summary>
        /// override the load method to allow dependency injection using ninject
        /// </summary>
        public override void Load()
        {
            var apiUrl = ConfigurationManager.AppSettings["API_URL"];            
            Bind<IMapper<GrillMenuData, GrillMenuEntity>>().To<GrillDataEntityMapper>();  //bind entities
            Bind<IApi>().To<ConnectGrillMenuApi>().WithConstructorArgument("apiUrl", apiUrl); //bind api
            Bind<IRepository>().To<GrillMenuRepository>(); //bind repository
            Bind<GetMenuInteractor>().ToSelf().InSingletonScope(); //bind use case handler
        }
    }
}
