using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_F_Grade
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

        public bool Add(Student student, Subject subject, string final_grade)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                Final_Mark f_mark = new Final_Mark();
                if (student == null)
                {
                    MessageBox.Show("Вы не выбрали ученика.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subject == null)
                {
                    MessageBox.Show("Вы не выбрали предмет.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(final_grade))
                {
                    MessageBox.Show("Вы не написали итоговую оценку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    f_mark.Student_ID = student.ID;
                    f_mark.Subject_ID = subject.ID;
                    int conv_fg = Convert.ToInt32(final_grade);
                    f_mark.FMark = conv_fg;
                    db.Final_Mark.Add(f_mark);
                    db.SaveChanges();
                    MessageBox.Show("Итоговая оценка добавлена", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_fg = db.Final_Mark.Where(i => i.ID == num).FirstOrDefault();
                if (d_fg == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Final_Mark.Remove(d_fg);
                    db.SaveChanges();
                    MessageBox.Show("Итоговая оценка удалена.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, Student student, Subject subject, string final_grade)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_fg = db.Final_Mark.Where(u => u.ID == num).FirstOrDefault();
                if (student == null)
                {
                    MessageBox.Show("Вы не выбрали ученика.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subject == null)
                {
                    MessageBox.Show("Вы не выбрали предмет.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(final_grade))
                {
                    MessageBox.Show("Вы не написали итоговую оценку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    int conv_fg = Convert.ToInt32(final_grade);
                    if (u_fg == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_fg.Student_ID = student.ID;
                    u_fg.Subject_ID = subject.ID;
                    u_fg.FMark = conv_fg;
                    db.SaveChanges();
                    MessageBox.Show("Итоговая оценка изменена", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
