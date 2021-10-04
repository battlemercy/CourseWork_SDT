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
    /// Логика взаимодействия для Teacher_Home.xaml
    /// </summary>
    public partial class Teacher_Home : Window
    {
        M_Grade m_g = new M_Grade();
        M_Homework m_hw = new M_Homework();
        M_F_Grade m_fg = new M_F_Grade();
        gr691_msiEntities db;
        public Teacher_Home()
        {
            InitializeComponent();
            db = new gr691_msiEntities();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            string text = S_Search.Text;
                if (S_Search.Text == "")
                {
                    Table_Mark.ItemsSource = db.Mark.ToList();
                    db = new gr691_msiEntities();
                    return;
                }
                else
                {
                    Table_Mark.ItemsSource = db.Mark.Where(w => w.Student.Last_Name.Contains(text)).ToList();
                }
        }

        //сортировка полей на ввод только чисел
        private void Digit_Check(object sender, TextCompositionEventArgs e)
        {
            if (m_g.Digit_Check(e.Text) == false || (m_fg.Digit_Check(e.Text) == false))
            {
                e.Handled = true;
            }
        }

        // функции, связанные со вкладкой "оценки"

        private void Grade_Insert(object sender, RoutedEventArgs e)
        {
            if (m_g.Add(Cb_G_Student.SelectedItem as Student, Cb_G_Subject.SelectedItem as Subject, Grade_Date.Text, Grade_Theme.Text, Grade_Grade.Text) == true)
            {
                Cb_G_Student.SelectedIndex = -1;
                Cb_G_Student.SelectedIndex = -1;
                Grade_Date.Clear();
                Grade_Theme.Clear();
                Grade_Grade.Clear();
            }
            Table_Mark.ItemsSource = db.Mark.ToList();
        }
        private void Grade_Delete(object sender, RoutedEventArgs e)
        {
            Mark mark = Table_Mark.SelectedItem as Mark;
            if (Table_Mark.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_g = db.Mark.Where(i => i.ID == mark.ID).FirstOrDefault();
            m_g.Delete(mark != null ? mark.ID.ToString() : "0");
            Table_Mark.ItemsSource = db.Mark.ToList();
        }
        private void Grade_Update(object sender, RoutedEventArgs e)
        {
            Mark mark = Table_Mark.SelectedItem as Mark;
            if (Table_Mark.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Mark.Where(i => i.ID == mark.ID).FirstOrDefault();
            if (m_g.Update(mark != null ? mark.ID.ToString() : "0", Cb_G_Student.SelectedItem as Student, Cb_G_Subject.SelectedItem as Subject, Grade_Date.Text, Grade_Theme.Text, Grade_Grade.Text) == true)
            {
                Cb_G_Student.SelectedIndex = -1;
                Cb_G_Student.SelectedIndex = -1;
                Grade_Date.Clear();
                Grade_Theme.Clear();
                Grade_Grade.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Mark.ItemsSource = db.Mark.ToList();
            }
        }

        // функции, связанные со вкладкой "домашние задания"

        private void Homework_Insert(object sender, RoutedEventArgs e)
        {
            if (m_hw.Add(Cb_HW_Teacher.SelectedItem as Teacher, Cb_HW_Subject.SelectedItem as Subject, Homework_Date.Text, Homework_Task.Text, Homework_Status.Text) == true)
            {
                Cb_HW_Teacher.SelectedIndex = -1;
                Cb_HW_Subject.SelectedIndex = -1;
                Homework_Date.Clear();
                Homework_Task.Clear();
                Homework_Status.Clear();
            }
            Table_Homework.ItemsSource = db.Homework.ToList();
        }
        private void Homework_Delete(object sender, RoutedEventArgs e)
        {
            Homework homework = Table_Homework.SelectedItem as Homework;
            if (Table_Homework.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_a = db.Homework.Where(i => i.ID == homework.ID).FirstOrDefault();
            m_hw.Delete(homework != null ? homework.ID.ToString() : "0");
            Table_Homework.ItemsSource = db.Homework.ToList();
        }
        private void Homework_Update(object sender, RoutedEventArgs e)
        {
            Homework homework = Table_Homework.SelectedItem as Homework;
            if (Table_Homework.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Homework.Where(i => i.ID == homework.ID).FirstOrDefault();
            if (m_hw.Update(homework != null ? homework.ID.ToString() : "0", Cb_HW_Teacher.SelectedItem as Teacher, Cb_HW_Subject.SelectedItem as Subject, Homework_Date.Text, Homework_Task.Text, Homework_Status.Text) == true)
            {
                Cb_HW_Teacher.SelectedIndex = -1;
                Cb_HW_Subject.SelectedIndex = -1;
                Homework_Date.Clear();
                Homework_Task.Clear();
                Homework_Status.Clear();
                gr691_msiEntities db = new gr691_msiEntities();
                Table_Homework.ItemsSource = db.Homework.ToList();
            }
        }

        // функции, связанные со вкладкой "итоговые оценки"

        private void Final_Grade_Insert(object sender, RoutedEventArgs e)
        {
            if (m_fg.Add(Cb_FG_Student.SelectedItem as Student, Cb_FG_Subject.SelectedItem as Subject, FG_FG.Text) == true)
            {
                Cb_FG_Student.SelectedIndex = -1;
                Cb_FG_Subject.SelectedIndex = -1;
                FG_FG.Clear();
            }
            Table_Final_Grade.ItemsSource = db.Final_Mark.ToList();
        }
        private void Final_Grade_Delete(object sender, RoutedEventArgs e)
        {
            Final_Mark f_mark = Table_Final_Grade.SelectedItem as Final_Mark;
            if (Table_Final_Grade.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var d_fg = db.Final_Mark.Where(i => i.ID == f_mark.ID).FirstOrDefault();
            m_fg.Delete(f_mark != null ? f_mark.ID.ToString() : "0");
            Table_Final_Grade.ItemsSource = db.Final_Mark.ToList();
        }
        private void Final_Grade_Update(object sender, RoutedEventArgs e)
        {
            Final_Mark f_mark = Table_Final_Grade.SelectedItem as Final_Mark;
            if (Table_Final_Grade.SelectedItem == null)
            {
                MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var select = db.Final_Mark.Where(i => i.ID == f_mark.ID).FirstOrDefault();
            if (m_fg.Update(f_mark != null ? f_mark.ID.ToString() : "0", Cb_FG_Student.SelectedItem as Student, Cb_FG_Subject.SelectedItem as Subject, FG_FG.Text) == true)
            {
                gr691_msiEntities db = new gr691_msiEntities();
                FG_FG.Clear();
                Table_Final_Grade.ItemsSource = db.Final_Mark.ToList();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new gr691_msiEntities();
            Table_Homework.ItemsSource = db.Homework.ToList();
            Table_Class.ItemsSource = db.Class.ToList();
            Table_Mark.ItemsSource = db.Mark.ToList();
            Table_Subject.ItemsSource = db.Subject.ToList();
            Table_Teacher.ItemsSource = db.Teacher.ToList();
            Table_Final_Grade.ItemsSource = db.Final_Mark.ToList();
            Cb_G_Student.ItemsSource = db.Student.ToList();
            Cb_G_Subject.ItemsSource = db.Subject.ToList();
            Cb_HW_Subject.ItemsSource = db.Subject.ToList();
            Cb_HW_Teacher.ItemsSource = db.Teacher.ToList();
            Cb_FG_Student.ItemsSource = db.Student.ToList();
            Cb_FG_Subject.ItemsSource = db.Subject.ToList();
        }
    }
}
