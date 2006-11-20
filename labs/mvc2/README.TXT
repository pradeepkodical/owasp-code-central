Author:      Paul Boal
Email:       paul@lesterboal.net
Date:        Nov. 2002
Description:

This code is an example of the Dynamic MVC Framework I described in the associated ASPToday arcticle, "A More Dynamic MVC through ASP.NET and XSLT."  The example code uses ASP.NET, XSLT, and the type reflection available in the MS .NET framework to implement an MVC Framework for web applications.


Using the code requires knowledge of setting up ASP.NET web applications and is easiest with the Visual Studio.NET IDE.  In order to use this code on a local installation of the Internet Information Server, you should uncompress the ZIP file to a new directory (e.g. mvc2), then use the Internet Information Services application to create a new Virtual Directory that allows Script Execution.  The application would then be available locally through a URL something like: http://localhost/mvc2/.