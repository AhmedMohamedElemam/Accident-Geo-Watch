<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aciident_Geo_Watch.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Acident Geo-Watch</title>
    <script type="text/javascript">
        
        function repassword1()
        {
            var repass = document.getElementById("repassword");
            var pass = document.getElementById("password2");
            repass.style.color = "white";

            repass.style.backgroundColor = "red";

            var repassvalue = repass.value;
            var passvalue = pass.value;
            if (repassvalue==passvalue)
            {
                repass.style.color = "white";
                repass.style.backgroundColor = "#2ecc7a";
            }
        }

        function testemail()
        {
            var emailtextbox = document.getElementById("email2");
            var email = emailtextbox.value;
            var emailregix = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            emailtextbox.style.color = "white";
            if (emailregix.test(email)) {
                //emailtextbox.style.backgroundColor = "green";
                emailtextbox.style.color = "#2ecc7a";
                document.getElementById("Label3").innerHTML ="Strong";
            }
            else
            {
                //emailtextbox.style.backgroundColor = "red";
                emailtextbox.style.color = "red";
                document.getElementById("Label3").innerHTML = "Weak";
            }
        }
        function testpassword()
        {
            var passwordtextbox = document.getElementById("password2");
            var password = passwordtextbox.value;
            var specialcharacters = "!$%^&*_@#~?";
            var passwordscore = 0;
            for (var i = 0; i < password.length; i++)
            {
                if (specialcharacters.indexOf(password.charAt(i)) > -1)
                {
                    passwordscore += 20;

                }
            }
            if (/[a-z]/.test(password))
            {
                passwordscore += 20;

            }
            if (/[A-Z]/.test(password)) {
                passwordscore += 20;
            }
            if (/[\d]/.test(password)) {
                passwordscore += 20;
            }
            if (password.length>=8) {
                passwordscore += 20;
            }
            var strength = "";
            var background = "";
            if(passwordscore>=100)
            {
                strength = "Strong";
                background = "#2ecc7a";
            }
            else if (passwordscore >= 80) {
                strength = "Medium";
                background = "#2ecc7a";
            }
            else if (passwordscore >= 60) {
                strength = "Weak";
                background = "orange";
            }
            else
            {
                strength = "Very Weak";
                background = "red";
            }
            document.getElementById("Label1").innerHTML = strength;
            passwordtextbox.style.color = "white";
            passwordtextbox.style.backgroundColor = background;


            return false;





        }
        function showalert()
        {
            alert('successful registration');
        }


    </script>

    <style>

        body{
                margin: 0 auto;
                background-image: url("123.jpg");
                background-repeat: no-repeat;
                background-size: 100% 730px;
                background-attachment: fixed;
                
            }
            .container{
                width:500px;
                height:320px;
                text-align: center;
                background-color: rgba(52,73,94,0.5);
                border-radius: 4px;
                margin: 0 auto; 
            }
            .cont
            {
                width:500px;
                height:250px;
                text-align: center;
                border-radius: 4px;
            }
            .p1{
                font-family: sans-serif;
                text-align: left;
                margin-top: 40px;
                margin-left: 20px;
                font-size: 40px;
                color: white;
                font-weight: bold; 
            }
            .p2{
                font-family: sans-serif;
                text-align: left;
                margin-top: -10px;
                margin-left: 65px;
                font-size: 23px;
                color: white;
                font-weight: bold;
                
            }
            .p3{
                text-align: center;
                color: white;
                font-weight: bold;
                font-size: 20px;
                
            }
            .contain{
                width:500px;
                height:530px;
                text-align: center;
                background-color: rgba(52,73,94,0.5);
                border-radius: 4px;
                margin: 0 auto; 
                
            }
            .contain{
                position: absolute;
                top:380px;
                right:20px;
            }
          
           
            input[type="text"],input[type="password"]{
              
                height: 45px;
                width:300px;
                font-size: 18px;
                margin-top: 20px;
                padding-left: 40px;

            }
           #Label1{
               color:white;
               font-weight:bold;
               position:absolute;
               right:23px;
               top:475px;


          }
       
            .btn1{
                position:absolute;
                top:245px;
                right:210px;
                padding: 15px 30px;
                color: white;
                border-radius: 4px;
                border: none;
                background-color: #2ecc7a;
            }
            .forget a{
                color: white;
                 
            }
             .t {
            position:absolute;
            top:710px;
            right:204px;
        }
            .forget ul li{
                list-style: none;
                display: inline;
                font-weight: bold;
                padding: 18px; 
            }
            .forget{
                position: absolute;
                right: 170px;
                top:220px;
            height: 38px;
        }
             .forget li a:hover{
                 font-weight: bold; 
                 color:red;
                 transition: all 0.45s;
                 filter:alpha (opacity=70); /* IE8 earlier */ 
            }
             .btn1:hover{
                 border: 1px solid #ffffff;
                 background: red;
                 transition: all 0.45s;
                 opacity: 0.9;
                filter:alpha (opacity=70); /* IE8 earlier */ 
            }
                .btn2{
                position:absolute;
                top:105px;
                right:18px;
                padding: 15px 30px;
                color: white;
                border-radius: 4px;
                border: none;
                background-color: #2ecc7a;
            }
              .btn2:hover{
                 border: 1px solid #ffffff;
                 background: red;
                 transition: all 0.45s;
                 opacity: 0.9;
                filter:alpha (opacity=70); /* IE8 earlier */ 
            }
            .container{
                position: absolute;
                right:20px;
                top:20px;
                
            }
             #Label2{
               color:white;
               font-weight:bold;
               position:absolute;
               right:190px;
               top:870px;
               color:yellow;


          }
             #Label3{
               color:white;
               font-weight:bold;
               position:absolute;
               right:23px;
               top:400px;
          }
      #CheckBox1,#CheckBox2{


            position:absolute;
            margin-top:10px;
            right:10px;
        }
        .v1 {
            display:inline-block;
            padding:5%;
            font-weight: bold;
            color: black;
            font-size:85%;
        }
         #advancedsearch {
            padding-top:5px;
            width:150px;
            height:64px;
            background-color:white;
            position:absolute;
            top:180px;
            right:200px;
            border:1px solid #000;
            border-radius:5px;

        }
        ListItem {
            color:red;
        }
        #Label4 {
            color:red;
            font-weight:bold;
            position:absolute;
            top:300px;
            right:140px;
        }

        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="container">

                <div class="form_input"> 
                    <asp:TextBox ID="email1" runat="server" placeholder="Enter Email"></asp:TextBox>
                </div>
                <div class="form_input">   
                    <asp:TextBox ID="password1" runat="server" placeholder="Enter Password" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn1" OnClick="Button1_Click" />
            <asp:Label ID="Label4" runat="server" Text=""></asp:Label>

               
        </div>

        
        
         <div class="contain">
                <p class="p3">Create New Account</p>
                 
                <div class="form_input">    
                 <asp:TextBox ID="email2" runat="server" placeholder="Enter Email" onkeyup="testemail()"></asp:TextBox>
                </div>
                <div class="form_input">                    
                 <asp:TextBox ID="password2" runat="server" placeholder="Enter Password" TextMode="Password" onkeyup="testpassword()" ></asp:TextBox>
                </div>
                <div class="form_input">                    
                 <asp:TextBox ID="repassword" runat="server" placeholder="Retype Password" onkeyup="repassword1()" TextMode="Password"></asp:TextBox>
                </div>
                <div class="form_input">                    
                 <asp:TextBox ID="name" runat="server" placeholder="Enter Name"></asp:TextBox>
                </div>
                <div class="form_input">                    
                 <asp:TextBox ID="city" runat="server" placeholder="Enter City"></asp:TextBox>
                </div>
        </div>
        
        <div class="cont">
            <p class="p1">Accident Geo-Watch</p>
            <p class="p2">Discover Places Using Map</p>
        </div>
        
       
         <div class="t">
                    <asp:Button ID="Button3" runat="server" Text="Register" CssClass="btn2" OnClick="Button2_Click"   />
          </div>


        <asp:Label ID="Label1" runat="server" ></asp:Label>
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
       <div id="advancedsearch">
             <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Selected="true">    Visualize Markers</asp:ListItem>
                <asp:ListItem>    Create Statistics</asp:ListItem>
            </asp:RadioButtonList>         
        </div>



        </div>
    </form>
</body>
</html>
