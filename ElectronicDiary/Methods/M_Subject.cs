using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_Subject
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

        public bool Add(string name)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                Subject subject = new Subject();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    subject.Name = name;
                    db.Subject.Add(subject);
                    db.SaveChanges();
                    MessageBox.Show("Предмет добавлен.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var d_sub = db.Subject.Where(i => i.ID == num).FirstOrDefault();
                if (d_sub == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Subject.Remove(d_sub);
                    db.SaveChanges();
                    MessageBox.Show("Предмет удален.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string name)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_sub = db.Subject.Where(u => u.ID == num).FirstOrDefault();
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Вы не заполнили поле.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_sub == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_sub.Name = name;
                    db.SaveChanges();
                    MessageBox.Show("Предемет изменен.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
