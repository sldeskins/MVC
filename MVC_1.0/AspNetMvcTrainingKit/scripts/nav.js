function topNavHover(sender,sib,over)
{
   try
   {
       var divs = sender.getElementsByTagName("div");
       var positions = new Array("left","middle","right");
                             
       //go through each div that make up the button and turn them on
       if(divs[0].className.indexOf("selected") < 0)
       {
           for(i=0;i<divs.length;i++)
           {
                for(j=0;j<positions.length;j++)
                {
                    if(divs[i].className.indexOf(positions[j]) > -1)
                    {
                        if(over)
                           divs[i].className = "topnav_item_" + positions[j] + "_hover";                           
                        else
                           divs[i].className = "topnav_item_" + positions[j];
                    }
                }
            }
        }
        
        toggleDisplay(sib,over);
        
    } catch(e){}
}

function subNavHover(sender,sib,over)
{
    try
    {
        topNavHover(sib,sender,over);
        toggleDisplay(sender,over);
    
    } catch(e){}
}

function toggleDisplay(elm,on)
{ 
    try
    {
        if(on)
        {
            elm.style.display = "block";
        }
        else            
            elm.style.display = "none";
        
    } catch(e){}
    
}

function getE(id)
{
    return document.getElementById(id);
}

function menuboxShowItem(sender, sib)
{   
    try
    {
		var divs = sender.parentNode.parentNode.getElementsByTagName("div");
	    
		// go through all divs in the menubox, unhighlighting menu items and hiding content times.
		for(i=0;i<divs.length;i++)
		{
			if(divs[i].className.indexOf("menuitem") > -1)
				divs[i].className = divs[i].className.replace("_selected",""); 
	        
			if(divs[i].className.indexOf("contentitem") > -1)
				toggleDisplay(divs[i],false);
		}
	    
		sender.className += "_selected";
		
		// Firefox counts white space as nodes (wondeful), so we can't count on the position of the firstChild cross browser.
		// It's either the first or second, so check before we change
		if(sender.childNodes[0].tagName == "DIV")
		{
			sender.childNodes[0].className += "_selected";
		}
		else
		{
			sender.childNodes[1].className += "_selected";
		}
	    
		toggleDisplay(sib,true);
    } catch(e){}
}