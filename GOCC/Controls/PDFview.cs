using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace GOCC.Controls
{
    public class PDFview : WebView
    {
        public static readonly BindableProperty UriProperty = BindableProperty.Create(propertyName: "Uri", returnType: typeof(string), declaringType: typeof(PDFview), defaultValue: default(string));
        public string Uri
        {
            get { return (string)GetValue(UriProperty); }
            set { SetValue(UriProperty, value); }
        }
        public static BindableProperty IsPDFProperty = BindableProperty.Create(propertyName: "isPDF", returnType: typeof(bool), declaringType: typeof(PDFview), defaultValue: default(string));
        public bool IsPDF
        {
            get { return (bool)GetValue(IsPDFProperty); }
            set { SetValue(IsPDFProperty, value); }
        }
    }
}
