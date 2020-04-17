<%@ Page Title="암호가 변경됨" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="MemoEngine.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div>
        <p>암호가 변경되었습니다. 로그인하려면 <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">여기를</asp:HyperLink> 클릭하십시오. </p>
    </div>
</asp:Content>
