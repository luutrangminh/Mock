using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Professor
    {
        private static Connections con = null;

        public static IDataReader Get()
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreatedBy, CreatedAt FROM Professors";
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(string username)
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreatedBy, CreatedAt FROM Professors" +
            " WHERE Username = '" + username + "'";
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader GetByEmail(string email)
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreatedBy, CreatedAt FROM Professors" +
            " WHERE Email = '" + email + "'";
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreatedBy, CreatedAt FROM Professors" +
            " WHERE Id = '" + id + "'";
            return con.ExecuteReader(queryStr);
        }
        public static IDataReader GetByAdmin(int id)
        {
            con = new Connections();
            string queryStr = "SELECT Professors.Id, Professors.FullName, Professors.Email, Professors.Username," +
            "Professors.Password, Professors.PhoneNumber, Professors.Address, Professors.CreatedBy, Administrator.FullName as CreatedByStr, CreatedAt FROM Professors, Administrator" +
            " WHERE Administrator.Id = Professors.CreatedBy AND CreatedBy = " + id;
            return con.ExecuteReader(queryStr);
        }

        public static void Add(int createdBy, DateTime createdAt, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            con = new Connections();
            string queryStr = "INSERT INTO [dbo].[Professors] " +
                "([FullName], [Email], [Username], [Password], [PhoneNumber], [Address], [CreatedBy], [CreatedAt])" +
                "VALUES (N'" + fullName + "', '" + email + "', '" + username + "', '" +
                password + "', '" + phoneNumber + "', '" + address + "', " + createdBy + ", CONVERT(datetime, '" + createdAt + "', 103))";
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string username, string password)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [Username] = N'" + username + "'" +
                ", [Password] = '" + password + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string fullName)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Updat(int id, string fullName, string email)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string fullName, string email, string username)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string fullName, string email, string username,
            string password)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                ", [PhoneNumber] = '" + phoneNumber + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            con = new Connections();
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                ", [PhoneNumber] = '" + phoneNumber + "'" +
                ", [Address] = N'" + address + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Delete(int id)
        {
            con = new Connections();
            string queryStr = "DELETE FROM [dbo].[Professors] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }

        public static void Delete(string username)
        {
            con = new Connections();
            string queryStr = "DELETE FROM [dbo].[Professors] WHERE [Username] = '" + username + "'";
            con.ExecuteNonQuery(queryStr);
            con.CloseConnection();
        }
    }
}
