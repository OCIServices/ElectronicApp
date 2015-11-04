<!-- 
	WebSignatureCapture (WEBSIGN) copyright © 2011 - 2012 www.websignaturecapture.com
	Contact: info@websignaturecapture.com
	This code is not a freeware. You are not authorized to distribute
	or use it if you have not purchased. Please visit
	http://www.websignaturecapture.com to buy it
-->
<html>
<head>
    <title>Signature</title>
    <!-- copyright www.raphaeljs.com -->
    <script src="r.js" type="text/javascript"></script>

    <script language="javascript">
			document.oncontextmenu	=	new Function("return false");
		
			if (self == top)
			 { 
				 window.location.href = './';
			 }
    </script>

    <style>
	    body
	    {
		    cursor:pointer;
		    padding:0;
		    margin:0;
	    }
    </style>
    <script language="javascript" type="text/javascript">
    

     var objX = "";
     var objY = "";
     var col = "blue";
     var wid = 4;

     var shouldMove = false;
     var divObj = null;
     var graphics = null;
     var isIE = window.navigator.userAgent.toUpperCase().indexOf("MSIE ") > 0;
    
     function AddToX(v)
     {
       objX = objX + v;
     }
     
     function AddToY(v)
     {
       objY = objY + v;
     }

    
    if (window.navigator.userAgent.toUpperCase().indexOf("IEMOBILE ") > 0) 
    {
        isIE = true;
    }

    if (window.navigator.userAgent.toUpperCase().indexOf("WINDOWS PHONE ") > 0) 
    {
        isIE = true;
    }

    function XBrowserAddHandler(target, eventName, handlerName) {
        if (target.addEventListener)
            target.addEventListener(eventName, handlerName, false);
        else if (target.attachEvent)
            target.attachEvent("on" + eventName, handlerName);
        else {
            try {
                MyAttachEvent(target, eventName, handlerName);
                target['on' + eventName] = function() { MyFireEvent(target, eventName) };
            }
            catch (ex) {
                alert("Event attaching exception, " + ex.description);
            }
        }

    }

    function ReturnFalse(e) {
        if (!isIE) {
            e.preventDefault();
        }
        else
        {
             if (e.preventDefault) { e.preventDefault(); } else { e.returnValue = false; }
        }
    }


    var LastX = 0;
    var LastY = 0;
    
    function MouseMove(e) {
        if (!isIE) {
            e.preventDefault();
        }
        else
        {
             if (e.preventDefault) { e.preventDefault(); } else { e.returnValue = false; }
        }

        if (shouldMove) {
            var currX = 0;
            var currY = 0;

            if (isIE) {
                currX = e.x;
                currY = e.y;
            }
            else {
                currX = e.pageX;
                currY = e.pageY;
            }

            try 
            {
                 var path = "M" + LastX + " " + LastY + "L" + currX + " " + currY;
	     	     var l = graphics.path(path);
	     	     l.attr({"stroke-width": wid, "stroke": col, "stroke-linejoin": "round", "stroke-linecap": "round"});
            }
            catch (mse) 
           {
                alert(mse.description);
            } 
            
            
            AddToX(currX + ',');
            AddToY(currY + ',');
        
            LastX = currX;
            LastY = currY;

        }
    }

    function MouseDown(e) {

       
        if (!isIE) {
            e.preventDefault();
        }
        else
        {
             if (e.preventDefault) { e.preventDefault(); } else { e.returnValue = false; }
        }

        if (isIE) {
            LastX = e.x;
            LastY = e.y;
        }
        else {
            LastX = e.pageX;
            LastY = e.pageY;
        }
        
      
        AddToX(LastX + ',');
        AddToY(LastY + ',');
        shouldMove = true;
    }

    function MouseUp(e) {
        shouldMove = false;
        AddToX('|');
        AddToY('|');
    }

    function DoR()
    {
      try
      {
         divObj = document.getElementById("ctlSignature");
      
         XBrowserAddHandler(divObj, "selectstart", ReturnFalse);
         XBrowserAddHandler(divObj, "dragstart", ReturnFalse);
         XBrowserAddHandler(divObj, "mousemove", MouseMove);
         XBrowserAddHandler(divObj, "mousedown", MouseDown);
         XBrowserAddHandler(divObj, "mouseup", MouseUp);
         
          if (isIE) 
          {
              XBrowserAddHandler(divObj, "mouseleave", MouseUp);
          }
        
         graphics = Raphael("ctlSignature", document.getElementById("l_CanvasW").value, document.getElementById("l_CanvasH").value);
                 
         divObj.style.backgroundColor = document.getElementById("l_BGColor").value;

         if(document.getElementById("l_BackImg").value.length > 0)
         {
            divObj.style.backgroundImage = "url('" + document.getElementById("l_BackImg").value + "')";
         }
      }
      catch (mse) 
      {
        alert(mse.description);
      } 
    }
    
    </script>
</head>
<body onselectstart="return false;" onload="DoR();">
    <form name="fm" method="post" action="Signature.aspx">
        <div id='ctlSignature' style='cursor:hand;width:100%; height: 100%;'></div>
        <input id="l_x" name="l_x" type="hidden">
        <input id="l_y" name="l_y" type="hidden">
        <input id="l_Width" name="l_Width" type="hidden">
        <input id="l_Color" name="l_Color" type="hidden">
        <input id="l_BGColor" name="l_BGColor" type="hidden">
        <input id="l_File" name="l_File" type="hidden">
        <input id="l_CanvasW" name="l_CanvasW" type="hidden">
        <input id="l_CanvasH" name="l_CanvasH" type="hidden">
        <input id="l_SavePath" name="l_SavePath" type="hidden">
        <input id="l_BackImg" name="l_BackImg" type="hidden">
    </form>
    <noscript>
        <meta http-equiv="refresh" content="1;URL=./">
    </noscript>

    <script language="javascript">

    var noSign = "";
    var IsValid = false;
    document.getElementById("l_Width").value = getQueryVariable("PWidth");
    document.getElementById("l_Color").value = getQueryVariable("PColor");
    document.getElementById("l_BGColor").value = getQueryVariable("BGColor");
    document.getElementById("l_File").value = getQueryVariable("SignFile");
    document.getElementById("l_CanvasW").value = getQueryVariable("CanvasW");
    document.getElementById("l_CanvasH").value = getQueryVariable("CanvasH");
    noSign = removespace(getQueryVariable("NoSign"));
    document.getElementById("l_SavePath").value = getQueryVariable("SSavePath");
    document.getElementById("l_BackImg").value = getQueryVariable("SBackImg").replace(/_/g, "/");
     
    col = document.getElementById("l_Color").value
    wid = document.getElementById("l_Width").value

function removespace(inputstr)
{
	posn = inputstr.indexOf("%20");                    //find the first %20 
	 while (posn > -1)                                  //while there is a %20 
     { inputstr = inputstr.substring(0,posn) + " " + inputstr.substring(posn+3); 
       posn = inputstr.indexOf("%20");              //find next %20 
     }; 	
     
     return inputstr;
}

function save()
{
 	if(objX == "" || objY == "")
	{
	   IsValid = false;
	   alert(noSign);
	}
	else
	{	
	   document.getElementById("l_x").value = objX;
       document.getElementById("l_y").value = objY;
	   IsValid = true;
	   document.fm.submit();
	}
}

function clear()
{
  objX = "";
  objY = "";
  
  graphics.clear();
}

function getQueryVariable(variable)
{
    var query = window.location.search.substring(1);
    var vars = query.split("&");
    for (var i=0;i<vars.length;i++)
    {
        var pair = vars[i].split("=");
        if (pair[0] == variable)
        {
            return pair[1];
        }
    }
}    
 </script>
    
</body>
</html>
