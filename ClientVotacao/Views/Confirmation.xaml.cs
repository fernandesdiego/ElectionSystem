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
using ClientVotacao.Models;
using ClientVotacao.Data;
using MySql.Data.MySqlClient;

namespace ClientVotacao.Views
{
    /// <summary>
    /// Interaction logic for Confirmation.xaml
    /// </summary>
    public partial class Confirmation : Page
    {
        public Candidate Candidate { get; set; }
        public Confirmation()
        {
            InitializeComponent();
        }

        public Confirmation(Candidate candidate)
        {
            Candidate = candidate;
            InitializeComponent();
            CandidateName.Text = candidate.Name;
            CandidateImage.Source = new BitmapImage(candidate.PhotoUri);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            using (var _context = new ClientVotacaoContext())
            {
                Vote vote = new Vote()
                {
                    CandidateID = Candidate.Id,
                    CPF = int.Parse(Environment.UserName),
                    Moment = DateTime.Now
                };
                _context.Vote.Add(vote);
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            NavigationService.Navigate(new Final());
        }
    }
}
