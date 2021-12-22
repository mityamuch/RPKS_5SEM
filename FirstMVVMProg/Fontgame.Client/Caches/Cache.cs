using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fontgame.Client
{
    public class User:IComparable,IComparable<User>
    {
        public string Name;
        public int Score;
        public string Date;

        public int CompareTo(object u)
        {
            if (u == null)
            {
                throw new ArgumentNullException(nameof(u),"gg");
            }
            User p = u as User;
            if (p != null)
                return CompareTo(p);
            else
                throw new ArgumentException("Невозможно сравнить два объекта");
        }
        public int CompareTo(User u)
        {
            if (u != null)
                return this.Score.CompareTo(u.Score);
            else
                throw new ArgumentException("Невозможно сравнить два объекта");
        }

    }

    internal sealed  class Cache
    {
        private List<User> _users;
        private string _path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FontGame", "uTop.bin");
        

        public  void SaveInTop(int score)
        {

            if (!File.Exists(_path))
            {
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\FontGame"));
                File.Create(_path);
            }
            GetUsersScore(_path);
            _users.Add(new User { Name = System.Environment.MachineName.ToString(), Score = score,Date=DateTime.Now.ToString() });
            _users.Sort();

            while (_users.Count >= 10)
            {
                _users.RemoveAt(_users.Count - 1);
            }

            using (StreamWriter sw = new StreamWriter(_path, false))
            {
                foreach (User u in _users)
                {
                    string text = u.Name + ":" + u.Score.ToString()+":"+u.Date;
                    sw.WriteLine(text);
                }
               
            }


        }
        private  void GetUsersScore(string p)
        {
            _users = new List<User>();
            if (!File.Exists(p))
            {
                return;
            }
            using (StreamReader sr = new StreamReader(p))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] words = line.Split(':');
                    _users.Add(new User { Name=words[0],Score=Convert.ToInt32(words[1]),Date=words[2] });
                }
            }

        }




    }
}
