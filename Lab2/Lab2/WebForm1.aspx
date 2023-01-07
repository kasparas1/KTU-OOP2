<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Lab2.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Iveskite Moduli"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ieskoti" />
        </p>
        <asp:Label ID="Label2" runat="server" Text="Informacija apie modulius:"></asp:Label>
&nbsp;<br />
        <asp:Table ID="Table1" runat="server">
        </asp:Table>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Informacija apie studentus:"></asp:Label>
        <br />
        <asp:Table ID="Table2" runat="server">
        </asp:Table>
        <asp:Label ID="Label4" runat="server" Text="Destytojas su daugiausiai moduliu"></asp:Label>
        <asp:Table ID="Table3" runat="server">
        </asp:Table>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Studentai kurie pasirinko ta destytoja"></asp:Label>
        <br />
        <asp:Table ID="Table4" runat="server">
        </asp:Table>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Studentu sarasas pagal spesifini moduli"></asp:Label>
        <br />
        <asp:Table ID="Table5" runat="server">
        </asp:Table>
    </form>
</body>
</html>
