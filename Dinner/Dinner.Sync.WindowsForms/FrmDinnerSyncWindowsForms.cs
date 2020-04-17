using Dinner.Common;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Dinner.Sync.WindowsForms
{
    public partial class FrmDinnerSyncWindowsForms : Form
    {
        public FrmDinnerSyncWindowsForms()
        {
            InitializeComponent();
        }

        private void btnMakeDinner_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //[1] 밥 만들기
            Rice rice = (new Cooking()).MakeRice();
            lblDisplay.Text = $"밥 준비 완료 - {rice.GetHashCode()}";

            //[2] 국 만들기
            Soup soup = (new Cooking()).MakeSoup();
            lblDisplay.Text = $"국 준비 완료 - {soup.GetHashCode()}";

            //[3] 달걀 만들기
            Egg egg = (new Cooking()).MakeEgg();
            lblDisplay.Text = $"달걀 준비 완료 - {egg.GetHashCode()}";

            stopwatch.Stop();
            lblDisplay.Text = $"\n시간: {stopwatch.ElapsedMilliseconds}밀리초";

            lblDisplay.Text = ("동기 방식으로 식사 준비 완료");
        }

        private void btnWachingTV_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = 
                "TV 보는 중... " + DateTime.Now.Millisecond.ToString(); 
        }
    }
}
