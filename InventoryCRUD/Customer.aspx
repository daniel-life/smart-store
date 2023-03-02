<%@ Page Title="" Language="C#" MasterPageFile="~/CustomerSite.Master" AutoEventWireup="true" CodeBehind="Customer.aspx.cs" Inherits="InventoryCRUD.Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="server">
    <!DOCTYPE html>
    <html>
    <head>
        <title>SmartStore</title>
        <link rel="stylesheet" type="text/css" href="assets/css/index.css" />
    </head>
    <body>
        <section class="breadcrumbs">
            <div class="container">

                <ol>
                    <li><a href="~/">Home</a></li>
                    <li>Home</li>
                </ol>
                <h2>Welcome</h2>
            </div>
        </section>

        <div class="slideshow-container">
            <div class="mySlides">
                <div class="numbertext">1 / 4</div>
                <img src="Images/Vegetables.jpg" style="width: 100%; height: 500px">
            </div>

            <div class="mySlides">
                <div class="numbertext">2 / 4</div>
                <img src="Images/Shelves.jpg" style="width: 100%; height: 500px">
            </div>

            <div class="mySlides">
                <div class="numbertext">3 / 4</div>
                <img src="Images/Breakfast.jpg" style="width: 100%; height: 500px">
            </div>

            <div class="mySlides">
                <div class="numbertext">4 / 4</div>
                <img src="Images/shopping bag.jpg" style="width: 100%; height: 500px">
            </div>

            <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
            <a class="next" onclick="plusSlides(1)">&#10095;</a>
        </div>
        <br />
        <br />
        <div class="jumbotron">
            <h1>Welcome <%:Session["Name"]%> to our Grocery Store!</h1>
            <h1>ID: <%:Session["ID"]%></h1>
            <h1><%:Session["Auth"]%></h1>
            <p>
                <asp:Button ID="Logout" runat="server" OnClick="Logout_Click" Text="Log out" />
            </p>
            <p class="lead">We sell a wide range of daily essential products, such as fruits & vegetables, dairy, and baby products.</p>
        </div>

        <script>
            var slideIndex = 1;
            showSlides(slideIndex);

            function plusSlides(n) {
                showSlides(slideIndex += n);
            }

            function currentSlide(n) {
                showSlides(slideIndex = n);
            }

            function showSlides(n) {
                var i;
                var slides = document.getElementsByClassName("mySlides");
                var dots = document.getElementsByClassName("dot");
                if (n > slides.length) { slideIndex = 1 }
                if (n < 1) { slideIndex = slides.length }
                for (i = 0; i < slides.length; i++) {
                    slides[i].style.display = "none";
                }
                for (i = 0; i < dots.length; i++) {
                    dots[i].className = dots[i].className.replace(" active", "");
                }
                slides[slideIndex - 1].style.display = "block";
                dots[slideIndex - 1].className += " active";
            }
        </script>
    </body>
    </html>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>