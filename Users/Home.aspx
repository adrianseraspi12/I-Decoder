<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Users_Default" MasterPageFile="~/Users/Main.master" %>

<asp:Content ContentPlaceHolderID="PlaceholderContent" runat="server" ID="ContentPH">
    <div class="global-content">
        <div id="content">
            <br />
            <br />
            <div id="QandA">
                <span class="QTitle">Questions</span>
                <br />
                <asp:Button ID="btnAsk" Text="Ask a Question" runat="server" CssClass="btnAsk" onclick="btnAsk_Click" />
            </div>    
            <div class="container-Question">
                    <asp:Repeater ID="QuestionRepeater" runat="server" 
                        OnItemCommand="QuestionRepeater_ItemCommand" 
                        onitemdatabound="QuestionRepeater_ItemDataBound" >
                        <ItemTemplate>
                            <hr />
                            Q: <asp:LinkButton ID="hlTitle" runat="server" Text='<% #Eval("Title") %>' />
                            <br />
                            <br />
                            <span class="fontsmall">Asked By:</span> <asp:Label ID="lblName" CssClass="questionUser" 
                                runat="server" Text='<% #Eval("Username") %>' />
                            <asp:Label ID="lblDate" runat="server" CssClass="questionDate" Text='<% #Eval("Date") %>' />
                        </ItemTemplate>
                        
                        <FooterTemplate>
                            <asp:Label ID="lblEmptyData" Text="No Questions Available, Be the first one to ask a question." runat="server" Visible="false" />
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
                
                <div>
                    <asp:Label ID="helpText" CssClass="text-help" runat="server" Visible="true" Text=" Our friends have problems! Let's Help them solve their problem" />
                </div>
        </div>
    </div>
</asp:Content>