<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutus.aspx.cs" Inherits="Aciident_Geo_Watch.aboutus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AboutUs</title>

    <style>
            body{
                font-family: sans-serif;
                margin-left:5px;
                margin-right: 5px;
                margin-top: 0px;
                background-image: url(123.jpg);
                background-repeat: no-repeat;
                background-size: 100% 730px;
            }
            #nav{
                width:100%;
                height:400px;
                background-size: 100% 420px;
            }
            #nav_wrapper{
                height: 100px;
                width:50%;
                background: rgba(52,73,94,0.7); 
                margin-left: auto;
                margin-right: auto;
                margin-top: 30px;
                opacity: 1;
                filter:alpha (opacity=70); /* IE8 earlier */
            }
            #nav_wrapper ul li{
                list-style: none;
                display: inline;
                font-size:14px;
                font-weight: bold;
                padding: 16px; 
            }
            #nav_wrapper a{
                color: white;
                text-decoration: none;
                padding: 10px;   
            }
             #nav_wrapper ul li:hover{
                 background: red;
                 transition: all 0.45s;
                 opacity: 1;
                 filter:alpha (opacity=70); /* IE8 earlier */ 
            }
            .m{
                height: 500px;
                width:60%;
                background: rgba(52,73,94,0.7); 
                margin-left: auto;
                margin-right: auto;
                position: absolute;
                top: 165px;
                right: 270px;
                opacity: 0.9;
                filter:alpha (opacity=70); /* IE8 earlier */  
            }
            .p1
            {
                font-family: sans-serif;
                color:bisque;
                text-align: left;
                margin-top: 60px;
                margin-left: 40px;
                font-size: 30px;
                font-weight: bold; 
            }
            .p2
            {
                font-family: sans-serif;
                text-align: left;
                margin-left: 40px;
                font-size: 15px;
                color: white;
                font-weight: bold; 
            }
             #Button1 {
            position:absolute;
            top:55px;
            right:140px;

        }
              #Button1{
                margin-top: 20px;
                padding: 15px 30px;
                color: white;
                border-radius: 4px;
                border: none;
                background-color: #377D7A;
            }
             #Button1:hover{
                 border: 1px solid #ffffff;
                 background: red;
                 transition: all 0.45s;
                 opacity: 1;
                filter:alpha (opacity=70); /* IE8 earlier */ 
            }
           
           
        
         
        </style>

</head>
<body>
    <form id="form1" runat="server">
    <div>

         <div id="nav"><br/>
            
            <div id="nav_wrapper"><br/>
                
                <ul style="margin-left:75px;">
                    <li><a href="http://localhost:49932/GP.aspx">Home </a> </li>
                    <li><a href="http://localhost:49932/contactus.aspx">Contact Us</a> </li>
                    <li><a href="http://localhost:49932/aboutus.aspx">About Us</a> </li>
                    <li><a href="http://localhost:49932/summ.aspx">Summary</a> </li>

                </ul>
                
            </div>
        </div><br/>
        <div class="m">
            <p class="p1">Accident Geo-Watch</p><br/>
            <p class="p2">Is an Arabic website that aims to cover up-to-date accidents in several districts of governorates in Egypt. </p>
            <p class="p2">The data will be collected from famous Egyptian online news websites, where text mining and summarization </p>
            <p class="p2">are applied for categorization and generating keyword tags/abstracts.</p><br/><br/>
            <p class="p2">The  design  will  consist  of  an  interactive  map  that  will  mark  violent  accidents,  crimes,  or whatsoever, by</p>
            <p class="p2">location within Egypt's boundaries; if the user clicks on any of the visualized markers,  the  user  is transferred</p>
            <p class="p2">to  the  respective  news  accident  page.  The  developed website  is  useful  for  giving  a  view  of  how  accidents  or</p>
            <p class="p2">crimes  are  frequently  located  and distributed geographically.</p>
        
        
        
        
        </div>
        <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click" />
       
           
        

    
    </div>
    </form>
</body>
</html>
