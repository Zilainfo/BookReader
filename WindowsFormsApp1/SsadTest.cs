// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
using System.Windows.Forms;

[TestFixture]
public class SsadTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp(string path)
    {
        ChromeOptions options = new ChromeOptions();
        options.AddUserProfilePreference("download.default_directory", path);
        options.AddUserProfilePreference("intl.accept_languages", "nl");
        options.AddUserProfilePreference("disable-popup-blocking", "true");
        options.AddArgument("start-maximized");
        options.AddExtensions(@"C:\Users\kstas\Desktop\folder\extension.crx");
          driver = new ChromeDriver(options);
     
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();

  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void GoToYandex() {
        
    driver.Navigate().GoToUrl("https://cloud.yandex.ru/services/speechkit");

       
    }

    public void Read(string text)
    {

     

        driver.FindElement(By.CssSelector(".SpeechKitDemo")).Click();
        driver.FindElement(By.Name("message")).Click();
        driver.FindElement(By.Name("message")).Clear();
        driver.FindElement(By.Name("message")).Click();
        Clipboard.SetText(text);
        driver.FindElement(By.Name("message")).SendKeys(OpenQA.Selenium.Keys.Control + "v");

        // js.ExecuteScript("document.getElementsByName(\"message\")[0].value =  `"+text+"`");

        //js.ExecuteScript("var preview = document.querySelectorAll(\"textarea[name='message']\"); for (var i = 0; i < preview.length;  i++){  preview[i].setAttribute('value', 'text');} ");
    
        driver.FindElement(By.CssSelector(".cc-form-layout__row:nth-child(1) .yc-select-control__tokens-text")).Click();
        driver.FindElement(By.CssSelector(".yc-select-control_focused .yc-select-control__tokens-text")).Click();
        driver.FindElement(By.CssSelector(".cc-form-layout__row:nth-child(3) .yc-select-control__tokens-text")).Click();
        driver.FindElement(By.CssSelector(".yc-select-item:nth-child(8) .yc-select-item__title")).Click();
        driver.FindElement(By.CssSelector(".cc-form-layout__row:nth-child(4) .yc-select-control__tokens-text")).Click();
        driver.FindElement(By.CssSelector(".popup2_visible_yes .yc-select-item:nth-child(3) .yc-select-item__title")).Click();
        driver.FindElement(By.XPath("//button[contains(.,\'Синтезировать речь\')]")).Click();

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(10);
        driver.FindElement(By.XPath("//div[@id=\'panel$3\']/div/div/div[2]/ul/li/div/div[2]/div/button[@aria-disabled=\'false\']")).Click();
       
        driver.FindElement(By.XPath("//div[@id=\'panel$3\']/div/div/div[2]/ul/li/div/div[2]/div/button[2]")).Click();
    }

    
}
