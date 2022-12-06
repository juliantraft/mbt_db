<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MBTDB.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Dashboard</h2>
            <asp:Button ID="MBTForm" runat="server" Text="MBT Database" OnClick="MBTForm_Click" />
            <asp:Button ID="MANUForm" runat="server" Text="Manufacturer Database" OnClick="MANUForm_Click" />
            <asp:Button ID="COUNTRYForm" runat="server" Text="Country Database" OnClick="COUNTRYForm_Click" />
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <br />
            <asp:Button ID="Refresh" runat="server" Text="Refresh" OnClick="Refresh_Click" />
            <asp:Button ID="Logout" runat="server" Text="Logout" OnClick="Logout_Click" />
        </div>
    </form>
</body>
</html>
