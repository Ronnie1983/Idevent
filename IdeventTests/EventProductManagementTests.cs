using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using IdeventAdminBlazorServer.Pages;
using Microsoft.AspNetCore.Components;
using IdeventAdminBlazorServer.Pages.Admin.Events;

namespace IdeventTests
{
    /// <summary>
    /// Tests if you can load all pages by checking the h1 tag of each page after navigating to it.
    /// </summary>
    [TestClass]
    public class EventProductManagementTests : TestBase
    {
        private Bunit.TestContext _testContext;
        private NavigationManager _navManager;

        [TestInitialize]
        public void Inititialise()
        {
            _testContext = new Bunit.TestContext();
            _navManager = _testContext.Services.GetService<NavigationManager>();
        }
        [TestCleanup]
        public void Cleanup()
        {
            _testContext.Dispose();
        }

        [TestMethod]
        public void EventProductManagement_ToggleAddStand()
        {
            IRenderedComponent<EventProductManagement> page = _testContext.RenderComponent<EventProductManagement>();
            
        }
    }
}
