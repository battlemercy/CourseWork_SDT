using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_Appointment
    {
        public bool Add(Teacher teacher, Subject subject)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                Appointment appointment = new Appointment();
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
                else
                {
                    appointment.Teacher_ID = teacher.ID;
                    appointment.Subject_ID = subject.ID;
                    db.Appointment.Add(appointment);
                    db.SaveChanges();
                    MessageBox.Show("Назначение добавлено", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_a = db.Appointment.Where(i => i.ID == num).FirstOrDefault();
                if (d_a == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Appointment.Remove(d_a);
                    db.SaveChanges();
                    MessageBox.Show("Назначение удалено", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Внесите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, Teacher teacher, Subject subject)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_a = db.Appointment.Where(u => u.ID == num).FirstOrDefault();
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
                else
                {
                    if (u_a == null)
                    {
                        MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                    u_a.Teacher_ID = teacher.ID;
                    u_a.Subject_ID = subject.ID;
                    db.SaveChanges();
                    MessageBox.Show("Назначение изменено", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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