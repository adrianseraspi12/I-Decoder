<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUp.aspx.cs" Inherits="SignUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="~/css/main.css" />
    <link rel="stylesheet" type="text/css" media="only screen and (min-width:768px) and (max-width:980px)" href="~/css/largestyle.css" />
    <link rel="stylesheet" type="text/css" media="only screen and (min-width:600px) and (max-width:767px)" href="~/css/mediumstyle.css" />
    <link rel="stylesheet" type="text/css" media="only screen and (min-width:445px) and (max-width:599px)" href="~/css/smallstyle.css" />
    <link rel="stylesheet" type="text/css" media="only screen and (min-width:300px) and (max-width:444px)" href="~/css/xsmallstyle.css" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="global-container">
            <header>
                <div class="header-wrapper">
                    <ul class="headerList">     
                        <li class="logo">
                            <asp:Image ID="logoPic" ImageUrl="~/Images/Logo.jpg" runat="server"/>
                        </li>
                        <li class="headerList-item itemThree"> 
                            <a id="showSignUp" class="spanList" runat="server" causesvalidation="false" onclick="showSignUp_Click"
                                style="text-decoration:none; color:Black">SignUp</a> 
                        </li>
                        <li class="headerList-item itemFour"> 
                            <a id="showLogIn" class="spanList" runat="server" causesvalidation="false" onclick="showLogIn_Click" 
                                style="text-decoration:none; color:Black">LogIn</a>
                        </li>
                    </ul>
                </div>
            </header>

            <main>
                <div class="wrapper">
                    <asp:Image ID="headerPic" runat="server" ImageUrl="~/Images/back2.jpg" />
                    <div class="header-text"></div>
                        <div class="textHeader">
                            <h1 class="joinTitle">Join Us Now!</h1>
                            <p class="joinDescription">
                            Forums are a great place to find what's new, what's trendy and hot for today. Participating
                            in forums discussions not only allow you to share your interest and first-hand tips, but to
                            gain knowledge as well. This is a perfect place to look for design, feedback and ask for possible
                            solutions when facing technical difficulties.
                            </p>
                        </div>
                    <div class="newWrapper"></div>
                        <div id="SU" class="SignUp" runat="server">
                            <span>Username</span><br />
                            <asp:TextBox ID="newUser" CssClass="uName" runat="server" ValidationGroup="validate" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" 
                                ControlToValidate="newUser" />
                            <br />
                            <span>Password:</span><br />
                            <asp:TextBox ID="newPass" CssClass="pWord" runat="server" ValidationGroup="validate" TextMode="Password" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*"
                                ControlToValidate="newPass" />
                            <br />
                            <span>Re-Type Password:</span><br />
                            <asp:TextBox ID="rtPass" CssClass="pWord" runat="server" ValidationGroup="validate" TextMode="Password" />
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="newPass" 
                                ControlToValidate="rtPass" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage=""
                                ControlToValidate="rtPass" />
                            <br />
                            <asp:Button ID="btnSignUp" CssClass="login" runat="server" Text="SignUp" onclick="btnSignUp_Click" />
                        </div>
                </div>
                <div class="introduction-block">
                    <div class="intro first-intro">
                        <asp:Image ID="connectPic" runat="server" ImageUrl="~/Images/connect.jpg" />
                        <div class="intro-title">CONNECT</div>
                        <div class="intro-content">
                        There are 7 billion people living in this world and there are 7 continents that are connected
                            in the internet. CONNECT with them and have fun talking to them 
                        </div>
                    </div>

                    <div class="intro second-intro">
                        <asp:Image ID="sharePic" runat="server" ImageUrl="~/Images/share.png" />
                        <div class="intro-title">SHARE</div>
                        <div class="intro-content">Maybe you want to share your "<i>work of art</i>" code or your 
                            projects you build? SHARE it and people here in I-Decoder will see your work.</div>
                    </div>

                    <div class="intro third-intro" style="margin-right: 0;">
                        <asp:Image ID="aamPic" runat="server" ImageUrl="~/Images/meet.jpeg" />
                        <div class="intro-title">ASK, ANSWER, MEET</div>
                        <div class="intro-content">Having Trouble in technical stuff? ASK a question. 
                            Do you want to help those who are in Trouble? ANSWER their questions. and MEET them</div>
                    </div>
                    
                </div>
            </main>

            <footer>
                <div class="footer">
                    <div id="social">
                        <asp:ImageButton ID="socialFb" CssClass="social-cons" PostBackUrl="https://facebook.com" ImageUrl="~/Images/fb.png" runat="server" CausesValidation="False" />
                        <asp:ImageButton ID="socialTwitter" CssClass="social-cons" PostBackUrl="https://twitter.com" ImageUrl="~/Images/twitter.png" runat="server" CausesValidation="False" />
                        <asp:ImageButton ID="socialGoogle" CssClass="social-cons" PostBackUrl="https://gmail.com" ImageUrl="~/Images/google+.png" style="margin-right:0px" runat="server" CausesValidation="False" />
                    </div>
                </div>
            </footer>
        </div>
    </form>
</body>
</html>
