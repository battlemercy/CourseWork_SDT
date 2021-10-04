using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_Homework
    {
        public bool Add(Teacher teacher, Subject subject, string date, string task, string status)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                Homework homework = new Homework();
                if (teacher == null)
                {
                    MessageBox.Show("Вы не выбрали учителя", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subject == null)
                {
                    MessageBox.Show("Вы не выбрали предмет", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(task) || string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    homework.Teacher_ID = teacher.ID;
                    homework.Subject_ID = subject.ID;
                    homework.Date = date;
                    homework.Task = task;
                    homework.Status = status;
                    db.Homework.Add(homework);
                    db.SaveChanges();
                    MessageBox.Show("Домашнее задание добавлено", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_hm = db.Homework.Where(i => i.ID == num).FirstOrDefault();
                if (d_hm == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Homework.Remove(d_hm);
                    db.SaveChanges();
                    MessageBox.Show("Домашнее задание удалено", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, Teacher teacher, Subject subject, string date, string task, string status)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_hm = db.Homework.Where(u => u.ID == num).FirstOrDefault();
                if (teacher == null)
                {
                    MessageBox.Show("Вы не выбрали учителя", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (subject == null)
                {
                    MessageBox.Show("Вы не выбрали предмет", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else if (string.IsNullOrWhiteSpace(date) || string.IsNullOrWhiteSpace(task) || string.IsNullOrWhiteSpace(status))
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    if (u_hm == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_hm.Teacher_ID = teacher.ID;
                    u_hm.Subject_ID = subject.ID;
                    u_hm.Date = date;
                    u_hm.Task = task;
                    u_hm.Status = status;
                    db.SaveChanges();
                    MessageBox.Show("Домашнее задание изменено", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
