using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CobaAuth
{
    internal class Admin
    {
        private static string[] username = new string[0];
        private static string[] password = new string[0];
        public static void Main(string[] args) => Admin.HalamanDepan();
        private static void HalamanDepan()
        {
            Console.Clear();
            Console.WriteLine("==Manajemen Anggota==");
            Console.WriteLine("1. Mendaftar");
            Console.WriteLine("2. Lihat Anggota");
            //Console.WriteLine("3. Cari Anggota");
            Console.WriteLine("3. Login Anggota");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilihan : ");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Admin.Mendaftar();
                    break;
                case 2:
                    Admin.Lihat();
                    break;
                case 3:
                    Admin.masuk();
                    break;
                case 4:
                    Console.WriteLine("Menu Lainnya Belum Tersedia :)");
                    Console.WriteLine("*");
                    Console.WriteLine("*");
                    break;
            }
        }
        private static void Mendaftar()
        {
            Console.Clear();
            Console.Write("UserName: ");
            string userName = Console.ReadLine();
            Console.Write("Password: ");
            string passwords = (Console.ReadLine());
            Admin.User(userName, passwords);
            Console.WriteLine();
            Console.WriteLine("Data user berhasil dibuat");
            Console.ReadKey();
            Admin.HalamanDepan();
        }
        private static void User(string userName, string passwords)
        {
            Admin.username = ((IEnumerable<string>)Admin.username).Append<string>(userName).ToArray<string>();
            Admin.password = ((IEnumerable<string>)Admin.password).Append<string>(passwords).ToArray<string>();
        }
        private static void Lihat()
        {
            Console.Clear();
            int urut = 1;
            Console.WriteLine("==Daftar Anggota==");
            for (int index = 0; index < Admin.username.Length; ++index)
            {
                Console.WriteLine("========================");
                DefaultInterpolatedStringHandler interpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 1);
                interpolatedStringHandler.AppendLiteral("ID \t : ");
                interpolatedStringHandler.AppendFormatted<int>(urut++);
                Console.WriteLine(interpolatedStringHandler.ToStringAndClear());
                Console.WriteLine("Username : " + Admin.username[index]);
                Console.WriteLine("Password : " + Admin.password[index]);
                Console.WriteLine("========================");
            }
        }
        private static void masuk()
        {
            Console.Clear();
            Console.WriteLine("==Menu Login Akun==");
            Console.Write("Username : ");
            string input_username = Console.ReadLine();
            Console.Write("Password : ");
            string input_password = Console.ReadLine();
            string usr1 = Array.Find<string>(Admin.username, (Predicate<string>)(n => n == input_username));
            int pasw1 = Array.IndexOf<string>(Admin.username, usr1);
            string usr2 = Array.Find<string>(Admin.password, (Predicate<string>)(n => n == input_password));
            int pasw2 = Array.IndexOf<string>(Admin.password, usr2);
            if (pasw1 == -1 || pasw2 == -1)
            {
                Console.WriteLine("Gabisa Login");
                Console.ReadKey();
                Admin.HalamanDepan();
            }
            else if (pasw1 == pasw2)
            {
                Console.WriteLine("Anda Berhasil Login");
                Console.ReadKey();
                Admin.HalamanDepan();
            }
            else
            {
                Console.WriteLine("Gabisa Login");
                Console.ReadKey();
                Admin.HalamanDepan();
            }
        }
    }
}