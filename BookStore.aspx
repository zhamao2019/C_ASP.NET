<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="BookStore.aspx.cs" Inherits="BookStore" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book Store</title>
    <link href="App_Themes/SiteStyles.css" rel="stylesheet" />
</head>
<body>
    <h1>Online Book Store</h1>
    <form id="form1" runat="server">
        <a  href="ShoppingCartView.aspx">View Shopping Cart</a> (<asp:Label runat="server" ID="lblNumItems"></asp:Label>) <br /><br />
        <asp:DropDownList  ID="drpBookSelection" runat="server" CssClass="dropdown" 
            OnSelectedIndexChanged="drpBookSelection_SelectedIndexChanged" AutoPostBack="true" >
            <asp:ListItem Value="-1">Select a Book ... </asp:ListItem>
        </asp:DropDownList><br />
        
        <%-- Todo: Add Required Field Validator so that the user has to select a book from the dropdown list --%>
        <asp:RequiredFieldValidator runat="server" ID="rfvBookSelection" 
            ControlToValidate="drpBookSelection" ErrorMessage="Must Select One" 
             InitialValue="-1" Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>

        <div class="description">
            <asp:Label runat="server" ID="lblDescription"></asp:Label>
        </div>
        <br />
        <span class="emphsis">Price: </span><asp:Label runat="server" ID="lblPrice" CssClass="Price" ></asp:Label>                
        <span class="emphsis">Quantity: </span><asp:TextBox runat="server" ID="txtQuantity" cssclass="input"/>

        <%-- todo: Add Required Field Validator so that the user has to enter a value --%>
        <asp:RequiredFieldValidator runat="server" ID="rfvQuantity"
             ControlToValidate="txtQuantity" ErrorMessage="Required" 
             Display="Dynamic" CssClass="error"></asp:RequiredFieldValidator>

        <%-- todo: Add Range Validator so that the user has to enter a number greater than 0 and less than 3 --%>
        <asp:RangeValidator runat="server" ID="rvQuantity"
             ControlToValidate="txtQuantity" ErrorMessage="The maximum quantity is 2"
             MaximumValue="2" MinimumValue="1" 
             Display="Dynamic" CssClass="error"></asp:RangeValidator>

        <br /><br /><asp:Button runat="server" ID="btnAddToCart" Text="Add to Cart" cssclass="button" OnClick="btnAddToCart_Click"/>
    </form>  
</body>
</html>

