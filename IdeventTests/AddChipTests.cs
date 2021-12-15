using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdeventAdminBlazorServer.Pages.Admin.Chips;
using Bunit;
using AngleSharp.Dom;
using Microsoft.Extensions.DependencyInjection;
using IdeventLibrary.Repositories;
using IdeventAdminBlazorServer.Shared;
using IdeventLibrary.Models;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;

namespace IdeventTests
{
    [TestClass]
    public class AddChipTests : TestBase
    {
        [TestInitialize]
        public void Setup()
        {
            _testContext.JSInterop.SetupVoid("BlazorFocusElement", _ => true);
            _testContext.Services.AddSingleton<CompanyRepository>(new CompanyRepository());
            _testContext.Services.AddSingleton<ChipRepository>(new ChipRepository());
            _testContext.Services.AddSingleton<EventRepository>(new EventRepository());
            _testContext.Services.AddSingleton<ChipGroupRepository>(new ChipGroupRepository());
            _testContext.Services.AddSingleton<StandProductRepository>(new StandProductRepository());
            _testContext.Services.AddSingleton<ChipContentRepository>(new ChipContentRepository());
        }
        [TestCleanup]
        public void Teardown()
        {

        }
        //[TestMethod]
        //public void SelectCompanyAndShowEventSelection()
        //{
        //    // Arrange
        //    IRenderedComponent<AddChip> page = _testContext.RenderComponent<AddChip>();
        //    // Give a parameter to the SelectCompany child component on AddChip.
        //    IRenderedComponent<SelectCompany> selectCompanyComponent = page.FindComponent<SelectCompany>();
        //    Helpers.SetListParameterForChildComponent<CompanyModel>(selectCompanyComponent, "Companies");

        //    // Act
        //    IElement companySelect = page.Find("#companySelect");
        //    companySelect.Change(1);
        //    // Arrange
        //    // Give a parameter to the SelectEvent child component on AddChip.
        //    IRenderedComponent<SelectEvent> selectEventComponent = page.FindComponent<SelectEvent>();
        //    Helpers.SetListParameterForChildComponent<EventModel>(selectEventComponent, "Events");

        //    // Act
        //    IElement eventSelect = page.Find("#eventSelect");
        //    string eventSelectMarkup = eventSelect.ToMarkup();

        //    // Assert
        //    page.Markup.Contains(eventSelectMarkup);
        //}
    }
}
