using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject_Test.Page
{
    public class LoginPage
    {
        private IPage _page;
        public LoginPage(IPage page) => _page = page;

        private ILocator _linklogin => _page.Locator(selector: "text=Login");
        private ILocator _textUserName => _page.Locator(selector: "#UserName");
        private ILocator _textPassword => _page.Locator(selector: "#Password");
        private ILocator _btnLogin => _page.Locator(selector: "text=Log in");
        private ILocator _linkEmployeeDetails => _page.Locator(selector: "text=Employee Details");
        private ILocator _linkEmployeeLists => _page.Locator(selector: "text=Employee List");

        public async Task ClickLogin()
        {
            await _page.RunAndWaitForNavigationAsync(async () =>
            {
                await _linklogin.ClickAsync();
            }, new PageRunAndWaitForNavigationOptions
            {
                UrlString = "**/Login"
            });
           
        }
        public async Task ClickEmployeeList() => await _linkEmployeeLists.ClickAsync();
        public async Task Login(string userName, string passWord)
        {
            await _textUserName.FillAsync(userName);
            await _textPassword.FillAsync(passWord);
            await _btnLogin.ClickAsync();
        }



        public async Task<bool> IsEmployeeDetailsExist() => await _linkEmployeeDetails.IsVisibleAsync();
      
    }
}
