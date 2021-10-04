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
using System.Windows.Shapes;

namespace ElectronicDiary
{
    /// <summary>
    /// Логика взаимодействия для Student_Home.xaml
    /// </summary>
    public partial class Student_Home : Window
    {
        gr691_msiEntities db;
        public Student_Home()
        {
            InitializeComponent();
            db = new gr691_msiEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_msiEntities();
            Table_Homework.ItemsSource = db.Homework.ToList();
            Table_Mark.ItemsSource = db.Mark.ToList();
            Table_Subject.ItemsSource = db.Subject.ToList();
            Table_Teacher.ItemsSource = db.Teacher.ToList();
            Table_Final_Grade.ItemsSource = db.Final_Mark.ToList();
        }
    }
}
