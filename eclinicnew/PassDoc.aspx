<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PassDoc.aspx.cs" Inherits="eclinicnew.PassDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-family: Complex"><b>Zmiana hasła</b></h3>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 110px">Login</td>
            <td>
                <asp:Label ID="lblLogin" runat="server" Font-Bold="True" Font-Names="Complex_IV50" Font-Size="Large"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Hasło</td>
            <td>
                <asp:TextBox ID="tbDocPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">
                <asp:Button ID="btnOK" runat="server" Text="Zapisz" Font-Bold="True" Font-Names="Complex" Width="100px" OnClick="btnOK_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Wstecz" Font-Bold="True" Font-Names="Complex" Width="100px" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblResult" runat="server" Text="" Font-Bold="True" Font-Size="Large" Font-Names="Complex" Font-Overline="False"></asp:Label>
            </td>
        </tr>
        <asp:HiddenField ID="tbHiddenId" runat="server" />
    </table>
</asp:Content>
