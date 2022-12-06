<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MBTDB.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    
    <!-- <link href="style/LoginStyle.css" rel="style.css" /> -->
</head>

<body>
    <form id="form1" runat="server">
        <!-- <section>
            <img src="src/BackG.jpg" alt="Alternate Text" class="BI"/>
        </section> -->
        <div>
            <h2>MBT Database</h2>
        </div>
        <div class="child">
                    <b>Login</b><br />
                    <asp:TextBox ID="txtUSER" placeholder="Username" runat="server"></asp:TextBox><br />
                    <asp:TextBox ID="txtPASS" placeholder="Password" runat="server"></asp:TextBox><br />
                    <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
                   
        </div>
        <div>
             <asp:Label ID="Label4" runat="server" Font-Size="X-Large"></asp:Label>
        </div>
    </form>
</body>
</html>
