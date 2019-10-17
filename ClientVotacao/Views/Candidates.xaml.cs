using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using ClientVotacao.Data;
using ClientVotacao.Models;

namespace ClientVotacao.Views
{
    /// <summary>
    /// Interaction logic for Candidates.xaml
    /// </summary>
    public partial class Candidates : Page
    {
        public Election Election { get; set; }
        public List<Candidate> CandidateList { get; set; }
        public Candidates()
        {
            InitializeComponent();
            using (var _context = new ClientVotacaoContext())
            {
                Election = _context.Election.Where(e => e.Year == DateTime.Now.Year).FirstOrDefault();
                this.CandidateList = _context.Candidate.Where(c => c.Election.Year == DateTime.Now.Year).ToList();
                CandidatesList.ItemsSource = this.CandidateList;
            }

        }

        private void CandidatesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = CandidatesList.SelectedItem;
            NavigationService.Navigate(new Confirmation((Candidate)selectedItem));
        }

        private void NullVote_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            NavigationService.Navigate(new Confirmation(new Candidate() { Id = 2, Name = "Nulo", ElectionID = Election.Id, Election = this.Election }));
        }

        private void WhiteVote_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            NavigationService.Navigate(new Confirmation(new Candidate() { Id = 3, Name = "Branco", ElectionID = Election.Id, Election = this.Election }));
        }
    }
}
