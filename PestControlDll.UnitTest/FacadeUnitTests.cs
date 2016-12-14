using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PestControlDll.Entities;

namespace PestControlDll.UnitTest
{
    [TestClass()]
    public class FacadeUnitTests
    {
        [TestMethod()]
        public void AssertGetUserRepository()
        {
            var userRepository = new DALFacade().GetUserRepository();
            Assert.IsNotNull(userRepository);
            Assert.IsInstanceOfType(userRepository, typeof(IRepository<User>));
        }
        [TestMethod()]
        public void AssertGetRouteRepository()
        {
            var routeRepository = new DALFacade().GetRouteRepository();
            Assert.IsNotNull(routeRepository);
            Assert.IsInstanceOfType(routeRepository, typeof(IRepository<Route>));
        }
        [TestMethod()]
        public void AssertGetDestinationRepository()
        {
            var destinationRepository = new DALFacade().GetDestinationRepository();
            Assert.IsNotNull(destinationRepository);
            Assert.IsInstanceOfType(destinationRepository, typeof(IRepository<Destination>));
        }
        [TestMethod()]
        public void AssertGetWorksheetRepository()
        {
            var worksheetRepository = new DALFacade().GetWorksheetRepository();
            Assert.IsNotNull(worksheetRepository);
            Assert.IsInstanceOfType(worksheetRepository, typeof(IRepository<Worksheet>));
        }
        [TestMethod()]
        public void AssertGetPestTypeRepository()
        {
            var pestTypeRepository = new DALFacade().GetPestTypeRepository();
            Assert.IsNotNull(pestTypeRepository);
            Assert.IsInstanceOfType(pestTypeRepository, typeof(IRepository<PestType>));
        }
    }
}
