using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bunit;
using IdeventAdminBlazorServer.Pages;
using Microsoft.AspNetCore.Components;

namespace IdeventTests
{

    [TestClass]
    public class NavigationTests
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
        public void DashboardIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Dashboard.Index>(), "Dashboard", "Home");
        }
        [TestMethod]
        public void ProfileIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Profile.Index>(), "Profile");
        }
        [TestMethod]
        public void ChipsIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Chips.Index>(), "Chips");
        }
        [TestMethod]
        public void CompaniesIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Companies.Index>(), "Companies");
        }
        [TestMethod]
        public void EventsIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Events.Index>(), "Events");
        }
        [TestMethod]
        public void OperatorSiteIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.OperatorSite.Index>(), "Operator's Site", "OperatorSite");
        }
        [TestMethod]
        public void ChipActivityLogIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.ChipActivityLog.Index>(), "Chip Activity Log", "ChipActivityLog");
        }
        [TestMethod]
        public void UsersIndex_Loads()
        {
            LoadPageTest(_testContext.RenderComponent<IdeventAdminBlazorServer.Pages.Admin.Users.Index>(), "Users");
        }


        /// <summary>
        /// Tests if a specified page loads with an expected title.
        /// </summary>
        /// <param name="pageComponent">The page component to test.</param>
        /// <param name="pageTitle">The expected content of the page's h1 tag.</param>
        /// <param name="navigationTitle">(optional) If the url is different from "baseuri/pageTitle" you can replace pageTitle with navigationTitle.</param>
        private void LoadPageTest(IRenderedComponent<IComponent> pageComponent, string pageTitle, string navigationTitle = "")
        {
            // Arrange
            var page = pageComponent;
            string url;
            if (string.IsNullOrEmpty(navigationTitle))
            {
                url = $"{_navManager.BaseUri}{pageTitle}";
            }
            else
            {
                url = $"{_navManager.BaseUri}{navigationTitle}";
            }
            string expectedH1Tag = $"<h1>{pageTitle}</h1>";

            // Act
            _navManager.NavigateTo(url);

            bool containsExpected = page.Markup.Contains(expectedH1Tag);

            // Assert
            Assert.IsTrue(containsExpected);
        }

    }
}
