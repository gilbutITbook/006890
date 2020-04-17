using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using MemoEngine.Models;

namespace MemoEngine.Account
{
    public partial class ForgotPassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // 사용자의 전자 메일 주소 확인
                var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                ApplicationUser user = manager.FindByName(Email.Text);
                if (user == null || !manager.IsEmailConfirmed(user.Id))
                {
                    FailureText.Text = "사용자가 없거나 확인되지 않았습니다.";
                    ErrorMessage.Visible = true;
                    return;
                }
                // 계정 확인 및 암호 재설정을 사용하도록 설정하는 방법에 대한 자세한 내용은 https://go.microsoft.com/fwlink/?LinkID=320771을 참조하세요.
                // 암호 재설정 페이지에 대한 코드 및 리디렉션이 포함된 전자 메일 보내기
                //string code = manager.GeneratePasswordResetToken(user.Id);
                //string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
                //manager.SendEmail(user.Id, "암호 재설정", "다음을 클릭하여 암호를 재설정하십시오. <a href=\"" + callbackUrl + "\">여기</a>");
                loginForm.Visible = false;
                DisplayEmail.Visible = true;
            }
        }
    }
}