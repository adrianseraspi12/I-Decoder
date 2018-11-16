<%@ Page Title="" Language="C#" MasterPageFile="~/Users/Main.master" AutoEventWireup="true" CodeFile="AskAnswer.aspx.cs" Inherits="Users_AskAnswer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PlaceholderContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="true" />
    <div class="global-content">
    <div id="content">
        <br />
        <br />
        <div id="QandA">
            <span class="QTitle">Ask a Question</span>
            <br />
            <asp:Button ID="btnAnswerQuestions" CssClass="btnAnswerQuestions" runat="server" Text="Answer a Question" 
                onclick="btnAnswerQuestions_Click" />
        </div>
        <div class="asking-container">
            <hr />
            
                <table cellspacing="30">
                    <tr>
                        <td class="style1">
                            Title:
                        </td>
                        <td class="style1">
                            <asp:TextBox ID="txtboxTitle" CssClass="titleBox" runat="server" Height="33px" 
                                        Width="532px" MaxLength="200" />
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <br />
                                    <asp:Label ID="titleCharacters" CssClass="remaining-characters" runat="server" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                </Triggers>
                            </asp:UpdatePanel>
                                      
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            Description:
                        </td>
                        <td>
                            <asp:TextBox ID="txtboxDescription" CssClass="descriptionBox" runat="server" TextMode="MultiLine" 
                                Height="137px" Width="532px" MaxLength="2000" />
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <br />
                                    <asp:Label ID="descriptionCharacters" CssClass="remaining-characters" runat="server" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align:right;">
                            <asp:Button ID="btnAskNow" runat="server" Text="Ask" CssClass="btnAsk" onclick="btnAskNow_Click" />
                        </td>
                    </tr>
                </table>
            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick" />
        </div>
    </div>
</div>
</asp:Content>