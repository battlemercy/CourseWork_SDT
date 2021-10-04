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
    /// Логика взаимодействия для Admin_Home.xaml
    /// </summary>
    public partial class Admin_Home : Window
    {
        M_User m_u = new M_User();
        M_Teacher m_t = new M_Teacher();
        M_Subject m_sub = new M_Subject();
        M_Student m_stu = new M_Student();
        M_Class m_c = new M_Class();
        M_Appointment m_a = new M_Appointment();
        gr691_msiEntities db;
        public Admin_Home()
        {
            InitializeComponent();
            db = new gr691_msiEntities();
        }
        //обработка полей на ввод только кириллицы
        private void Word_Check(object sender, TextCompositionEventArgs e)
        {
            if (m_t.Word_Check(e.Text) == false || m_sub.Word_Check(e.Text) == false || m_stu.Word_Check(e.Text) == false)
            {
                e.Handled = true;
            }
        }

        // функции, связанные со вкладкой "ученики"

        private void Student_Insert(object sender, RoutedEventArgs e)
        {
            if (m_stu.Add(Student_Last_Name.Text, Student_First_Name.Text, Student_Middle_Name.Text, Cb_S_Class.SelectedItem as Class) == true)
            {
                Student_Last_Name.Clear();
                Student_First_Name.Clear();
                Student_Middle_Name.Clear();
                Cb_S_Class.SelectedIndex = -1;
            }
            Table_Student.ItemsSource = db.Student.ToList();
        }

        private void Student_Delete(object sender, RoutedEventArgs e)
        {
            Student student = Table_Student.SelectedItem as Student;
            if (Table_Student.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_s = db.Student.Where(i => i.ID == student.ID).FirstOrDefault();
            m_stu.Delete(student != null ? student.ID.ToString() : "0");
            Table_Student.ItemsSource = db.Student.ToList();
        }

        private void Student_Update(object sender, RoutedEventArgs e)
        {
            Student student = Table_Student.SelectedItem as Student;
            if (Table_Student.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Student.Where(i => i.ID == student.ID).FirstOrDefault();
            if (m_stu.Update(student != null ? student.ID.ToString() : "0", Student_Last_Name.Text, Student_First_Name.Text, Student_Middle_Name.Text, Cb_S_Class.SelectedItem as Class) == true)
            {
                Student_Last_Name.Clear();
                Student_First_Name.Clear();
                Student_Middle_Name.Clear();
                Cb_S_Class.SelectedIndex = -1;
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Student.ItemsSource = db.Student.ToList();
            }
        }

        // функции, связанные со вкладкой "преподаватели"

        private void Teacher_Insert(object sender, RoutedEventArgs e)
        {
            if (m_t.Add(Teacher_last.Text, Teacher_first.Text, Teacher_middle.Text, Teacher_telephone.Text) == true)
            {
                Teacher_last.Clear();
                Teacher_first.Clear();
                Teacher_middle.Clear();
                Teacher_telephone.Clear();
            }
            Table_Teacher.ItemsSource = db.Teacher.ToList();
        }

        private void Teacher_Delete(object sender, RoutedEventArgs e)
        {
            Teacher teacher = Table_Teacher.SelectedItem as Teacher;
            if (Table_Teacher.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_t = db.Teacher.Where(i => i.ID == teacher.ID).FirstOrDefault();
            m_t.Delete(teacher != null ? teacher.ID.ToString() : "0");
            Table_Teacher.ItemsSource = db.Teacher.ToList();
        }
        private void Teacher_Update(object sender, RoutedEventArgs e)
        {
            Teacher teacher = Table_Teacher.SelectedItem as Teacher;
            if (Table_Teacher.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Teacher.Where(i => i.ID == teacher.ID).FirstOrDefault();
            if (m_t.Update(teacher != null ? teacher.ID.ToString() : "0", Teacher_last.Text, Teacher_first.Text, Teacher_middle.Text, Teacher_telephone.Text) == true)
            {
                Teacher_last.Clear();
                Teacher_first.Clear();
                Teacher_middle.Clear();
                Teacher_telephone.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Teacher.ItemsSource = db.Teacher.ToList();
            }
        }

        // функции, связанные со вкладкой "пользователи"

        private void User_Insert(object sender, RoutedEventArgs e)
        {
            if (m_u.Add(User_login.Text, User_password.Text, Cb_U_Role.SelectedItem as Role) == true)
            {
                User_login.Clear();
                User_password.Clear();
                Cb_U_Role.SelectedIndex = -1;
            }
            Table_User.ItemsSource = db.Users.ToList();
        }

        private void User_Delete(object sender, RoutedEventArgs e)
        {
            Users user = Table_User.SelectedItem as Users;
            if (Table_User.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_t = db.Users.Where(i => i.ID == user.ID).FirstOrDefault();
            m_u.Delete(user != null ? user.ID.ToString() : "0");
            Table_User.ItemsSource = db.Users.ToList();
        }
        private void User_Update(object sender, RoutedEventArgs e)
        {
            Users user = Table_User.SelectedItem as Users;
            if (Table_User.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Users.Where(i => i.ID == user.ID).FirstOrDefault();
            if (m_u.Update(user != null ? user.ID.ToString() : "0", User_login.Text, User_password.Text, Cb_U_Role.SelectedItem as Role) == true)
            {
                User_login.Clear();
                User_password.Clear();
                Cb_U_Role.SelectedIndex = -1;
                gr691_msiEntities db = new gr691_msiEntities();
                Table_User.ItemsSource = db.Users.ToList();
            }
        }

        // функции, связанные со вкладкой "предметы"

        private void Subject_Insert(object sender, RoutedEventArgs e)
        {
            if (m_sub.Add(Subject_name.Text) == true)
            {
                Subject_name.Clear();
            }
            Table_Subject.ItemsSource = db.Subject.ToList();
        }
        private void Subject_Delete(object sender, RoutedEventArgs e)
        {
            Subject subject = Table_Subject.SelectedItem as Subject;
            if (Table_Subject.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_sub = db.Subject.Where(i => i.ID == subject.ID).FirstOrDefault();
            m_sub.Delete(subject != null ? subject.ID.ToString() : "0");
            Table_Subject.ItemsSource = db.Subject.ToList();
        }
        private void Subject_Update(object sender, RoutedEventArgs e)
        {
            Subject subject = Table_Subject.SelectedItem as Subject;
            if (Table_Subject.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Subject.Where(i => i.ID == subject.ID).FirstOrDefault();
            if (m_sub.Update(subject != null ? subject.ID.ToString() : "0", Subject_name.Text) == true)
            {
                Subject_name.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Subject.ItemsSource = db.Subject.ToList();
            }
        }

        // функции, связанные со вкладкой "учебные классы"

        private void Class_Insert(object sender, RoutedEventArgs e)
        {
            if (m_c.Add(Class_Name.Text) == true)
            {
                Class_Name.Clear();
            }
            Table_Class.ItemsSource = db.Class.ToList();
        }
        private void Class_Delete(object sender, RoutedEventArgs e)
        {
            Class cla = Table_Class.SelectedItem as Class;
            if (Table_Class.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_sub = db.Class.Where(i => i.ID == cla.ID).FirstOrDefault();
            m_c.Delete(cla != null ? cla.ID.ToString() : "0");
            Table_Class.ItemsSource = db.Class.ToList();
        }
        private void Class_Update(object sender, RoutedEventArgs e)
        {
            Class cla = Table_Class.SelectedItem as Class;
            if (Table_Class.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Class.Where(i => i.ID == cla.ID).FirstOrDefault();
            if (m_c.Update(cla != null ? cla.ID.ToString() : "0", Class_Name.Text) == true)
            {
                Class_Name.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Class.ItemsSource = db.Class.ToList();
            }
        }

        // функции, связанные со вкладкой "назначения"

        private void Appointment_Insert(object sender, RoutedEventArgs e)
        {
            if (m_a.Add(Cb_A_Teacher.SelectedItem as Teacher, Cb_A_Subject.SelectedItem as Subject) == true)
            {
                Cb_A_Teacher.SelectedIndex = -1;
                Cb_A_Subject.SelectedIndex = -1;
            }
            Table_Appointment.ItemsSource = db.Appointment.ToList();
        }
        private void Appointment_Delete(object sender, RoutedEventArgs e)
        {
            Appointment appointment = Table_Appointment.SelectedItem as Appointment;
            if (Table_Appointment.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_a = db.Appointment.Where(i => i.ID == appointment.ID).FirstOrDefault();
            m_a.Delete(appointment != null ? appointment.ID.ToString() : "0");
            Table_Appointment.ItemsSource = db.Appointment.ToList();
        }
        private void Appointment_Update(object sender, RoutedEventArgs e)
        {
            Appointment appointment = Table_Appointment.SelectedItem as Appointment;
            if (Table_Appointment.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Appointment.Where(i => i.ID == appointment.ID).FirstOrDefault();
            if (m_a.Update(appointment != null ? appointment.ID.ToString() : "0", Cb_A_Teacher.SelectedItem as Teacher, Cb_A_Subject.SelectedItem as Subject) == true)
            {
                Cb_A_Teacher.SelectedIndex = -1;
                Cb_A_Subject.SelectedIndex = -1;
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Appointment.ItemsSource = db.Appointment.ToList();
            }
        }

        // загрузка данных

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_msiEntities();
            Table_User.ItemsSource = db.Users.ToList();
            Table_Class.ItemsSource = db.Class.ToList();
            Table_Student.ItemsSource = db.Student.ToList();
            Table_Subject.ItemsSource = db.Subject.ToList();
            Table_Teacher.ItemsSource = db.Teacher.ToList();
            Cb_S_Class.ItemsSource = db.Class.ToList();
            Cb_U_Role.ItemsSource = db.Role.ToList();
            Cb_A_Teacher.ItemsSource = db.Teacher.ToList();
            Cb_A_Subject.ItemsSource = db.Subject.ToList();
        }
    }
}
