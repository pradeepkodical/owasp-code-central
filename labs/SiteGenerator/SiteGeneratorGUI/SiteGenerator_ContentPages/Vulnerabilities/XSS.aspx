<%@ Page  ValidateRequest="false"  %>
<h1> Xss Example</h1>
<hr>
Querystring XSS = <%= request.QueryString("xss") %>
</hr>