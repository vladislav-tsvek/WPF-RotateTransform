using DotNetBrowser;
using DotNetBrowser.WPF;
using System;
using System.Windows;
using System.Windows.Media;

namespace WPF_RotateTransform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BrowserView webView;

        public MainWindow()
        {
            InitializeComponent();

            webView = new WPFBrowserView(BrowserFactory.Create(BrowserType.LIGHTWEIGHT));
            WPFWeb.Children.Add((UIElement)webView.GetComponent());

            webView.Browser.LoadURL("http://www.google.com");            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           try
            {
                RotateTransform rotate = new RotateTransform(Convert.ToDouble(textBoxAngle.Text),
                    Convert.ToDouble(textBoxCenterX.Text), Convert.ToDouble(textBoxCenterY.Text));

                WPFWeb.RenderTransform = rotate;
            }
            catch { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!webView.Browser.IsDisposed())
            {
                webView.Dispose();
                webView.Browser.Dispose();
            }
        }
    }
}
