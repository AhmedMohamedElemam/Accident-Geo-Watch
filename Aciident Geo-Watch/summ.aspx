<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="summ.aspx.cs" Inherits="Aciident_Geo_Watch.summ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
         body{
                font-family: sans-serif;
                margin-left:5px;
                margin-right: 5px;
                margin-top: 0px;
                background-image: url(123.jpg);
                background-repeat: no-repeat;
                background-size: 100% 730px;
                background-attachment:fixed;
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
                width:70%;
                background: rgba(52,73,94,0.7); 
                margin-left: auto;
                margin-right: auto;
                position: absolute;
                top: 165px;
                right: 208px;
                opacity: 0.9;
                filter:alpha (opacity=70); /* IE8 earlier */  
            }
        #h2 {
            color:white;
            font-weight:bold;
            position:absolute;
            top:180px;
            left: 525px;
        }
        #ListBox1 {
            width:140px;
            height:270px;
            position:absolute;
            top:300px;
            left:250px;
            direction:rtl;
            padding-right:2px;
            padding-top:2px;

        }
        #Label1 {
            color:white;
            background:red;
            top:276px;
              position:absolute;
            left:268px;
            color:bisque;
            font-weight:bold;
        }
        #search {
            position:absolute;
            top:256px;
            right:250px;

        }
        #TextBox1 {
            height:20px;
            padding-left:2px;
            

        }
         #Button1 {
            height:26px;
            margin-left:-5px;
        }
          .btn{
                color: white;
                border: none;
                background-color: #2ecc7a;
            }
            .btn:hover{
                 background: red;
                 transition: all 0.45s;
                 opacity: 1;
                filter:alpha (opacity=70); /* IE8 earlier */ 
            }
        #summary {
            width:400px;
            height:280px;
            background:white;
            position:absolute;
            top:300px;
            right:250px;
        }
        td {
            width:150px;
            padding-left:5px;
        }
        th {
              width:200px;
              color:red;

        }
        caption {
            font-weight:bold;
            margin-bottom:7px;
        }
        table {
            margin-left:18px;
            margin-top:40px;
            background-color:#efefef;
        }
         #Button2 {
            position:absolute;
            top:55px;
            right:140px;

        }
              #Button2{
                margin-top: 20px;
                padding: 15px 30px;
                color: white;
                border-radius: 4px;
                border: none;
                background-color: #377D7A;
            }
             #Button2:hover{
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
        </div>
        <h2 id="h2">Check Safety Of Your Place</h2>
        <asp:Label ID="Label1" runat="server" Text="Select Place"></asp:Label>
        <asp:ListBox ID="ListBox1" runat="server" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <div id="search">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Your Place"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Text="Search" CssClass="btn" OnClick="Button1_Click" />
        </div>
        <div id="summary">
            <table border="1" >
                <caption>Your Place Result</caption>
                <tr>
                    <th>Fire</th>
                    <td><asp:Label ID="fire" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <th>Accident</th>
                    <td><asp:Label ID="accident" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <th>Murder</th>
                    <td><asp:Label ID="murder" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <th>Theft</th>
                    <td><asp:Label ID="theft" runat="server" Text=""></asp:Label></td>
                </tr>
                 <tr>
                    <th>Total</th>
                    <td><asp:Label ID="total" runat="server" Text=""></asp:Label></td>
                </tr>
                 
            </table>
        </div>
        <asp:Button ID="Button2" runat="server" Text="Logout" OnClick="Button2_Click"/>
        

    </div>
        
    </form>
</body>
</html>
