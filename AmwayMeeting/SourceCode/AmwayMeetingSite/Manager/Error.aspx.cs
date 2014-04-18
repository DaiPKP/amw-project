using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Threading;

public partial class Manager_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        byte[] delay = new byte[1];

        RandomNumberGenerator prng = new RNGCryptoServiceProvider();

        prng.GetBytes(delay);

        Thread.Sleep((int)delay[0]);

        IDisposable disposable = prng as IDisposable;

        if (disposable != null) { disposable.Dispose(); }
    }
}