<%@ Page Title="Browse" Language="C#" MasterPageFile="~/PagesPublic/NestedPublic.Master" AutoEventWireup="true" CodeBehind="BrowseProducts.aspx.cs" Inherits="ShoppingCart.BrowseProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="publicContentPlaceHolder" runat="server">
    <%--<head>
        <title>Contact Form</title>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.6/css/bootstrap.min.css" rel="stylesheet" />
        <link href='https://fonts.googleapis.com/css?family=Lato:300,400,700' rel='stylesheet' type='text/css' />
        <link href='content/custom.css' rel='stylesheet' type='text/css' />
        <link href="~/favicon2.ico" rel="shortcut icon" type="image/x-icon" />
    </head>
    <body>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        
        <ContentTemplate>
            <div>

                <div class="container">

    
                    <div class="col-md-9">

                        <!--Begin carousel to rotate through banner images.-->
                        <div class="row carousel-holder">

                            <div class="col-md-12">
                                <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                        <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                                        <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                                        <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                                    </ol>
                                    <div class="carousel-inner">
                                        <div class="item active">
                                            <asp:image runat="server" class="slide-image" imageurl="~/Images/Large/pets_banner.png" alt="pet banner" />
                                        </div>
                                        <div class="item">
                                            <asp:Image runat="server" class="slide-image" ImageUrl="~/Images/Large/sale-banner.jpg" alt="pet banner" />
                           
                                        </div>
                                        <div class="item">
                                            <asp:Image runat="server" class="slide-image" ImageUrl="~/Images/Large/festivepet.gif" alt="pet banner" />
                            
                                        </div>
                                    </div>
                                    <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                                        <span class="glyphicon glyphicon-chevron-left"></span>
                                    </a>
                                    <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                                        <span class="glyphicon glyphicon-chevron-right"></span>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--End Carousel-->
                    
                    <div class="row">

                        <div class="col-sm-3">
                            <p class="lead">Categories</p>
                            <div class="list-group">
                                <a href="DogProducts.aspx" class="list-group-item">Dog</a>
                                <a href="page2.aspx" class="list-group-item">Cat</a>
                                <a href="page3.aspx" class="list-group-item">Fish</a>
                                <a href="page4.aspx" class="list-group-item">Rodent</a>
                                <a href="page4.aspx" class="list-group-item">Bird</a>
                            </div>
                        </div>

                        <!--search box for users to search for products-->

                        <div class="col-sm-3 col-md-3 pull-right">
                            <form class="navbar-form" role="search" id="searchForm">
                                <div class="input-group">
                                    <input type="text" class="form-control" placeholder="Search" name="search" />
                                    <div class="input-group-btn">
                                        <button class="btn btn-default" type="submit" onclick="GetProducts"><i class="glyphicon glyphicon-search"></i></button>
                                    </div>
                                </div>
                            </form>
                        </div>

                        <!--end search box-->

                        <br />
                        <br />
                    </div>

                    <h1>All Products</h1>
                    <!--Display all products from Products table which include Name, Picture, Description, Price, and price per portion.  
                        *ASP.NET must track a session ID for each user so that it can map the user to session state information on the server. 
        By default, ASP.NET uses a non-persistent cookie to store the session state.-->
                <asp:DataList ID="dlProduct" runat="server" OnItemCommand="dlProduct_ItemCommand" DataSourceID="odsProducts" DataKeyField="Id" RepeatColumns="4" RepeatDirection="Horizontal">
                    <ItemTemplate>
                        <div class="product-content">
                            <img src='../<%# Eval("PicLocLg") %>' />
                            <asp:Label ID="lblName" runat="server" Text='<%# Eval("Name") %>' CssClass="product-title"></asp:Label><br />
                            <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("Description") %>'></asp:Label><br />
                            <b>
                                <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                                /  
                        <asp:Label ID="lblPricePer" runat="server" Text='<%# Eval("PricePer") %>'></asp:Label></b>
                            <br />
                            <br />
                            <asp:DropDownList ID="ddlQuantity" runat="server">
                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:LinkButton ID="lbAddToCart" runat="server" CommandName="Add" CommandArgument='<%# Eval("Id") %>'>Add To Cart</asp:LinkButton>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
                <asp:ObjectDataSource ID="odsProducts" runat="server" SelectMethod="getActiveProductList" TypeName="ShoppingCart.BusinessLogic"></asp:ObjectDataSource>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

