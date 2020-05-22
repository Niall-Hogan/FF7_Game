<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="OO_Practice.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>

      
        /* Flex container to hold all elements */
        .container {
            width: 100%;
            height: 900px;
            display: flex;
            flex-shrink:0;
            min-width:80%;
            background: rgb(2,0,36);
            background: linear-gradient(45deg, rgba(2,0,36,0.9051995798319328) 0%, rgba(9,9,121,1) 6%, rgba(0,164,255,1) 100%);

        }

        /* Container to hold teams charcters */
        .teams {
            width: 20%;
            height: auto;
            border: solid 2px #D6D5DD;
            display: flex;
            flex-direction: column;

        }

        /* Holds character images */
        .chars {
            display:block;
            width: 150px;
            height: 150px;
            border: 2px black solid;
            margin: auto;
        }

   

        /* holds team name */
        .teamHead {
            width: auto;
            height: 70px;
            position: relative;
            font-family: Verdana, sans-serif;
            color:aliceblue;
            font-weight:bold;
            font-size:20px;
            text-align: center;
            margin:auto;
            border-bottom:solid 2px #D6D5DD;

        }

        /* holds active players and console */
        #playArea {
            width: 60%;
            height: auto;
            display: flex;
            flex-direction: row;
            flex-wrap: wrap;
            justify-content: center;
        }

        .player {
            width: 250px;
            height: 400px;
            border: solid 2px #D6D5DD;
            border-radius:10px;
            margin: auto;
            display: flex;
            flex-direction: column;
            
        }

     

        #start 
        {
            position:fixed;
            margin-top:200px;
            padding:20px;
        }

        .health {
            height: 30px;
            width: 200px;
            margin: auto;
            font-family: Verdana, sans-serif;
            color:aliceblue;
            font-size:22px;
            text-align:center;
           
        }
        #p1Stats, #p2Stats {
            width: 100px;
            height: 100px;
            margin: auto;
            padding-top:20px;
            
        }

        #attackp1,#attackP2,#p1Choose,#p2Choose,#changeChar1,#changeChar2 {
            border-radius:10px;
        }

       

        #stats1, #stats2 {
            font-family: Verdana, sans-serif;
            color:aliceblue;
            font-size:14px;
            text-align:center;
        }

        .console {
            width: 55%;
            height: 200px;
            border: solid 5px #D6D5DD;
            border-radius:10px;
            margin: auto;
            display: flex;
            flex-direction: column;

        }

        #console {
            resize:none;
            line-height:150%;
        }

        #console::-webkit-scrollbar{
            display: none;
        }


    </style>
</head>
<body>
    <form id="form1" runat="server">
     
        <div class="container">

        <div class="teams">
            <div class="teamHead">
                <asp:Label ID="lblT1" runat="server" Text=""></asp:Label>
            </div>
            <div class="chars">
                <asp:ImageButton ID="Image1" runat="server" Visible="False" OnClick="Image1_Click" Enabled="False" />
                </div>
            <div class="chars">
                <asp:ImageButton ID="Image2" runat="server" Visible="False" OnClick="Image2_Click" Enabled="False" /></div>
            <div class="chars">
                <asp:ImageButton ID="Image3" runat="server" Visible="False" OnClick="Image3_Click" Enabled="False" /></div>
            <div class="chars">
                <asp:ImageButton ID="Image4" runat="server" Visible="False" OnClick="Image4_Click" Enabled="False" /></div>
        </div>

        <div id="playArea">

            <div class="player">
                <div class="chars">
                    <asp:Image ID="imageP1" runat="server" />
                </div>
                  <div class ="health">   
                      <asp:Label ID="p1Name" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="health"> 
                    <asp:Button ID="attackp1" runat="server" Text="Attack" Style ="margin:auto; display:block;" Width="200px" Height="30px " OnClick="attackp1_Click" Enabled="False" />
                </div>
                <div class="health"> 
                    <asp:Button ID="p1Choose" runat="server" Text="Choose Card" Style="margin:auto; display:block;" Width="200px" Height="30px" OnClick="p1Choose_Click" Enabled="False" />
                </div>
                <div class="health"> 
                    <asp:Button ID="changeChar1" runat="server" Text="Change Character" Style="margin:auto; display:block;" Width="200px" Height="30px" OnClick="changeChar1_Click" Enabled="False" />
                </div>
                <div id ="p1Stats"> <asp:Label ID="stats1" runat="server" Text=""></asp:Label> </div>
            </div>
            <asp:Button ID="start" runat="server" Text="Start" Height="50px" Width="200px" OnClick="start_Click" />
            <div class="player">
                <div class="chars">
                    <asp:Image ID="imageP2" runat="server"  />
                </div>
                <div class ="health">   
                    <asp:Label ID="p2Name" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
                <div class="health"> 
                    <asp:Button ID="attackP2" runat="server" Text="Attack" Style="margin:auto; display:block;" Width="200px" Height="30px" OnClick="attackP2_Click" Enabled="False" />
                </div>
                <div class="health">
                    <asp:Button ID="p2Choose" runat="server" Text="Choose Card" Style="margin:auto; display:block;" Width="200px" Height="30px" OnClick="p2Choose_Click" Enabled="False" />

                </div>
                <div class="health"> 
                    <asp:Button ID="changeChar2" runat="server" Text="Change Character" Style="margin:auto; display:block;" Width="200px" Height="30px" OnClick="changeChar2_Click" Enabled="False" />
                </div>
                <div id ="p2Stats"> <asp:Label ID="stats2" runat="server" Text=""></asp:Label></div>
            </div>

            <div class="console" >
                <asp:TextBox ID="console" runat="server" Height="150px" Width="300px" Style="margin:auto; display:block;" TextMode="MultiLine" BackColor="transparent" Font-Names="Verdana" ForeColor="White"  />

            </div>
        </div>



        <div class="teams">
            <div class="teamHead">
                <asp:Label ID="lblT2" runat="server" Text=""></asp:Label>
            </div>
            <div class="chars">
                <asp:ImageButton ID="Image5" runat="server" Visible="False" OnClick="Image5_Click" Enabled="False" /></div>
            <div class="chars">
                <asp:ImageButton ID="Image6" runat="server" Visible="False" OnClick="Image6_Click" Enabled="False" /></div>
            <div class="chars">
                <asp:ImageButton ID="Image7" runat="server" Visible="False" OnClick="Image7_Click" Enabled="False" /></div>
            <div class="chars">
                <asp:ImageButton ID="Image8" runat="server" Visible="False" OnClick="Image8_Click" Enabled="False" /></div>

        </div>
    </div>

    </form>
</body>
</html>
