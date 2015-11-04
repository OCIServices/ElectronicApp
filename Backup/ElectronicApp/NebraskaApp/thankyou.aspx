<%@ Page Language="C#" AutoEventWireup="true" Theme="FormPage" CodeBehind="thankyou.aspx.cs" Inherits="ElectronicApp.NebraskaApp.thankyou" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Thank You</title>
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
        <div id="FormTop"><h1>Thank You</h1></div>
           <div id="FormMid">
           <br />
           <h2 style="margin-left: 30px"><span class="red">We have recieved your application and have logged you out</span></h2>
           <p>Please close all browser windows to help protect your privacy.</p>
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
           <br />
                      
           <h2><p>If you have further questions please contact your agent</p></h2>
               <br />
               <table style="width: 100%; margin-left: 31px; margin-bottom: 0px;" 
                     id="BrokerInfo" runat="server">
                   <tr>
                       <td class="style1" rowspan="5">
                          <asp:Image ID="Image1" runat="server" AlternateText="Broker Image" 
                          ImageUrl="../BrokerImages/default.jpeg" />
&nbsp;</td>
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
                       <td class="style5"><asp:label ID="Label45" CssClass="labelRight" runat="server" Text="Fax:"></asp:label></td>
                       <td class="style2" runat="server" id="BrokerFax"></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label ID="Label46" CssClass="labelRight" runat="server" Text = "Address:"></asp:label></td>
                       <td class="style3" runat="server" id="BrokerAddress"></td>
                   </tr>
                   <tr>
                       <td class="style6">&nbsp;</td>
                       <td class="style6">&nbsp;</td>
                       <td class="style3" runat="server" id="BrokerAddress2"></td>
                   </tr>
               </table>
           
                         <div class="clearFloat"></div>
           </div>
                   <div id="FormBottom"></div>
     </div>
    </form>
</body>
</html>