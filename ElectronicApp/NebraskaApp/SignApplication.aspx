<%@ Reference Control="~/SignatureControl/ctlSignature.ascx" %>
<%@ Page Language="C#" Theme="FormPage" AutoEventWireup="true" CodeBehind="SignApplication.aspx.cs" Inherits="ElectronicApp.NebraskaApp.SignApplication" %>
<%@ Register TagPrefix="uc" TagName="Signature"  Src="~/SignatureControl/ctlSignature.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Sign Application</title>
    <script src="../SignatureControl/signature.js" type="text/javascript"></script>
    <script src="../SignatureControl/r.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function() {
            GetOffset();
            DoR();
        }

        function ClearSignature() {
            clear();
        }
    </script>
    
    <style type="text/css">
        .flatbutton
        {
            margin-left: 0px;
            height: 26px;
        }
        .style1
        {
            width: 40px;
        }
        .style2
        {
            width: 160px;
        }
        .style3
        {
            width: 42px;
        }
        .style6
        {
            width: 413px;
        }

    </style>
        <style type="text/css">
       #ctlSignature{
		background:#fff;
		cursor:pointer;
		padding:0;
		margin:0;
		width: 500px;
		height:150px;
		border: solid black 1px;

	}
	#pointer{
		position:absolute;
		background:#000;
		width:3px;
		height:3px;
		font-size:1px;
		z-index:32768;
	}
    </style>
</head>
<body onselectstart="return false;">
    <form id="form1" runat="server">
     <div id="FormContainer">
        <div id="FormTop"><h1><span class="red">Sign</span> Application</h1></div>
           <div id="FormMid">   
               <table style="width: 100%; margin-left: 37px; margin-top: 0px;">
                   <tr>
                       <td class="style6">
                           <h4>By Signing Below you Agree to the following Authorization Terms:</h4></td>
                       <td>
                           <a href="AuthorizationAndCert.aspx" target="_blank">Read Authorization Agreement</a>
                       </td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                   </table>

                            <!--table style="width: 100%; margin-left: 51px; margin-top: 11px;">
                   <tr>
                       <td class="style5">
                           <asp:CheckBox ID="CheckBox1" runat="server" 
                               Text=" I have read and agree to terms contained in the Authorization Agreement" />
                       </td>
                       <td>
                           &nbsp;
                       </td>
                       <td>
                           &nbsp;
                       </td>
                   </tr>
                   </table-->
                   <br />
                   <br />
                   <div class="terms">
                   <h4 style="margin-left: 41px">Please Read Before Signing:</h4>
                   <br />
                   <p style="width: 717px; font-weight: normal; color: #000000; margin-left: 17px;">I certify that I am legally authorized to apply for coverage for myself and all other persons named in this application. I further certify that, after this application was completed, I
carefully and fully read it, that the statements and answers set forth are full, true and correct to the best of my knowledge and belief, and that no information required to be given,
either expressly or by implication, has been knowingly withheld. </p>
<p style="width: 717px; font-weight: normal; color: #000000; margin-left: 17px;">I understand that the Carrier will rely on the completeness and truthfulness of the information given and the
statements made, and that if I have made any false statements or misrepresentations, or have failed to disclose or concealed any material fact, the Carrier will be entitled to
declare any contract or coverage issued pursuant to this application void and to refuse allowance on benefits to any person thereunder, which means that any claims incurred will
become my liability. </p>
<p style="width: 717px; font-weight: normal; color: #000000; margin-left: 17px;">If the group policy does not require my contribution, I understand that I cannot decline any coverage unless the policy indicates otherwise. If the group policy
requires my contribution, I authorize my employer to deduct from my pay. I understand an agent or broker cannot guarantee coverage, revise rates, benefits or provisions without written approval from the Carrier.</p>
<br />
<br />

</div>
<br />
<br />
                          <table style="width:100%; margin-left: 52px;">
                          <tr><td><h2>Sign Here:</h2></td></tr>
                          
                            <tr>
                            <td class="style1">
                                <div id="sign">
                                    <div id="ctlSignature" style='cursor:hand;'>
                                        <asp:HiddenField ID="l_x" runat="server" />
                                         <asp:HiddenField ID="l_y" runat="server" />
                                    </div>
							        </div>
						    </td>
                            <td>
                                 &nbsp;</td>
                            </tr>

                           </table>
                                

  							 
                                
              <table style="margin-left: 260px;">
                                <tr>
                                    <td class="style3">
						<input type="button" class="flatbutton" value=" Clear Signature " onclick="ClearSignature()"/>	
						</td>
                                    <td class="style2">
						<asp:Button  Runat="server" ID="btnSave" style="margin-left:10px;"
                                Text="Sign Application and Submit" onclick="Submit_Click" CssClass="flatbutton"/></td>
                                </tr>
                </table>
							<br />
							<br />


							<!--input type="button" class="flatbutton" value="  Clear " onclick="ClearSignature(); EnableSaveButton(true);"/-->&nbsp;&nbsp;

					   
					    <br />
					    
					    
					    <%--<asp:Button ID="btnNext" runat="server" Height="30px" 
                            style="margin-right: 40px; margin-top: 22px;" Text="Next" Width="70px" onclick="btnNext_Click" 
                            CssClass="btnLogin" />--%>
                         <div class="clearFloat"></div>
                         <br />
                         <p>If you are having problems signing the application above <a href="https://ienroll.ociservices.com/NebraskaApp/preview.aspx" target="_blank">click here to download</a>  the completed application.  You may then print and sign the application.  Please email or fax the application to you agent. </p>
           </div>
                   <div id="FormBottom"></div>
           
     </div>

    </form>
</body>
</html>

