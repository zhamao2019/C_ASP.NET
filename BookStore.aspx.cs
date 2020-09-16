using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookStore : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Todo: Add you code here 
        List<Book> availableBooks = BookCatalogDataAccess.GetAllBooks(); ;
        ShoppingCart shoppingCart;

        if (Session["books"] == null)
        {
            Session["books"] = availableBooks;
        }
        else
        {
            availableBooks = (List<Book>)Session["books"];
        }

        if (Session["cart"] == null)
        {
            shoppingCart = new ShoppingCart();
            Session["cart"] = shoppingCart;
            lblNumItems.Text = "empty";
        }
        else
        {
            shoppingCart = (ShoppingCart)Session["cart"];
            lblNumItems.Text = shoppingCart.NumOfItems.ToString();
        }

        // display the available book list
        if (!IsPostBack)
        {
            for(int i = 0; i < availableBooks.Count; i++)
            {
                drpBookSelection.Items.Add(new ListItem(availableBooks[i].Title, availableBooks[i].Id));
            }
        }
    }
    protected void drpBookSelection_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Todo: Add your code here
        if (drpBookSelection.SelectedValue != "-1")
        {
            Book selectedBook = BookCatalogDataAccess.GetBookById(drpBookSelection.SelectedValue);
            lblPrice.Text = selectedBook.Price.ToString();
            lblDescription.Text = selectedBook.Description;
        }
        else
        {
            lblDescription.Visible = false;
            lblPrice.Visible = false;
        }
    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        //Todo: Add your code here
        if (!Page.IsValid) return;

        var shoppingCart = (ShoppingCart)Session["cart"];
        var availableBooks = (List<Book>)Session["books"];

        Book selectedBook = BookCatalogDataAccess.GetBookById(drpBookSelection.SelectedValue);
        BookOrder bookOrder = new BookOrder(selectedBook, int.Parse(txtQuantity.Text));

        // updated the selected book list
        shoppingCart.AddBookOrder(bookOrder);

        // make a selected book unavailable
        //availableBooks.Remove(availableBooks.Where(b => b.Id == selectedBook.Id).FirstOrDefault<Book>());
        drpBookSelection.Items.Remove(drpBookSelection.Items.FindByValue(selectedBook.Id));
        availableBooks.RemoveAll(b => b.Id == selectedBook.Id);

        // display messages
        lblDescription.Text = $"{txtQuantity.Text} copy of {selectedBook.Title} is added to the shopping cart";
        lblNumItems.Text = shoppingCart.NumOfItems.ToString();
        drpBookSelection.SelectedValue = "-1";
    }
    protected void btnViewCart_Click(object sender, EventArgs e)
    {
        Response.Redirect("ShoppingCartView.aspx");
    }
}