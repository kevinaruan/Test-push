using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject_Test.Drivers
{
    public class Driver : IDisposable
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = Initializeplaywright();
        }

        public IPage Page => _page.Result;

        public void Dispose()
        {
            _browser?.CloseAsync();
        }

        public async Task<IPage> Initializeplaywright()
        {
            //Playwright
            var playwright = await Playwright.CreateAsync();
            //Browser
           _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
                //Channel = "chrome"
            });
            //Page
            return await _browser.NewPageAsync();
        }
    }
}
