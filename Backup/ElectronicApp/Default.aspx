<%@ Page Language="C#" Theme="LoginPage" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ElectronicApp._Default"  EnableSessionState="True" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        #Text1
        {
            width: 294px;
        }
        #User
        {
            width: 400px;
        }
        .style1
        {
            width: 162px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="LoginContainer">
    
        <div id="LoginTop"><h1><span class="red">e</span>-ENROLL</h1></div>
                    
        <div id="LoginMid">

            <label class="txtLogin">User Name:</label>
  
                <asp:TextBox ID="txtUserName" runat="server" Width="300px" 
                BorderColor="#666666" BorderStyle="Solid" CssClass="txtLogin" 
                BorderWidth="1px"></asp:TextBox>
                          <div class="clearFloat"></div>
                <label class="txtLogin">Password:</label>

                <asp:TextBox ID="txtPassword" TextMode="password" runat="server" Width="300px" 
                BorderColor="#666666" BorderStyle="Solid" CssClass="txtLogin" 
                BorderWidth="1px">txtPassword</asp:TextBox>
                <table style="width:100%;">
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                <div class="clearFloat"></div>
            <asp:ImageButton ID="ImageButton1" runat="server" 
                ImageUrl="~/App_Themes/LoginPage/Images/button(3).gif" CssClass="btnLogin" onclick="ImageButton1_Click" 
                />
</div>
        <div id="LoginBottom">
            
        </div>
        
    </div>
    </form>
</body>
</html>
