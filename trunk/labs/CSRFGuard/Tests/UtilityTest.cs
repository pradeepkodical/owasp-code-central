using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace Org.Owasp.CsrfGuard.Tests
{
    /// <summary>
    /// Summary description for UtilityTest.
    /// </summary>
    [TestFixture]
    public class UtilityTest
    {
        [Test]
        public void LocalResourceURLIsSameOriginIsValid()
        {
            String testUrl = "/some/path/index.html";
            Assert.IsTrue(Util.IsUrlSameOriginAsServer(testUrl),
                          "Url {0} should be relative but the code said otherwise", testUrl);
        }

        [Test]
        public void FullLocalURLIsSameOriginIsValid()
        {
            String testUrl = "https://localhost/some/path/index.html";
            Assert.IsTrue(Util.IsUrlSameOriginAsServer(testUrl), "Url {0} should be local but the code said otherwise",
                          testUrl);
        }


        [Test]
        public void JavascriptUrlIsNotSameOriginIsValid()
        {
            String testUrl = "javascript:__doPostBack(thisshouldnotgetatoken)";
            Assert.IsFalse(Util.IsUrlSameOriginAsServer(testUrl),
                           "Url {0} should NOT be local but the code said otherwise", testUrl);

            Regex skipJavascriptRegex = new Regex("^javascript:", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Assert.IsTrue(skipJavascriptRegex.IsMatch(testUrl));

            Regex extensionWhitelistRegex =
                new Regex(App.Configuration.ExtensionWhitelistPattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            Assert.IsFalse(extensionWhitelistRegex.IsMatch(testUrl));

            Assert.IsFalse(Util.IsUrlSameOriginAsServer(testUrl)
                           && !skipJavascriptRegex.IsMatch(testUrl)
                           && !extensionWhitelistRegex.IsMatch(testUrl));
        }
    }
}