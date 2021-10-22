using AutomationPractice.Resource;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.POM
{
    public abstract class BasePageModel
    {
        protected SeleniumExtension SeleniumExtensionObject { get; set; }

        public BasePageModel(SeleniumExtension seleniumExtensionObject) => SeleniumExtensionObject = seleniumExtensionObject;

        public abstract bool IsPageLoaded();
    }
}
