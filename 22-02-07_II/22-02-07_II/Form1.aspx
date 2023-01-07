<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="_22_02_07_II.Form1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Kugio Aukstine, H"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Label ID="Label2" runat="server" Text="Kugio spindulys, R"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Kugio spindulys, r"></asp:Label>
        <br />
        <p>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Kugio turis"></asp:Label>
        <br />
        <p>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        </p>
        <br />
        <br />
        <asp:Button ID="Button1" runat ="server" Text="Skaiciuoti!" OnClick="Button1_Click" />
    </form>
</body>
</html>
