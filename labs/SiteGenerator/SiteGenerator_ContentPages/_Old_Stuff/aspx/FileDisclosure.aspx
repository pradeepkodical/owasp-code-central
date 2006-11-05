<%@ Page  ValidateRequest="false"  %>
<h1>File Disclosure</h1>
<hr>
Querystring XSS = <%= request.QueryString("xss") %>
</hr>