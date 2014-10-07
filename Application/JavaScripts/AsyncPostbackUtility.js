var _AsyncPostbackUtility = new AsyncPostbackUtility();

function AsyncPostbackUtility(){
    
    var currentFocusedControlId = "";
    var executingElement = "";
    var requestQueue = new Array();
    
    if (Sys)
        Sys.Application.add_init(appInit);
    else
        throw 'Sys is not defined, please verify you have a script manager on the page ' +
        'and that this object js file is included in its script collection.';    
    
    function appInit(){
        
        Sys.WebForms.PageRequestManager.getInstance().add_initializeRequest(initializeRequestHandler);
        Sys.WebForms.PageRequestManager.getInstance().add_pageLoading(pageLoadingHandler);    
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endRequestHandler);
    }
    
    function focusControl(){   
        if (typeof(currentFocusedControlId) != "undefined" && currentFocusedControlId != ""){
	        var targetControl = document.getElementById(currentFocusedControlId);
	        if (targetControl.contentEditable != "undefined"){
	            oldContentEditableSetting = targetControl.contentEditable;
	            targetControl.contentEditable = false;
	        }
	        targetControl.focus();    
		    
		    if (oldContentEditableSetting != "undefined")
		        targetControl.contentEditable = oldContentEditableSetting;
		    
		    targetControl.value = targetControl.value;
		}
    }

    function initializeRequestHandler(sender, args){
        var postBackElement = args.get_postBackElement();
        if (Sys.WebForms.PageRequestManager.getInstance().get_isInAsyncPostBack() == false){
             executingElement = postBackElement;
        }
        else{    
            if (executingElement != postBackElement){
                var evArg = $get("__EVENTARGUMENT").value;
                Array.enqueue(requestQueue, new Array(postBackElement, evArg));
            }
        
            args.set_cancel(true);
        }
    }

    function pageLoadingHandler(sender, args){   
        currentFocusedControlId = typeof(document.activeElement) == "undefined" ? "" : document.activeElement.id;
    }
    
    function endRequestHandler(sender, args){   
        
        focusControl();
	    
        if (requestQueue.length > 0){
            var elemEntry = Array.dequeue(requestQueue);
            var _element =  elemEntry[0];
            var _eventArg = elemEntry[1];
            Sys.WebForms.PageRequestManager.getInstance()._doPostBack(_element.id, _eventArg);
        }
    }
}

