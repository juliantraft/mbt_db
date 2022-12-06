<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="COUNTRYForm.aspx.cs" Inherits="MBTDB.COUNTRYForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Country List</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Countries</h2>
            <br />
            <asp:Button ID="Dashboard" runat="server" Text="Dashboard" OnClick="Dashboard_Click" /><br />
        </div>

        <div>
            <table>
                <tr>
                    <td>Country ID :</td>
                    <td>
                        <asp:TextBox ID="txtID_C" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Name :</td>
                    <td>
                        <asp:TextBox ID="txtNAME" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Continent :</td>
                    <td>
                        <asp:TextBox ID="txtCONTINENT" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>GDP per Capita (USD) :</td>
                    <td>
                        <asp:TextBox ID="txtGDP" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Text="ADD"
                            OnClick="btnAdd_Click" />
                        <asp:Button ID="btnSoftDelete" runat="server"
                            Text="SOFT DELETE" OnClick="btnSoftDelete_Click" />
                        <asp:Button ID="btnHardDelete" runat="server"
                            Text="HARD DELETE" OnClick="btnHardDelete_Click" />
                    </td>
                    <td>
                        <asp:Button ID="btnUpdate" runat="server"
                            Text="UPDATE" OnClick="btnUpdate_Click" />
                        <asp:Button ID="btnRestore" runat="server"
                            Text="RESTORE" OnClick="btnRestore_Click" />
                        <asp:Button ID="btnClear" runat="server"
                            Text="CLEAR" OnClick="btnClear_Click" />
                    </td>
                </tr>
                <tr>
                    <td> </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtSEARCH" placeholder="Name" runat="server"></asp:TextBox>
                        <asp:Button ID="SEARCH" runat="server" Text="SEARCH" OnClick="Search_Click" />
                    </td>
                </tr>
            </table>
        </div>

        <div>
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
            <asp:Button ID="Refresh" runat="server" Text="Refresh" OnClick="Refresh_Click" /><br />
        </div>
    </form>
</body>
</html>
