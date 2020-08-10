<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="eclinicnew.UserLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-family: Complex"><b>Zaloguj się</b></h3>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 137px">Login</td>
            <td style="width: 253px">
                <asp:TextBox ID="tbLogin" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 137px">Hasło</td>
            <td style="width: 253px">
                <asp:TextBox ID="tbPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" style="font-size: large">
                <asp:Label ID="lblResult" runat="server" ForeColor="Red" 
                    Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 137px">
                <asp:Button ID="btnLogin" runat="server" Text="Zaloguj się" Width="125px" Font-Bold="True" Font-Names="Complex" OnClick="btnLogin_Click" />
            </td>
            <td style="width: 253px">
                <asp:Button ID="btnReg" runat="server" Text="Zarejestruj się" Width="180px" Font-Bold="True" Font-Names="Complex" OnClick="btnReg_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Wstecz" Font-Bold="True" Font-Names="Complex" OnClick="btnCancel_Click" Width="90px" />
            </td>
        </tr>
    </table>
</asp:Content>
