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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _5_CalculatriceFonctionnelle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Double> memorisationNum = new List<Double>();
        private String memorisationSign;
        private Double resultat = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        private void num_Click(object sender, RoutedEventArgs e)
        {
            txtblckAfficheurActu.Text += ((Button)(sender)).Content;
        }

        private void symb_Click(object sender, RoutedEventArgs e)
        {
            if (Double.TryParse(txtblckAfficheurActu.Text, out double valeurActu))
            {
                txtblckAfficheurMemo.Text += txtblckAfficheurActu.Text + ((Button)(sender)).Content;
                memorisationNum.Add(valeurActu);
                if (memorisationSign != null)
                {
                    switch (memorisationSign)
                    {
                        case "+":
                            resultat += valeurActu;
                            txtblckAfficheurActu.Text = "";
                            break;
                        case "-":
                            resultat -= valeurActu;
                            txtblckAfficheurActu.Text = "";
                            break;
                        case "*":
                            resultat *= valeurActu;
                            txtblckAfficheurActu.Text = "";
                            break;
                        case "/":
                            resultat /= valeurActu;
                            txtblckAfficheurActu.Text = "";
                            break;
                        default:
                            break;
                    }
                    if ((String)((Button)(sender)).Content=="=")
                    {
                        txtblckAfficheurMemo.Text += resultat.ToString();
                        txtblckAfficheurActu.Text = resultat.ToString();
                        memorisationSign = null;
                    }
                }
                else
                {
                    resultat = valeurActu;
                    txtblckAfficheurActu.Text = "";
                }
                memorisationSign = (String)((Button)(sender)).Content;
            }

        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private void cancelCur_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
