using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ShoppingCartView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Todo: Add your code here
        var shoppingCart = (ShoppingCart)Session["cart"];

        if (Session["cart"] == null || shoppingCart.IsEmpty)
        {
            //create the default empty table
            Label NoData = new Label();
            TableRow row = new TableRow();
            TableCell cell = new TableCell();

            NoData.CssClass = "error";
            tblShoppingCart.Rows.Add(row);
            
            NoData.Text = "Your Shopping Cart is Empty";
            cell.Controls.Add(NoData);
            row.Cells.Add(cell);

            cell.ColumnSpan = 3;
            row.HorizontalAlign = HorizontalAlign.Center;
            
        }
        else
        {
            // display book oders in table
            foreach (BookOrder bookOrder in shoppingCart.BookOrders)
            {
                TableRow row = new TableRow();
                tblShoppingCart.Rows.Add(row);

                for (int j = 0; j < 3; j++)
                {
                    TableCell cell = new TableCell();
                    
                    if (j == 0) { cell.Text = bookOrder.Book.Title; }
                    if (j == 1) { cell.Text = bookOrder.NumOfCopies.ToString(); }
                    if (j == 2) { cell.Text = (bookOrder.Book.Price * bookOrder.NumOfCopies).ToString(); }
           
                    row.Cells.Add(cell);
                }
            }
            // display total price
            TableRow rowLast = new TableRow();
            TableCell cellLast = new TableCell();
            tblShoppingCart.Rows.Add(rowLast);
            rowLast.Cells.Add(cellLast);
            cellLast.Text = $"Total:  {shoppingCart.TotalAmountPayable.ToString()}";
            cellLast.ColumnSpan = 3;
            rowLast.HorizontalAlign = HorizontalAlign.Right;
            
        }
    }
    

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Bookstore.aspx");
    }

    protected void btnEmptyShoppingCart_Click(object sender, EventArgs e)
    {
        //Todo: Add your code here
        Session["cart"] = null;
        Session["books"] = null;

        Response.Redirect("ShoppingCartView.aspx");
    }

}