using System;
using System.Collections;
using NUnit.Framework;

namespace org.owasp.csrfguard.Tests
{
	/// <summary>
	/// Summary description for UtilityTest.
	/// </summary>
	[TestFixture]
	public class UtilityTest
	{

		[Test]
        public void urlIsSameOriginAsServerRelativeURLSlash()
		{
            String testUrl = "/some/path/index.html";
            Assert.IsTrue(Util.urlIsSameOriginAsServer(testUrl), "Url {0} should be relative but the code said otherwise");
		}

		[Test]
        public void urlIsSameOriginAsServerFullUrl()
		{
            String testUrl = "https://localhost/some/path/index.html";
            Assert.IsTrue(Util.urlIsSameOriginAsServer(testUrl), "Url {0} should be local but the code said otherwise");		
		}


		[Test]
		public void GetOlbExReturnsInner1()
		{
			
		}

		[Test]
		public void GetOlbExReturnsNewOlb()
		{
			
		}

		[Test]
		public void GetOlbExReturnsNewOlb1()
		{
			
		}
	}
}
