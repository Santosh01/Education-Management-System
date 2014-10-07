//Functions.js
//This is a common file to handle all client side validations 
//Each form will have the following statements to call the routines 
//<script language="javascript" src ="Functions.js"></script>

<!--Begin

//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/

window.history.forward(1)

        
function noSelect() {
   if (event.srcElement.tagName != "INPUT" && event.srcElement.tagName != "TEXTAREA") {
       return false
   }
}

//document.onselectstart = noSelect


function ConfirmYesno(a)
{
  var ans = confirm(a);
  if (ans)
  {
  return 1;
  }
  else 
  {
  return 0;
  }
}


function roundOff(value, precision)
{   result = 0;
    if (!isNaN(value) && !isNaN(precision))
    {   value = parseFloat(value);
        precision = parseInt(precision);
        var whole = Math.round(value * Math.pow(10, precision))/Math.pow(10, precision);
        whole  = whole.toString();
        if (precision > 0)
        {  var str = whole.indexOf(".");
           var zeropad = 0;
           if (str == -1)
           {
              zeropad = "."
              for (r=1; r<=precision; r++) {
                 zeropad = zeropad + "0";
              }
              return whole+""+zeropad;
           }
           else
           {
              var dotoprt = whole.length-str;
              if (dotoprt == precision+1) {
              }
              else {
                 padd = precision - dotoprt;
                 for (k=1; k<=padd; k++)
                 {
                     zeropad = zeropad + "0";
                 }
                 whole = whole.concat(zeropad);
              }
           }
        }
        result = whole;
    }
    else
    {  
    // alert('INVALID NUMERIC VALUE / PRECISION.');
      return 0; 
    }
    return result;
}

function noRightClick()
{   if (event.srcElement.tagName != "INPUT")
    {   if (event.button==2)
        {   alert("Right click disabled.");         
            return false;
        }
    }
}
document.onmousedown=noRightClick


function dblclick() 
{   window.scrollTo(0,0)
}
if (document.layers) 
{   document.captureEvents(Event.ONDBLCLICK);
}
document.ondblclick=dblclick;

var swidth = screen.width;
var sheight = screen.height;
var scolorDepth = screen.colorDepth;
var n = navigator.appName
var ns = (n=="Netscape")
var ie = (n=="Microsoft Internet Explorer")

if (ns)
{   //alert('This Application does not support Netscape Navigator.\N Please use Internet Explorer 5.0 and above');
    //location="blank.html"
}
else
{   if (swidth < 800 || sheight < 600)
    {   alert('This Application is best viewed on screen resolution of 800 x 600.\nit is recommanded that you change screen resolution and then continue.');
        location="blank.html"
    }
}

//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/


//Section II : This Section will contain all standard routines used for
//Client side validations

// VARIABLE DECLARATIONS

/* whitespace characters
 \t : Horizontal tab (Ctrl-I),
 \n : Line feed (newline) ,  
 \r : Carriage return   */
 
var whitespace = " \t\n\r";

//VARIABLE DECLARATIONS FOR CALENDAR FUNCTION

var weekend = [0,6];
var weekendColor = "#e0e0e0";
var fontface = "Verdana";
var fontsize = 2;

var gNow = new Date();
var ggWinCal;
isNav = (navigator.appName.indexOf("Netscape") != -1) ? true : false;
isIE = (navigator.appName.indexOf("Microsoft") != -1) ? true : false;

Calendar.Months = ["January", "February", "March", "April", "May", "June",
"July", "August", "September", "October", "November", "December"];

// Non-Leap year Month days..
Calendar.DOMonth = [31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
// Leap year Month days..
Calendar.lDOMonth = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];

/* ======================================================================
FUNCTION:   isEmpty

INPUT:      str (string) 

RETURN:     Returns true if the string is empty

DESC:       This function will check for empty (blank) strings
====================================================================== */

function isEmpty(s)
{   var str = Trim(s);
    return ((str == null) || (str.length == 0))
}

/* ======================================================================
FUNCTION:   isDate

INPUT:      str (string) 

RETURN:     Returns true if string is valid date in dd/mm/yyyy format

DESC:       This function will check for valid date 
====================================================================== */

function isDate(elm)
{   var err=0
    var a=elm.value

    if (a.length != 10) err=1
    b = a.substring(0, 2)// day
    c = a.substring(2, 3)// '/'
    d = a.substring(3, 5)// month
    e = a.substring(5, 6)// '/'
    f = a.substring(6, 10)// year
    if (d<1 || d>12) err = 1
    if (c != '/') err = 1
    if (b<1 || b>31) err = 1
    if (e != '/') err = 1
    if (f<1890) err = 1
    if (d==4 || d==6 || d==9 || d==11)
    {   if (b==31) err=1
    }
    if (d==2)
    {   var g=parseInt(f/4)
        if (isNaN(g))
        {   err=1
        }
        if (b>29) err=1
        if (b==29 && ((f/4)!=parseInt(f/4))) err=1
    }
    if (err==1) 
    {   return false;
    }
    else 
    {   return true;
    }
}

/* ======================================================================
FUNCTION:   isWhitespace

INPUT:      str (string) 

RETURN:     Returns true if string s is empty or whitespace characters only.

DESC:       This function will check if string s is empty or contains 
            whitespace characters only.
====================================================================== */

function isWhitespace (s)
{   var i;
    if (isEmpty(s)) return true;
    for (i = 0; i < s.length; i++)
    {   // Check that current character isn't whitespace.
        var c = s.charAt(i);
        if (whitespace.indexOf(c) == -1) return false;
    }
    return true;
}

/* ======================================================================
FUNCTION:   isEmail

INPUT:      str (string) 

RETURN:     Returns true if string s is a valid email address.

DESC:       This function will check for valid Email Address
            Email address must be of form a@b.c -- in other words:
            * there must be at least one character before the @
            * there must be at least one character before and after the .
            * the characters @ and . are both required
====================================================================== */

function isEmail (s)
{   if (isEmpty(s)) 
      return false;
      
    // is s whitespace?
    if (isWhitespace(s)) return false;
    
    // there must be >= 1 character before @, so we
    // start looking at character position 1 
    // (i.e. second character)
    var i = 1;
    var sLength = s.length;

    // look for @
    while ((i < sLength) && (s.charAt(i) != "@"))
    { i++
    }

    if ((i >= sLength) || (s.charAt(i) != "@")) return false;
    else i += 2;

    // look for . (dot)
    while ((i < sLength) && (s.charAt(i) != "."))
    { i++
    }

    // there must be at least one character after the .(dot)
    if ((i >= sLength - 1) || (s.charAt(i) != ".")) return false;
    else return true;
}


/* ======================================================================
FUNCTION:   TrimLeft
 
INPUT:      str (string): the string to be altered

RETURN:     A string with no leading spaces;
            returns null if invalid arguments were passed

DESC:       This function removes all leading spaces from a string.
====================================================================== */

function TrimLeft( str )
{
    var resultStr = "";
    var i = len = 0;

    // Return immediately if an invalid value was passed in
    if (str+"" == "undefined" || str == null)   
        return null;

    // Make sure the argument is a string
    str += "";

    if (str.length == 0) 
        resultStr = "";
    else 
    {   // Loop through string starting at the beginning as long as there
        // are spaces.
        len = str.length;
        
        while ((i <= len) && (str.charAt(i) == " "))
            i++;

        // When the loop is done, we're sitting at the first non-space char,
        // so return that char plus the remaining chars of the string.
        resultStr = str.substring(i, len);
    }

    return resultStr;
}


/* ======================================================================
FUNCTION:   TrimRight
 
INPUT:      str (string): the string to be altered

RETURN:     A string with no trailing spaces;
            returns null if invalid arguments were passed

DESC:       This function removes all trailing spaces from a string.
====================================================================== */

function TrimRight( str )
{   var resultStr = "";
    var i = 0;

    // Return immediately if an invalid value was passed in
    if (str+"" == "undefined" || str == null)   
        return null;

    // Make sure the argument is a string
    str += "";
    
    if (str.length == 0) 
        resultStr = "";
    else 
    {   // Loop through string starting at the end as long as there
        // are spaces.
        i = str.length - 1;
        while ((i >= 0) && (str.charAt(i) == " "))
            i--;
            
        // When the loop is done, we're sitting at the last non-space char,
        // so return that char plus all previous chars of the string.
        resultStr = str.substring(0, i + 1);
    }
    
    return resultStr;   
} 


/* ======================================================================
FUNCTION:   Trim
 
INPUT:      str (string): the string to be altered

RETURN:     A string with no leading or trailing spaces;
            returns null if invalid arguments were passed

DESC:       This function removes all leading and tralining spaces from a string.

CALLS:      This function depends on the functions TrimLeft & TrimRight
            They must be included in order for this function to work properly.
====================================================================== */

function Trim( str ) 
{   var resultStr = "";
    
    resultStr = TrimLeft(str);
    resultStr = TrimRight(resultStr);
    
    return resultStr;
} 

/* ======================================================================
FUNCTION:   DateFormat
 
INPUT:      str (string): the string to be altered

DESC:       Automatic Formatting For Date Fields

USAGE :     <input type="text" name="testDate" size='10' maxlength="10" 
            onKeyUp="DateFormat(this,this.value,event,false,'3')" 
            onBlur="DateFormat(this,this.value,event,true,'3')">
====================================================================== */

// Check browser version
var isNav4 = false, isNav5 = false, isIE4 = false
var strSeperator = "/";

// If you are using any Java validation on the back side you will want to use the / because
// Java date validations do not recognize the dash as a valid date separator.
var vDateType = 3; // Global value for type of date format
//                1 = mm/dd/yyyy
//                2 = yyyy/dd/mm  (Unable to do date check at this time)
//                3 = dd/mm/yyyy

var vYearType = 4; //Set to 2 or 4 for number of digits in the year for Netscape
var vYearLength = 2; // Set to 4 if you want to force the user to enter 4 digits for the year before validating.
var err = 0; // Set the error code to a default of zero
if(navigator.appName == "Netscape")
{   if (navigator.appVersion < "5")
    {   isNav4 = true;
        isNav5 = false;
    }
    else
    if (navigator.appVersion > "4")
    {   isNav4 = false;
        isNav5 = true;
    }
}
else
{   isIE4 = true;
}


function DateFormat(vDateName, vDateValue, e, dateCheck, dateType)
{   vDateType = dateType;
            // vDateName = object name
            // vDateValue = value in the field being checked
            // e = event
            // dateCheck
            // True  = Verify that the vDateValue is a valid date
            // False = Format values being entered into vDateValue only
            // vDateType
            // 1 = mm/dd/yyyy
            // 2 = yyyy/mm/dd
            // 3 = dd/mm/yyyy
            //Enter a tilde sign for the first number and you can check the variable information.
    if (vDateValue == "~")
    {   alert("AppVersion = "+navigator.appVersion+" \nNav. 4 Version = "+isNav4+" \nNav. 5 Version = "+isNav5+" \nIE Version = "+isIE4+" \nYear Type = "+vYearType+" \nDate Type = "+vDateType+" \nSeparator = "+strSeperator);
        vDateName.value = "";
        vDateName.focus();
        return true;
    }
    
    // Begining of Changes
    // 05-Jul-2007
    // Changes made by Ajit Tondwalkar

    //var whichCode = (window.Event) ? e.which : e.keyCode;        // Line was commented since was not working with ajax enhancement
    var whichCode = e.keyCode;  // New Line Added since new Ajax Enhancement Implemented, the above line was not working properly.

    // End of Changes

    // Check to see if a seperator is already present.
    // bypass the date if a seperator is present and the length greater than 8
    if (vDateValue.length > 8 && isNav4)
    {   if ((vDateValue.indexOf("-") >= 1) || (vDateValue.indexOf("/") >= 1))
            return true;
    }

    //Eliminate all the ASCII codes that are not valid
    var alphaCheck = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ/-";
    if (alphaCheck.indexOf(vDateValue) >= 1)
    {   if (isNav4)
        {   vDateName.value = "";
            vDateName.focus();
            vDateName.select();
            return false;
        }
        else
        {   vDateName.value = vDateName.value.substr(0, (vDateValue.length-1));
            return false;
        }
    }

    if (whichCode == 8) //Ignore the Netscape value for backspace. IE has no value
        return false;
    else
    {   //Create numeric string values for 0123456789/
        //The codes provided include both keyboard and keypad values
        var strCheck = '47,48,49,50,51,52,53,54,55,56,57,58,59,95,96,97,98,99,100,101,102,103,104,105';
        if (strCheck.indexOf(whichCode) != -1)
        {   if (isNav4)
            {   if (((vDateValue.length < 6 && dateCheck) || (vDateValue.length == 7 && dateCheck)) && (vDateValue.length >=1))
                {   alert("Invalid Date\nFormat - DD/MM/YYYY");
                    vDateName.value = "";
                    vDateName.focus();
                    vDateName.select();
                    return false;
                }
                if (vDateValue.length == 6 && dateCheck)
                {   var mDay = vDateName.value.substr(2,2);
                    var mMonth = vDateName.value.substr(0,2);
                    var mYear = vDateName.value.substr(4,4)
                    //Turn a two digit year into a 4 digit year
                    if (mYear.length == 2 && vYearType == 4)
                    {   var mToday = new Date();
                        //If the year is greater than 30 years from now use 19, otherwise use 20
                        var checkYear = mToday.getFullYear() + 30;
                        var mCheckYear = '20' + mYear;
                        if (mCheckYear >= checkYear)
                            mYear = '19' + mYear;
                        else
                            mYear = '20' + mYear;
                    }
                    var vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;
                    if (!dateValid(vDateValueCheck))
                    {   alert("Invalid Date\nFormat - DD/MM/YYYY");
                        vDateName.value = "";
                        vDateName.focus();
                        vDateName.select();
                        return false;
                    }
                    return true;
                }
                else
                {   // Reformat the date for validation and set date type to a 1
                    if (vDateValue.length >= 8  && dateCheck)
                    {   if (vDateType == 1) // mmddyyyy
                        {   var mDay = vDateName.value.substr(2,2);
                            var mMonth = vDateName.value.substr(0,2);
                            var mYear = vDateName.value.substr(4,4)
                            vDateName.value = mMonth+strSeperator+mDay+strSeperator+mYear;
                        }
                        if (vDateType == 2) // yyyymmdd
                        {   var mYear = vDateName.value.substr(0,4)
                            var mMonth = vDateName.value.substr(4,2);
                            var mDay = vDateName.value.substr(6,2);
                            vDateName.value = mYear+strSeperator+mMonth+strSeperator+mDay;
                        }
                        if (vDateType == 3) // ddmmyyyy
                        {   var mMonth = vDateName.value.substr(2,2);
                            var mDay = vDateName.value.substr(0,2);
                            var mYear = vDateName.value.substr(4,4)
                            vDateName.value = mDay+strSeperator+mMonth+strSeperator+mYear;
                        }

                        //Create a temporary variable for storing the DateType and change
                        //the DateType to a 1 for validation.
                        var vDateTypeTemp = vDateType;
                        vDateType = 1;
                        var vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;
                        if (!dateValid(vDateValueCheck))
                        {   alert("Invalid Date\nFormat - DD/MM/YYYY");
                            vDateType = vDateTypeTemp;
                            vDateName.value = "";
                            vDateName.focus();
                            vDateName.select();
                            return false;
                        }
                        vDateType = vDateTypeTemp;
                        return true;
                    }
                    else
                    {   if (((vDateValue.length < 8 && dateCheck) || (vDateValue.length == 9 && dateCheck)) && (vDateValue.length >=1))
                        {   alert("Invalid Date\nFormat - DD/MM/YYYY");
                            vDateName.value = "";
                            vDateName.focus();
                            vDateName.select();
                            return false;
                        }
                    }
                }
            }
            else
            {   // Non isNav Check
                if (((vDateValue.length < 8 && dateCheck) || (vDateValue.length == 9 && dateCheck)) && (vDateValue.length >=1))
                {   alert("Invalid Date\nFormat - DD/MM/YYYY");
                    vDateName.value = "";
                    vDateName.focus();
                    return true;
                }

                // Reformat date to format that can be validated. mm/dd/yyyy
                if (vDateValue.length >= 8 && dateCheck)
                {   // Additional date formats can be entered here and parsed out to
                    // a valid date format that the validation routine will recognize.
                    if (vDateType == 1) // mm/dd/yyyy
                    {   var mMonth = vDateName.value.substr(0,2);
                        var mDay = vDateName.value.substr(3,2);
                        var mYear = vDateName.value.substr(6,4)
                    }
                    if (vDateType == 2) // yyyy/mm/dd
                    {   var mYear = vDateName.value.substr(0,4)
                        var mMonth = vDateName.value.substr(5,2);
                        var mDay = vDateName.value.substr(8,2);
                    }
                    if (vDateType == 3) // dd/mm/yyyy
                    {   var mDay = vDateName.value.substr(0,2);
                        var mMonth = vDateName.value.substr(3,2);
                        var mYear = vDateName.value.substr(6,4)
                    }
                    if (vYearLength == 4)
                    {   if (mYear.length < 4)
                        {   alert("InvaIid Date\nFormat - DD/MM/YYYY");
                            vDateName.value = "";
                            vDateName.focus();
                            return true;
                        }
                    }

                    // Create temp. variable for storing the current vDateType
                    var vDateTypeTemp = vDateType;

                    // Change vDateType to a 1 for standard date format for validation
                    // Type will be changed back when validation is completed.
                    vDateType = 1;

                    // Store reformatted date to new variable for validation.
                    var vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;
                    if (mYear.length == 2 && vYearType == 4 && dateCheck)
                    {   //Turn a two digit year into a 4 digit year
                        var mToday = new Date();
                        //If the year is greater than 30 years from now use 19, otherwise use 20
                        var checkYear = mToday.getFullYear() + 30;
                        var mCheckYear = '20' + mYear;
                        if (mCheckYear >= checkYear)
                            mYear = '19' + mYear;
                        else
                            mYear = '20' + mYear;
                        vDateValueCheck = mMonth+strSeperator+mDay+strSeperator+mYear;

                        // Store the new value back to the field.  This function will
                        // not work with date type of 2 since the year is entered first.
                        if (vDateTypeTemp == 1) // mm/dd/yyyy
                            vDateName.value = mMonth+strSeperator+mDay+strSeperator+mYear;
                        if (vDateTypeTemp == 3) // dd/mm/yyyy
                            vDateName.value = mDay+strSeperator+mMonth+strSeperator+mYear;
                    }
                    if (!dateValid(vDateValueCheck))
                    {   alert("InvaIid Date\nFormat - DD/MM/YYYY");
                        vDateType = vDateTypeTemp;
                        vDateName.value = "";
                        vDateName.focus();
                        return true;
                    }
                    vDateType = vDateTypeTemp;
                    return true;
                }
                else
                {   if (vDateType == 1)
                    {   if (vDateValue.length == 2)
                        {   vDateName.value = vDateValue+strSeperator;
                        }
                        if (vDateValue.length == 5)
                        {   vDateName.value = vDateValue+strSeperator;
                        }
                    }
                    if (vDateType == 2)
                    {   if (vDateValue.length == 4)
                        {   vDateName.value = vDateValue+strSeperator;
                        }
                        if (vDateValue.length == 7)
                        {   vDateName.value = vDateValue+strSeperator;
                        }
                    }
                    if (vDateType == 3)
                    {   if (vDateValue.length == 2)
                        {   vDateName.value = vDateValue+strSeperator;
                        }
                        if (vDateValue.length == 5)
                        {   vDateName.value = vDateValue+strSeperator;
                        }
                    }
                    return true;
               }
    }
    if (vDateValue.length == 10&& dateCheck)
    {   if (!dateValid(vDateName))
        {   // Un-comment the next line of code for debugging the dateValid() function error messages
            //alert(err);
            alert("InvaIid Date\nFormat - DD/MM/YYYY");
            vDateName.focus();
            vDateName.select();
        }
    }
    return false;
}
else
{   // If the value is not in the string return the string minus the last
    // key entered.
    if (isNav4)
    {   vDateName.value = "";
        vDateName.focus();
        vDateName.select();
        return false;
    }
    else
    {   vDateName.value = vDateName.value.substr(0, (vDateValue.length-1));
        return false;
    }
}
}
}

function dateValid(objName)
{   var strDate;
    var strDateArray;
    var strDay;
    var strMonth;
    var strYear;
    var intday;
    var intMonth;
    var intYear;
    var booFound = false;
    var datefield = objName;
    var strSeparatorArray = new Array("-"," ","/",".");
    var intElementNr;
    // var err = 0;
    var strMonthArray = new Array(12);
    strMonthArray[0] = "Jan";
    strMonthArray[1] = "Feb";
    strMonthArray[2] = "Mar";
    strMonthArray[3] = "Apr";
    strMonthArray[4] = "May";
    strMonthArray[5] = "Jun";
    strMonthArray[6] = "Jul";
    strMonthArray[7] = "Aug";
    strMonthArray[8] = "Sep";
    strMonthArray[9] = "Oct";
    strMonthArray[10] = "Nov";
    strMonthArray[11] = "Dec";
    //strDate = datefield.value;
    strDate = objName;
    if (strDate.length < 1)
    {   return true;
    }
    for (intElementNr = 0; intElementNr < strSeparatorArray.length; intElementNr++)
    {   if (strDate.indexOf(strSeparatorArray[intElementNr]) != -1)
        {   strDateArray = strDate.split(strSeparatorArray[intElementNr]);
            if (strDateArray.length != 3)
            {   err = 1;
                return false;
            }
            else
            {   strDay = strDateArray[0];
                strMonth = strDateArray[1];
                strYear = strDateArray[2];
            }
            booFound = true;
       }
    }
    if (booFound == false)
    {   if (strDate.length>5)
        {   strDay = strDate.substr(0, 2);
            strMonth = strDate.substr(2, 2);
            strYear = strDate.substr(4);
        }
    }
    //Adjustment for short years entered
    if (strYear.length == 2)
    {   strYear = '20' + strYear;
    }
    strTemp = strDay;
    strDay = strMonth;
    strMonth = strTemp;
    intday = parseInt(strDay, 10);
    if (isNaN(intday))
    {   err = 2;
        return false;
    }
    intMonth = parseInt(strMonth, 10);
    if (isNaN(intMonth))
    {   for (i = 0;i<12;i++)
        {   if (strMonth.toUpperCase() == strMonthArray[i].toUpperCase())
            {   intMonth = i+1;
                strMonth = strMonthArray[i];
                i = 12;
            }
        }
        if (isNaN(intMonth))
        {   err = 3;
            return false;
        }
    }
    intYear = parseInt(strYear, 10);
    if (isNaN(intYear))
    {   err = 4;
        return false;
    }
    if (intMonth>12 || intMonth<1)
    {   err = 5;
        return false;
    }
    if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intday > 31 || intday < 1))
    {   err = 6;
        return false;
    }
    if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30 || intday < 1))
    {   err = 7;
        return false;
    }
    if (intMonth == 2)
    {   if (intday < 1)
        {   err = 8;
            return false;
        }
        if (LeapYear(intYear) == true)
        {   if (intday > 29)
            {   err = 9;
                return false;
            }
        }
        else
        {   if (intday > 28)
            {   err = 10;
                return false;
            }
        }
    }
return true;
}

function LeapYear(intYear)
{   if (intYear % 100 == 0)
    {   if (intYear % 400 == 0) { return true; }
    }
    else
    {   if ((intYear % 4) == 0) { return true; }
    }
    return false;
}

/* ======================================================================
FUNCTION:   showtip / hidetip
 
INPUT:      tooltip text

DESC:       This function will be used to show tooltips on buttons / images .
====================================================================== */

if (!document.layers&&!document.all)
  event="test"

function showtip(current,e,text)
{   if (document.all)
    {   thetitle=text.split('<br>')
        if (thetitle.length>1)
        {   thetitles=''
            for (i=0;i<thetitle.length;i++)
            thetitles+=thetitle[i]
            current.title=thetitles
        }
        else
            current.title=text
    }
    else if (document.layers)
    {   document.tooltip.document.write('<layer bgColor="white" style="border:1px solid black;font-size:12px;">'+text+'</layer>')
        document.tooltip.document.close()
        document.tooltip.left=e.pageX+5
        document.tooltip.top=e.pageY+5
        document.tooltip.visibility="show"
    }
}

function hidetip()
{   if (document.layers)
      document.tooltip.visibility="hidden"
}


/* ======================================================================
FUNCTION:   QuickList

INPUT:      url,width,height,top,left

RETURN:     grid help window

====================================================================== */

function QuickList(thisurl,thiswidth,thisheight,thistop,thisleft) 
{  popwindowURL    = thisurl
   popwindowwidth  = thiswidth
   thisheight      = thisheight
   popwindowheight = thisheight
   popwindowtop    = (screen.availHeight) ? (screen.availHeight-thisheight)/2 : 0;  
   popwindowleft   = (screen.availWidth)  ? (screen.availWidth-thiswidth)/2 : 0;
   popwindow = window.open(popwindowURL, "popwindow", "status=1,toolbar=no,scrollbars=1,resizable=1,dependent=1,alwaysRaised=1,width="+popwindowwidth+",height="+popwindowheight+",top="+popwindowtop+",left="+(popwindowleft)+"");
   //popwindow.focus();
}


function Display(thisurl,thiswidth,thisheight,thistop,thisleft) 
{  popwindowURL    = thisurl
   popwindowwidth  = thiswidth
   popwindowheight = thisheight
   popwindowtop    = (screen.height) ? (screen.height-thisheight)/2 : 0; 
   popwindowleft   = (screen.width) ? (screen.width-thiswidth)/2 : 0;
   popwindow       = window.open(popwindowURL, "popwindow", "status=1,toolbar=no,scrollbars=1,resizable=0,width="+popwindowwidth+",height="+popwindowheight+",top="+popwindowtop+",left="+(popwindowleft)+"");
   //popwindow.focus();
}

function AuthWindow(thisurl)
{  authwindowURL    = thisurl
   authwindowwidth  = screen.availWidth
   authwindowheight = screen.availHeight
   authwindowtop    = 0
   authwindowleft   = 0
   authwindow       = window.open(authwindowURL, "authwindow", "status=1,toolbar=no,scrollbars=1,resizable=1,width="+authwindowwidth+",height="+authwindowheight+",top="+authwindowtop+",left="+(authwindowleft)+"");
   //authwindow.focus();

}

/* ======================================================================
FUNCTION:   PreviewReport

INPUT:      

RETURN:     

DESC:       Function to Preview Report
====================================================================== */

function PreviewReport(thisurl,thiswidth,thisheight,thistop,thisleft)
{    rptwindowURL    =  thisurl;
     rptwindowwidth  =  screen.availWidth;
     rptwindowheight =  screen.availHeight;
     rptwindowtop    =  0;   
     rptwindowleft   =  0;
     rptwindow   =  window.open(rptwindowURL, "rptwindow", "status=1,toolbar=no,scrollbars=1,resizable=1,width="+rptwindowwidth+",height="+rptwindowheight+",top="+rptwindowtop+",left="+(rptwindowleft)+"");
     rptwindow.focus();
}




/* ======================================================================
FUNCTION:   ClearControls

INPUT:      form

DESC :  This function will clear the contents of form

====================================================================== */

function ClearControls(frm)
{
       var len = frm.elements.length;
       var i;
       for( i=0; i<len; i++)
       {
        switch (frm.elements[i].type)
        {
         case 'text':
              frm.elements[i].value="";
              break;
         case 'textarea':
              frm.elements[i].value="";
              break;
         case 'checkbox':
              frm.elements[i].checked = false;
              break;
         case 'hidden':
          frm.elements[i].value="";
              break;
         default:
              break;
        }     
      }
}


/* ======================================================================
FUNCTION:   SetAction

INPUT:      form

DESC :        This function will set the action for save/add etc.

====================================================================== */


function SetAction(btn,frm)
{   switch (Trim(btn.value))
    {  case 'Save':
          if (isEmpty(frm.action.value))
          {     if (frm.mp.value.substr(1,1)=="0")
                {   alert("PERMISSION DENIED.\nCANNOT ADD NEW RECORD.");
                    return 0;
                }
                else
                {   frm.action.value = "Add";
                    frm.submit();
                }
          }
          else
          {     if (frm.mp.value.substr(2,1)=="0")
                {   alert("PERMISSION DENIED.\nCANNOT EDIT/UPDATE RECORD.");
                    return 0;
                }
                else
                {   frm.submit();
                }
          }          
          break;
         
     case 'Find':     
          frm.action.value = "Edit";          
          break;
          
     case 'Delete':
          if (frm.mp.value.substr(3,1)=="0")
          {   alert("PERMISSION DENIED.\nCANNOT DELETE RECORD.");
              return 0;
          }
          var ans = confirm("ARE YOU SURE TO DELETE THIS RECORD?");
          if (ans)
          {    frm.action.value = "Delete";   
               frm.submit();
          }                      
          break;           
         
     case 'Reject' :
          if (frm.mp.value.substr(3,1)=="0")
          {   alert("PERMISSION DENIED.\nCANNOT REJECT RECORD.");
              return 0;
          }
          if (validatereject(frm.name, frm)) 
          {   var ans = confirm("ARE YOU SURE TO REJECT THIS APPLICATION?");
              if (ans)
              {   frm.elements["trnstatus"].value = "R";
                  frm.submit();
              }
          }
          break;
        
     case 'Cancel':  
          return ClearControls(frm);
          frm.action.value = "";
          break;
          
     case 'Clear':  
          return ClearControls(frm);
          frm.action.value = "";
          break;
          
     case 'Close':
          window.location = 'Blank.html'
          break;
   }
}  

function checkpermission(frm)
{   if (frm.mp.value.substr(4,1)=="0")
    {   alert("PERMISSION DENIED.\nCANNOT PROCESS TRANSACTION.");
        return false;
    }
}


/* ======================================================================
FUNCTION:   Calendar

INPUT:      

RETURN:     Calendar window

DESC:       Thsi functions will be used to show a calendar popup screen
====================================================================== */



function Calendar(p_item, p_WinCal, p_month, p_year, p_format) {
    if ((p_month == null) && (p_year == null))  return;

    if (p_WinCal == null)
        this.gWinCal = ggWinCal;
    else
        this.gWinCal = p_WinCal;
    
    if (p_month == null) {
        this.gMonthName = null;
        this.gMonth = null;
        this.gYearly = true;
    } 
    else 
    {
        this.gMonthName = Calendar.get_month(p_month);
        this.gMonth = new Number(p_month);
        this.gYearly = false;
    }

    this.gYear = p_year;
    this.gFormat = p_format;
    this.gBGColor = "white";
    this.gFGColor = "black";
    this.gTextColor = "black";
    this.gHeaderColor = "black";
    this.gReturnItem = p_item;
}
Calendar.get_month = Calendar_get_month;
Calendar.get_daysofmonth = Calendar_get_daysofmonth;
Calendar.calc_month_year = Calendar_calc_month_year;
Calendar.print = Calendar_print;

function Calendar_get_month(monthNo) 
{
    return Calendar.Months[monthNo];
}

function Calendar_get_daysofmonth(monthNo, p_year) 
{
    /* 
    Check for leap year ..
    1.Years evenly divisible by four are normally leap years, except for... 
    2.Years also evenly divisible by 100 are not leap years, except for... 
    3.Years also evenly divisible by 400 are leap years. 
    */
    if ((p_year % 4) == 0) {
        if ((p_year % 100) == 0 && (p_year % 400) != 0)
            return Calendar.DOMonth[monthNo];
    
        return Calendar.lDOMonth[monthNo];
    } 
    else
        return Calendar.DOMonth[monthNo];
}

function Calendar_calc_month_year(p_Month, p_Year, incr) {
    /* 
    Will return an 1-D array with 1st element being the calculated month 
    and second being the calculated year 
    after applying the month increment/decrement as specified by 'incr' parameter.
    'incr' will normally have 1/-1 to navigate thru the months.
    */
    var ret_arr = new Array();
    
    if (incr == -1) {
        // B A C K W A R D
        if (p_Month == 0) {
            ret_arr[0] = 11;
            ret_arr[1] = parseInt(p_Year) - 1;
        }
        else {
            ret_arr[0] = parseInt(p_Month) - 1;
            ret_arr[1] = parseInt(p_Year);
        }
    } 
    else if (incr == 1) {
        // F O R W A R D
        if (p_Month == 11) {
            ret_arr[0] = 0;
            ret_arr[1] = parseInt(p_Year) + 1;
        }
        else {
            ret_arr[0] = parseInt(p_Month) + 1;
            ret_arr[1] = parseInt(p_Year);
        }
    }
    
    return ret_arr;
}

function Calendar_print() {
    ggWinCal.print();
}

function Calendar_calc_month_year(p_Month, p_Year, incr) {
    /* 
    Will return an 1-D array with 1st element being the calculated month 
    and second being the calculated year 
    after applying the month increment/decrement as specified by 'incr' parameter.
    'incr' will normally have 1/-1 to navigate thru the months.
    */
    var ret_arr = new Array();
    
    if (incr == -1) {
        // B A C K W A R D
        if (p_Month == 0) {
            ret_arr[0] = 11;
            ret_arr[1] = parseInt(p_Year) - 1;
        }
        else {
            ret_arr[0] = parseInt(p_Month) - 1;
            ret_arr[1] = parseInt(p_Year);
        }
    } else if (incr == 1) {
        // F O R W A R D
        if (p_Month == 11) {
            ret_arr[0] = 0;
            ret_arr[1] = parseInt(p_Year) + 1;
        }
        else {
            ret_arr[0] = parseInt(p_Month) + 1;
            ret_arr[1] = parseInt(p_Year);
        }
    }
    
    return ret_arr;
}

// This is for compatibility with Navigator 3, we have to create and discard one object before the prototype object exists.
new Calendar();

Calendar.prototype.getMonthlyCalendarCode = function() {
    var vCode = "";
    var vHeader_Code = "";
    var vData_Code = "";
    
    // Begin Table Drawing code here..
    vCode = vCode + "<TABLE BORDER=1 BGCOLOR=\"" + this.gBGColor + "\">";
    
    vHeader_Code = this.cal_header();
    vData_Code = this.cal_data();
    vCode = vCode + vHeader_Code + vData_Code;
    
    vCode = vCode + "</TABLE>";
    
    return vCode;
}

Calendar.prototype.show = function() {
    var vCode = "";
    
    this.gWinCal.document.open();

    // Setup the page...
    this.wwrite("<html>");
    this.wwrite("<head><title>Calendar</title>");
    this.wwrite("</head>");

    this.wwrite("<body " + 
        "link=\"" + this.gLinkColor + "\" " + 
        "vlink=\"" + this.gLinkColor + "\" " +
        "alink=\"" + this.gLinkColor + "\" " +
        "text=\"" + this.gTextColor + "\">");
    this.wwriteA("<FONT FACE='" + fontface + "' SIZE=2><B>");
    this.wwriteA(this.gMonthName + " " + this.gYear);
    this.wwriteA("</B><BR>");

    // Show navigation buttons
    var prevMMYYYY = Calendar.calc_month_year(this.gMonth, this.gYear, -1);
    var prevMM = prevMMYYYY[0];
    var prevYYYY = prevMMYYYY[1];

    var nextMMYYYY = Calendar.calc_month_year(this.gMonth, this.gYear, 1);
    var nextMM = nextMMYYYY[0];
    var nextYYYY = nextMMYYYY[1];
    
    this.wwrite("<TABLE WIDTH='100%' BORDER=1 CELLSPACING=0 CELLPADDING=0 BGCOLOR='#e0e0e0'><TR><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"" +
        "javascript:window.opener.Build(" + 
        "'" + this.gReturnItem + "', '" + this.gMonth + "', '" + (parseInt(this.gYear)-1) + "', '" + this.gFormat + "'" +
        ");" +
        "\"><<<\/A>]</TD><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"" +
        "javascript:window.opener.Build(" + 
        "'" + this.gReturnItem + "', '" + prevMM + "', '" + prevYYYY + "', '" + this.gFormat + "'" +
        ");" +
        "\"><<\/A>]</TD><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"javascript:window.print();\">Print</A>]</TD><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"" +
        "javascript:window.opener.Build(" + 
        "'" + this.gReturnItem + "', '" + nextMM + "', '" + nextYYYY + "', '" + this.gFormat + "'" +
        ");" +
        "\">><\/A>]</TD><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"" +
        "javascript:window.opener.Build(" + 
        "'" + this.gReturnItem + "', '" + this.gMonth + "', '" + (parseInt(this.gYear)+1) + "', '" + this.gFormat + "'" +
        ");" +
        "\">>><\/A>]</TD></TR></TABLE><BR>");

    // Get the complete calendar code for the month..
    vCode = this.getMonthlyCalendarCode();
    this.wwrite(vCode);

    this.wwrite("</font></body></html>");
    this.gWinCal.document.close();
}

Calendar.prototype.showY = function() {
    var vCode = "";
    var i;
    var vr, vc, vx, vy;     // Row, Column, X-coord, Y-coord
    var vxf = 285;      // X-Factor
    var vyf = 200;      // Y-Factor
    var vxm = 10;           // X-margin
    var vym;            // Y-margin
    if (isIE)   vym = 75;
    else if (isNav) vym = 25;
    
    this.gWinCal.document.open();

    this.wwrite("<html>");
    this.wwrite("<head><title>Calendar</title>");
    this.wwrite("<style type='text/css'>\n<!--");
    for (i=0; i<12; i++) {
        vc = i % 3;
        if (i>=0 && i<= 2)  vr = 0;
        if (i>=3 && i<= 5)  vr = 1;
        if (i>=6 && i<= 8)  vr = 2;
        if (i>=9 && i<= 11) vr = 3;
        
        vx = parseInt(vxf * vc) + vxm;
        vy = parseInt(vyf * vr) + vym;

        this.wwrite(".lclass" + i + " {position:absolute;top:" + vy + ";left:" + vx + ";}");
    }
    this.wwrite("-->\n</style>");
    this.wwrite("</head>");

    this.wwrite("<body " + 
        "link=\"" + this.gLinkColor + "\" " + 
        "vlink=\"" + this.gLinkColor + "\" " +
        "alink=\"" + this.gLinkColor + "\" " +
        "text=\"" + this.gTextColor + "\">");
    this.wwrite("<FONT FACE='" + fontface + "' SIZE=2><B>");
    this.wwrite("Year : " + this.gYear);
    this.wwrite("</B><BR>");

    // Show navigation buttons
    var prevYYYY = parseInt(this.gYear) - 1;
    var nextYYYY = parseInt(this.gYear) + 1;
    
    this.wwrite("<TABLE WIDTH='100%' BORDER=1 CELLSPACING=0 CELLPADDING=0 BGCOLOR='#e0e0e0'><TR><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"" +
        "javascript:window.opener.Build(" + 
        "'" + this.gReturnItem + "', null, '" + prevYYYY + "', '" + this.gFormat + "'" +
        ");" +
        "\" alt='Prev Year'><<<\/A>]</TD><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"javascript:window.print();\">Print</A>]</TD><TD ALIGN=center>");
    this.wwrite("[<A HREF=\"" +
        "javascript:window.opener.Build(" + 
        "'" + this.gReturnItem + "', null, '" + nextYYYY + "', '" + this.gFormat + "'" +
        ");" +
        "\">>><\/A>]</TD></TR></TABLE><BR>");

    // Get the complete calendar code for each month..
    var j;
    for (i=11; i>=0; i--) {
        if (isIE)
            this.wwrite("<DIV ID=\"layer" + i + "\" CLASS=\"lclass" + i + "\">");
        else if (isNav)
            this.wwrite("<LAYER ID=\"layer" + i + "\" CLASS=\"lclass" + i + "\">");

        this.gMonth = i;
        this.gMonthName = Calendar.get_month(this.gMonth);
        vCode = this.getMonthlyCalendarCode();
        this.wwrite(this.gMonthName + "/" + this.gYear + "<BR>");
        this.wwrite(vCode);

        if (isIE)
            this.wwrite("</DIV>");
        else if (isNav)
            this.wwrite("</LAYER>");
    }

    this.wwrite("</font><BR></body></html>");
    this.gWinCal.document.close();
}

Calendar.prototype.wwrite = function(wtext) {
    this.gWinCal.document.writeln(wtext);
}

Calendar.prototype.wwriteA = function(wtext) {
    this.gWinCal.document.write(wtext);
}

Calendar.prototype.cal_header = function() {
    var vCode = "";
    
    vCode = vCode + "<TR>";
    vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Sun</B></FONT></TD>";
    vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Mon</B></FONT></TD>";
    vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Tue</B></FONT></TD>";
    vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Wed</B></FONT></TD>";
    vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Thu</B></FONT></TD>";
    vCode = vCode + "<TD WIDTH='14%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Fri</B></FONT></TD>";
    vCode = vCode + "<TD WIDTH='16%'><FONT SIZE='2' FACE='" + fontface + "' COLOR='" + this.gHeaderColor + "'><B>Sat</B></FONT></TD>";
    vCode = vCode + "</TR>";
    return vCode;
}

Calendar.prototype.cal_data = function() {
    var vDate = new Date();
    vDate.setDate(1);
    vDate.setMonth(this.gMonth);
    vDate.setFullYear(this.gYear);

    var vFirstDay=vDate.getDay();
    var vDay=1;
    var vLastDay=Calendar.get_daysofmonth(this.gMonth, this.gYear);
    var vOnLastDay=0;
    var vCode = "";

    /*
    Get day for the 1st of the requested month/year..
    Place as many blank cells before the 1st day of the month as necessary. 
    */

    vCode = vCode + "<TR>";
    for (i=0; i<vFirstDay; i++) {
        vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(i) + "><FONT SIZE='2' FACE='" + fontface + "'> </FONT></TD>";
    }

    // Write rest of the 1st week
    for (j=vFirstDay; j<7; j++) {
        vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j) + "><FONT SIZE='2' FACE='" + fontface + "'>" + 
            "<A HREF='#' " + 
                "onClick=\"self.opener.document." + this.gReturnItem + ".value='" + 
                this.format_data(vDay) + 
                "';window.close();\">" + 
                this.format_day(vDay) + 
            "</A>" + 
            "</FONT></TD>";
        vDay=vDay + 1;
    }
    vCode = vCode + "</TR>";

    // Write the rest of the weeks
    for (k=2; k<7; k++) {
        vCode = vCode + "<TR>";

        for (j=0; j<7; j++) {
            vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j) + "><FONT SIZE='2' FACE='" + fontface + "'>" + 
                "<A HREF='#' " + 
                    "onClick=\"self.opener.document." + this.gReturnItem + ".value='" + 
                    this.format_data(vDay) + 
                    "';window.close();\">" + 
                this.format_day(vDay) + 
                "</A>" + 
                "</FONT></TD>";
            vDay=vDay + 1;

            if (vDay > vLastDay) {
                vOnLastDay = 1;
                break;
            }
        }

        if (j == 6)
            vCode = vCode + "</TR>";
        if (vOnLastDay == 1)
            break;
    }
    
    // Fill up the rest of last week with proper blanks, so that we get proper square blocks
    for (m=1; m<(7-j); m++) {
        if (this.gYearly)
            vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j+m) + 
            "><FONT SIZE='2' FACE='" + fontface + "' COLOR='gray'> </FONT></TD>";
        else
            vCode = vCode + "<TD WIDTH='14%'" + this.write_weekend_string(j+m) + 
            "><FONT SIZE='2' FACE='" + fontface + "' COLOR='gray'>" + m + "</FONT></TD>";
    }
    
    return vCode;
}

Calendar.prototype.format_day = function(vday) {
    var vNowDay = gNow.getDate();
    var vNowMonth = gNow.getMonth();
    var vNowYear = gNow.getFullYear();

    if (vday == vNowDay && this.gMonth == vNowMonth && this.gYear == vNowYear)
        return ("<FONT COLOR=\"RED\"><B>" + vday + "</B></FONT>");
    else
        return (vday);
}

Calendar.prototype.write_weekend_string = function(vday) {
    var i;

    // Return special formatting for the weekend day.
    for (i=0; i<weekend.length; i++) 
    {
        if (vday == weekend[i])
            return (" BGCOLOR=\"" + weekendColor + "\"");
    }
    
    return "";
}

Calendar.prototype.format_data = function(p_day) {
    var vData;
    var vMonth = 1 + this.gMonth;
    vMonth = (vMonth.toString().length < 2) ? "0" + vMonth : vMonth;
    var vMon = Calendar.get_month(this.gMonth).substr(0,3).toUpperCase();
    var vFMon = Calendar.get_month(this.gMonth).toUpperCase();
    var vY4 = new String(this.gYear);
    var vY2 = new String(this.gYear.substr(2,2));
    var vDD = (p_day.toString().length < 2) ? "0" + p_day : p_day;

    switch (this.gFormat) {
        case "MM\/DD\/YYYY" :
            vData = vMonth + "\/" + vDD + "\/" + vY4;
            break;
        case "MM\/DD\/YY" :
            vData = vMonth + "\/" + vDD + "\/" + vY2;
            break;
        case "MM-DD-YYYY" :
            vData = vMonth + "-" + vDD + "-" + vY4;
            break;
        case "MM-DD-YY" :
            vData = vMonth + "-" + vDD + "-" + vY2;
            break;

        case "DD\/MON\/YYYY" :
            vData = vDD + "\/" + vMon + "\/" + vY4;
            break;
        case "DD\/MON\/YY" :
            vData = vDD + "\/" + vMon + "\/" + vY2;
            break;
        case "DD-MON-YYYY" :
            vData = vDD + "-" + vMon + "-" + vY4;
            break;
        case "DD-MON-YY" :
            vData = vDD + "-" + vMon + "-" + vY2;
            break;

        case "DD\/MONTH\/YYYY" :
            vData = vDD + "\/" + vFMon + "\/" + vY4;
            break;
        case "DD\/MONTH\/YY" :
            vData = vDD + "\/" + vFMon + "\/" + vY2;
            break;
        case "DD-MONTH-YYYY" :
            vData = vDD + "-" + vFMon + "-" + vY4;
            break;
        case "DD-MONTH-YY" :
            vData = vDD + "-" + vFMon + "-" + vY2;
            break;

        case "DD\/MM\/YYYY" :
            vData = vDD + "\/" + vMonth + "\/" + vY4;
            break;
        case "DD\/MM\/YY" :
            vData = vDD + "\/" + vMonth + "\/" + vY2;
            break;
        case "DD-MM-YYYY" :
            vData = vDD + "-" + vMonth + "-" + vY4;
            break;
        case "DD-MM-YY" :
            vData = vDD + "-" + vMonth + "-" + vY2;
            break;

        default :
            vData = vMonth + "\/" + vDD + "\/" + vY4;
    }

    return vData;
}

function Build(p_item, p_month, p_year, p_format) {
    var p_WinCal = ggWinCal;
    gCal = new Calendar(p_item, p_WinCal, p_month, p_year, p_format);

    // Customize your Calendar here..
    gCal.gBGColor="white";
    gCal.gLinkColor="black";
    gCal.gTextColor="black";
    gCal.gHeaderColor="darkgreen";

    // Choose appropriate show function
    if (gCal.gYearly)   gCal.showY();
    else    gCal.show();
}

function show_calendar() {
    /* 
        p_month : 0-11 for Jan-Dec; 12 for All Months.
        p_year  : 4-digit year
        p_format: Date format (mm/dd/yyyy, dd/mm/yy, ...)
        p_item  : Return Item.
    */

    p_item = arguments[0];
    if (arguments[1] == null)
        p_month = new String(gNow.getMonth());
    else
        p_month = arguments[1];
    if (arguments[2] == "" || arguments[2] == null)
        p_year = new String(gNow.getFullYear().toString());
    else
        p_year = arguments[2];
    if (arguments[3] == null)
        p_format = "MM/DD/YYYY";
    else
        p_format = arguments[3];

    vWinCal = window.open("", "Calendar", 
        "width=250,height=250,status=no,toolbar=no,resizable=no,top=200,left=200");
    vWinCal.opener = self;
    ggWinCal = vWinCal;

    Build(p_item, p_month, p_year, p_format);
}
/*
Yearly Calendar Code Starts here
*/
function show_yearly_calendar(p_item, p_year, p_format) {
    // Load the defaults..
    if (p_year == null || p_year == "")
        p_year = new String(gNow.getFullYear().toString());
    if (p_format == null || p_format == "")
        p_format = "MM/DD/YYYY";

    var vWinCal = window.open("", "Calendar", "scrollbars=yes");
    vWinCal.opener = self;
    ggWinCal = vWinCal;

    Build(p_item, null, p_year, p_format);
}

/* ======================================================================
FUNCTION:   s2n &n2s

INPUT:      

RETURN:     

DESC:       Function to encrypt and decrypt string
====================================================================== */

function s2n(t) 
{   num_out = "";
    str_in = escape(t);
    for(i = 0; i < str_in.length; i++) 
    {   num_out += str_in.charCodeAt(i) - 23;
    }
    return num_out
}

function n2s(t) 
{   str_out = "";
    num_out = t;  
    for(i = 0; i < num_out.length; i += 2) 
    {   num_in = parseInt(num_out.substr(i,[2])) + 23;
        num_in = unescape('%' + num_in.toString(16));
        str_out += num_in;
    }
    return unescape(str_out);
}

/* ======================================================================
FUNCTION:   isGreaterDate

INPUT:      startdate and enddate

RETURN:     Returns false if startdate is greater than enddate

DESC:       Function to Check if the startdate is greater than enddate

USAGE:      isGreaterDate(startdate,enddate)
====================================================================== */

function isGreaterDate(startdate,enddate)
{ var err = 0;
  date1 = startdate;
  startday    = date1.substring(0,2)
  startmonth  = date1.substring(3,5)
  startyear   = date1.substring(6,10)

  date2 = enddate;
  endday    = date2.substring(0,2)
  endmonth  = date2.substring(3,5)
  endyear   = date2.substring(6,10)

  if (startyear > endyear)
  {  err = 1;
  }
  else
  {  if (startyear == endyear)
     {  if (startmonth > endmonth)
        {  err = 1;
        }
        else
        {  if (startmonth == endmonth)
           {    if (startday > endday)
                {  err = 1;
                }
           }
        }
     }
  }
  
    if (err == 1 ) 
    {   return false;
    }
    else 
    {   return true;
    }  
}
  
/* ======================================================================
FUNCTION:   isLessDate

INPUT:      startdate and enddate

RETURN:     Returns false if startdate is Less than enddate

DESC:       Function to Check if the startdate is less than enddate

USAGE:      isLessDate(startdate,enddate)
====================================================================== */

function isLessDate(startdate,enddate)
{ var err = 0;
  date1 = startdate;
  startday    = date1.substring(0,2)
  startmonth  = date1.substring(3,5)
  startyear   = date1.substring(6,10)

  date2 = enddate;
  endday    = date2.substring(0,2)
  endmonth  = date2.substring(3,5)
  endyear   = date2.substring(6,10)

  if (startyear < endyear)
  {  err = 1;
  }
  else
  {  if (startyear == endyear)
     {  if (startmonth < endmonth)
        {  err = 1;
        }
        else
        {  if (startmonth == endmonth)
           {    if (startday < endday)
                {  err = 1;
                }
           }
        }
     }
  }  
    
    if (err == 1 ) 
    {   return false;
    }
    else 
    {   return true;
    }  
}


/* ======================================================================
FUNCTION:   isBetweenDates

INPUT:      referencedate,startdate,enddate

RETURN:     Returns false if referencedate is not in between startdate and enddate

DESC:       Function to Check if referencedate is in between startdate and enddate

USAGE:      isBetweenDates(refdate,startdate,enddate)
====================================================================== */

function isBetweenDates(checkdate,startdate,enddate)
{   var grerr = 1;
    var leerr = 1;
    
    date0 = checkdate;
    checkday    = date0.substring(0,2)
    checkmonth  = date0.substring(3,5)
    checkyear   = date0.substring(6,10)

    date1 = startdate;
    startday    = date1.substring(0,2)
    startmonth  = date1.substring(3,5)
    startyear   = date1.substring(6,10)

    date2 = enddate;
    endday    = date2.substring(0,2)
    endmonth  = date2.substring(3,5)
    endyear   = date2.substring(6,10)

    //Check if checkdate is greater than startdate
    if (checkyear > startyear)
    {  grerr = 0;
    }
    else
    {   if (checkyear == startyear)
        {   if (checkmonth > startmonth)
            {  grerr = 0;
            }
            else
            {   if (checkmonth == startmonth)
                {   if (checkday >= startday)
                    {  grerr = 0;
                    }
                }
            }
        }
    }
    
    //Check if checkdate is less than enddate

    if (checkyear < endyear)
    {  leerr = 0;
    }
    else
    {   if (checkyear == endyear)
        {   if (checkmonth < endmonth)
            {  leerr = 0;
            }
            else
            {   if (checkmonth == endmonth)
                {   if (checkday <= endday)
                    {  leerr = 0;
                    }
                }
            }
        }
    }  

    if (leerr == 1  || grerr == 1)
    {   return false;
    }
    else 
    {   return true;
    }  
}
  
/* ======================================================================
FUNCTION:   getdatediff

INPUT:      startdate and enddate

RETURN:     Returns difference in days between startdate and enddate

DESC:       Function to calculate difference between startdate and enddate

USAGE:      getdatediff(startdate,enddate)
====================================================================== */


function getdatediff(startdate,enddate)
{ var diff,t,t1,t2,date1,date2,newdate1,newdate2;
  var MinMilli = 1000 * 60;
  var HrMilli  = MinMilli * 60;
  var DyMilli  = HrMilli * 24;
  date1    = startdate;
  newdate1 = date1.substring(3,5) + '/' + date1.substring(0,2) + '/' + date1.substring(6,10)
  date2    = enddate;
  newdate2 = date2.substring(3,5) + '/' + date2.substring(0,2) + '/' + date2.substring(6,10)
  t1 = Date.parse(newdate1);
  t2 = Date.parse(newdate2);
  t = (t1 - t2);
  diff = Math.round(Math.abs(t / DyMilli));  
  return(diff);
}


function clearname(frm,field)
{   frm.elements[field.name].value = "";
}

/* ======================================================================
FUNCTION:   chequeAmount

INPUT:      amount

RETURN:     Amount Converted to words

DESC:       Function to convert amount into words

USAGE:      
====================================================================== */


function makeArray0()
{  for (i = 0; i<makeArray0.arguments.length; i++)
        this[i] = makeArray0.arguments[i];
}

var numbers = new makeArray0('','One','Two','Three','Four','Five','Six','Seven','Eight','Nine','Ten','Eleven','Twelve','Thirteen','Fourteen','Fifteen','Sixteen','Seventeen','Eighteen','Nineteen');

var numbers10 = new makeArray0('','Ten','Twenty','Thirty','Fourty','Fifty','Sixty','Seventy','Eighty','Ninety');

function chequeAmount(input) {
  var rupees = Math.floor(input);
  var paise = Math.round((input*100 - rupees*100));

  var hundredcrores = (rupees - rupees % 1000000000) / 1000000000;
  rupees -= hundredcrores * 1000000000;
  var crores = (rupees - rupees % 10000000) / 10000000;
  rupees -= crores * 10000000;
  var lakhs = (rupees - rupees % 100000) / 100000;
  rupees -= lakhs * 100000;
  var thousands = (rupees - rupees % 1000) / 1000;
  rupees -= thousands * 1000;
  var hundreds = (rupees - rupees % 100) / 100;
  rupees -= hundreds * 100;

  var output = '';
  output += ((hundredcrores > 0 || crores > 0 || lakhs > 0 || thousands > 0 || hundreds > 0 || rupees > 0) ? 'Rupees ' : '')
  output += (hundredcrores > 0 && crores > 0  ? fN(hundredcrores) + ' Hundred ' : '') +
            (hundredcrores > 0 && crores == 0 ? fN(hundredcrores) + ' Hundred Crores ' : '') +
            (crores > 0 ? fN(crores) + ' Crores ' : '') +
            (lakhs > 0 ? fN(lakhs) + ' Lakhs ' : '') +
            (thousands > 0 ? fN(thousands) + ' Thousand ' : '') +
            (hundreds > 0 ? fN(hundreds) + ' Hundred ' : '') +
            (rupees > 0 ? fN(rupees) + ' ' : '') +            
            ((Math.floor(input) > 0 && paise > 0) ? 'and ' : '') +
            (paise > 0 ? fN(paise) + ' Paise' : '');
 if (output !='') {output += ' Only';}  
  return output.substring(0,1).toUpperCase() + output.substring(1);
}

function fN(i) {
  if (i<20) return numbers[i];
  var tens = (i - i % 10) / 10, units = i - (i - i % 10);
  return numbers10[tens] + ((tens > 0 && units > 0) ? ' ' : '') + numbers[units];
}


/* ======================================================================
FUNCTION:   roundOff

INPUT:      numeric value having decimals

RETURN:     number rounded off to the given precision

DESC:       Function to Round Off the number

USAGE:      
====================================================================== */


function roundOff1(value, precision)
{       result = 0;
        if (!isNaN(value) && !isNaN(precision))
        {   value = parseFloat(value);
            precision = parseInt(precision);
           var whole = Math.round(value * Math.pow(10, precision))/Math.pow(10, precision);
            result = whole;
        }
        else
        {   alert("INVALID NUMERIC VALUE / PRECISION.");
        }
        return result;
}

/* ======================================================================
FUNCTION:   copy /paste

INPUT:      formname and requisite fields

DESC:       Function to copy and paste contents of one field to another

====================================================================== */

//Variables declaration for copy / paste function
var saddress1,saddress2,saddress3,scity,spincode,stelno,spanno1,spanno2;
var semailid , sfinacleclientid;

function CopyPaste(frm,btn)
{   var holder = btn.name.substr(7,2);
    switch (btn.name.substr(3,4))
    {   case 'Copy':            
            if( isEmpty(frm.elements[holder+'address1'].value) &&
                isEmpty(frm.elements[holder+'address2'].value) &&
                isEmpty(frm.elements[holder+'address3'].value) &&
                isEmpty(frm.elements[holder+'city'].value)     &&
                isEmpty(frm.elements[holder+'pincode'].value)  &&
                isEmpty(frm.elements[holder+'telno'].value)
              )   
            {   alert('NOTHING TO COPY');           
            }
            else
            {   saddress1 = frm.elements[holder+'address1'].value;
                saddress2 = frm.elements[holder+'address2'].value;
                saddress3 = frm.elements[holder+'address3'].value;
                scity     = frm.elements[holder+'city'].value; 
                spincode  = frm.elements[holder+'pincode'].value;
                stelno    = frm.elements[holder+'telno'].value;
            }
            break;
        
        case 'Past':
            if (isEmpty(saddress1) && isEmpty(saddress2) && isEmpty(saddress3) &&
                isEmpty(scity)     && isEmpty(spincode)  && isEmpty(stelno))
            {   alert('NOTHING TO PASTE');
            }
            else
            {   frm.elements[holder+'address1'].value = saddress1;
                frm.elements[holder+'address2'].value = saddress2;
                frm.elements[holder+'address3'].value = saddress3;
                frm.elements[holder+'city'].value     = scity;
                frm.elements[holder+'pincode'].value  = spincode;
                frm.elements[holder+'telno'].value    = stelno;
            }
            break;      

        case 'Undo':
            frm.elements[holder+'address1'].value = "";
            frm.elements[holder+'address2'].value = "";
            frm.elements[holder+'address3'].value = "";
            frm.elements[holder+'city'].value     = "";
            frm.elements[holder+'pincode'].value  = "";
            frm.elements[holder+'telno'].value    = "";
            frm.elements[holder+'emailid'].value  = "";
            frm.elements[holder+'panno1'].value   = "";
            frm.elements[holder+'panno2'].value   = "";
            frm.elements[holder+'finacleclientid'].value   = "";
            break;  
    }
}


//ENDS HERE
//*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/*/
//

function chkstatus(frm,frmelement)
{   if (document.forms[0].elements["action"].value !="Edit")
    {    frmelement.blur();
         //frm.btnaction1.focus();
    }
}

function chkaction(frm,frmelement)
{   if (document.forms[0].elements["action"].value =="Edit")
    {    frmelement.blur();         
    }
}

function CallXML(sURL)
{   document.body.style.cursor='wait';


    // Create an instance of the XML HTTP Request object
    var oXMLHTTP = new ActiveXObject("Microsoft.XMLHTTP");

    oXMLHTTP.open("POST", sURL, false );

    // Execute the request
    oXMLHTTP.send();

    document.body.style.cursor='auto';
    
    return oXMLHTTP.responsetext;
}

  function now() 
{ 
	var stDate; 
	var now; 
	now_date= new Date(); 
	stDate=(now_date.getMonth()+1)+"/"+now_date.getDate()+"/"+now_date.getYear(); 
	return(stDate); 
} 

function IsEmail(sFieldValue)
{
	var checkEmail = "@.";
	var checkStr = sFieldValue;
	var EmailValid = false;
	var EmailAt = false;
	var EmailPeriod = false;

	for (i = 0;  i < checkStr.length;  i++)
	{
		ch = checkStr.charAt(i);
		for (j = 0;  j < checkEmail.length;  j++)
		{
			if (ch == checkEmail.charAt(j) && ch == "@")
				EmailAt = true;
			if (ch == checkEmail.charAt(j) && ch == ".")
				EmailPeriod = true;
			if (EmailAt && EmailPeriod)
				break;
			if (j == checkEmail.length)
				break;
		}
		// if both the @ and . were in the string
		if (EmailAt && EmailPeriod)
		{
			EmailValid = true
			break;
		}
	}

	return(EmailValid);
}

function IsNumeric(sFieldValue)
{
	var checkOK = "0123456789.";
	var checkStr = sFieldValue;
	var allValid = true;
	var allNum = "";

	if (checkStr=="")
	{
		return(false);
	}
	for (i = 0;  i < checkStr.length;  i++)
	{
		ch = checkStr.charAt(i);

		for (j = 0;  j < checkOK.length;  j++)
		{
			if (ch == checkOK.charAt(j))
				break;
		}
		
		if (j == checkOK.length)
		{
			allValid = false;
			break;
		}

		if (ch != ",")
		{
			allNum += ch;
		}

		if (!allValid)
		{
			allValid =false;
		}
	}

	return(allValid);
}
function IsDate(sFieldValue)
{
	var checkOK = "0123456789/";
	var checkStr = sFieldValue;
	var allValid = true;
	var allNum = "";

	if (checkStr=="")
	{
		return(false);
	}
	for (i = 0;  i < checkStr.length;  i++)
	{
		ch = checkStr.charAt(i);

		for (j = 0;  j < checkOK.length;  j++)
		{
			if (ch == checkOK.charAt(j))
				break;
		}
		
		if (j == checkOK.length)
		{
			allValid = false;
			break;
		}

		if (ch != ",")
		{
			allNum += ch;
		}

		if (!allValid)
		{
			allValid =false;
		}
	}

	return(allValid);
}
function IsAlpha(sFieldValue)
{
	var checkOK = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
	var checkStr = sFieldValue;
	var allValid = true;
	var allNum = "";

	if (checkStr=="")
	{
		return(false);
	}
	for (i = 0;  i < checkStr.length;  i++)
	{
		ch = checkStr.charAt(i);

		for (j = 0;  j < checkOK.length;  j++)
		{
			if (ch == checkOK.charAt(j))
				break;
		}
		
		if (j == checkOK.length)
		{
			allValid = false;
			break;
		}

		if (!allValid)
		{
			allValid =false;
		}
	}

	return(allValid);
}

function FieldValidation(sFieldName, sFieldValue, sRule, bRequired, maxLength)
{
	var sErrorMessage;
	
	sErrorMessage="";

	if (sFieldValue.length>0)
	{
	switch(sRule)
	{
		case "Numeric":
			if (IsNumeric(sFieldValue)==false)
			{
				sErrorMessage+=sFieldName + " is not numeric <br>";
			}
			break;
		case "Date":
			if (IsDate(sFieldValue)==false)
			{
				sErrorMessage+=sFieldName + " is not a Date <br>";
			}
			break;
		case "Alpha":
			if (IsAlpha(sFieldValue)==false)
			{
				sErrorMessage+=sFieldName + " is not alpha numeric <br>";
			}
			break;
		case "Email":
			if (IsEmail(sFieldValue)==false)
			{
				sErrorMessage+=sFieldName + " is not an email <br>";
			}
			break;
	}
	}
	
	/*------------------------------------------check if field is required---------------------------*/
	if ( (bRequired==true) && (sFieldValue!=""))
	{
		if (sFieldValue.length==0)
		{
			sErrorMessage+=sFieldName + " is required <br>";
		}
	}	
	else if ( (bRequired==true) && (sFieldValue==""))
	{
		sErrorMessage+=sFieldName + " is required <br>";
	}
	/*------------------------------------check for maxlength--------------------------------------*/
	if ((sFieldValue!="") && (maxLength>0))
	{
		if (sFieldValue.length>maxLength)
		{
			sErrorMessage+=sFieldName + " exceeded the maximum length of " + maxLength + " characters <br>";
		}
	}

	return(sErrorMessage);
}
function displayErrorMessage(sErrorMsg) 
{
win = window.open(",", 'popup', 'height = 200 width=200 toolbar = yes  titlebar=yes status = no resizeable=yes scrollbars=yes');
win.document.write("Data Validation Errors<br>");
win.document.write("" + sErrorMsg + "");
}

function now()
{
	var stDate;
	var now;
	now= new Date();
	stDate=(now.getMonth()+1)+"/"+now.getDate()+"/"+now.getYear();
	return(stDate);
}
function dayOfWeek(sDay)
{
	var stDate;
	var now;
	var assoc= new Array(7);

	assoc[0]="Sunday";
	assoc[1]="Monday";
	assoc[2]="Tuesday";
	assoc[3]="Wednesday";
	assoc[4]="Thursday";
	assoc[5]="Friday";
	assoc[6]="Saturday";

	now= new Date(sDay);
	stDate=now.getDay();
	return(assoc[stDate]);
}
function systemTime()
{
	var now;
	var stTime;
	now= new Date();
	if (now.getHours()>12)
	{
		stTime=(now.getHours()-12)+":"+now.getMinutes()+":"+now.getSeconds()+" p.m";
	}
	else
	{
		stTime=now.getHours()+":"+now.getMinutes()+":"+now.getSeconds()+ "a.m";
	}
	return(stTime);
}

function dateAdd(startDate, numDays, numMonths, numYears)
{
	var returnDate;
	var yearsToAdd;
	var month;

	returnDate = new Date(startDate.getTime());

	yearsToAdd=numYears;
	
	month = returnDate.getMonth()+ numMonths;
	
	if (month > 11)
	{
		yearsToAdd = Math.floor((month+1)/12);
		month -= 12*yearsToAdd;
		yearsToAdd += numYears;
	}
	returnDate.setMonth(month);
	returnDate.setFullYear(returnDate.getFullYear()	+ yearsToAdd);
	
	returnDate.setTime(returnDate.getTime()+60000*60*24*numDays);

	return returnDate;

}

function yearAdd(startDate, numYears)
{
		return dateAdd(startDate,0,0,numYears);
}

function monthAdd(startDate, numMonths)
{
		return dateAdd(startDate,0,numMonths,0);
}

function dayAdd(startDate, numDays)
{
		return dateAdd(startDate,numDays,0,0);
}

function getEndWorkDay(StartDate, Hours)
{
    var iHoursToDays;
    var iCount;
    var bFlag;
    var EndDate;
    var CheckDate;
    var iFoundCount;
    var sDay;
    var RetDate;

		StartDate=new Date(StartDate);    
        iHoursToDays = Math.ceil(eval(parseFloat(Hours) / 8.0));
        EndDate = StartDate;
        
        if (iHoursToDays > 1)
        {
            bFlag = false;
            iCount = 0;
            iFoundCount = 0;
            while (bFlag == false)
            {
               CheckDate = dayAdd(StartDate,iCount);
               sDay = dayOfWeek(CheckDate);
               if ((sDay != 'Sunday') && (sDay != 'Saturday'))
               {
                    EndDate = CheckDate;
                    iFoundCount = iFoundCount + 1;
               }
               if (iFoundCount >= iHoursToDays)
               {
                    break;
               }
               iCount = iCount + 1;
            }
        }

		RetDate=(EndDate.getMonth()+1)+"/"+EndDate.getDate()+"/"+EndDate.getYear();
        return(RetDate);
}

function CheckDateCharacters(txt){
  if (event.keyCode < 48 || event.keyCode > 57) {
     if(event.keyCode != 47){
        event.returnValue=false;
     }
  }
  if(event.returnValue!=false){
     if(txt.value.length==2 || txt.value.length==5) {
        txt.value = txt.value + "/"
     }
  }
};

function ValidateDate1(txt){
  var dt = txt.value.split("/")
  if(txt.value=="") 
     return false;
  else {          
     if(dt.length!=3){
        alert("Invalid Date");
        txt.focus();
     }
     else {
        if(dt[0]<1 || dt[0] >31){
           alert("Invalid Day");
           txt.focus();
        }
        else{
           if(dt[1]<1 || dt[1] >12) {
              alert("Invalid Month");
              txt.focus();
           }
           else {
              if(dt[2].length!=4){
                 alert("Year must in YYYY format");
                 txt.focus();
              }
           }
        }
     }
  }
};

function ValidateDate(txt){
  var dt = txt.value.split("/")
  if(txt.value=="") 
     return false;
  else {          
     if(dt.length!=3){
        alert("Invalid Date");
        txt.focus();
     }
     else {
        var vDateValueCheck = dt[0]+strSeperator+dt[1]+strSeperator+dt[2];
        if (dt[2].length == 2)
        {   //Turn a two digit year into a 4 digit year
            var mToday = new Date();
            //If the year is greater than 30 years from now use 19, otherwise use 20
            var checkYear = mToday.getFullYear() + 30;
            var mCheckYear = '20' + dt[2];
            if (mCheckYear >= checkYear)
                mYear = '19' + dt[2];
            else
                mYear = '20' + dt[2];
            vDateValueCheck = dt[0]+strSeperator+dt[1]+strSeperator+mYear;
        }
        txt.value = vDateValueCheck
        
        if (!EmberDateValidCheck(dt))
        {   alert("Invalid Date\nFormat - DD/MM/YYYY");
            txt.select();
            txt.focus();
            return false;
        }
     }
  }
}

function EmberDateValidCheck(dt)
{   var intday;
    var intMonth;
    var intYear;

    intday = parseInt(dt[0], 10);
    if (isNaN(intday))
    {   err = 2;
        return false;
    }
    intMonth = parseInt(dt[1], 10);
    if (isNaN(intMonth))
    {   err = 3;
        return false;
    }

    intYear = parseInt(dt[2], 10);
    if (isNaN(intYear))
    {   err = 4;
        return false;
    }
    if (intMonth>12 || intMonth<1)
    {   err = 5;
        return false;
    }
    if ((intMonth == 1 || intMonth == 3 || intMonth == 5 || intMonth == 7 || intMonth == 8 || intMonth == 10 || intMonth == 12) && (intday > 31 || intday < 1))
    {   err = 6;
        return false;
    }
    if ((intMonth == 4 || intMonth == 6 || intMonth == 9 || intMonth == 11) && (intday > 30 || intday < 1))
    {   err = 7;
        return false;
    }
    if (intMonth == 2)
    {   if (intday < 1)
        {   err = 8;
            return false;
        }
        if (LeapYear(intYear) == true)
        {   if (intday > 29)
            {   err = 9;
                return false;
            }
        }
        else
        {   if (intday > 28)
            {   err = 10;
                return false;
            }
        }
    }
return true;
}


//End-->

