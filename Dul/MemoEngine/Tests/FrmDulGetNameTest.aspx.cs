using System;

namespace MemoEngine.Tests
{
    public partial class FrmDulGetNameTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Dul.Creator.GetName());
        }
    }
}
