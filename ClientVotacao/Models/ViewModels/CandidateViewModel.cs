using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientVotacao.Models.ViewModels
{
    class CandidateViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public string Photo { get; set; }
        public int ElectionID { get; set; }
        public virtual Election Election { get; set; }
        public CandidateViewModel()
        {

        }

    }
}
