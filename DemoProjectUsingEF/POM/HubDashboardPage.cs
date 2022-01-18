using BluePrism.AutomatedUITests.POM;
using BluePrism.Web.AutomatedUITests.Helpers;
using BluePrism.Web.AutomatedUITests.Context;
using BoDi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using DemoProjectUsingEF.Configuration;

namespace DemoProjectUsingEF.POM
{
    class HubDashboardPage
    {
        readonly string HubUrl = ConfigurationLoader.Settings.HubApplicationUrl;
        private readonly string onPageTitle = "//main//h1";
        private readonly string logOut = "//a[@href='#/account/logout']";
        private readonly string LoadDashboardButton = $"//button[contains(., '{Resources.ResourceStrings["LOAD_DASHBOARD"]}')]";
        private readonly string CreateDashboard = $"//button[contains(., '{Resources.ResourceStrings["CREATE_DASHBOARD"]}')]";
        private readonly string AddWidgets = $"//button[contains(., '{Resources.ResourceStrings["ADD_WIDGETS"]}')]";
        private readonly string EditWidgetsButton = $"//button[contains(., '{Resources.ResourceStrings["EDIT_WIDGETS"]}')]";
        private readonly string EnableLabelsButton = $"//button[.='{Resources.ResourceStrings["ENABLE_LABELS"]}']";
        private readonly string DisableLabelsButton = $"//button[.='{Resources.ResourceStrings["DISABLE_LABELS"]}']";
        private readonly string WidgetAddedToaster = $"//div[contains(@class, 'toast--success')]//*[.='{Resources.ResourceStrings["WIDGET_HAS_BEEN_SUCCESSFULLY_ADDED"]}']";
        private string NonIncludedWidget(string widgetName) => $"//p[.='{Resources.ResourceStrings["NOT_INCLUDED"]}']/parent::div//h5[contains(.,'{widgetName}')]/ancestor::button";
        private string NonIncludedWidgetDescription(string widgetName) => $"//p[.='{Resources.ResourceStrings["NOT_INCLUDED"]}']/parent::div//h5[contains(.,'{widgetName}')]/ancestor::button//span";
        private string IncludedWidget(string widgetName) => $"//p[.='{Resources.ResourceStrings["INCLUDED"]}']/parent::div//h5[contains(.,'{widgetName}')]/ancestor::button";
        private string IncludedWidgetDescription(string widgetName) => $"//p[.='{Resources.ResourceStrings["INCLUDED"]}']/parent::div//h5[contains(.,'{widgetName}')]/ancestor::button//span";
        private string CloseDrawer = $"//div[@data-testid='add-widgets-drawer']//button[contains(., '{Resources.ResourceStrings["CLOSE_DRAWER"]}')]";
        private string WidgetOnDashboard(string widgetName) => $"//div[@class='widgets-block']//h5[.='{widgetName}']/ancestor::div[contains(@id, 'Widget')]";
        private string FilterWidget(string widgetName) => $"//div[@class='widgets-block']//h5[.='{widgetName}']/ancestor::div[contains(@id, 'Widget')]//button[contains(., '{Resources.ResourceStrings["FILTER"]}')]";
        private string RemoveWidgetButton(string widgetName) => $"//div[@class='widgets-block']//h5[.='{widgetName}']/ancestor::div[contains(@id, 'Widget')]//button[contains(., '{Resources.ResourceStrings["REMOVE"]}')]";
        private string WidgetNoDataText(string widgetName) => $"//div[@class='widgets-block']//h5[.='{widgetName}']/ancestor::div[contains(@id, 'Widget')]//p";
        private string WidgetDateInput(string widgetName) => $"//div[@class='widgets-block']//h5[.='{widgetName}']/ancestor::div[contains(@id, 'Widget')]//input[contains(@class, 'DateInput')]";
        private readonly string WidgetResourceLables = $".//*[local-name() = 'g' and @style = 'opacity: 1;']/*[@text-anchor='end']";
        private readonly string UsagesColor = $".//*[name() = 'g' and @style = 'cursor: pointer;']/*[name() = 'rect']";
        private readonly string UsagesValues = $".//*[name() = 'g' and @style = 'cursor: pointer;']";
        private string OptionButton(string widgetName) => $"//h5[.='{widgetName}']/following::button[div[.='{Resources.ResourceStrings["OPTIONS"]}']]";
        private string OptionRadio(string optionName) => $"//label[contains(.,'{optionName}')]";
        private readonly string DashboardNameInput = "//input[@id='nameWithoutCount']";
        private readonly string SaveDashboard = $"//div[@data-testid='create-dashboard-widgets-drawer']//button[.='{Resources.ResourceStrings["SAVE"]}']";
        private readonly string DashboardSaved = $"//div[contains(@class, 'toast--success')]//*[.='{Resources.ResourceStrings["NEW_DASHBOARD_WAS_SUCCESSFULLY_CREATED"]}']";
        private string DashboardInLoadDashboardDrawerByName(string dashboardName) => $"//h5[contains(text(), '{dashboardName}')]//ancestor::button";
        private readonly string SelectDigitalWorker = $"//p[.='{Resources.ResourceStrings["SELECT_DIGITAL_WORKERS_TO_SEE_GRAPHICS"]}']";
        public string AddedWidgetCount(string widgetName) => $"//h5[text()='{widgetName}']/ancestor::div[contains(@class,'included-widgets')]//span[contains(@class,'BadgeCount')]";
        public string AddWidgetsDrawer = $"//h5[text()='{Resources.ResourceStrings["ADD_WIDGETS"]}']/ancestor::div[contains(@class, 'Drawer')]";
        public string FilterSwitch(string filterName) => $"//span[text()='{filterName}']/preceding-sibling::div[contains(@class,'Switch')]";
        public string AddedFilters(string filterName) => $"//label[text()='{filterName}']/ancestor::div[contains(@class,'FieldContainer')]//li";
        public string FilterInput(string filterName) => $"//label[text()='{filterName}']/ancestor::div[contains(@class,'FieldContainer')]//input";
        private string QueueItemInListDropDown(string queueName) => $"//div[@data-testid='drawer-filter']/aside[contains(., '{queueName}')]";
        public readonly string ResetFiltersButton = "//button[@data-testid='reset-filter-button']";
        private string Next = $"//button[contains(.,'{Resources.ResourceStrings["NEXT"]}')]";
        private readonly string rowsPerPage = "//*[contains(.,'Rows per page')]/following::input";
        private string ComboboxList(string fieldName, string optionName) => $"//label[contains(text(),'{fieldName}')]/ancestor::div[contains(@class,'FormField__FieldContainer')]//span[text()='{optionName}' and @data-suggested-value]";
        private string ComboboxField(string fieldName) => $"//label[contains(text(),'{fieldName}')]/ancestor::div[contains(@class,'FormField__FieldContainer')]//input";
        public static string buttonOnAreYouSureModal(string buttonName) => $"//div[contains(@class, 'modal')]//div[@aria-hidden='false']//div//button[text()='{buttonName}']";
        public static string pageOnBreadcrumbs(string webpage) => $"//div/nav[@aria-label='breadcrumb']//li/a[text()='{webpage}']";
        private HubDashboardMap _hubDashboardMap;
        private HubContext _hubContext;
        private HubDashboardAssertions _hubDashboardAssertions;
        private WaitHelper _waitHelper;


        public HubDashboardPage(IObjectContainer objectContainer, HubContext hubContext, HubDashboardAssertions hubDashboardAssertions)
        {
            _hubDashboardMap = new HubDashboardMap(objectContainer);
            _hubContext = hubContext;
            _hubDashboardAssertions = hubDashboardAssertions;
            _waitHelper = new WaitHelper(objectContainer);
        }

        public HubDashboardPage VerifyThatItIsDashboardPage()
        {
            _hubDashboardAssertions.AreEqual("Dashboard", _hubDashboardMap.GetElement(onPageTitle).Text, "It is not Hub Dasboard page");
            return this;
        }
        public HubDashboardPage CreateDashboardClick()
        {
            _hubDashboardMap.ClickButton(CreateDashboard);
            return this;
        }

        public HubDashboardPage SendTextToNameInput(string dashboardName)
        {
            _hubDashboardMap.SendTextToInput(DashboardNameInput, dashboardName);
            return this;
        }

        public HubDashboardPage SaveDashboardClick()
        {
            _hubDashboardMap.ClickButton(SaveDashboard);
            return this;
        }

        public HubDashboardPage NavigateToDashboard()
        {
            _hubDashboardMap.Navigate($"{HubUrl}/#/dashboard");
            return this;
        }

        public HubDashboardPage LoadDashboardClick()
        {
            _hubDashboardMap.ClickButton(LoadDashboardButton);
            return this;
        }

        public HubDashboardPage ScrollToDashboardInDrawer(string dashboardName)
        {
            _hubDashboardMap.GetElement(DashboardInLoadDashboardDrawerByName(dashboardName));
            return this;
        }

        public bool DashboardIsDisplayed(string dashboardName)
        {
            return _hubDashboardMap.GetElement(DashboardInLoadDashboardDrawerByName(dashboardName)).Displayed;
        }

        public HubDashboardPage AddWidgetsClick()
        {
            _hubDashboardMap.ClickButton(AddWidgets);
            return this;
        }

        private HubDashboardPage AddWidgetFromIncludedList(string widgetName)
        {
            _hubDashboardMap.GetElement(IncludedWidget(widgetName)).Click();
            return this;
        }

        private HubDashboardPage AddWidgetFromNonIncludedList(string widgetName)
        {
            _hubDashboardMap.GetElement(NonIncludedWidget(widgetName)).Click();
            return this;
        }

        public HubDashboardPage AddWidget(string widgetName)
        {
            if (_hubDashboardMap.GetElementsWithoutWait(NonIncludedWidget(widgetName)).Count == 0)
                AddWidgetFromIncludedList(widgetName);
            else AddWidgetFromNonIncludedList(widgetName);

            WaitForWidgetToLoad();
            return this;
        }

        public HubDashboardPage WaitForWidgetToLoad()
        {
            _waitHelper.WaitForJavaScriptLoad();
            return this;
        }

        public HubDashboardPage LoadDashboard(string dashboadrName)
        {
            _hubDashboardMap.ClickButton(LoadDashboardButton);
            _hubDashboardMap.ClickButton(DashboardInLoadDashboardDrawerByName(dashboadrName));
            return this;
        }

        public HubDashboardPage CloseAddWidgetsDrawer()
        {
            try
            {
                _hubDashboardMap.ClickButton(CloseDrawer);
            }
            catch
            {
                _hubDashboardMap.ClickButton(AddWidgets);
            }
            return this;
        }

        public HubDashboardPage SetDateInFilter(string date, string widgetName)
        {
            _waitHelper.WaitForJavaScriptLoad();
            _hubDashboardMap.ClearInputAndSendText(WidgetDateInput(widgetName), date);
            WaitForWidgetToLoad().WaitForWidgetData();
            return this;
        }

        public HubDashboardPage WaitForWidgetData()
        {
            _hubDashboardMap.WaitForWidgetData(UsagesValues);
            return this;
        }

        public HubDashboardPage EditWidgets()
        {
            _hubDashboardMap.ClickButton(EditWidgetsButton);
            return this;
        }

        public HubDashboardPage OpenWidgetOptions(string widgetName)
        {
            _hubDashboardMap.ClickButton(OptionButton(widgetName));
            return this;
        }

        public HubDashboardPage SelectOption(string optionName)
        {
            WaitForWidgetToLoad();
            _hubDashboardMap.GetElement(OptionRadio(optionName)).Click();
            return this;
        }

        public HubDashboardPage VerifyWidgetUsage(Table expectedData)
        {
            var actualUsages = _hubDashboardMap.GetListOfTexts(UsagesValues);
            var expectedUsagesValues = expectedData.Rows[0]["Usage"].Split(',').ToList();

            for (var i = 0; i < expectedUsagesValues.Count; i++)
                _hubDashboardAssertions.AreEqual(expectedUsagesValues[i], actualUsages[i],
                    $"Actual usage for usage #{i} was {actualUsages[i]} instead of {expectedUsagesValues[i]}");
            return this;
        }

        public HubDashboardPage VerifyWidgetIsAddedToPage(string widgetName)
        {
            _hubDashboardAssertions.IsTrue(_hubDashboardMap.WidgetIsAddedToPage(WidgetOnDashboard(widgetName)),
                $"Wigdet {widgetName} was nor added to the page");
            return this;
        }

        public HubDashboardPage VerifyWidgetIsPresentInNotIncludedList(string widgetName)
        {
            _hubDashboardAssertions.IsTrue(_hubDashboardMap.WidgetIsPresentInList(NonIncludedWidget(widgetName)),
                $"Widget {widgetName} was not present in Not Included List");
            return this;
        }

        public HubDashboardPage VerifyWidgetIsPresentInIncludedList(string widgetName)
        {
            _hubDashboardAssertions.IsTrue(_hubDashboardMap.WidgetIsPresentInList(IncludedWidget(widgetName)),
                $"Widget {widgetName} was not present in Included List");
            return this;
        }

        public HubDashboardPage EnableLabels()
        {
            _hubDashboardMap.ClickButton(EnableLabelsButton);
            return this;
        }

        public HubDashboardPage VerifyDateInputValue(string expectedDate, string widgetName)
        {
            var actualDate = _hubDashboardMap.GetElement(WidgetDateInput(widgetName)).GetAttribute("value");
            _hubDashboardAssertions.AreEqual(expectedDate, actualDate,
                $"Wrong date for {widgetName} widget: was {actualDate} instead of {expectedDate}");
            return this;
        }

        public HubDashboardPage VerifyResourcesInUtilizationHeatmap(Table expectedData)
        {
            var actualResources = _hubDashboardMap.GetListOfTexts(WidgetResourceLables);
            _hubDashboardAssertions.AreEqual(expectedData.RowCount, actualResources.Count,
                $"The number of Resorces was {actualResources.Count} instead of expected {expectedData.RowCount}");
            for (var i = 0; i < expectedData.RowCount; i++)
                _hubDashboardAssertions.AreEqual(expectedData.Rows[i]["ResourceName"], actualResources[i],
                $"The Resource #{i} was {actualResources[i]} instead of {expectedData.Rows[i]["ResourceName"]}");
            return this;
        }

        public HubDashboardPage VerifyUsageUtilizationHeatmap(Table expectedData, string lablesStaus, string value)
        {
            var actualUsagesColorByResource = _hubDashboardMap.SplitUtilizationHeatmapUsagesByResource(_hubDashboardMap.GetElements(UsagesColor).Select(u => u.GetAttribute("fill")).ToList());
            var actualUsagesValueByResource = _hubDashboardMap.SplitUtilizationHeatmapUsagesByResource(_hubDashboardMap.GetElements(UsagesValues).Select(u => u.Text).ToList());

            for (int i = 0; i < expectedData.RowCount; i++)
            {
                var expectedUsages = expectedData.Rows[i]["Usages"].Split(';').Select(u => Convert.ToInt16(u)).ToList();

                for (int j = 0; j < expectedUsages.Count(); j++)
                {
                    var experctedUsage = value.Contains("percents") ? $"{Convert.ToByte((expectedUsages[j] / 60.0) * 100)}%" : expectedUsages[j].ToString();
                    if (lablesStaus.Contains("enabled"))
                    {
                        _hubDashboardAssertions.AreEqual(experctedUsage, actualUsagesValueByResource[i][j], $"Usage value is not correct for {expectedData.Rows[i]["ResourceName"]} in column {j + 1}");
                    }
                    else
                    {
                        _hubDashboardAssertions.IsEmpty(actualUsagesValueByResource[i][j], $"Usage value is not empty");
                    }
                    _hubDashboardAssertions.AreEqual(_hubDashboardMap.GetFillColorByUsage(expectedUsages[j]), actualUsagesColorByResource[i][j], $"'Usage color is not correct for {expectedData.Rows[i]["ResourceName"]} in column {j + 1}");
                }
            }
            return this;
        }

        public HubDashboardPage VerifyNumberOfResources(int numberOfRows)
        {
            WaitForWidgetData();
            var actualNumberOfResources = _hubDashboardMap.GetElements(WidgetResourceLables).ToList().Count;
            _hubDashboardAssertions.AreEqual(numberOfRows, actualNumberOfResources,
                $"Number of Resources displayed was {actualNumberOfResources} instead of {numberOfRows}");
            return this;
        }

        public HubDashboardPage DisableLabels()
        {
            _hubDashboardMap.ClickButton(DisableLabelsButton);
            return this;
        }

        public HubDashboardPage VerifyDefaultTextUtilizationChart()
        {
            _hubDashboardAssertions.IsTrue(_hubDashboardMap.GetElement(SelectDigitalWorker).Displayed,
                $"Default text for 'Utilization chart' widget is not displayed");
            return this;
        }

        public HubDashboardPage VerifyCountOfAddedWidgets(string widgetName, string expectedCount)
        {
            Assert.That(() => _hubDashboardMap.GetElement(AddedWidgetCount(widgetName)).Text,
              Is.EqualTo(expectedCount).After(2).Seconds.PollEvery(100), $"Count of '{widgetName}' widget is not correct");
            return this;
        }

        public HubDashboardPage RemoveWidget(string widgetName)
        {
            _hubDashboardMap.ClickButton(RemoveWidgetButton(widgetName));
            WaitForWidgetToLoad();
            return this;
        }

        public HubDashboardPage VerifyNumberOfWidgetsOnDashboard(string widgetName, string expectedCount)
        {
            _hubDashboardAssertions.AreEqual(expectedCount, _hubDashboardMap.GetElementsWithoutWait(WidgetOnDashboard(widgetName)).Count.ToString(),
                $"{widgetName}' is not on dashboard");
            return this;
        }

        public HubDashboardPage OpenFilterDrawer(string widgetName)
        {
            _hubDashboardMap.ClickButton(FilterWidget(widgetName));
            return this;
        }

        public HubDashboardPage SwitchFilter(string filterName)
        {
            _hubDashboardMap.GetElement(FilterSwitch(filterName)).Click();
            return this;
        }

        public HubDashboardPage VerifyFilterIsEmpty(string filterName)
        {
            _hubDashboardAssertions.IsTrue(_hubDashboardMap.GetElementsWithoutWait(AddedFilters(filterName)).Count == 0,
                $"Filter list is not empty");
            return this;
        }

        public HubDashboardPage SelectQueuesInFilter(List<string> queueNames, string filterName)
        {
            foreach (var queueName in queueNames)
            {
                _hubDashboardMap.ClickButton(FilterInput(filterName));
                WaitForWidgetToLoad();

                _hubDashboardMap.SelectQueueFromSuggested(QueueItemInListDropDown(queueName));
            }
            return this;
        }

        public HubDashboardPage ResetFilters()
        {
            _hubDashboardMap.ClickButton(ResetFiltersButton);
            return this;
        }

        public HubDashboardPage VerifyWorkQueueCompositionDefaultText()
        {
            WaitForWidgetToLoad();
            _hubDashboardAssertions.AreEqual(Resources.ResourceStrings["SELECT_QUEUE_TO_SEE_GRAPHICS"],
                _hubDashboardMap.GetText(WidgetNoDataText(Resources.ResourceStrings["WORK_QUEUE_COMPOSITIONS_CONTROL_ROOM"])),
                $"Incorrect default text for 'Work queue compositions' widget");
            return this;
        }

        public void NavigateToNextPageInUtilizationHeatmapChart()
        {
            _hubDashboardMap.GetElement(Next).Click();
        }

        public HubDashboardPage SetRowsPerPage(string rowsNumber)
        {
            _hubDashboardMap.ClearInputAndSendText(rowsPerPage, rowsNumber);
            return this;
        }

        public HubDashboardPage ClickOnBreadcrumbsNavigation(string webPage)
        {
            _hubDashboardMap.ClickButton(pageOnBreadcrumbs(webPage));
            return this;
        }

        public HubDashboardPage ClickOnButtonOnAreYouSureModal(string buttonName)
        {
            _hubDashboardMap.ClickButton(buttonOnAreYouSureModal(buttonName), true);
            return this;
        }

        public HubDashboardPage SelectValueInComboboxList(string fieldName, string envName)
        {
            _hubDashboardMap.ChooseElementInComboBoxList(ComboboxList(fieldName, envName), envName);
            return this;
        }

        public HubDashboardPage ClickOnComboboxList(string fieldName)
        {
            _hubDashboardMap.ClickButton(ComboboxField(fieldName));
            return this;
        }

        public HubDashboardPage GetHubPageTitle()
        {
            _hubContext.StoreTextValue(_hubDashboardMap.GetText(onPageTitle), "DashboardTitle");
            return this;

        }

        public HubDashboardPage ClickLogOutButton()
        {
            _hubDashboardMap.ClickButton(logOut);
            return this;
        }
    }
}
