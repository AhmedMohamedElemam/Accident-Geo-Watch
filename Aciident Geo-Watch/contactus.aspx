<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contactus.aspx.cs" Inherits="Aciident_Geo_Watch.contactus" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ContactUs</title>

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
            .p1
            {
                font-family: sans-serif;
                color:white;
                text-align: left;
                margin-top: 40px;
                margin-left: 40px;
                font-size: 30px;
                font-weight: bold; 
            }
            .p2
            {
                font-family: sans-serif;
                text-align: left;
                margin-top: -10px;
                margin-left: 40px;
                font-size: 15px;
                color: white;
                font-weight: bold; 
            }
            input[type="text"],input[type="password"]{
              
                height: 45px;
                width:320px;
                font-size: 18px;
                margin-top: 20px;
                padding-left: 40px;

            }
            .btn{
                margin-top: 30px;
                padding: 19px 40px;
                color: white;
                border-radius: 8px;
                border: none;
                background-color: #2ecc7a;
            }
            .btn:hover{
                 border: 1px solid #ffffff;
                 background: red;
                 transition: all 0.45s;
                 opacity: 1;
                filter:alpha (opacity=70); /* IE8 earlier */ 
            }
             .mm{
                position: absolute;
                top:350px;
                left:240px;
            }
            .fieldset{
                position: absolute;
                top: 340px;
                right: 250px;
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
         #Label1 {
             position:absolute;
             top:540px;
             left:380px;
             color:white;
             font-weight:bold;
         }
         
        </style>
    <script>
       
        function testemail(){
            var emailtextbox = document.getElementById("TextBox2");
            var email = emailtextbox.value;
            var emailtextbox1 = document.getElementById("Label1");
            var emailregix = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            emailtextbox.style.color = "white";
            if (emailregix.test(email)) {
                emailtextbox.style.backgroundColor = "#2ecc7a";

                emailtextbox.style.color = "white";
                emailtextbox1.style.color = "#2ecc7a"
                document.getElementById("Label1").innerHTML = "Correct Form Of Email Email";
                return true;
            }
            else {
                emailtextbox.style.backgroundColor = "red";
                emailtextbox.style.color = "white";
                emailtextbox1.style.color = "red";
                document.getElementById("Label1").innerHTML = "Error..! Email Isn't In The Correct Form ";
                return false;
            }
        }
    </script>


</head>
<body>
    <form id="form1" runat="server" >
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
            <p class="p1">Contact Us</p>
            <p class="p2">If you wish to contact us please enter the details regarding your query in to the form below and click "Send".</p>
            
        </div>
        <div class="mm">
                <div class="form_input">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Enter Name"></asp:TextBox>
                </div>
                <div class="form_input">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Enter Email" onkeyup="testemail()"></asp:TextBox>
                </div>
                <asp:Button runat="server" Text="Send"   name="submit"  class="btn" OnClick="Unnamed1_Click"  onsubmit="return testemail();" />
        </div>
        <div class="fieldset">
            <textarea id="TextArea1" cols="50" rows="20" placeholder="We Are So Happy Too Recieve Your Message...!"name="TextArea1"></textarea>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Logout" OnClick="Button1_Click"  />

        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
       
           


    
    </div>
    </form>
</body>
</html>
