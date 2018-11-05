using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DoCallService(object sender, EventArgs e)
        {
            divOutput.InnerHtml += "DoCallService Called<br/>";

            HttpClient client = new HttpClient();

            Task<HttpResponseMessage> resp = client.GetAsync("http://localhost/webapisvc/api/websvc/test");

            resp.Wait();
            string s;

            using (MemoryStream stm = new MemoryStream())
            {
                resp.Result.Content.CopyToAsync(stm).Wait();
                s = Encoding.UTF8.GetString(stm.ToArray());
            }

            divOutput.InnerText += $"Response = {s}";
        }
    }
}