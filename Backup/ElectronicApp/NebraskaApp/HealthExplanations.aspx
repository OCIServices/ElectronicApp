<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="HealthExplanations.aspx.cs" Inherits="ElectronicApp.NebraskaApp.HealthExplanations" EnableViewState="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <script language="javascript" type="text/javascript" src="Validation/HealthExplanations/ValidateHealthExplanations.js"></script>
    <script language="javascript" type="text/javascript" src="Validation/validationHelpers.js"></script>
    <title></title>
    <style type="text/css">
        #test
        {
            width: 731px;
            margin-left: 17px;
            margin-top: 0px;
            margin-bottom: 0px;
        }
        #Table2
        {
            margin-left: 20px;
        }
        #Table4
        {
            margin-left: 25px;
        }
        #test1
        {
            margin-left: 20px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
     <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Health</span> Statements</h1></div>
           <div id="FormMid"> 
               <table style="width: 100%; margin-left: 15px;">
                   <tr>
                       <td>
                           <asp:Label ID="Label1" runat="server" CssClass="tableTitle" Text="Section 3"></asp:Label>
                       </td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
                   <tr>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                       <td>
                           &nbsp;</td>
                   </tr>
               </table>
               <br />
               <asp:PlaceHolder runat="server" ID="c_placeHolder"></asp:PlaceHolder>
        <br />
        <asp:Label ID="c_resultLabel" runat="server"></asp:Label><br />
        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
               
               
               <br />
           <%--<asp:Button ID="Button1" runat="server" Text="Back" onclick="Button1_Click" CssClass="btnLogin" />
               <asp:Button ID="Button2" runat="server" Text="Button" CssClass="btnLogin"/>--%>
               <asp:Button ID="btnNext" runat="server" Height="30px" 
                   style="margin-right: 40px; margin-top: 22px;" Text="Next" Width="70px" onclick="btnNext_Click" 
                   CssClass="btnLogin" />
                <div class="clearFloat"></div>
               
               
    </div>
            <div id="FormBottom"></div>
    </div>
    </form>
</body>
</html>
