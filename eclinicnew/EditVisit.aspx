<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditVisit.aspx.cs" Inherits="eclinicnew.EditVisit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3 style="font-family: Complex"><b>Edycja wizyty</b></h3>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 110px">Lekarz</td>
            <td>
                <asp:TextBox ID="tbDoctor" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="Podaj lekarza" ControlToValidate="tbDoctor" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Imię</td>
            <td>
                <asp:TextBox ID="tbUserFname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="Podaj imię" Display="Dynamic" ControlToValidate="tbUserFname">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">Nazwisko</td>
            <td>
                <asp:TextBox ID="tbUserLname" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="Podaj nazwisko" ControlToValidate="tbUserLname" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">E-mail</td>
            <td>
                <asp:TextBox ID="tbUserEmail" runat="server" Width="250px"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="RegularExpressionValidator" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ControlToValidate="tbUserEmail" Display="Dynamic">*</asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="Podaj E-mail" ControlToValidate="tbUserEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 110px">PESEL</td>
            <td>
                <asp:TextBox ID="tbUserPesel" runat="server" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ErrorMessage="Podaj PESEL" ControlToValidate="tbUserPesel" Display="Dynamic">*</asp:RequiredFieldValidator>
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
