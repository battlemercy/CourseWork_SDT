using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_Grade
    {
        public bool Digit_Check(string text)
        {
            Regex regex = new Regex("[^2-5]+");
            bool check = regex.IsMatch(text);
            if (check == true)
            {
                return false;
            }
            else return true;
        }

        public bool Add(Student student, Subject subject, string date, string theme, string grade)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                Mark mark = new Mark();
                if (student == null)
                {
                    MessageBox.Show("Вы не выбрали ученика", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subject == null)
                {
                    MessageBox.Show("Вы не выбрали предмет", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(theme) || string.IsNullOrWhiteSpace(grade))
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    int conv_grade = Convert.ToInt32(grade);
                    mark.Student_ID = student.ID;
                    mark.Subject_ID = subject.ID;
                    mark.Date = date;
                    mark.Theme = theme;
                    mark.Mark1 = conv_grade;
                    db.Mark.Add(mark);
                    db.SaveChanges();
                    MessageBox.Show("Оценка добавлена", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Delete(string id)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var d_g = db.Mark.Where(i => i.ID == num).FirstOrDefault();
                if (d_g == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Mark.Remove(d_g);
                    db.SaveChanges();
                    MessageBox.Show("Оценка удалена", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, Student student, Subject subject, string date, string theme, string grade)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_g = db.Mark.Where(u => u.ID == num).FirstOrDefault();
                if (student == null)
                {
                    MessageBox.Show("Вы не выбрали ученика", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subject == null)
                {
                    MessageBox.Show("Вы не выбрали предмет", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(theme) || string.IsNullOrWhiteSpace(grade))
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    int conv_grade = Convert.ToInt32(grade);
                    if (u_g == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_g.Student_ID = student.ID;
                    u_g.Subject_ID = subject.ID;
                    u_g.Date = date;
                    u_g.Theme = theme;
                    u_g.Mark1 = conv_grade;
                    db.SaveChanges();
                    MessageBox.Show("Оценка изменена", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
