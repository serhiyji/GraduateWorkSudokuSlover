using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using GraduateWorkSudokuSlover.DBContexts;
using GraduateWorkSudokuSlover.SudokuSloverHendler.BetterMatrix;

namespace GraduateWorkSudokuSlover
{
    [AddINotifyPropertyChangedInterface]
    public class DatabaseHandler : Expansion.SingletonClass<DatabaseHandler>
    {
        private DataBaseContext db;
        public int IdUser { get;private set; }
        public string NameUser { get;private set; }
        public bool IsLogined { get; private set; }
        private bool IsLoginContains(string login) => db.Users.Select(i => i.Login).Contains(login);
        private bool IsSudokuContains(int IdSudoku) => db.SavingSudokus.Select(i => i.ID).Contains(IdSudoku);
        public DatabaseHandler()
        {
            this.db = new DataBaseContext();
            this.IsLogined = false;
            this.IdUser = -1;
            this.NameUser = "";
        }
        
        public int SaveSudoku(string nameSudoku, ref BetterMatrix matrix)
        {
            if (!IsLogined) { return -1; }
            try
            {
                db.SavingSudokus.Add(new DBContexts.Entities.SavingSudoku(){
                    Name = nameSudoku,
                    IdUser = this.IdUser,
                    Data = matrix.SaveSudoku(),
                    Time = DateTime.Now,
                });
                db.SaveChanges();
                return db.SavingSudokus.Where(s => s.IdUser == this.IdUser && s.Name == nameSudoku).First().ID;
            }
            catch (Exception ex)
            {
                throw new Exceptions.ExceptionConnectDatabase("Судоку не була збережена / Відсутнє зєднання з інтернетом");
            }
            return -1;

        }
        public bool SaveSudoku(int IdSudoku, ref BetterMatrix matrix)
        {
            if (!IsLogined) { return false; }
            try
            {
                if (!IsSudokuContains(IdSudoku)) { return false; }
                var sud = db.SavingSudokus.Where(i => i.ID == IdSudoku);
                if (sud.Count() == 1)
                {
                    sud.First().Data = matrix.SaveSudoku();
                    sud.First().Time = DateTime.Now;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exceptions.ExceptionConnectDatabase("Судоку не була збережена / Відсутнє зєднання з інтернетом");
            }
            return false;
        }
        public int LoadSudoku(int IdSudoku, ref BetterMatrix matrix)
        {
            try
            {
                if (!IsSudokuContains(IdSudoku)) { return -1; }
                var sud = db.SavingSudokus.Where(i => i.ID == IdSudoku);
                if (sud.Count() == 1)
                {
                    if (matrix.LoadSudoku(sud.First().Data))
                    {
                        return sud.First().ID;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
            }
            return -1;
        }
        public bool Login(string login, string password)
        {
            try
            {
                IEnumerable<DBContexts.Entities.User> users = db.Users.Where(i => i.Login == login && i.Password == password);
                if (users.Count() == 1)
                {
                    this.IdUser = users.First().ID;
                    this.NameUser = users.First().Login;
                    this.IsLogined = true;
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exceptions.ExceptionConnectDatabase("Вхід не відбувся / Відсутнє зєднання з інтернетом");
            }
            return false;
        }
        public bool Registration(string login, string password, string email)
        {
            try
            {
                if (!IsLoginContains(login))
                {
                    this.db.Users.Add(new DBContexts.Entities.User()
                    {
                        Login = login,
                        Password = password,
                        Email = email,
                    });
                    db.SaveChanges();
                    try
                    {
                        return this.Login(login, password);
                    }
                    catch (Exceptions.ExceptionConnectDatabase ex) { throw ex; }
                }
            }
            catch (Exception ex) 
            { 
                throw new Exceptions.ExceptionConnectDatabase("Реєстрація не відбулась / Відсутнє зєднання з інтернетом"); 
            }
            return false;
        }
        public bool DeleteSudoku(int IdSudoku)
        {
            try
            {
                db.SavingSudokus.Remove(db.SavingSudokus.Where(s => s.ID == IdSudoku).First());
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            { 
                throw new Exceptions.ExceptionConnectDatabase("Судоку не була збережена / Відсутнє зєднання з інтернетом"); 
            }
            return false;
        }
        public void LogOut()
        {
            this.IsLogined = false;
            this.IdUser = -1;
            this.NameUser = "";
        }
        public IEnumerable<DBContexts.Entities.SavingSudoku> GetSudokuByUser()
        {
            return IsLogined ? this.db.SavingSudokus.Where(s => s.IdUser == IdUser) : new List<DBContexts.Entities.SavingSudoku>();
        }
    }
}
