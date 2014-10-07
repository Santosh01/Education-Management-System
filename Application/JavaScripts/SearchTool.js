// JScript File

//browser detection
    var agt=navigator.userAgent.toLowerCase();
    var is_major = parseInt(navigator.appVersion);
    var is_minor = parseFloat(navigator.appVersion);

    var is_nav  = ((agt.indexOf('mozilla')!=-1) && (agt.indexOf('spoofer')==-1)
                && (agt.indexOf('compatible') == -1) && (agt.indexOf('opera')==-1)
                && (agt.indexOf('webtv')==-1) && (agt.indexOf('hotjava')==-1));
    var is_nav4 = (is_nav && (is_major == 4));
    var is_nav6 = (is_nav && (is_major == 5));
    var is_nav6up = (is_nav && (is_major >= 5));
    var is_ie     = ((agt.indexOf("msie") != -1) && (agt.indexOf("opera") == -1));

        var dragapproved=false
        var z,x,y
        var maxleft,maxtop,maxright,maxbottom;

        function setdragBounds(){
                //you can set the bounds of the draggable area here
                maxleft = 10;
                maxtop = 10;
                maxright = document.body.clientWidth - 10;
                maxbottom = document.body.clientHeight - 100;
        }

        function move(e){
                var tmpXpos = (!is_ie)? temp1+e.clientX-x: temp1+event.clientX-x;
                var tmpYpos = (!is_ie)? temp2+e.clientY-y : temp2+event.clientY-y;
                if (dragapproved){
                                z.style.left = tmpXpos;
                                z.style.top = tmpYpos;

                        if(tmpXpos < maxleft)z.style.left = maxleft;
                                if(tmpXpos > maxright)z.style.left = maxright;

                        if(tmpYpos < maxtop)z.style.top = maxtop;
                        if(tmpYpos > maxbottom)z.style.top = maxbottom;
                        return false
                }
        }

        function drags(e){
                if (!(is_ie)&&!(!is_ie))
                return
                var firedobj=(!is_ie)? e.target : event.srcElement
                var topelement=(!is_ie)? "HTML" : "BODY"

                while (firedobj.tagName!=topelement && firedobj.className!="drag" && firedobj.tagName!='SELECT' && firedobj.tagName!='TEXTAREA' && firedobj.tagName!='INPUT' && firedobj.tagName!='IMG'){
                        //you can add the elements that cannot be used for drag here. using their class name or id or tag names
                        firedobj=(!is_ie)? firedobj.parentNode : firedobj.parentElement
                }

                if (firedobj.className=="drag"){
                        dragapproved=true
                        z=firedobj
                        var tmpheight = z.style.height.split("px")
                        maxbottom = (tmpheight[0])?document.body.clientHeight - tmpheight[0]:document.body.clientHeight - 20;

                        temp1=parseInt(z.style.left+0)
                        temp2=parseInt(z.style.top+0)
                        x=(!is_ie)? e.clientX: event.clientX
                        y=(!is_ie)? e.clientY: event.clientY
                        document.onmousemove=move
                        return false
                }
        }
        document.onmousedown=drags
        document.onmouseup=new Function("dragapproved=false")

function positionIFrame(divid, frmid)
{
	var div = document.getElementById(divid);
	var frm = document.getElementById(frmid);
	frm.style.left = div.style.left;
	frm.style.top = div.style.top;
	frm.style.height = div.offsetHeight;
	frm.style.width = div.offsetWidth;
	frm.style.display = "block";	
}

function findPosX(obj)
{
	var curleft = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curleft += obj.offsetLeft
			obj = obj.offsetParent;
		}
	}
	else if (obj.x)
		curleft += obj.x;
	return curleft;
}

function findPosY(obj)
{
	var curtop = 0;
	if (obj.offsetParent)
	{
		while (obj.offsetParent)
		{
			curtop += obj.offsetTop
			obj = obj.offsetParent;
		}
	}
	else if (obj.y)
		curtop += obj.y;
	return curtop;
}

function positionDiv(divid, frmid)
{	
	var div = document.getElementById(divid);
	div.style.left=findPosX(document.getElementById("slct"))+ 5 + "px";
	div.style.top=findPosY(document.getElementById("slct"))+ 5 + "px";
	positionIFrame(divid, frmid);
}

