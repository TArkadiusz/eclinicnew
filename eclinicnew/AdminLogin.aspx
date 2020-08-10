<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="eclinicnew.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-family: Complex"><b>Zaloguj się</b></h3>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 137px">Login</td>
            <td>
                <asp:TextBox ID="tbLogin" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 137px">Hasło</td>
            <td>
                <asp:TextBox ID="tbPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: large">
                <asp:Label ID="lblResult" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 137px">
                <asp:Button ID="btnLogin" runat="server" Text="Zaloguj się" Font-Bold="True" Font-Names="Complex" Width="125px" OnClick="btnLogin_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Wstecz" Font-Bold="True" Font-Names="Complex" OnClick="btnCancel_Click" Width="90px" />
            </td>
        </tr>
    </table>
</asp:Content>
