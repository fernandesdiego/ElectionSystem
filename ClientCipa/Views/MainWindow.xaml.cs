using ClientCipa.Data;
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
using ClientCipa.Models;

namespace ClientCipa.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using (var db = new ELEICAOCIPAContext())
            {
                var election = db.Election.Where(e => e.Year == DateTime.Now.Year).FirstOrDefault();
                if (election.HasStarted && !election.HasFinished)
                {
                    var vote = db.Vote.Where(v => v.Cpf == int.Parse(Environment.UserName)).FirstOrDefault();
                    if (vote != null)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        InitializeComponent();
                    }

                }
                else
                {
                    Application.Current.Shutdown();
                }
            }
        }
    }
}
