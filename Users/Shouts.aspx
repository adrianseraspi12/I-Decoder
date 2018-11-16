<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Shouts.aspx.cs" Inherits="Users_Shouts" MasterPageFile="Main.master"  %>

<asp:Content ID="ShoutsContent" ContentPlaceHolderID="PlaceholderContent" runat="server">
<div class="global-content">
    <div id="content">
        <br />
        <h1 class="titleShout">Community Shout Box</h1>
        <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="True">
        </asp:ScriptManager>
        <div class="container-chat">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False" >
                <ContentTemplate>
                    <asp:Repeater ID="Repeater1" runat="server" >
                        <ItemTemplate>
                            <div class="mes-align">
                                <table cellspacing="5">
                                    <tr>
                                        <td>
                                            <asp:Image ID="defaultImage" runat="server" CssClass="userPic" ImageUrl='<% #Eval("Pictures") %>' />
                                        </td>
                                        <td>
                                            <asp:Label ID="lblName" style="margin-right: 5px" runat="server" Text='<% #Eval("Username") %>' />
                                            <asp:Label ID="lblTime" style="margin-right: 5px" runat="server" Text='<% #Eval("Time") %>' />
                                            <asp:Label ID="lblMessage" style="margin-right: 5px" runat="server" Text='<% #Eval("Message") %>' />
                                        </td>
                                    </tr>
                                </table>
                                
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick" />
        </div>

        <div class="userBox">
            <asp:Label ID="lblUser" runat="server" Visible="false" />
            <table cellspacing="20">
                <tr>
                    <td>
                        <asp:Image ID="userImage" style="margin-bottom: 25px;" runat="server" CssClass="userPic" />
                    </td>
                    <td>
                        <asp:TextBox ID="MessageBox" runat="server" TextMode="MultiLine" MaxLength="300"
                            Placeholder="Write Something" Height="50px" Width="500px" />
                            <br />
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False" >
                            <ContentTemplate>
                                <asp:Label ID="lblShouts" runat="server" Text="/300" CssClass="shouts" />
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:Timer ID="Timer2" runat="server" Interval="175" ontick="Timer2_Tick" />
                    </td>
                    <td>
                        <asp:Button ID="btnShout" CssClass="ShoutButton" runat="server" Text="Shout" onclick="btnShout_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
 </div>
    

</asp:Content>