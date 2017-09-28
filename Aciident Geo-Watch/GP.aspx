<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GP.aspx.cs" Inherits="Aciident_Geo_Watch.GP" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta name="viewport" content="initial-scale=1.0, user-scalable=no"/>

    <title>Accident Geo-watch</title>
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no"/>
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
                background:  rgba(52,73,94,0.7); 
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
            #search{
                
                width: 200px;
                padding: 7px;
                border: 1px solid #607d8b;
            }
            #submit{
                position: fixed;
                padding: 7px;
                background: #377D7A;
                border: 1px solid #607d8b;
                font-family: sans-serif;
                color: white;
                margin-left: -1px;   
                cursor: pointer;
            }
             #submit:hover{
               background: red;
                 transition: all 0.45s;
                 opacity: 0.9;
                filter:alpha (opacity=70); /* IE8 earlier */ 
            }
            #s1{
                position: absolute; top:80px;  right:70px;
            }
            #s2{
                position: absolute; top:80px;  right:70px;
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
        .ttt {
            position:absolute;
            top:0px;
            right: 1050px;
        }
        #googleMap {
            margin-top:15px;
            border: 1px solid #fff;
            position:absolute;
            top:150px;
        }
        #mapsearch {
            position:absolute;
            right:-60px;
            width:270px;
            height:30px;
            border: 1px solid #607d8b;
            border-radius:6px;
        }

          #info{
              border-radius:1px;
            width:280px;
            height:120px;
            background-color:white;
            position:absolute;
            top:510px;
            left:20px;
            border: 1px solid #000;
        }
        #i1 {
            position:absolute;
            top:40px;
            left:10px;

        }
         #i2 {
            position:absolute;
            top:40px;
            left:80px;

        }

           #i3 {
            position:absolute;
            top:40px;
            left:160px;

        }
            #i4 {
            position:absolute;
            top:40px;
            left:230px;

        }
        #i5 {
            position:absolute;
            top:9px;
            left: 65px;
        }
         #p1 {
            position:absolute;
            top:70px;
            left:13px;
            font-size:70%;
        }
          #P2{
            position:absolute;
            top:70px;
            left:77px;
            font-size:70%;

        }
           #P3 {
            position:absolute;
            top:70px;
            left:166px;
            font-size:70%;

        }
            #P4 {
            position:absolute;
            top:70px;
            left:225px;
            font-size:70%;

        }
        #advancedsearch {
            width:150px;
            height:190px;
            background-color:white;
            position:absolute;
            top:450px;
            right:60px;
            border:1px solid #000;
            border-radius:5px;

        }
        .v1 {
            display:inline-block;
            padding:5%;
            font-weight: bold;
            color: black;
            font-size:85%;
        }
        .v2 {
            position:absolute;
            right:2px;
        }
        #t1 {
            margin-top:10px;
        }
        #CheckBox1,#CheckBox2,#CheckBox3,#CheckBox4 {


            position:absolute;
            margin-top:10px;
            right:10px;
        }
        #CheckBox1 {
            margin-top:20px;
        }
        #labelsearch {
            width:60px;
            padding:5px;
            margin-top:20px;
            margin-left:43px;
            border-radius:2px;
            background-color:red;
        }
                    #labelsearch{
                        width:60px;
            padding:5px;
            margin-top:20px;
            margin-left:43px;
                            border: none;
            border-radius:4px;
             background-color: #2ecc7a;       
                color: white;
            }
                 #labelsearch:hover{
                 background: red;
                 color:white;
                 transition: all 0.45s;
                 opacity: 1;
                filter:alpha (opacity=70); /* IE8 earlier */ 
            }

        #number {
            position:absolute;
            top:485px;
            left:20px;
            width:100px;
            height:20px;
            background-color:white;
            border:1px solid #000;
            padding-left:10px;
        }
        </style>
    <script>
    </script>
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
               <div class="ttt"> 
                   <div id="s1"> <input type="text" placeholder="   Search Location....." maxlength="20" id="mapsearch"/> </div>
               </div>

    
        <asp:Button ID="Button1" runat="server" Text="Logout" CssClass=".btn" OnClick="Button1_Click" />
          <div id="googleMap" style="width:1330px;height:500px;"></div>


        <div id="info">
            <b id="i5">Marker Information</b>
            <img src="m1.png"  id="i1"/>
            <img src="m2.png"  id="i2"/>
            <img src="m3.png"  id="i3"/>
            <img src="m4.png"  id="i4"/>
            <p id="p1">Theft</p>
            <p id="P2">Murder</p>
            <p id="P3">Fire</p>
            <p id="P4">Accident</p>

        </div>
        <div id="advancedsearch">
                      <span class="v1" id="t1">Theft</span>  <asp:CheckBox ID="CheckBox1" runat="server"  /><br />
                     <span  class="v1"> Murder</span>   <asp:CheckBox ID="CheckBox2" runat="server" /><br />
                      <span class="v1"> Fires</span>  <asp:CheckBox ID="CheckBox3" runat="server" /><br />
                       <span class="v1">Accident</span> <asp:CheckBox ID="CheckBox4" runat="server" /><br />
            <asp:Button ID="labelsearch" runat="server" Text="Search" OnClick="labelsearch_Click" />

        </div>
        <div id="number">
           <asp:Label ID="Label1" runat="server" Text="Label" Font-Size="11px"></asp:Label><span style="font-size:11px;"> Results Found</span>
        </div>

         

        <script>


            ////////////////////////////
            function bindInfoWindow(marker, map, infowindow, html) {
                marker.addListener('click', function () {
                    infowindow.setContent(html);
                    infowindow.open(map, this);
                });
            }
            ////////////////////////////
            function myMap() {
                var mapProp = {
                    //center: new google.maps.LatLng(30.044727, 31.236191),
                    center: new google.maps.LatLng(30.477082932837682, 31.23138427734375),
                    //23.92, 32.8
                    zoom: 8,
                };
                var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

                ///////////////////////////////////////////////////////////////////
                var n;
                var m;
                //var markers;
                var infowindow = new google.maps.InfoWindow();
                var a = JSON.parse('<%= this.javaSerial.Serialize(this.l)%>');
                var aa = JSON.parse('<%= this.javaSerial.Serialize(this.ll)%>');


                if (aa.length != 0) {

                    document.getElementById('Label1').innerText = aa.length;
                    for (i = 0; i < aa.length; i++) {
                        var x = aa[i];
                        var splitted = x.split('@');

                        n = parseFloat(splitted[4]);
                        m = parseFloat(splitted[5]);

                        if (splitted[3] == "accident") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m4.png"

                            });

                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);

                        }
                            ////////////////////////////////////////////////////////////
                        else if (splitted[3] == "theft") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m1.png"
                            });
                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);

                        }
                            ///////////////////////////////////////////////
                        else if (splitted[3] == "murder") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m2.png"
                            });
                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);
                        }
                            //////////////////////////////////////////////////

                        else if (splitted[3] == "fires") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m3.png"
                            });
                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);


                        }


                    }

                }


                else if (aa.length == 0) {

                    document.getElementById('Label1').innerText = a.length;
                    for (i = 0; i < a.length; i++) {
                        var x = a[i];
                        var splitted = x.split('@');

                        n = parseFloat(splitted[4]);
                        m = parseFloat(splitted[5]);

                        if (splitted[3] == "accident") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m4.png"

                            });

                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);

                        }
                            ////////////////////////////////////////////////////////////
                        else if (splitted[3] == "theft") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m1.png"
                            });
                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);

                        }
                            ///////////////////////////////////////////////
                        else if (splitted[3] == "murder") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m2.png"
                            });
                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);
                        }
                            //////////////////////////////////////////////////

                        else if (splitted[3] == "fires") {
                            var markers = new google.maps.Marker({
                                position: {
                                    lat: n,
                                    lng: m,
                                },
                                map: map,
                                icon: "m3.png"
                            });
                            var temp = '<b>Type:  </b>' + splitted[3] + '</br>' + '<b>' + 'Location:  </b>' + splitted[2] + '</br>' + '<b>' + 'Date:  </b>' + splitted[6] + '</br>' + '<b>' + 'Longitude:  </b>' + splitted[4] + '</br>' + '<b>' + 'Latitude: </b>' + splitted[5] + '</br></br>' + '<b style="color:red;">' + splitted[0] + '</b></br></br>' + '<a href=' + splitted[1] + '>' + 'View More Details' + '</a>' + '</br>';
                            bindInfoWindow(markers, map, infowindow, temp);


                        }


                    }

                }



                var searchbox = new google.maps.places.SearchBox(document.getElementById('mapsearch'));
                google.maps.event.addListener(searchbox, 'places_changed', function () {
                    var places = searchbox.getPlaces();
                    var bounds = new google.maps.LatLngBounds();
                    var i, place;
                    for (i = 0; place = places[i]; i++) {
                        bounds.extend(place.geometry.location);
                        //marker.setPosition(place.geometry.location);
                    }
                    map.fitBounds(bounds);
                    map.setZoom(15);
                });

            }
        </script>



        <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyA_y6rodCBLGP7aqFh9YpV-CXedtMlR0bc&callback=myMap&libraries=places"></script>

        

       







    </div>
    </form>
      </body>
</html>
