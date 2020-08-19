<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddVisit.aspx.cs" Inherits="eclinicnew.AddVisit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/1.14.16/jquery.mask.js">
    </script>

    <script type="text/javascript">
        $(function () {
            $("#<%=lblPesel.ClientID %>").mask("9999999999999");
        });
    </script>
    <h3>Nowa wizyta</h3>
    <asp:Label ID="lblLogin" runat="server" Font-Bold="True" Font-Size="Large"></asp:Label>
    <table border="0" class="table">
        <tr>
            <td class="modal-sm" style="width: 250px">Imię</td>
            <td>
                <asp:Label ID="lblFname" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">Nazwisko</td>
            <td>
                <asp:Label ID="lblLname" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">PESEL</td>
            <td>
                <asp:Label ID="lblPesel" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">E-mail</td>
            <td>
                <asp:Label ID="lblEmailUser" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">Lekarz</td>
            <td>
                <asp:DropDownList ID="ddlDoctor" runat="server" DataSourceID="SqlDataSource1" DataTextField="full_name" TabIndex="0">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:eclinicConnectionString %>" 
                    ProviderName="<%$ ConnectionStrings:eclinicConnectionString.ProviderName %>" 
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
            <td class="modal-sm" style="width: 250px">
                Plik (PNG)
            </td>
            <td>
                <asp:FileUpload ID="fuImage" runat="server" Width="350px" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblResult" runat="server" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hfUserId" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hfDocId" runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:HiddenField ID="hfDocEmail" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="modal-sm" style="width: 250px">
                <asp:Button ID="btnOK" runat="server" Text="Zapisz na wizytę" OnClick="btnOK_Click" Font-Bold="True" />
            </td>
            <td>
                <asp:Button ID="btnCancel" runat="server" Text="Wstecz" OnClick="btnCancel_Click" Font-Bold="True" style="margin-left: 0px" Width="100px" />
            </td>
        </tr>
    </table>
</asp:Content>
