<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUDOps.aspx.cs" Inherits="PizzaClient.CRUD_Ops" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnDataOps" runat="server" Text="Operate On Dummy Data" OnClick="btnDataOps_Click" />
        </div>
        <div>
            <h1>Toppings</h1>
            <asp:BulletedList ID="BulletedListToppingsData" runat="server"></asp:BulletedList>
        </div>
        <div>
            <h1>Pizzas</h1>
            <asp:BulletedList ID="BulletedListPizzaData" runat="server"></asp:BulletedList>
        </div>
    </form>
</body>
</html>
