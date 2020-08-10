<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddDoctor.aspx.cs" Inherits="eclinicnew.AddDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     

    <h3 style="font-family: Complex"><b>Nowy lekarz</b></h3>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 110px">Login</td>
            <td>
                <asp:TextBox ID="tbDocLogin" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Podaj Login" ControlToValidate="tbDocLogin" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Hasło</td>
            <td>
                <asp:TextBox ID="tbDocPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Podaj hasło" ControlToValidate="tbDocPass" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Imię</td>
            <td>
                <asp:TextBox ID="tbDocFname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Podaj imię" Display="Dynamic" ControlToValidate="tbDocFname">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Nazwisko</td>
            <td>
                <asp:TextBox ID="tbDocLname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Podaj nazwisko" ControlToValidate="tbDocLname" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">E-mail</td>
            <td>
                <asp:TextBox ID="tbDocEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="tbDocEmail" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Podaj E-mail" ControlToValidate="tbDocEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
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
    </table>
</asp:Content>
