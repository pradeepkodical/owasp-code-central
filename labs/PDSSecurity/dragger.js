var writer;
var Membership = new Array();
var Selected = new Array();
var Items = new Array();
var ItemsID = new Array();
var MouseX;
var MouseY;
var Clicked;
var Dragging;
var DragStart;
var Modified;

writer	=  '<STYLE>'
	+  ''
	+  '  DIV.listarea {'
	+  '    background-color: ' + BackColour + ';'
	+  '    border-top: ' + ShadeColour + ' 2px solid;'
	+  '    border-left: ' + ShadeColour + ' 2px solid;'
	+  '    border-bottom:  ' + LightColour + ' 2px solid;'
	+  '    border-right:  ' + LightColour + ' 2px solid;'
	+  '    overflow: auto;'
	+  '  }'
	+  ''
	+  '  DIV.listbutton {'
	+  '    font-family: arial, sans-serif;'
	+  '    font-size: 10pt;'
	+  '    background-color: ' + BackColour + ';'
	+  '    border-top: ' + LightColour + ' 2px solid;'
	+  '    border-left: ' + LightColour + ' 2px solid;'
	+  '    border-bottom:  ' + ShadeColour + ' 2px solid;'
	+  '    border-right:  ' + ShadeColour + ' 2px solid;'
	+  '    overflow: auto;'
	+  '    cursor: default;'
	+  '  }'
	+  ''
	+  '  TD.listbutton {'
	+  '    font-family: arial, sans-serif;'
	+  '    font-size: 10pt;'
	+  '  }'
	+  ''
	+  '  DIV.dragicon {'
	+  '    border:  #555555 2px solid;'
	+  '    cursor: default;'
	+  '  }'
	+  ''
	+  '  DIV.listitem {'
	+  '    font-family: arial, sans-serif;'
	+  '    font-size: 10pt;'
	+  '    background-color: ' + BackColour + ';'
	+  '    padding-left: 6px;'
	+  '    padding-top: 2px;'
	+  '    padding-bottom: 2px;'
	+  '    color: ' + TextColour + ';'
	+  '    cursor: default;'
	+  '    width: 100%;'
	+  '  }'
	+  '</STYLE>';

document.writeln(writer);

document.onmousedown = MouseDown;
document.onmousemove = MouseMove;
document.onmouseup   = MouseUp;

function MouseDown(event) {
  var className = window.event.srcElement.className;
  if (className == "listitem") {
    MouseX = window.event.clientX;
    MouseY = window.event.clientY;
    Clicked = 1;
  }
}

function MouseMove(event) {
  if (Clicked && !Dragging) {
    if ((Math.abs(window.event.clientY - MouseY) > 10 || Math.abs(window.event.clientX - MouseX) > 10)) {
      Dragging = 1;
      getLayer("dragicon").style.visibility = "visible";
      if (window.event.clientX >= DestLeft && window.event.clientX <= DestLeft + ListWidth && window.event.clientY >= DestTop && window.event.clientY <= DestTop + ListHeight)
        DragStart = 1;
      if (window.event.clientX >= SourceLeft && window.event.clientX <= SourceLeft + ListWidth && window.event.clientY >= SourceTop && window.event.clientY <= SourceTop + ListHeight)
        DragStart = 0;
    }
  }
  if (Dragging) {
    getLayer("dragicon").style.left = (window.event.clientX - 10) + "px";
    getLayer("dragicon").style.top = (window.event.clientY - 10) + "px";
  }
}

function MouseUp(event) {
  if (Dragging) {
    Dragging = 0;
    getLayer("dragicon").style.visibility = "hidden";
    if (window.event.clientX >= DestLeft && window.event.clientX <= DestLeft + ListWidth && window.event.clientY >= DestTop && window.event.clientY <= DestTop + ListHeight && DragStart == 0)
      ToDest();
    if (window.event.clientX >= SourceLeft && window.event.clientX <= SourceLeft + ListWidth && window.event.clientY >= SourceTop && window.event.clientY <= SourceTop + ListHeight && DragStart == 1)
      ToSrc();
  }
  Clicked = 0;
}

function getLayer(name) {
  return document.getElementById(name);
}

function ChangeSelect(index) {
  if (Selected[index])
    Selected[index] = 0;
  else 
    Selected[index] = 1;
}

function Over(menu, index) {
  getLayer(menu + "item" + index).style.backgroundColor = SelectColour;
  getLayer(menu + "item" + index).style.color = TextOverColour;
}

function Out(menu, index) {
  if (Selected[index])
    getLayer(menu + "item" + index).style.backgroundColor = OverColour;
  else
    getLayer(menu + "item" + index).style.backgroundColor = BackColour;
  getLayer(menu + "item" + index).style.color = TextColour;
}

function Reshuffle() {
  var i;
  var dheight = 0;
  var sheight = 0;

  for (i = 0; i < Items.length; i++) {
    if (Membership[i] == 0) {
      getLayer("1item" + i).style.visibility = "visible";
      getLayer("2item" + i).style.visibility = "hidden";
      getLayer("1item" + i).style.top = sheight + "px";
      getLayer("2item" + i).style.top = "0px";
      getLayer("1item" + i).style.backgroundColor = BackColour;
      getLayer("1item" + i).style.color = TextColour;
      sheight += 20;
    }
    if (Membership[i] == 1) {
      getLayer("2item" + i).style.visibility = "visible";
      getLayer("1item" + i).style.visibility = "hidden";
      getLayer("2item" + i).style.top = dheight + "px";
      getLayer("1item" + i).style.top = "0px";
      getLayer("2item" + i).style.backgroundColor = BackColour;
      getLayer("2item" + i).style.color = TextColour;
      dheight += 20;
    }
  }
  getLayer("source2").style.width = getLayer("source").clientWidth + "px";
  getLayer("dest2").style.width = getLayer("dest").clientWidth + "px";

  if (!Modified) {
    document.getElementById("updatebutton").innerHTML = '<table width=' + (SubmitCaption.length * 10 - 4) + '><tr><td class="listbutton" align=center>' + SubmitCaption + '</tr></td></table>';
    Modified = 1;
  }
}

function ToDest() {
  for (i = 0; i < Items.length; i++) {
    if (Membership[i] == 0 && Selected[i]) {
      Membership[i] = 1;
      Selected[i] = 0;
    }
  }
  Reshuffle();
}

function AllToDest() {
  for (i = 0; i < Items.length; i++) {
    if (Membership[i] == 0) {
      Membership[i] = 1;
      Selected[i] = 0;
    }
  }
  Reshuffle();
}

function ToSrc() {
  for (i = 0; i < Items.length; i++) {
    if (Membership[i] == 1 && Selected[i]) {
      Membership[i] = 0;
      Selected[i] = 0;
    }
  }
  Reshuffle();
}

function AllToSrc() {
  for (i = 0; i < Items.length; i++) {
    if (Membership[i] == 1) {
      Membership[i] = 0;
      Selected[i] = 0;
    }
  }
  Reshuffle();
}

function ReturnID() {
  var InIDs = "";
  
  for (i = 0; i < Items.length; i++) {
    if (Membership[i] == 1)
      InIDs += "," + ItemsID[i];
  }

  SubmitField.value = InIDs;
  SubmitForm.submit();
  window.alert(SubmitMessage);
}

function Lists(sid, s, sact, did, d, dact) {
  var i;
  modified = 0;

  writer	=  '<div class="listarea" id="source" style="position: absolute; left: ' + SourceLeft + 'px; top: ' + (SourceTop + 26) + 'px; width: ' + ListWidth + '; height: ' + ListHeight + '; visibility: show;">'
  		+  '<div class="listarea2" id="source2" style="position: absolute; left: 0px; top: 0px; width: ' + ListWidth + 'px; visibility: show;">';
  
  for (i = 0; i < s.length; i++) {
    Items[i] = s[i];
    ItemsID[i] = sid[i];
    Membership[i] = 0;
    Selected[i] = 0;
    if (sact.length) {
      if (sact[i] == 1)
        mage = '<img src="' + Icon + '" align=top border=1 alt="Currently Active">';
      else
        mage = '<img src="' + DeactiveIcon + '" align=top border=1 alt="Currently Not Active">';
    }
    else
      mage = '<img src="' + Icon + '" align=top border=1>';
    
    writer	+= '<div onclick="ChangeSelect(' + i + ')" onmouseover="Over(1, ' + i + ')" onmouseout="Out(1, ' + i + ')" class="listitem" id="1item' + i + '" style="position: absolute; left: 0px; top: ' + (i * 20) + 'px; height: 20; visibility: visible;">'
		+     mage + '<img src="white.gif" width=5 height=1>'
		+     Items[i]
		+  '</div>';
  }

  for (i = s.length; i < (d.length + s.length); i++) {
    Items[i] = d[i - s.length];
    ItemsID[i] = did[i - s.length];
    Membership[i] = 1;
    Selected[i] = 0;
    if (dact.length) {
      if (dact[i - s.length] == 1)
        mage = '<img src="' + Icon + '" align=top border=1 alt="Currently Active">';
      else
        mage = '<img src="' + DeactiveIcon + '" align=top border=1 alt="Currently Not Active">';
    }
    else
      mage = '<img src="' + Icon + '" align=top border=1>';

    writer	+= '<div onclick="ChangeSelect(' + i + ')" onmouseover="Over(1, ' + i + ')" onmouseout="Out(1, ' + i + ')" class="listitem" id="1item' + i + '" style="position: absolute; left: 0px; top: 0px; height: 20; visibility: hidden;">'
		+     mage + '<img src="white.gif" width=5 height=1>'
		+ Items[i]
		+  '</div>';
  }

  writer	+= '</div>'
		+  '</div>'
		+  '<div class="listarea" id="dest" style="position: absolute; left: ' + DestLeft + 'px; top: ' + (DestTop + 26) + 'px; width: ' + ListWidth + '; height: ' + ListHeight + '; visibility: show;">'
  		+  '<div class="listarea2" id="dest2" style="position: absolute; left: 0px; top: 0px; width: ' + ListWidth + 'px; visibility: show;">';

  for (i = s.length; i < (d.length + s.length); i++) {
    if (dact.length) {
      if (dact[i - s.length] == 1)
        mage = '<img src="' + Icon + '" align=top border=1 alt="Currently Active">';
      else
        mage = '<img src="' + DeactiveIcon + '" align=top border=1 alt="Currently Not Active">';
    }
    else
      mage = '<img src="' + Icon + '" align=top border=1>';

    writer	+= '<div onclick="ChangeSelect(' + i + ')" onmouseover="Over(2, ' + i + ')" onmouseout="Out(2, ' + i + ')" class="listitem" id="2item' + i + '" style="position: absolute; left: 0px; top: ' + ((i * 20) - (s.length * 20)) + 'px; height: 20; visibility: visible;">'
		+     mage + '<img src="white.gif" width=5 height=1>'
		+     Items[i]
		+  '</div>';
  }

  for (i = 0; i < s.length; i++) {
    if (sact.length) {
      if (sact[i] == 1)
        mage = '<img src="' + Icon + '" align=top border=1 alt="Currently Active">';
      else
        mage = '<img src="' + DeactiveIcon + '" align=top border=1 alt="Currently Not Active">';
    }
    else
      mage = '<img src="' + Icon + '" align=top border=1>';

    writer	+= '<div onclick="ChangeSelect(' + i + ')" onmouseover="Over(2, ' + i + ')" onmouseout="Out(2, ' + i + ')" class="listitem" id="2item' + i + '" style="position: absolute; left: 0px; top: 0px; height: 20; visibility: hidden;">'
		+     mage + '<img src="white.gif" width=5 height=1>'
		+     Items[i]
		+  '</div>';
  }
  writer	+= '</div>'
		+  '</div>'
		+  '<div class="listbutton" onclick="ToDest();" id="todest" style="position: absolute; left: ' + ButtonLeft + 'px; top: ' + ButtonTop + 'px; width: 30; height: 20; visibility: show;">'
		+  '  &nbsp;&nbsp;>'
		+  '</div>'
		+  '<div class="listbutton" onclick="AllToDest();" id="alltodest" style="position: absolute; left: ' + ButtonLeft + 'px; top: ' + (ButtonTop + 30) + 'px; width: 30; height: 20; visibility: show;">'
		+  '  &nbsp;>'+'>'
		+  '</div>'
		+  '<div class="listbutton" onclick="ToSrc();" id="tosrc" style="position: absolute; left: ' + ButtonLeft + 'px; top: ' + (ButtonTop + 60) + 'px; width: 30; height: 20; visibility: show;">'
		+  '  &nbsp;&nbsp;<'
		+  '</div>'
		+  '<div class="listbutton" onclick="AllToSrc();" id="alltosrc" style="position: absolute; left: ' + ButtonLeft + 'px; top: ' + (ButtonTop + 90) + 'px; width: 30; height: 20; visibility: show;">'
		+  '  &nbsp;<'+'<'
		+  '</div>'
		+  '<div class="dragiconbottom" id="dragicon" style="position: absolute; left: 0px; top: 0px; width: 20; height: 20; visibility: hidden;">'
		+  '  <div class="dragicon" id="dragicona" style="position: absolute; left: 0px; top: 0px; height: 15; width: 15; visibility: inherit; filter: alpha(opacity=50);">'
		+  '  </div>'
		+  '  <div class="dragicon" id="dragiconb" style="position: absolute; left: 5px; top: 5px; height: 15; width: 15; visibility: inherit; filter: alpha(opacity=50);">'
		+  '  </div>'
		+  '</div>'
		+  '<div onclick="ReturnID()" id="updatebutton" class="listbutton" style="HEIGHT: 28px; WIDTH: ' + (SubmitCaption.length * 10) + '; LEFT: ' + SubmitLeft + 'px; POSITION: absolute; TOP: ' + SubmitTop + 'px">'
		+  '  <table width=' + (SubmitCaption.length * 10 - 4) + '><tr><td class="listbutton" align=center><font color=' + SelectColour + '>' + SubmitCaption + '</font></tr></td></table>'
		+  '</div>'
		+  '<div id="srccaption" style="HEIGHT: 20px; LEFT: ' + SourceLeft + 'px; POSITION: absolute; TOP: ' + SourceTop  + 'px; WIDTH: ' + ListWidth + 'px">'
		+  '  <font size=-1><b><center>' + OutCaption + '</center></b></font>'
		+  '</div>'
		+  '<div id="destcaption" style="HEIGHT: 20px; LEFT: ' + DestLeft + 'px; POSITION: absolute; TOP: ' + DestTop + 'px; WIDTH: ' + ListWidth + 'px">'
  		+  '  <font size=-1><b><center>' + InCaption + '</center></b></font>'
		+  '</div>';

  document.writeln(writer);

  getLayer("source2").style.width = getLayer("source").clientWidth + "px";
  getLayer("dest2").style.width = getLayer("dest").clientWidth + "px";
}