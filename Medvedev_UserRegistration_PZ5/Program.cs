using System;
using PasswordHasherLib;
using Medvedev_UserRegistration_PZ5.Model;

namespace Medvedev_UserRegistration_PZ5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создание новой учетной записи для пользователя");

            Console.Write("Введите имя пользователя: ");
            string firstName = Console.ReadLine();

            Console.Write("Введите фамилию пользователя: ");
            string lastName = Console.ReadLine();

            Console.Write("Введите логин пользователя: ");
            string login = Console.ReadLine();

            Console.Write("Введите пароль пользователя: ");
            string password = Console.ReadLine();

            string hashedPassword = PasswordHasher.GetSha256Hash(password);
            Console.WriteLine($"Хешированный пароль пользователя: {hashedPassword}");

            try
            {
                using (var db = new AppDbContext())
                {
                    var newUser = new User
                    {
                        Login = login,
                        PasswordHash = hashedPassword,
                        Role = "User"
                    };

                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                Console.WriteLine("Учетная запись добавлена");
            }
            catch (Exception ex)
            {
                Console.WriteLine("========================================");
                Console.WriteLine($"ОШИБКА: {ex.Message}");

                if (ex.InnerException != null)
                {
                    Console.WriteLine("--- Внутренняя ошибка ---");
                    Console.WriteLine(ex.InnerException.Message);

                    if (ex.InnerException.InnerException != null)
                    {
                        Console.WriteLine("--- Глубинная ошибка ---");
                        Console.WriteLine(ex.InnerException.InnerException.Message);
                    }
                }
                Console.WriteLine("========================================");
            }

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}