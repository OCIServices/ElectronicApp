<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="RowControl.ascx.cs" Inherits="ElectronicApp.NebraskaApp.Controls.RowControl" %>
<asp:Table runat="server" style="margin-left: 15px">
    <asp:TableRow>
        <asp:TableCell width="100px">
            <asp:DropDownList ID="txtPersonName" width="100px" runat="server"></asp:DropDownList></asp:TableCell>
        <asp:TableCell width="115px">
            <asp:TextBox ID="txtCondition"  width="115px" runat="server"></asp:TextBox></asp:TableCell>
        <asp:TableCell width="70px">
            <asp:TextBox ID="txtDiagnosed" width="70px" runat="server"></asp:TextBox></asp:TableCell>
        <asp:TableCell width="70px">
            <asp:TextBox ID="txtTreated" width="70px" runat="server"></asp:TextBox></asp:TableCell>
        <asp:TableCell width="206px"><asp:TextBox ID="txtMed" width="206px" runat="server"></asp:TextBox></asp:TableCell>
        <asp:TableCell width="66px">
            <asp:DropDownList ID="txtOngoing" width="66px" runat="server">
                <asp:ListItem>Select</asp:ListItem>
                <asp:ListItem>no</asp:ListItem>
                <asp:ListItem>yes</asp:ListItem>
            </asp:DropDownList>
        </asp:TableCell>
        <asp:TableCell width="100px">
            <asp:TextBox ID="txtRecovery" width="100px" runat="server"></asp:TextBox></asp:TableCell>
            <asp:TableCell>
                <asp:HiddenField ID="QuestionNumber" runat="server" />
            </asp:TableCell>
    </asp:TableRow>
</asp:Table>
