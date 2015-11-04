
<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="ReviewAndSign.aspx.cs" Inherits="ElectronicApp.NebraskaApp.ReviewAndSign" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Review Application</title>
    <style type="text/css">
        #frame1
        {
            margin-left: 22px;
        }
        .style1
        {
        }
        .style2
        {
            width: 103px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
     <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Review</span> Application</h1></div>
           <div id="FormMid">
           <br />
           <h2 style="margin-left: 25px">Please review your application for accuracy</h2>
           <p>Press next at bottom of the page to proceed with signing your application</p>
           <br />
           <iframe id="frame1" src=""  runat="server" width="750px" height="800px" > </iframe>
                       <%-- <br />
                        <b>Please Sign In Box Below (press left mouse button inside box below)</b>
                        <br />
                            
                            <table style="width:100%; margin-left: 24px;">
                                <tr>
                                    <td class="style1" colspan="2">
                            
                            <uc:Signature id="ctlMySignature" PenColor="black"  PenWidth="2" BackColor="White" SignWidth="500" SignHeight="100"
							SavePath="~/Signatures/" SignatureCodePath="~/SignatureControl/" SignatureFileFormat="Gif" Runat="server"></uc:Signature>
							        </td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style2">
							
						<input type="button" class="flatbutton" value="  Preview  " onclick="SaveSignature(); EnableSaveButton(true);"/></td>
                                    <td>
						<input type="button" class="flatbutton" value="  Re-Sign " onclick="ClearSignature(); EnableSaveButton(false);"/></td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="style2">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
               </table>
							<br />
							<br />

							<input type="button" class="flatbutton" value="  Clear " onclick="ClearSignature(); EnableSaveButton(true);"/>&nbsp;&nbsp;

					    <asp:Button disabled="disabled" Runat="server" ID="btnSave" Text=" Save " onclick="Submit_Click" />--%>
					    <br />
					    <asp:Button ID="btnNext" runat="server" Height="30px" 
                            style="margin-right: 40px; margin-top: 22px;" Text="Next" Width="70px" onclick="btnNext_Click" 
                            CssClass="btnLogin" />
                         <div class="clearFloat"></div>
           </div>
                   <div id="FormBottom"></div>
           
     </div>
    </form>
    		<%--<script language="javascript">
		
		  // This is an extra method called after signing or clear sign
		  // you can optionally call this. See the onclick events of Preview and Re-Sign button
		  function EnableSaveButton(enable)
		  {
		    var btnSave = document.getElementById("btnSave");
		    
		    if(enable)
		      btnSave.disabled = "";
		    else
		      btnSave.disabled = "disabled";
		  }
		  
		</script>--%>
</body>
</html>
