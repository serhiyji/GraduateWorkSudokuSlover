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

namespace GraduateWorkSudokuSlover.LoginRegistration
{
    public partial class LoginRegistration : Window
    {
        ViewModel model;
        public LoginRegistration()
        {
            InitializeComponent();
            this.model = new ViewModel();
            this.model.OnClosedWindow += (s, e) => { this.Close(); };
            this.passwordL.PasswordChanged += (s, e) => { this.model.PasswordLChanget(this.passwordL.Password); };
            this.passwordR.PasswordChanged += (s, e) => { this.model.PasswordRChanget(this.passwordR.Password); };
            this.DataContext = model;
        }
    }
}
