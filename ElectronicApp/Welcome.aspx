<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="ElectronicApp.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">

    <title></title>

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
           <p>Welcome to your Online Health Insurance Enrollment.  By using an online enrollment process we will be able to quickly submit your applications to multiple insurance companies to receive quotes without you needing to fill out multiple applications.
               </p>
                 <br />
                 <h2><p><span class="red">Required Information Checklist</span></p></h2>
               <p>Please have the following information on hand to help the application process go smoothly</p>
               <br />
                    <ul style="margin-left: 68px">
                        <li>Social Security Numbers, height, weight, and birthdates for yourself and any dependents applying for coverage</li>
                        <li>Health History and medications for yourself and any dependents applying for coverage</li>
                        <li>Information regarding previous Health Coverage or any coverage remaining in force in addition to coverage you are applying for</li>
                    </ul>
               <br />
               <br />
                 <h2><p><span class="red">System Requirements</span></p></h2>
               <p>Please have the following information on hand to help the application process go smoothly</p>
               <br />
                    <ul style="margin-left: 68px">
                        <li>Javascript and cookies must be enabled</li>
                        <li>Adobe Reader must be installed <a href="http://get.adobe.com/reader/" target="_blank">(Get Adobe Reader)</a></li>
                    </ul>
               <br />
               <br />
               <asp:Button ID="Button1" runat="server" BackColor="#CCCCCC" 
                 BorderColor="#CCCCCC" style="margin-left: 58px" 
                 Text="Begin Enrollment" Width="154px" Font-Bold="False" ForeColor="Black" 
                 Height="26px" onclick="Button1_Click" />
               <br />
               <br />
               <br />
               <h2><p>Your Agent's Information:</p></h2>
               <br />
               <table style="width: 100%; margin-left: 31px; margin-bottom: 0px;">
                   <tr>
                       <td class="style1" rowspan="6">
                            <asp:Image ID="Image1" runat="server" AlternateText="Broker Image" ImageUrl="../BrokerImages/default.jpeg"/>
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
                       <td class="style5"><asp:label CssClass="labelRight" runat="server" Text="Fax:"></asp:label></td>
                       <td class="style2" runat="server" id="BrokerFax"></td>
                   </tr>
                   <tr>
                       <td class="style6"><asp:label CssClass="labelRight" runat="server" Text = "Address:"></asp:label></td>
                       <td class="style3" runat="server" id="BrokerAddress"></td>
                   </tr>
                   <tr>
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
