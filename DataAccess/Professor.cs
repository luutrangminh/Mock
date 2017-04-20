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
        Connections con = new Connections();

        public IDataReader Get()
        {
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreateBy, CreateAt FROM Professors";
            return con.ExecuteReader(queryStr);
        }

        public IDataReader Get(string username)
        {
            string queryStr = "SELECT Id, FullName, Email, Username," +
            "Password, PhoneNumber, Address, CreateBy, CreateAt FROM Professors" +
            "WHERE Username = '" + username + "'";
            return con.ExecuteReader(queryStr);
        }

        public IDataReader Add(int createdBy, DateTime createdAt, string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            string queryStr = "INSERT INTO [dbo].[Professors] " +
                "([FullName], [Email], [Username], [Password], [PhoneNumber], [Address], [CreatedBy], [CreatedAt])" +
                "VALUES (N'" + fullName + "', '" + email + "', '" + username + "', '" +
                password + "', '" + phoneNumber + "', '" + address + "', " + createdBy + ", '" + createdAt + "')";
            return (IDataReader)con.ExecuteScalar(queryStr);
        }

        public void Update(string fullName)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(string fullName, string email)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(string fullName, string email, string username)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(string fullName, string email, string username,
            string password)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(string fullName, string email, string username,
            string password, string phoneNumber)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                ", [PhoneNumber] = '" + phoneNumber + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Update(string fullName, string email, string username,
            string password, string phoneNumber, string address)
        {
            string queryStr = "UPDATE [dbo].[Professors] SET [FullName] = N'" + fullName + "'" +
                ", [Email] = '" + email + "'" +
                ", [Username] = '" + username + "'" +
                ", [Password] = '" + password + "'" +
                ", [PhoneNumber] = '" + phoneNumber + "'" +
                ", [Address] = N'" + address + "'";
            con.ExecuteNonQuery(queryStr);
        }

        public void Delete(int id)
        {
            string queryStr = "DELETE FROM [dbo].[Professors] WHERE [Id] = " + id;
            con.ExecuteNonQuery(queryStr);
        }

        public void Delete(string username)
        {
            string queryStr = "DELETE FROM [dbo].[Professors] WHERE [Username] = '" + username + "'";
            con.ExecuteNonQuery(queryStr);
        }
    }
}
