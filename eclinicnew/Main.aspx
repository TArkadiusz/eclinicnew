<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="eclinicnew.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-image: url('uploads/eclinic.png'); height: 768px; width: 1004px;">
        <div style="width: 439px; height: 765px; margin-left: 1200px;">
            
            <table>
                
            <asp:Button ID="btnPatient" runat="server" Height="60px" Text="Pacjent" Width="270px" BorderStyle="Ridge" 
                Font-Bold="True" Font-Names="Complex" Font-Size="Larger" ForeColor="Black" style="margin-top: 240px" OnClick="btnPatient_Click" />
                
            </table>
            <table>

            <asp:Button ID="btnDoc" runat="server" Height="60px" Text="Lekarz" Width="270px" BorderStyle="Ridge" 
                Font-Bold="True" Font-Names="Complex" Font-Size="Larger" ForeColor="Black" style="margin-top: 70px" OnClick="btnDoc_Click" />

            </table>

            <asp:Button ID="btnAdmin" runat="server" Height="60px" Text="Administrator" Width="270px" BorderStyle="Ridge" 
                Font-Bold="True" Font-Names="Complex" Font-Size="Larger" ForeColor="Black" style="margin-top: 70px" OnClick="btnAdmin_Click" />

            

        </div>
        </div>
    </form>
</body>
</html>
