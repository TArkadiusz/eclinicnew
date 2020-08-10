<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateUser.aspx.cs" Inherits="eclinicnew.UpdateUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.js">
    </script>

    <script type="text/javascript">
        $(function () {
            $("#<%=tbEditPesel.ClientID %>").mask("9999999999999");
        });
    </script>

    <h3 style="font-family: Complex"><b>Edytuj dane</b></h3>
    <asp:Label ID="lblLogin" runat="server" Font-Bold="True" Font-Names="Complex_IV50" Font-Size="Large"></asp:Label>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 110px">Login</td>
            <td>
                <asp:TextBox ID="tbEditLogin" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Podaj Login" ControlToValidate="tbEditLogin" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Hasło</td>
            <td>
                <asp:TextBox ID="tbEditPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Podaj hasło" ControlToValidate="tbEditPass" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Imię</td>
            <td>
                <asp:TextBox ID="tbEditFname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Podaj imię" Display="Dynamic" ControlToValidate="tbEditFname" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Nazwisko</td>
            <td>
                <asp:TextBox ID="tbEditLname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Podaj nazwisko" ControlToValidate="tbEditLname" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">E-mail</td>
            <td>
                <asp:TextBox ID="tbEditEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="tbEditEmail" Display="Dynamic" Enabled="True">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Podaj E-mail" ControlToValidate="tbEditEmail" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">PESEL</td>
            <td>
                <asp:TextBox ID="tbEditPesel" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Podaj PESEL" ControlToValidate="tbEditPesel" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
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
        <asp:HiddenField ID="tbHiddenId" runat="server" />
    </table>
</asp:Content>
