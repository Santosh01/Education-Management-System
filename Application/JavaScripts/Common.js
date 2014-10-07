
    var clientId ;   
    var ex;
    var divColor;
    function ShowMatchings(ClientId) 
    {   
        if(document.getElementById(ClientId.toString() +'_txtCust').value!='')
            {            
            clientId = ClientId;          
            GetData();
            }   
            else
            {
                removeElement();
            }
    }

    function onBlur()
    {
    setTimeout(removeElement,500);
    }
 function loadXMLDoc(fname)
    {
        var xmlDoc;
        // code for IE
        if (window.ActiveXObject)
        {
        xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
        }
        // code for Mozilla, Firefox, Opera, etc.        
        else
        {
        alert('Your browser cannot handle this script');
        }
        xmlDoc.async=false;
        xmlDoc.load(fname);
        return(xmlDoc);
    }
    
    function removeElement() 
    {       
        if(document.getElementById("DIV")!=null)
        {
            var Parent =  document.getElementById(clientId.toString() +'_txtDiv'); 
            var Divelement = document.getElementById("DIV");
            Parent.removeChild(Divelement);
        }
    }
    function Edit(Item)
    {    
        var txt = document.getElementById(clientId.toString() +'_txtCust');
        var txtID = document.getElementById(clientId.toString() +'_txtID');
        
        var str = Item.split("|");
        txt.value = str[0]; 
        txtID.value = str[1]; 
        removeElement();       
    }
    function GetData()
         {
            var message = '';
            var context = '';            
            DoClientCallBack(document.getElementById(clientId.toString() +'_txtCust').value +'~'+ document.getElementById(clientId.toString() +'_hdnType').value);
         }
        function BindData()
        {
        
        }
        function BindDatatoDiv(result,cnt) 
        {        
       // var Parent = document.getElementById('form1');  
        var Parent = document.getElementById(clientId.toString() +'_txtDiv'); 
        var txt = document.getElementById(clientId.toString() +'_txtCust'); 
        var Divelement;
        if(document.getElementById("DIV")==null)
        {
         Divelement=document.createElement("DIV");
        }
        else
        {
         Divelement=document.getElementById('DIV');
        }
        Divelement.setAttribute('id',"DIV");
        Divelement.align="right";				
        Divelement.style.width=txt.clientWidth;
        Divelement.style.height=cnt * 25;
        Divelement.style.left=txt.style.left;
        //Divelement.style.top=txt.offsetHeight+txt.clientHeight;
        Divelement.style.position='absolute';
        Divelement.style.background='#9fc9d3';        
        Divelement.innerHTML = ex;
        Parent.appendChild(Divelement); 
         }
        function onCallbackComplete(result, context)
            {                        
                var xmlDoc;        
                if (window.ActiveXObject)
                {
                xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
                }               
                xmlDoc.async=false;
                var xmlString = result.split('~_~');
                xmlDoc.loadXML(xmlString[0]);               
                var  xsl=loadXMLDoc("Common.xsl");
                if (window.ActiveXObject)
                    {
                    ex=xmlDoc.transformNode(xsl); 
                    BindDatatoDiv(ex,xmlString[1]);                   
                    }
                else
                    {
                    alert("Use Internet Explorer");
                    }
            }

        function onCallbackError()
            {            
                alert("Error");
            }