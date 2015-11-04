<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="EditInfo.aspx.cs" Inherits="ElectronicApp.BrokerAdmin.EditInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title>Edit Broker Information</title>

    <style type="text/css">
        .style1
        {
            width: 109px;
        }
        .style2
        {
            height: 6px;
            width: 1459px;
        }
        .style3
        {
            height: 5px;
            width: 1459px;
        }
        .style4
        {
            width: 58px; 
            font-weight: bold;
        }
        .style5
        {
            height: 6px;
            width: 58px;
            font-weight: bold;
        }
        .style6
        {
            height: 5px;
            width: 58px;
            font-weight: bold;
        }
        .style7
        {
            width: 1459px;
        }
        .style8
        {
            width: 58px;
            font-weight: bold;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
     <div id="FormContainer">
        <div id="FormTop"><h1 id="header" runat = "server"><span class="red">Edit Contact Card</span> </h1></div>
           <div id="FormMid">
               
               
           <h2><p><span class="red">Your Contact Card</span></p></h2>
               <br />
               <table style="width: 100%; margin-left: 31px; margin-bottom: 0px;">
                   <tr>
                       <td class="style1" rowspan="11">
                           <asp:Image ID="Image1" runat="server" AlternateText="Broker Image" ImageUrl="../BrokerImages/default.jpeg"/>
                           &nbsp;</td>
                       <td class="style8">
                           <asp:label ID="Label3" CssClass="labelRight" runat="server" Text="Name:"></asp:label>                       </td>
                       <td class="style7" runat="server">
                           <asp:TextBox ID="BrokerFirstName" MaxLength="50" runat="server"></asp:TextBox> <asp:TextBox ID="BrokerLastName" MaxLength="50" runat="server"></asp:TextBox>
                           </td>
                   </tr>
                   <tr>
                       <td class="style8">
                           <asp:label ID="Label2" CssClass="labelRight" runat="server" Text="Email:"></asp:label></td>
                       <td class="style7" runat="server">
                           <asp:TextBox ID="BrokerEmail" MaxLength="100" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="style4">
                           <asp:label ID="Label1" CssClass="labelRight" runat="server" Text="Phone:"></asp:label>
                       </td>
                       <td class="style7" runat="server">
                           <asp:TextBox ID="BrokerPhone" MaxLength="15" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="style5"><asp:label ID="Label5" CssClass="labelRight" runat="server" Text="Fax:"></asp:label></td>
                       <td class="style2" runat="server">
                           <asp:TextBox ID="BrokerFax" MaxLength="15" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label4" CssClass="labelRight" runat="server" Text = "Address:"></asp:label></td>
                       <td id="Td2" class="style3" runat="server">
                           <asp:TextBox ID="BrokerAddress" MaxLength="50" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label7" CssClass="labelRight" runat="server" Text = "City:"></asp:label></td>
                       <td id="Td3" class="style3" runat="server">
                           <asp:TextBox ID="BrokerCity" MaxLength="50" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label8" CssClass="labelRight" runat="server" Text = "State:"></asp:label></td>
                       <td id="Td4" class="style3" runat="server">
                           <asp:TextBox ID="BrokerState" MaxLength="2" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label9" CssClass="labelRight" runat="server" Text = "Zip:"></asp:label></td>
                       <td id="Td5" class="style3" runat="server">
                           <asp:TextBox ID="BrokerZip" MaxLength="5" runat="server"></asp:TextBox></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label6" CssClass="labelRight" runat="server" Text = "New Picture:"></asp:label><asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
                       <td id="Td1" class="style3" runat="server">
                           <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label10" CssClass="labelRight" runat="server" Text = "Username:"></asp:Label></td>
                       <td id="Td6" class="style3" runat="server">
                           <asp:Label ID="username" runat="server"></asp:Label>
                       </td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label11" CssClass="labelRight" runat="server" Text = "Username:"></asp:Label></td>
                       <td id="Td7" class="style3" runat="server">
                           <asp:TextBox ID="Password" runat="server"></asp:TextBox>
                           <asp:Label ID="lblMessage2" runat="server" ForeColor="Red" Visible="False"></asp:Label>
                       </td>
                   </tr>
               </table>
               <br />
               <br />
               <br />
               <asp:Button ID="Button2" runat="server" BackColor="#CCCCCC" 
                 BorderColor="#CCCCCC" style="margin-left: 58px" 
                 Text="Cancel" Width="154px" Font-Bold="False" ForeColor="Black" 
                 Height="26px" onclick="Button2_Click" />
               
               
              
               <asp:Button ID="Button1" runat="server" BackColor="#CCCCCC" 
                 BorderColor="#CCCCCC" style="margin-left: 58px" 
                 Text="Update" Width="154px" Font-Bold="False" ForeColor="Black" 
                 Height="26px" onclick="Button1_Click" />
               
               
              
                <div class="clearFloat"></div>
               
            </div>
                    <div id="FormBottom"></div>
        </div>
    </form>
</body>
</html>