using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _6_TestMultiWindows
{
    /// <summary>
    /// Interaction logic for sousWindow.xaml
    /// </summary>
    public partial class sousWindow : Window
    {
        private readonly MainWindow proprio;
        public sousWindow(MainWindow owner)
        {
            InitializeComponent();
            proprio = owner;
        }

        private void btnSubWindow_Click(object sender, RoutedEventArgs e)
        {            
            proprio.txtbxMainWindow.Text = txtbxSubWindow.Text;
            this.Close();
        }
    }
}
