using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_Class
    {
        public bool Add(string name)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            Class cla = new Class();
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                cla.Name = name;
                db.Class.Add(cla);
                db.SaveChanges();
                MessageBox.Show("Учебный класс добавлен.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_s = db.Class.Where(i => i.ID == num).FirstOrDefault();
                if (d_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Class.Remove(d_s);
                    db.SaveChanges();
                    MessageBox.Show("Учебный класс удалён", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
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
                var u_s = db.Class.Where(u => u.ID == num).FirstOrDefault();
                if (u_s == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(name))
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_s.Name = name;
                db.SaveChanges();
                MessageBox.Show("Учебный класс изменён", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
