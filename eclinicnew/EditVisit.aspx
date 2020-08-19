<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditVisit.aspx.cs" Inherits="eclinicnew.EditVisit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-family: Complex"><b>Edycja wizyty</b></h3>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 110px">Imię</td>
            <td>
                <asp:Label ID="lblFname" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Nazwisko</td>
            <td>
                <asp:Label ID="lblLname" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Lekarz</td>
            <td>
                <asp:DropDownList ID="ddlDoctor" runat="server" DataSourceID="SqlDataSource1" DataTextField="full_name"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:eclinicConnectionString3 %>" 
                    ProviderName="<%$ ConnectionStrings:eclinicConnectionString3.ProviderName %>" 
                    SelectCommand="SELECT full_name FROM doctor"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">
                Data wizyty
            </td>
            <td>
                <asp:TextBox ID="tbDate" runat="server" TextMode="Date"></asp:TextBox><asp:TextBox ID="tbTime" runat="server" TextMode="Time"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">Opis</td>
            <td>
                <asp:TextBox ID="tbDescr" runat="server" TextMode="MultiLine" Width="300px" Rows="10"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Status</td>
            <td>
                <asp:DropDownList ID="ddlStatus" runat="server">
                    <asp:ListItem>AKCEPTACJA</asp:ListItem>
                    <asp:ListItem>ANULOWANE</asp:ListItem>
                    <asp:ListItem>ZAKOŃCZONE</asp:ListItem>
                </asp:DropDownList>
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
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblResult" runat="server" Text="" Font-Bold="True" Font-Size="Large" Font-Names="Complex" Font-Overline="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hfDocEmail" runat="server" />
            </td>
        </tr>
        <asp:HiddenField ID="tbHiddenId" runat="server" />
    </table>
</asp:Content>
