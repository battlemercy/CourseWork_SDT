using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_Student
    {
        public bool Word_Check(string text)
        {
            Regex regex = new Regex("[^А-ЯЁа-яё]+");
            bool check = regex.IsMatch(text);
            if (check == true)
            {
                return false;
            }
            else return true;
        }

        public bool Add(string last, string first, string middle, Class clas)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            Student student = new Student();
            try
            {
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle) || clas == null)
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                student.Last_Name = last;
                student.First_Name = first;
                student.Middle_Name = middle;
                student.Class_ID = clas.ID;
                db.Student.Add(student);
                db.SaveChanges();
                MessageBox.Show("Ученик добавлен", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_s = db.Student.Where(i => i.ID == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Student.Remove(d_s);
                    db.SaveChanges();
                    MessageBox.Show("Ученик удалён", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string last, string first, string middle, Class clas)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_s = db.Student.Where(u => u.ID == num).FirstOrDefault();
                if (u_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(last) || string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(middle))
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_s.Last_Name = last;
                u_s.First_Name = first;
                u_s.Middle_Name = middle;
                u_s.Class_ID = clas.ID;
                db.SaveChanges();
                MessageBox.Show("Ученик изменён", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
