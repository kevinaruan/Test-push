using SpecFlowProject_Test.Drivers;
using SpecFlowProject_Test.Page;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowProject_Test.StepDefinitions
{
    [Binding]
    public class EaAppStepDefinitions
    {
        private readonly Driver _driver;
        private readonly LoginPage _loginpage;
        public EaAppStepDefinitions(Driver driver)
        {
            _driver = driver;
            _loginpage = new LoginPage(_driver.Page);
        }


        [Given(@"I navigate to application")]
        public void GivenINavigateToApplication()
        {
            _driver.Page.GotoAsync("http://www.eaapp.somee.com");
        }

        [Given(@"I click login link")]
        public async Task GivenIClickLoginLink()
        {
          await _loginpage.ClickLogin();
        }

        [Given(@"I enter following login details")]
        public async Task GivenIEnterFollowingLoginDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            await _loginpage.Login((string)data.UserName, (string)data.Password);
        }

        [Then(@"I see Employee Lists")]
        public async Task ThenISeeEmployeeLists()
        {
            var isExist = await _loginpage.IsEmployeeDetailsExist();
            isExist.Should().Be(true);
        }
    }
}
