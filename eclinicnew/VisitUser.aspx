<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisitUser.aspx.cs" Inherits="eclinicnew.VisitUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Twoje wizyty</h3>
    <asp:Label ID="lblLogin" runat="server" Text="" Font-Size="Large" Font-Bold="True"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" CellSpacing="5" Width="100%" Font-Bold="False" ForeColor="#333333">
        <AlternatingRowStyle BackColor="White" ForeColor="#003366" />
        <Columns>
            <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
            <asp:BoundField DataField="fname" HeaderText="Imię" SortExpression="fname" />
            <asp:BoundField DataField="lname" HeaderText="Nazwisko" SortExpression="lname" />
            <asp:BoundField DataField="doctor" HeaderText="Lekarz" SortExpression="doctor" DataFormatString="" />
            <asp:TemplateField HeaderText="E-mail" SortExpression="email">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# Eval("email", "mailto:{0}") %>' Text='<%# Eval("email") %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="visit_date" HeaderText="Data wizyty" SortExpression="visit_date" />
            <asp:BoundField DataField="descr" HeaderText="Opis" SortExpression="descr" />
            <asp:ImageField HeaderText="Obraz" NullDisplayText="BRAK" DataImageUrlField="image" 
                DataImageUrlFormatString="~/uploads/{0}" ControlStyle-Width="150px">
                <ControlStyle Width="150px"></ControlStyle>
            </asp:ImageField>
            <asp:BoundField DataField="status" HeaderText="Status" SortExpression="status" />
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
        SelectCommand="SELECT fname, lname, doctor, visit_date, descr, image, status FROM visits "></asp:SqlDataSource>
    <table class="table">
        <tr>
            <td class="modal-sm" style="width: 200px">
                <asp:Button ID="btnAddVisit" runat="server" Text="Nowa wizyta" Font-Bold="True" OnClick="btnAddVisit_Click" Width="150px" />
            </td>
            <td class="modal-sm" style="width: 200px">
                <asp:Button ID="btnEditUser" runat="server" Text="Edytuj dane" Font-Bold="True" OnClick="btnEditUser_Click" Width="150px" />
            </td>
            <td>
                <asp:Button ID="btnLogout" runat="server" Text="Wyloguj" Font-Bold="True" OnClick="btnLogout_Click" Width="150px" />
            </td>
        </tr>
    </table>
</asp:Content>
