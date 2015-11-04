<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="myRow.ascx.cs" Inherits="ElectronicApp.n.myRow" %>

    <asp:Table ID="Answers" runat="server">
    <asp:TableRow>
        <asp:TableCell width="100px">Person Name</asp:TableCell>
        <asp:TableCell width="125px">Condition</asp:TableCell>
        <asp:TableCell width="70px">Date Diagnosed</asp:TableCell>
        <asp:TableCell width="70px">Date Last Treated</asp:TableCell>
        <asp:TableCell width="210px">Type of Treatment and Names of Medication (e.g. Oral,  Injectable, infusion, inhaled or transdermal)</asp:TableCell>
        <asp:TableCell width="70px">Medication Ongoing</asp:TableCell>
        <asp:TableCell width="105px"> Degree of Recovery</asp:TableCell>
    </asp:TableRow>
    </asp:Table>