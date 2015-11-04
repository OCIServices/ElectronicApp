<%@ Page Language="C#" AutoEventWireup="true" Theme="FormPage" CodeBehind="Processing.aspx.cs" Inherits="ElectronicApp.NebraskaApp.Processing" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    
    <title>Prepare Application</title>
    
   <style type="text/css">
        .style4
        {
            width: 333px;
        }
        .style5
        {
            width: 445px;
        }
    </style>
    
    <script language="javascript" type="text/javascript">
        function valSubmit()
        {
            document.getElementById("myMessage").style.display = "none";
            return true;
        }
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Prepare</span> Application</h1></div>
           <div id="FormMid">
         <asp:UpdateProgress ID="updProgress" AssociatedUpdatePanelID="UpdatePanel1" runat="server">
         <ProgressTemplate>
          
                    <table style="width: 100%;">
                        <tr>
                            <td class="style4">
                                &nbsp;
                            </td>
                            <td class="style5">
                                <img alt="progress" src="Images/ajax-loader.gif" align="middle" />
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
        </ProgressTemplate>
        </asp:UpdateProgress>
        
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div id ="myMessage">
               <br />
               <h2><p><span class="red">You Are Almost Done</span></p></h2>
               <br />
                   <p style="width: 648px; margin-left: 5px; margin-right: 0px">
                       Please Press next to review and sign your application. After the page loads 
                       please review the application for accuracy.</p>
                       <p style="width: 648px; margin-left: 5px; margin-right: 0px">After you have reviewed your application you will be asked to sign the application using your mouse.</p>
                     <br />  
                     
                   
                   <br />
                   <br />
                   <asp:Button ID="btnNext" runat="server" CssClass="btnLogin" Height="30px" 
                       onclick="btnNext_Click" style="margin-right: 40px; margin-top: 22px;" 
                       Text="Next" Width="70px" />
                   <br />
                   <br />
                <div class="clearFloat"></div>
               </div>

        </ContentTemplate>
        </asp:UpdatePanel>

                 </div>
                         <div id="FormBottom"></div>
             </div>
    </form>

</body>
</html>



