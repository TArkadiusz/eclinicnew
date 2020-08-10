<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditVisitDoc.aspx.cs" Inherits="eclinicnew.EditVisitDoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Edycja statusu zgłoszenia</h3>
    <table border="0" class="table">
        <tr>
            <td style="width: 250px">Zmiana statusu</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem Value="0">---</asp:ListItem>
                    <asp:ListItem Value="1">AKCEPTACJA</asp:ListItem>
                    <asp:ListItem Value="-1">ANULOWANO</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblStatus" runat="server" Text="" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="width: 250px">
                <asp:Button ID="btnOK" runat="server" Text="Zmień status" OnClick="btnOK_Click" Font-Bold="True" />
            </td>
            <td>
                <asp:Button ID="btnClose" runat="server" Text="Wstecz" Font-Bold="True" OnClick="btnClose_Click" Width="150px" />
            </td>
        </tr>
        <asp:HiddenField ID="tbHiddenId" runat="server" />
    </table>
</asp:Content>
