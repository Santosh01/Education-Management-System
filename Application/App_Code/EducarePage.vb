Imports System
Imports System.Data
Imports System.Data.OleDb

'<AjaxPro.AjaxNamespace("AspDotNetForm")> _
Public Class EducarePage
    Inherits System.Web.UI.Page


    Private _ErrorMessage As String = ""
    Private _PageMenuID As String = ""

    Public Property ErrorMessage() As String
        Get
            Return _ErrorMessage
        End Get
        Set(ByVal value As String)
            _ErrorMessage = value
        End Set
    End Property

    Public Property PageMenuID() As String
        Get
            Return _PageMenuID
        End Get
        Set(ByVal value As String)
            _PageMenuID = value
        End Set
    End Property

    Private Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Page.ClientScript.RegisterClientScriptInclude("Functions", "JavaScripts/Functions.js")
        Page.ClientScript.RegisterClientScriptInclude("Functions", "JavaScripts/Common.js")
    End Sub

    Public Sub DisplayCustomMessageSummary(Optional ByVal message As String = "")
        message = Replace(message, ChrW(10), "\n")
        message = Replace(message, ChrW(13), "")
        message = Replace(message, "'", "")
        ScriptManager.RegisterClientScriptBlock(Me, Me.GetType, "Message", "alert('" & message & "');", True)
    End Sub

    Public Enum TextType
        NumericField = 1
        AmountField = 2
        CharacterField = 3
        AlphNumericField = 4
        TelephoneField = 5
        'EmailField = 6
        RemarkField = 7
        UpperCase = 8
        LowerCase = 9
        DateField = 10
        'DateTimeField = 11
    End Enum

    Public Sub SetValueType(ByVal TextAppreance As TextType, ByVal field As TextBox)
        Dim num As String
        Dim amt As String
        Dim upp As String
        Dim low As String
        Dim spl As String
        Dim tel As String

        num = "0123456789"
        amt = "0123456789."
        upp = "ABCDEFGHIJKLMNOPQRSTUVWXYZ.` "
        low = "abcdefghijklmnopqrstuvwxyz.` "
        tel = "0123456789()+- ,"
        spl = "@!#$%&*()_+:?><./[]\=-1`~"

        'removed |; from spl variable because it is used internally in javascript for master detail form.

        Select Case TextAppreance
            Case TextType.NumericField
                field.Attributes.Add("onkeypress", "var str='" & num & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}")
            Case TextType.AmountField
                field.Attributes.Add("onkeypress", "var str='" & amt & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}else {var str = this.value.split('.');if(str.length>=2 && event.keyCode==46){event.returnValue=false}}")
                field.Attributes.Add("onfocusout", "if (this.value!=''){ this.value = roundOff(this.value, 2);}")
            Case TextType.CharacterField
                field.Attributes.Add("onkeypress", "var str='" & upp + low & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}")
            Case TextType.AlphNumericField
                field.Attributes.Add("onkeypress", "var str='" & upp + low + amt & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}")
            Case TextType.TelephoneField
                field.Attributes.Add("onkeypress", "var str='" & tel & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}")
                'Case TextType.EmailField
            Case TextType.RemarkField
                field.Attributes.Add("onkeypress", "var str='" & upp + low + amt + spl & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}")
            Case TextType.UpperCase
                'field.Attributes.Add("onkeypress", "var str='" & upp & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}")
                field.Attributes.Add("onblur", "this.value = this.value.toUpperCase()")
            Case TextType.LowerCase
                field.Attributes.Add("onkeypress", "var str='" & low & "';if(str.indexOf(String.fromCharCode(event.keyCode))==-1){event.returnValue = false;}")
            Case TextType.DateField
                field.Attributes.Add("onkeypress", "CheckDateCharacters(this);")
                field.Attributes.Add("onblur", "ValidateDate(this);")
                'Case TextType.DateTimeField
        End Select
    End Sub

    Protected Class UpdProgress
        Implements ITemplate

        Dim _Message As String

        Public Sub New()
            _Message = "Processing Request..."
        End Sub

        Public Sub New(ByVal message As String)
            _Message = message
        End Sub

        Public Sub InstantiateIn(ByVal container As System.Web.UI.Control) Implements System.Web.UI.ITemplate.InstantiateIn
            Dim lc As LiteralControl = New LiteralControl
            lc.Text = "<li>" & _Message & "</li>"
            container.Controls.Add(lc)
        End Sub
    End Class

    Private Sub Page_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PreRender
        
    End Sub
End Class


