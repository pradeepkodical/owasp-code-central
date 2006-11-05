<%@ Page  ValidateRequest="false"  %>
<h1> Xss Example</h1>
<hr>
Session Test= <%= HttpContext.Current.Session("LoggedIn") %>
</hr>
Session Test= <% HttpContext.Current.Session("LoggedIn") = Request.QueryString("LoggedIn")%>
<hr>
Session Test= <%= HttpContext.Current.Session("Test") %>
<hr>
<% if (HttpContext.Current.Session("LoggedIn")="true") %>
<a href="/Livedemo/LoggedInInfo.aspx?user_id=1" />SQL Injection</a><br/>
<% end if %>

