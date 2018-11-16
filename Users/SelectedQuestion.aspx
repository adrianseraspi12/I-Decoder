<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectedQuestion.aspx.cs" Inherits="SelectedQuestion" MasterPageFile="Main.master" %>

<asp:Content ContentPlaceHolderID="PlaceholderContent" runat="server" ID="ContentPH2">
    <div class="global-content">
        <div id="content">
            <br />
            <br />
            <div class="question">
            <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="true" />
                <table style="width: 100%" cellspacing="20">
                    <th colspan="2" style="text-align:left">
                        <asp:Label ID="titleQuestion" runat="server" Text="" CssClass="QTitle" />
                    </th>

                    <tr>
                        <td>
                            <span class="asked">Asked by:</span> <asp:Label ID="personQuestion" CssClass="asked" runat="server" Text="" />
                        </td>

                        <td>
                            <asp:Label ID="dateQuestion" runat="server" Text="" CssClass="asked" style="float: right"/>
                        </td>
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:Label ID="descriptionQuestion" runat="server" Text="" CssClass="QDescription" />
                        </td>
                    </tr>
                </table>
            </div>

            <div class="container-Answer">
                <h1>Solutions: </h1>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="False" >
                    <ContentTemplate>
                        <asp:Repeater ID="Repeater1" runat="server" >
                            <ItemTemplate>
                                <hr />
                                <br />
                                    <div class="answer-Indent">
                                        <div class="titleWidth">
                                            <span class="answer-font">RE:</span><asp:Label ID="lblTitle" runat="server" CssClass="answer-font" Text='<% #Eval("Title") %>' />
                                         </div>
                                         <br />
                                         <div class="width">
                                            <asp:Label ID="Label1" runat="server" CssClass="answer-font" Text='<% #Eval("Answer") %>' />
                                         </div>
                                         <br />
                                         <div class="answeredWidth">
                                             <span class="answer-font">Answered By:</span>
                                             <asp:Label ID="Label2" runat="server" CssClass="answer-font" Text='<% #Eval("Username") %>' />
                                             <asp:Label ID="Label3" CssClass="answer-font" style="float:right" runat="server" Text='<% #Eval("Date") %>' />
                                         </div>
                                     </div>
                                 <br />       
                            </ItemTemplate>
                        </asp:Repeater>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Timer2" EventName="Tick" />
                    </Triggers>                    
                </asp:UpdatePanel>
                <asp:Timer ID="Timer2" Interval="1000" runat="server" ontick="Timer2_Tick" />
            </div>
            
            <div class="answer-question">
                <br />
                <hr />
                <table cellspacing="20">
                    <th style="text-align:left; font-size: 26px">
                        Your Answer:
                    </th>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtAnswer" runat="server" CssClass="answerBox" 
                                TextMode="MultiLine" Height="190px" 
                                Width="835px" MaxLength="2000" />
                            
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <asp:Label ID="txtboxAnswer" CssClass="remaining-characters" Text="/2000" runat="server" />
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick" />
                       </td>
                        
                    </tr>
                    <tr>
                        <td style="text-align:right">
                            <asp:Button ID="btnPost" runat="server" Text="Post" CssClass="buttonPost" onclick="btnPost_Click" />
                        </td>
                    </tr>
                </table>
                <br />
                
                <br />
                
            </div>
        </div>
    </div>
</asp:Content>