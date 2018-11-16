<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Main.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="Users_UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 7px;
            width: 400px;
        }
        .style2
        {
            width: 119px;
        }
        .style3
        {
            width: 400px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="PlaceholderContent" Runat="Server">
    <div class="global-content">
    <div id="content">
        <table style="position: relative; left: 58px; top: 40px; width: 80%; height:120px">
            <tr>
                <td rowspan="3" class="style2">
                    <asp:Image ID="imgProfile" runat="server" ImageUrl="~/Images/red.jpg" Height="120px" Width="120px" />
                <!--    <asp:FileUpload ID="fuProfile" runat="server" style="position: absolute; left: 10px; top: 50px" visible="false" /> -->
                </td>
                <td class="style1">
                
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Label ID="lblUsername" runat="server" Text="" style="font-size: 28px;"  />
                    <br />
                    <asp:Button ID="btnLogout" runat="server" Text="Logout" 
                        onclick="btnLogout_Click" />
                </td>
            </tr>
            <tr>
                <td class="style3">
                    <asp:Button ID="btnSave" runat="server" Text="Save" style="position:absolute; top:100px" 
                        visible="false" onclick="btnSave_Click"/>
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
                        style="position:relative; left: 50px; top: 45px;" visible="false" 
                        onclick="btnCancel_Click"/>
                </td>
            </tr>
        </table>
        <hr width="80%" style="position: relative; top: 70px; left: 10%" />

        <div style="position: relative; top: 120px; display:block; left: 10%;">
            <table style=" width: 80%">
                <tr>
                    <td align="center">
                        <span style="font-size: 24px;">Asked</span>
                    </td>
                    <td align="center">
                        <span style="font-size: 24px;">Answered</span>
                    </td>
                </tr>

                <tr>
                    <td align="center">
                        <div class="circle">
                            <asp:Label ID="lblAsked" runat="server" Text="0" style="font-size: 30px; position: relative; top: 32px;" />
                        </div>
                    </td>
                    <td align="center">
                        <div class="circle">
                            <asp:Label ID="lblAnswered" runat="server" Text="0" style="font-size: 30px; position: relative; top: 32px;" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        
        <div class="container-Answer" style="margin-top: 180px">
            <h3>Recently Asked Questions</h3>
            <div>
                <asp:Repeater ID="rptRecentlyAskedQuestion" runat="server" 
                    onitemcommand="rptRecentlyAskedQuestion_ItemCommand">
                    <ItemTemplate>
                        <hr />
                            <br />
                                <div class="answer-Indent">
                                    <div class="titleWidth">
                                        <span class="answer-font">RE:</span><asp:LinkButton ID="lblTitle" runat="server" CssClass="answer-font" Text='<% #Eval("Title") %>' />
                                    </div>
                                    <br />
                                    <div class="answeredWidth">    
                                        <asp:Label ID="Label3" CssClass="answer-font" runat="server" Text='<% #Eval("Date") %>' />
                                    </div>
                                    </div>
                                <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>    
        </div>
    </div>
    </div>
</asp:Content>

