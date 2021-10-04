using ElectronicDiary.Methods;
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

namespace ElectronicDiary
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        gr691_msiEntities db;
        public Authorization()
        {
            InitializeComponent();
            db = new gr691_msiEntities();
        }

        private void Auth_Enter(object sender, RoutedEventArgs e)
        {
            M_Auth m_auth = new M_Auth();
            var authorization = db.Users.FirstOrDefault(ch => ch.Login == Auth_Login.Text && ch.Password == Auth_Password.Password);
            if (m_auth.Enter(Auth_Login.Text, Auth_Password.Password) == true)
            {
                MessageBox.Show("Вход выполнен", "Авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                Hide();
                switch (authorization.Role_ID)
                {
                    case 1:
                        new Student_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                    case 2:
                        new Teacher_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                    case 3:
                        new Admin_Home().ShowDialog();
                        Application.Current.Shutdown();
                        break;
                }
            }
        }
    }
}
