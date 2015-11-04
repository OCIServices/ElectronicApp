     var objX = "";
     var objY = "";
     var col = "black";
     var wid = 2;
     var offsetX = 0;
     var offsetY = 0;

     var shouldMove = false;
     var divObj = null;
     var graphics = null;
     var isIE = window.navigator.userAgent.toUpperCase().indexOf("MSIE ") > 0;

     function GetOffset() {
         var el = document.getElementById("ctlSignature");
         for (var lx = 0, ly = 0; el != null; lx += el.offsetLeft, ly += el.offsetTop, el = el.offsetParent);
         offsetX = lx;
         offsetY = ly;
     }       
    
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
                currX = e.clientX + document.body.scrollLeft +
                            document.documentElement.scrollLeft - offsetX;
                currY = e.clientY + document.body.scrollTop +
                            document.documentElement.scrollTop - offsetY; 
            }
            else {
                currX = e.pageX - offsetX;
                currY = e.pageY - offsetY;
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

            LastX = currX
            LastY = currY

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
            LastX = e.clientX + document.body.scrollLeft +
                            document.documentElement.scrollLeft -offsetX;
            LastY = e.clientY + document.body.scrollTop +
                            document.documentElement.scrollTop -offsetY; 
        }
        else {
            LastX = e.pageX - offsetX;
            LastY = e.pageY - offsetY;
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

          graphics = Raphael("ctlSignature", 500, 150);
          //graphics.circle(100, 100, 80);
                 
         divObj.style.backgroundColor = "white";

        // if(document.getElementById("l_BackImg").value.length > 0)
        /// {
          //  divObj.style.backgroundImage = "url('" + document.getElementById("l_BackImg").value + "')";
        // }
      }
      catch (mse) 
      {
        alert(mse.description);
      }
  }

  function save() {
      //if (objX == "" || objY == "") {
      if((objX.split(",").length -1 < 3) || (objX.split(",").length -1 < 3)){
          IsValid = false;
          alert("No Signature Found");
          return false;
      }
      else 
      {
          document.getElementById("l_x").value = objX;
          document.getElementById("l_y").value = objY;
          IsValid = true;
          return true;
      }
  }

  function clear() {
      objX = "";
      objY = "";
      graphics.clear();
      return false;
  }