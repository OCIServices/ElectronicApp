<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="ElectronicApp.BrokerAdmin.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <script language="javascript" type="text/javascript" src="../Validation/validationHelpers.js"></script>
    <title>Broker Administration Portal</title>

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
            <div id="FormTop"><h1 id="header" runat = "server"><span class="red">Welcome</span> </h1></div>
            <div id="FormMid"> 
                <p>Welcome to your Online Health Insurance Portal.  Here you can modify your contact information and picture, 
                    enter a new group, and see submitted applications from your clients.
                </p>
                <br />
                
                <div id="newmsg" runat="server" style="width: 70%; float:left; margin-left: 60px; display:none; border-color: #d6d549; background-color: #fffd7d; border: 3px solid #d6d549; padding: 8px; border-radius: 8px; -moz-border-radius: 8px; -webkit-border-radius: 8px;"></div>
                <div class="clearFloat"></div>
                
                <h2><p><span class="red">Your Contact Card</span></p></h2>
                <table style="border: 1px solid; padding-right: 5px; margin-right: 31px; margin-left: 31px; margin-bottom: 0px;">
                   <tr>
                       <td class="style1" rowspan="5">
                           <asp:Image ID="Image1" runat="server" AlternateText="Broker Image" ImageUrl="../BrokerImages/default.jpeg"/>
                           <!--img alt="Broker Image" src="BrokerImages/default.jpeg" style="height: 96px; width: 96px"-->
                       </td>
                       <td class="style8">
                           <asp:label ID="Label3" CssClass="labelRight" runat="server" Text="Name:"></asp:label>                       </td>
                       <td class="style7" runat="server" id="BrokerName">
                           </td>
                   </tr>
                   <tr>
                       <td class="style8">
                           <asp:label ID="Label2" CssClass="labelRight" runat="server" Text="Email:"></asp:label></td>
                       <td class="style7" runat="server" id="BrokerEmail"></td>
                   </tr>
                   <tr>
                       <td class="style4">
                           <asp:label ID="Label1" CssClass="labelRight" runat="server" Text="Phone:"></asp:label>
                       </td>
                       <td class="style7" runat="server" id="BrokerPhone"></td>
                   </tr>
                   <tr>
                       <td class="style5"><asp:label ID="Label5" CssClass="labelRight" runat="server" Text="Fax:"></asp:label></td>
                       <td class="style2" runat="server" id="BrokerFax"></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label4" CssClass="labelRight" runat="server" Text = "Address:"></asp:label></td>
                       <td class="style3" runat="server" id="BrokerAddress"></td>
                   </tr>
               </table>
               <p><a href="EditInfo.aspx"><small>Edit Info/Change Password</small></a></p>
               <br />
               <br />
               <h2><p><span class="red">New Groups</span></p></h2>
                <p>Click the link below to enter a new group.</p>
                <p><a href="GroupAdd.aspx">Add New Group</a></p>
               <br />
               <br />
               <h2><p><span class="red">Client Information</span></p></h2>
               <p>You can view submissions and edit a client's contact information here.</p>
                
               <table style="width: 100%; margin-left: 31px; margin-bottom: 0px;" runat="server" id="ClientApp">
               <tr><td><asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ID="DropDownList1" runat="server">
                    </asp:DropDownList></td></tr>
               </table>
               <br />
               <br />
                <h2><p><span class="red">Done?</span></p></h2>
                <p>When you are finished, please click the link below and then close your browser to protect the integrity of your account.</p>
                <p><a href="../SessionDestroy.aspx">Log Out</a></p>
                
                
                <div class="clearFloat">
                    
                    </div>
            </div>
            <div id="FormBottom"></div>
        </div>
    </form>
</body>
</html>
