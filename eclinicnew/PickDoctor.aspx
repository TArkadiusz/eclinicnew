<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PickDoctor.aspx.cs" Inherits="eclinicnew.PickDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Lekarze</h3>
    <asp:GridView ID="gridView" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CellSpacing="5" Width="100%" Font-Bold="False" ForeColor="#333333" DataKeyNames="id" DataSourceID="SqlDataSource" OnRowCommand="gridView_RowCommand">
        <AlternatingRowStyle BackColor="White" ForeColor="#003366" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="fname" HeaderText="Imię" SortExpression="fname" />
            <asp:BoundField DataField="lname" HeaderText="Nazwisko" SortExpression="lname" />
            <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("email", "mailto:{0}") %>' Text='<%# Eval("email") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField DataNavigateUrlFields="id" DataNavigateUrlFormatString="EditDoctor.aspx?id={0}" HeaderText="" Text="Edytuj" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="Button1" runat="server"  
                        CommandArgument='<%# Eval("id") %>'
                        Text="Usuń" CommandName="DeleteRow"
                        OnClientClick="return confirm('Czy na pewno usunąć lekarza?');"
                        />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#0033CC" ForeColor="White" />
        <HeaderStyle BackColor="#3366FF" ForeColor="White" />
        <PagerStyle BackColor="#003366" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="server=127.0.0.1;user id=root;password=root;database=eclinic;persistsecurityinfo=True" ProviderName="MySql.Data.MySqlClient" 
        SelectCommand="SELECT * FROM doctor"></asp:SqlDataSource>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 200px">
                <asp:Button ID="btnEditUser" runat="server" Text="Pacjenci" Font-Bold="True" OnClick="btnEditUser_Click" Width="150px" />
            </td>
            <td class="modal-sm" style="width: 200px">
                <asp:Button ID="btnEditVisit" runat="server" Text="Wizyty" Font-Bold="True" OnClick="btnEditVisit_Click" Width="150px" />
            </td>
            <td class="modal-sm" style="width: 200px">
                <asp:Button ID="btnAddDoc" runat="server" Text="Dodaj lekarza" Font-Bold="True" OnClick="btnAddDoc_Click" Width="150px" />
            </td>
            <td>
                <asp:Button ID="btnLogout" runat="server" Text="Wyloguj" Font-Bold="True" OnClick="btnLogout_Click" Width="150px" />
            </td>
        </tr>
    </table>
</asp:Content>
