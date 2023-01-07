<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_22_02_07_III.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Naujas irasas"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ivesti" />
        <p>
            <asp:Label ID="Label2" runat="server" Text="Egzistuojantis irasai"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <asp:Table ID="Table1" runat="server" BorderColor="Black" BorderWidth="1px">
        </asp:Table>
    </form>
</body>
</html>
