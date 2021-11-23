using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GOCC.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Java.Net;
using GOCC.Controls;
using System.Net;

[assembly: ExportRenderer(typeof(PDFview), typeof(PDFViewRenderer))]
namespace GOCC.Droid
{
    public class PDFViewRenderer : WebViewRenderer
    {
        public PDFViewRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var customWebView = Element as PDFview;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.LoadUrl(string.Format("file:///android_asset/pdfjs/web/viewer.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(customWebView.Uri))));
            }
        }
    }
}