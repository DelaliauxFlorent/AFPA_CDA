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
        private String memorisationSign;
        private Double resultat = 0;
        private String[] listeOperandes = { "+", "-", "*", "/"};
        private bool justEqual = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void num_Click(object sender, RoutedEventArgs e)
        {
            if (justEqual)
            {
                txtblckAfficheurActu.Text = "";
                txtblckAfficheurMemo.Text = "";
                memorisationSign = null;
                justEqual = false;
            }
            txtblckAfficheurActu.Text += ((Button)(sender)).Content;
        }

        private void symb_Click(object sender, RoutedEventArgs e)
        {
            //if (txtblckAfficheurActu.Text == "" &&
            //    (txtblckAfficheurMemo.Text[txtblckAfficheurMemo.Text.Length-1]=='+' ||
            //    txtblckAfficheurMemo.Text[txtblckAfficheurMemo.Text.Length - 1] == '-' ||
            //    txtblckAfficheurMemo.Text[txtblckAfficheurMemo.Text.Length - 1] == '*' ||
            //    txtblckAfficheurMemo.Text[txtblckAfficheurMemo.Text.Length - 1] == '/'))
            //{
            //    txtblckAfficheurMemo.Text = txtblckAfficheurMemo.Text.Remove(txtblckAfficheurMemo.Text.Length-1, 1);
            //    txtblckAfficheurMemo.Text += ((Button)(sender)).Content;
            //    memorisationSign= (String)((Button)(sender)).Content;
            //}
            if (Double.TryParse(txtblckAfficheurActu.Text, out double valeurActu))
            {
                if (justEqual)
                {
                    txtblckAfficheurMemo.Text = "";
                    memorisationSign = null;
                    justEqual = false;
                }
                txtblckAfficheurMemo.Text += txtblckAfficheurActu.Text + ((Button)(sender)).Content;
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
                    if ((String)((Button)(sender)).Content == "=")
                    {
                        //txtblckAfficheurMemo.Text = "";
                        //txtblckAfficheurActu.Text = resultat.ToString();
                        txtblckAfficheurActu.Text = eval(txtblckAfficheurMemo.Text.Remove(txtblckAfficheurMemo.Text.Length-1)).ToString();
                        memorisationSign = null;
                        justEqual = true;
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
            memorisationSign = null;
            resultat = 0;
            txtblckAfficheurMemo.Text = "";
            cancelCur_Click(sender, e);
        }
        private void cancelCur_Click(object sender, RoutedEventArgs e)
        {
            txtblckAfficheurActu.Text = "";
        }

        private Double eval(String histo)
        {
            if (Double.TryParse(histo, out Double valeur))
            {
                return valeur;
            }
            else
            {
                int indexListeCar = 0;
                String[] tableau;
                String sign = " ";
                do
                {
                    String[] caractSplit = { listeOperandes[indexListeCar] };
                    tableau = histo.Split(caractSplit, 2);
                    histo.Split()
                    if (tableau.Length == 2)
                    {
                        sign = listeOperandes[indexListeCar];
                    }
                    else
                    {
                        indexListeCar++;
                    }
                } while ((indexListeCar < listeOperandes.Length) && !listeOperandes.Contains(sign));
                if (listeOperandes.Contains(tableau[0][tableau[0].Length - 1]))
                {
                    tableau[1] = sign + tableau[1];
                    sign = tableau[0][tableau[0].Length - 1];
                    tableau[0] = tableau[0].Remove(tableau[0].Length - 1);
                }
                switch (sign)
                {
                    case '+':
                        return eval(tableau[0]) + eval(tableau[1]);
                    case '-':
                        return eval(tableau[0]) - eval(tableau[1]);
                    case '*':
                        return eval(tableau[0]) * eval(tableau[1]);
                    case '/':
                        return eval(tableau[0]) / eval(tableau[1]);
                    default:
                        return 0;
                }
            }
        }

        private void pM_Click(object sender, RoutedEventArgs e)
        {
            if (txtblckAfficheurActu.Text[0] == '-')
            {
                txtblckAfficheurActu.Text = txtblckAfficheurActu.Text.Remove(0, 1);
            }
            else
            {
                txtblckAfficheurActu.Text = "-" + txtblckAfficheurActu.Text;
            }
        }

        private void delet_Click(object sender, RoutedEventArgs e)
        {
            if (txtblckAfficheurActu.Text.Length > 0)
            {
                txtblckAfficheurActu.Text = txtblckAfficheurActu.Text.Remove(txtblckAfficheurActu.Text.Length - 1, 1);
            }

        }
    }
}
