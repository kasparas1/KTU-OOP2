<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="_22_02_07_V.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Konkurso dalyvio registracija:"></asp:Label>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
        <p>
            <asp:Label ID="Label2" runat="server" Text="Vardas"></asp:Label>
&nbsp;<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1" ErrorMessage="Vardas yra privalomas" ForeColor="Red" ViewStateMode="Disabled">*</asp:RequiredFieldValidator>
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Pavarde"></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label5" runat="server" Text="Mokyklos pav."></asp:Label>
&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="Amzius"></asp:Label>
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Neteisinga metu reiksme" ForeColor="Red" MaximumValue="25" MinimumValue="14" Type="Integer">*</asp:RangeValidator>
        </p>
        <asp:Label ID="Label4" runat="server" Text="Programavimo kalba:"></asp:Label>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="XmlDataSource1" DataTextField="title" DataValueField="title">
        </asp:CheckBoxList>
        <asp:XmlDataSource ID="XmlDataSource1" runat="server" DataFile="~/App_Data/Kalbos.xml"></asp:XmlDataSource>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Registruokis" />
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Istrinti" />
&nbsp;<asp:Table ID="Table1" runat="server">
            </asp:Table>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Dalyvių kiekis"></asp:Label>
        </p>
    </form>
</body>
</html>
