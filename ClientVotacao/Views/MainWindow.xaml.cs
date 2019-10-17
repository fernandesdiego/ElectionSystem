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
using ClientVotacao.Data;
using ClientVotacao.Models;
using MySql.Data.MySqlClient;

namespace ClientVotacao.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            using (var _context = new ClientVotacaoContext())
            {
                int user = int.Parse(Environment.UserName);
                //int user = 0912831923;
                bool vote = false;
                try
                {
                    vote = _context.Vote.Where(v => v.CPF == user && v.Moment.Year == DateTime.Now.Year).Any();
                    var election = _context.Election.Where(e => e.Year == DateTime.Now.Year).FirstOrDefault();
                    if (election != null && election.HasStarted && !election.HasFinished && !vote)
                    {
                        InitializeComponent();
                        MainFrame.Navigate(new Intro());
                    }
                    else
                    {
                        Application.Current.Shutdown();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }            
        }
    }
}
