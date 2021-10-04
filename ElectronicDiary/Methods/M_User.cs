using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Text.RegularExpressions;

namespace ElectronicDiary.Methods
{
    public class M_User
    {
        public bool Add(string login, string password, Role role)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            Users user = new Users();
            try
            {
                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || role == null)
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                user.Login = login;
                user.Password = password;
                user.Role_ID = role.ID;
                db.Users.Add(user);
                db.SaveChanges();
                MessageBox.Show("Пользователь добавлен.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
                var d_t = db.Users.Where(i => i.ID == num).FirstOrDefault();
                if (d_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                else
                {
                    db.Users.Remove(d_t);
                    db.SaveChanges();
                    MessageBox.Show("Пользователь удалён.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch
            {
                MessageBox.Show("Введите корректные значения.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        public bool Update(string id, string login, string password, Role role)
        {
            gr691_msiEntities db = new gr691_msiEntities();
            try
            {
                int num = Convert.ToInt32(id);
                var u_t = db.Users.Where(u => u.ID == num).FirstOrDefault();
                if (u_t == null)
                {
                    MessageBox.Show("Вы не выбрали строку.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password) || role == null)
                {
                    MessageBox.Show("Заполнены не все поля.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                u_t.Login = login;
                u_t.Password = password;
                u_t.Role_ID = role.ID;
                db.SaveChanges();
                MessageBox.Show("Пользователь изменён.", "Дневник", MessageBoxButton.OK, MessageBoxImage.Information);
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
