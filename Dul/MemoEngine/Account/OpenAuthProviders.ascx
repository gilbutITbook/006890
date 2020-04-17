<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OpenAuthProviders.ascx.cs" Inherits="MemoEngine.Account.OpenAuthProviders" %>

<div id="socialLoginList">
    <h4>다른 서비스를 사용하여 로그인합니다.</h4>
    <hr />
    <asp:ListView runat="server" ID="providerDetails" ItemType="System.String"
        SelectMethod="GetProviderNames" ViewStateMode="Disabled">
        <ItemTemplate>
            <p>
                <button type="submit" class="btn btn-default" name="provider" value="<%#: Item %>"
                    title="사용자의 계정을 사용하여 <%#: Item %> 로그인합니다.">
                    <%#: Item %>
                </button>
            </p>
        </ItemTemplate>
        <EmptyDataTemplate>
            <div>
                <p>구성된 외부 인증 서비스가 없습니다. 외부 서비스를 통한 로그인을 지원하도록 이 ASP.NET 응용 프로그램을 설정하는 방법에 대한 자세한 내용은 <a href="https://go.microsoft.com/fwlink/?LinkId=252803">이 문서</a>를 참조하세요.</p>
            </div>
        </EmptyDataTemplate>
    </asp:ListView>
</div>
