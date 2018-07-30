<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="PizzaClient.Menu1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PHMenuHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PHMenuBody" runat="server">
    <div>
        <div id="menuItemsContainer">
            <asp:PlaceHolder ID="PLMenuList" runat="server"></asp:PlaceHolder>
        </div>

    </div>
</asp:Content>
