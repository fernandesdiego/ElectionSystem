using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace ClientVotacao.Views
{
    /// <summary>
    /// Interação lógica para Final.xam
    /// </summary>
    public partial class Final : Page
    {
        public Final()
        {
            InitializeComponent();
            Timer timer = new Timer(6000.0);
            timer.Elapsed += Exit;
            timer.Enabled = true;
        }

        private static void Exit(Object source, System.Timers.ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.InvokeShutdown();
        }
    }
}
