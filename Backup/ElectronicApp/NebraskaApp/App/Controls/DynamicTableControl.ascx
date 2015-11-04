<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DynamicTableControl.ascx.cs" Inherits="ElectronicApp.NebraskaApp.Controls.DynamicTableControl" %>
<style type="text/css">
    .style2
    {
        width: 790px;
    }
    .style3
    {
        width: 102px;
    }
    .style4
    {
        width: 102px;
        height: 8px;
    }
    .style5
    {
        width: 790px;
        height: 8px;
    }
</style>
<div>
    
   <table style="margin-left: 15px">
        <tr>
            <td colspan ="7">
                <asp:Label ID="Question" runat="server" style="font-weight:Bold;" Text=""></asp:Label>
            </td>
        </tr>
        <!--<tr><td colspan="7"> &nbsp</td></tr>-->
        <tr>
            <td width="105px">
                Person Name
            </td>
            <td width="130px">
                Condition
            </td>
            <td width="75px">
                Date Diagnosed
            </td>
            <td width="75px">
                Date Last Treated
            </td>
            <td width="211px">
                Type of Treatment and Names of Medication (e.g. Oral,  Injectable, infusion, inhaled or transdermal)
            </td>
            <td width="71px">
                Medication Ongoing
            </td>
            <td width="105">
                Degree of Recovery
            </td>
        </tr>
    </table>
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
    <%--<asp:Table runat="server" style="display: block; margin-left: 20px;" Width="780px">
    <asp:TableRow>
        <asp:TableCell>  
        
        
        </asp:TableCell></asp:TableRow></asp:Table>--%>
        <table style="width: 760px; margin-left: 20px; border-collapse:collapse;">
        <tr>
            <td class="style3" >
                &nbsp;</td>
            <td class="style2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" style="color:#666666" valign="middle">
                <asp:ImageButton runat="server" style="text-decoration:none; color:#666666; margin-right: 5px; margin-left: 7px;" 
                    ID="c_insertAboveButton" Text=" Add Row" OnClick="InserAboveClick" 
                    AlternateText="+ Add Row" ImageAlign="Bottom" 
                    ImageUrl="~/App_Themes/FormPage/Images/plus.png" Height="12px" 
                    Width="12px" /> 
                 <asp:LinkButton runat="server" style="text-decoration:none; color:#666666;" ID="AddRow" Text="Add Row" OnClick="InserAboveClick"/> 
            </td>
            <td class="style5" style="color:#666666" valign="top">
                <asp:ImageButton runat="server" 
                    style="text-decoration:none; color:#666666; margin-left: 5px; margin-right: 3px;" 
                    id="LinkButton1" Text="Remove Row" OnClick="RemoveClick" ImageAlign="Bottom" 
                    ImageUrl="~/App_Themes/FormPage/Images/minus.png" Height="12px" 
                    Width="12px" />
                <asp:LinkButton runat="server" style="text-decoration:none; color:#666666;" id="c_removeButtom" Text="Remove Row" OnClick="RemoveClick" />
            </td>
        </tr>
        <tr>
            <td class="style3" style="border-bottom-style: solid; border-width: thin; border-color: #000000 ">
                &nbsp;</td>
            <td class="style2"style="border-bottom-style: solid; border-width: thin; border-color: #000000">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style3">&nbsp; </td>
            <td class="style2">&nbsp;</td>
        </tr>
    </table>
   </div>