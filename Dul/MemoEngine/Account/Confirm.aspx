<%@ Page Title="계정 확인" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Confirm.aspx.cs" Inherits="MemoEngine.Account.Confirm" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div>
        <asp:PlaceHolder runat="server" ID="successPanel" ViewStateMode="Disabled" Visible="true">
            <p>
                계정을 확인해 주셔서 감사합니다. 로그인하려면 <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">여기를</asp:HyperLink>  클릭하십시오.             
            </p>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="errorPanel" ViewStateMode="Disabled" Visible="false">
            <p class="text-danger">
                오류가 발생했습니다.
            </p>
        </asp:PlaceHolder>
    </div>
</asp:Content>
