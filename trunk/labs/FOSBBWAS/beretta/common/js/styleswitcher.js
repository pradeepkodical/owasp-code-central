// JavaScript Document
// This is the styleswitcher script, for switching between
// alternative stylesheets.
//
// by Paul Sowden <mailto:paul@idontsmoke.co.uk>
// ala article: <http://alistapart.com/stories/alternate/>
// site: <http://idontsmoke.co.uk/2002/ss/>

function setActiveStyleSheet(title) {
	var a;
	for (var i = 0; (a = document.getElementsByTagName("link")[i]); i++) {
		if (a.getAttribute("rel") && a.getAttribute("rel").indexOf("style") != -1 && a.getAttribute("title")) {
			a.disabled = true;
			if (a.getAttribute("title") == title) a.disabled = false;
		}
	}
	if (getActiveStyleSheet() == null) {
		title = getPreferredStyleSheet();
		if (title != null) setActiveStyleSheet(title, true);
	}
	createCookie("style",title, 365);
}

function getActiveStyleSheet() {
	var a;
	for (var i = 0; (a = document.getElementsByTagName("link")[i]); i++) {
		if (a.getAttribute("rel") && a.getAttribute("rel").indexOf("style") != -1 && a.getAttribute("title") && !a.disabled) return a.getAttribute("title");
	}
	return null;
}

function getPreferredStyleSheet() {
	var a;
	for (var i = 0; (a = document.getElementsByTagName("link")[i]); i++) {
		if (a.getAttribute("rel") && a.getAttribute("rel").indexOf("style") != -1 && a.getAttribute("rel").indexOf("alt") == -1 && a.getAttribute("title")) return a.getAttribute("title");
	}
	return null;
}

function createCookie(name,value,days) {
	if (days) {
		var date = new Date();
		date.setTime(date.getTime()+(days*24*60*60*1000));
		var expires = "; expires="+date.toGMTString();
	} else var expires = "";
	document.cookie = name+"="+value+expires+"; path=/";
}

function readCookie(name) {
	var nameEQ = name + "=";
	var ca = document.cookie.split(';');
	for(var i=0;i < ca.length;i++) {
		var c = ca[i];
		while (c.charAt(0)==' ') c = c.substring(1,c.length);
		if (c.indexOf(nameEQ) == 0) return c.substring(nameEQ.length,c.length);
	}
	return null;
}

function start(e) {
	var cookie = readCookie("style");
	var title = cookie ? cookie : getPreferredStyleSheet();
	setActiveStyleSheet(title);
}

function end(e) {
	var title = getActiveStyleSheet();
	createCookie("style", title, 365);
}

if (window.addEventListener) {
	window.addEventListener("load", start, true);
	window.addEventListener("unload", end, true);
} else if (window.attachEvent) {
	window.attachEvent("onload", start);
	window.attachEvent("onunload", end);
}

if (document.getElementsByTagName) {
	var cookie = readCookie("style");
	var title = cookie ? cookie : getPreferredStyleSheet();
	setActiveStyleSheet(title);
}