using System;
using System.Collections;
using NUnit.Framework;

namespace org.owasp.csrfguard.Tests
{
    /// <summary>
    /// Summary description for HtmlTagTest.
    /// </summary>
    [TestFixture]
    public class HtmlTagTest
    {

        // FUTURE TODO:  make sure we can deal with this javascript cruft without breaking it:  document.write ('<A HREF="' + OAS + 'click_nx.ads/'+ OASpage + '" TARGET="_top" ><IMG SRC="' + OAS + 'adstream_nx.ads/' + OASpage + '" BORDER="0" WIDTH="' + width + '" HEIGHT="' + height + '"></a>');

        [Test]
        public void simpleSelfClosingTagNoAttributes()
        {
            HtmlTag testTag = new HtmlTag("<br />");
            Assert.IsTrue(testTag.AttrCount == 0);
        }

        [Test]
        public void simpleTagNoAttributes()
        {
            HtmlTag testTag = new HtmlTag("<head>");
            Assert.AreEqual(0, testTag.AttrCount);
            Assert.AreEqual("<head>", testTag.TagString);
        }

        [Test]
        public void tagWithMultipleAttributesAndNiceSpacing()
        {
            const String orig = "<IMG src=\"http://a52.g.akamaitech.net/f/52/827/1d/www.space.com/template_images/common_topmenu08_968x28.gif\" border=\"0\" usemap=\"#common_topmenu\"/>";
            const String normalized = "<img src=\"http://a52.g.akamaitech.net/f/52/827/1d/www.space.com/template_images/common_topmenu08_968x28.gif\" border=\"0\" usemap=\"#common_topmenu\" />";
            HtmlTag testTag = new HtmlTag(orig);
            Assert.IsTrue(testTag.AttrCount == 3, "Tag count is incorrect.  Got {0}, expected {1}", testTag.AttrCount, 3);
            Assert.IsTrue("\"http://a52.g.akamaitech.net/f/52/827/1d/www.space.com/template_images/common_topmenu08_968x28.gif\"" == testTag.getAttributeValue("src"), "Attribute value mismatch");
            Assert.IsTrue("\"0\"" == testTag.getAttributeValue("border"), "Attribute value mismatch");
            Assert.IsTrue("\"#common_topmenu\"" == testTag.getAttributeValue("usemap"), "Attribute value mismatch");

            // ensure modified string is what we expect. In this case, one change.
            Assert.AreEqual(normalized, testTag.TagString, "Modified string {0} does not match expected {1}!", testTag.TagString, normalized);
        }

        [Test]
        public void tagWithSpacesInAttributeValue()
        {
            const String orig = "<META name=\"keywords\" content=\"wmap, cmb, hole, radio, universe, matter, dark matter, galaxies, huge hole\">";
            const String normalized = "<meta name=\"keywords\" content=\"wmap, cmb, hole, radio, universe, matter, dark matter, galaxies, huge hole\">";
            HtmlTag testTag = new HtmlTag(orig);
            Assert.IsTrue(testTag.AttrCount == 2, "Tag count is incorrect.  Got {0}, expected {1}", testTag.AttrCount, 2);
            Assert.IsTrue("\"keywords\"" == testTag.getAttributeValue("name"), "Attribute value mismatch");
            Assert.IsTrue("\"wmap, cmb, hole, radio, universe, matter, dark matter, galaxies, huge hole\"" == testTag.getAttributeValue("content"), "Attribute value mismatch");

            // ensure modified string is what we expect. In this case, one change.
            Assert.IsTrue(normalized == testTag.TagString, "Modified string does not match expected!");
        }

        [Test]
        public void tagWithLotsOfAbnormalSpacing()
        {
            const String orig = "<META    name     =  \"keywords\"     content  =     \"wmap, cmb, hole, radio, universe, matter, dark matter, galaxies, huge hole\">";
            const String normalized = "<meta name=\"keywords\" content=\"wmap, cmb, hole, radio, universe, matter, dark matter, galaxies, huge hole\">";
            HtmlTag testTag = new HtmlTag(orig);
            Assert.IsTrue(testTag.AttrCount == 2, "Tag count is incorrect.  Got {0}, expected {1}", testTag.AttrCount, 2);
            Assert.IsTrue("\"keywords\"" == testTag.getAttributeValue("name"), "Attribute value mismatch");
            Assert.IsTrue("\"wmap, cmb, hole, radio, universe, matter, dark matter, galaxies, huge hole\"" == testTag.getAttributeValue("content"), "Attribute value mismatch");

            // ensure modified string is what we expect. In this case, one change.
            Assert.IsTrue(normalized == testTag.TagString, "Modified string does not match expected!");
        }

        [Test]
        public void tagWithEqualsSignInValue()
        {
            const String orig = "<IMG src     =  \"keywords\"     content  =     \"1 + 1 = 2\">";
            const String normalized = "<img src=\"keywords\" content=\"1 + 1 = 2\">";
            HtmlTag testTag = new HtmlTag(orig);
            Assert.IsTrue(testTag.AttrCount == 2, "Tag count is incorrect.  Got {0}, expected {1}", testTag.AttrCount, 2);
            Assert.IsTrue("\"keywords\"" == testTag.getAttributeValue("src"), "Attribute value mismatch");
            Assert.IsTrue("\"1 + 1 = 2\"" == testTag.getAttributeValue("content"), "Attribute value mismatch");

            // ensure modified string is what we expect. In this case, one change.
            Assert.IsTrue(normalized == testTag.TagString, "Modified string does not match expected!");
        }
        [Test]
        public void updatingAttributeUpdatesTag()
        {
            const String orig = "<IMG src     =  \"keywords\"     content  =     \"1 + 1 = 2\">";
            const String updated = "<img src=\"keywords\" content=\"2 + 2 = 4\">";
            HtmlTag testTag = new HtmlTag(orig);
            Assert.IsTrue(testTag.AttrCount == 2, "Tag count is incorrect.  Got {0}, expected {1}", testTag.AttrCount, 2);
            Assert.IsTrue("\"1 + 1 = 2\"" == testTag.getAttributeValue("content"), "Attribute value mismatch");

            testTag.setAttributeValue("content", "\"2 + 2 = 4\"");
            Assert.IsTrue("\"2 + 2 = 4\"" == testTag.getAttributeValue("content"), "Attribute value mismatch");

            // ensure modified string is what we expect. In this case, one change.
            Assert.IsTrue(updated == testTag.TagString, "Modified string does not match expected!");
        }

        [Test]
        public void EmptyAttributeIsValid()
        {
            const String orig = "<IMG src=\"blah.gif\" alt=\"\" />";
            const String updated = "<img src=\"blah.gif\" alt=\"\" />";
            HtmlTag testTag = new HtmlTag(orig);
            Assert.AreEqual(2, testTag.AttrCount, "Tag count is incorrect.  Got {0}, expected {1}", testTag.AttrCount, 2);
            Assert.AreEqual("\"blah.gif\"", testTag.getAttributeValue("src"), "Attribute value mismatch");
            Assert.AreEqual("\"\"", testTag.getAttributeValue("alt"), "Attribute value mismatch");

            // ensure modified string is what we expect. In this case, one change.
            Assert.AreEqual(updated, testTag.TagString, "Modified string does not match expected!");
        }

        [Test]
        public void EntityGetsLeftAloneIsValid()
        {
            // tags starting with <! get left alone
            const String orig = "<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\" \"http://www.w3.org/TR/html4/loose.dtd\">";
            const String updated = orig;
            HtmlTag testTag = new HtmlTag(orig);
            Assert.IsTrue(testTag.AttrCount == 0, "Tag count is incorrect.  Got {0}, expected {1}", testTag.AttrCount, 0);

            // ensure modified string is what we expect. In this case, no change.
            Assert.AreEqual(updated, testTag.TagString, "Modified string does not match expected!");
        }
    }
}
