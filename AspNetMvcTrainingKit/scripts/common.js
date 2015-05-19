// remove footer
function addEvent(obj, evType, fn)
{
    try
    {
		if (obj.addEventListener)
		{ 
			obj.addEventListener(evType, fn, false); 
			return true; 
		} 
		else if (obj.attachEvent)
		{ 
			var r = obj.attachEvent("on"+evType, fn); 
			return r; 
		}
		else
		{ 
			return false;
		}
    } catch(e){}
}

try
{
	addEvent(window, 'load', windowOnload);
} catch(e){}

function windowOnload()
{
	//removeMNPBottomElements();
}

function removeMNPBottomElements()
{
//	try
//	{
//		var ftr = document.getElementById("msviFooter");    
//	  
//		if (ftr != null)
//		{
//			// remove the br tag befor the MNP footer
//			var br = ftr.previousSibling;
//	        
//			if(br != null && br.nodeName == "BR")
//			{
//				br.parentNode.removeChild(br);
//			}        
//	        
//			// remove everything below the MNP footer
//			while(ftr.nextSibling != null)
//			{
//				ftr.nextSibling.parentNode.removeChild(ftr.nextSibling);
//			}
//	        
//			// remove the MNP footer
//			ftr.parentNode.removeChild(ftr);
//		}
//    } catch(e){}
}


function removeMNPStyleSheets()
{
    try
    {
		//remove MNP stylesheets.
		for(i=2;i<document.styleSheets.length;i++)
		{
			document.styleSheets[i].cssText = "";
		}
		
    } catch(e){}
}

function promoHover(sender,hover)
{
	if(hover)
		sender.style.backgroundImage = "url(" + sender.attributes["bgImgHover"].value + ")";
	else
		sender.style.backgroundImage = "url(" + sender.attributes["bgImg"].value + ")";		
}

var currVideo = null;

function showVideo(newVideo)
{	
	// if currVideo is null this is our first time in
	if(currVideo == null)
		currVideo = 'vid1';

	// get the current video object
	var objCurrVideo = document.getElementById(currVideo);
	var objNewVideo = document.getElementById(newVideo);
	
	// only if it's ie can we do the stop and play...
	if(navigator.appName == "Microsoft Internet Explorer")
	{
		// if currVideo and newVideo are different then stop the current video
		if(currVideo != newVideo)
		{
			// stop the current video
			objCurrVideo.stop();
			
			// play the new video
			objNewVideo.play();
		}
	}
	
	// hide the current video...
	objCurrVideo.style.display = "none";

	// remember out new video...
	currVideo = newVideo;
	
	// show the new video	
	objNewVideo.style.display = "block";
}