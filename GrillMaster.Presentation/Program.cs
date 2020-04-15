using System;
using Ninject;
using GrillMaster.Domain;
using System.Linq;

namespace GrillMaster.Presentation
{
    internal class Program
    {
        /// <summary>
        /// Loading modules into ninject kernel container
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new GrillModule());
            var useCase = kernel.Get<GetMenuInteractor>();
            var output = useCase.Handle();
            //foreach (var menu in output)
            //{
            //    Console.WriteLine($"{menu.menu} : {menu.BarbequeRounds} rounds");
            //}

            //Console.WriteLine($"Total Barbeque Rounds : { output.Select(x => x.TotalBarbequeRounds).FirstOrDefault()} ");
            Console.ReadLine();
        }

    }
}
