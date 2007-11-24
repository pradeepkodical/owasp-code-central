<script language="JavaScript">

	var tokenName = '<%NAME%>';
	var tokenValue = '<%VALUE%>';

	function updateAnchors()
	{
		updateTag('a','href');
	}
	
	function updateLinks()
	{
		updateTag('link', 'href');
	}
	
	function updateAreas()
	{
		updateTag('area', 'href');
	}
	
	function updateFrames()
	{
		updateTag('frame', 'src');
	}
	
	function updateIFrames()
	{
		updateTag('iframe', 'src');
	}
	
	function updateStyles()
	{
		updateTag('style', 'src');
	}
	
	function updateScripts()
	{
		updateTag('script', 'src');
	}
	
	function updateImages()
	{
		updateTag('img', 'src');
	}
	
	function updateForms()
	{
		var forms = document.getElementsByTagName('form');
		
		for(i=0; i<forms.length; i++)
		{
			var html = forms[i].innerHTML;
			
			html += '<input type=hidden name=' + tokenName + ' value=' + tokenValue + ' />';
			
			//alert('new html: ' + html);
			
			forms[i].innerHTML = html;
		}
	}
	
	function updateTag(name,attr)
	{
		var links = document.getElementsByTagName(name);
		
		//alert('length: ' + links.length);
		
		for(i=0; i<links.length; i++)
		{
			var src = links[i].getAttribute(attr);
			
			if(src != null && src != '')
			{
				//alert('found ' + src + '!');
			
				if(isHttpLink(src))
				{
					var index = src.indexOf('?');
				
					if(index != -1)
					{
						src = src + '&' + tokenName + '=' + tokenValue;
					}
					else
					{
						src = src + '?' + tokenName + '=' + tokenValue;
					}
					
					//alert('new src ' + src);
					
					links[i].setAttribute(attr, src);
				}
			}
		}
	}
	
	function isHttpLink(src)
	{
		var result = 0;
		
		if(src.substring(0, 4) == 'http' || src.substring(0, 1) == '/' || src.indexOf(':') == -1)
		{
			result = 1;
		}
		
		return result;
	}
	
	updateAnchors();
	updateLinks();
	updateAreas();
	updateFrames();
	updateIFrames();
	updateStyles();
	updateScripts();
	updateImages();
	updateForms();
</script>
