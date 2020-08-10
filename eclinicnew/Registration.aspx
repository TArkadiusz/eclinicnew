<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="eclinicnew.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.js">
    </script>

    <script type="text/javascript">
        $(function () {
            $("#<%=tbRegPesel.ClientID %>").mask("9999999999999");
        });
    </script>

    <h3 style="font-family: Complex"><b>Rejestracja</b></h3>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 110px">Login</td>
            <td>
                <asp:TextBox ID="tbRegLogin" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Podaj Login" ControlToValidate="tbRegLogin" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Hasło</td>
            <td>
                <asp:TextBox ID="tbRegPass" runat="server" Width="250px" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ErrorMessage="Podaj hasło" ControlToValidate="tbRegPass" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Imię</td>
            <td>
                <asp:TextBox ID="tbRegFname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Podaj imię" Display="Dynamic" ControlToValidate="tbRegFname" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Nazwisko</td>
            <td>
                <asp:TextBox ID="tbRegLname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Podaj nazwisko" ControlToValidate="tbRegLname" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">E-mail</td>
            <td>
                <asp:TextBox ID="tbRegEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="tbRegEmail" Display="Dynamic" Enabled="True">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Podaj E-mail" ControlToValidate="tbRegEmail" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">PESEL</td>
            <td>
                <asp:TextBox ID="tbRegPesel" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Podaj PESEL" ControlToValidate="tbRegPesel" Display="Dynamic" Enabled="True">*</asp:RequiredFieldValidator>
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
