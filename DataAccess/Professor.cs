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
        private static Connections con = new Connections();

        public static IDataReader Get()
        {
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreatedBy, CreatedAt FROM Professors";
            return con.ExecuteReader(queryStr);
        }

        public static IDataReader Get(string username)
        {
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreatedBy, CreatedAt FROM Professors" +
            " WHERE Username = '" + username + "'";
            return con.ExecuteReader(queryStr);
        }

        public static void Add(int createdBy, DateTime createdAt, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            string queryStr = "INSERT INTO [dbo].[Professors] " +
                "([FullName], [Email], [Username], [Password], [PhoneNumber], [Address], [CreatedBy], [CreatedAt])" +
                "VALUES (N'" + fullName + "', '" + email + "', '" + username + "', '" +
                password + "', '" + phoneNumber + "', '" + address + "', " + createdBy + ", '" + createdAt + "')";
            con.ExecuteScalar(queryStr);
        }

        public static void Update(int id, string fullName)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, string fullName, string email)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, string fullName, string email, string username)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, string fullName, string email, string username,
            string password)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                ", [PhoneNumber] = '" + phoneNumber + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Update(int id, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                ", [PhoneNumber] = '" + phoneNumber + "'" +
                ", [Address] = N'" + address + "'" +
                " WHERE Id = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Professors] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public static void Delete(string username)
        {
            string queryStr = "DELETE FROM [dbo].[Professors] WHERE [Username] = '" + username + "'";
            con.ExecuteNonQuery(queryStr);
        }
    }
}
