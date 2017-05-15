using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Business
{
    public class propOnlineTest
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime expiryDate { get; set; }
        public int score { get; set; }
        public DateTime submitAt { get; set; }
    }

    public class OnlineTest
    {
        public static propOnlineTest Get(int studentId)
        {
            propOnlineTest onlineTest = new propOnlineTest();
            var data = DataAccess.OnlineTest.Get(studentId);
            if (data == null)
                return null;
            while (data.Read())
            {
                onlineTest.id = int.Parse(data["Id"].ToString());
                onlineTest.studentId = int.Parse(data["StudentId"].ToString());
                onlineTest.startDate = DateTime.Parse(data["StartDate"].ToString());
                onlineTest.expiryDate = DateTime.Parse(data["ExpiryDate"].ToString());
                onlineTest.score = int.Parse(data["Score"].ToString());
                onlineTest.submitAt = DateTime.Parse(data["SubmitAt"].ToString());
            }
            data.Close();
            return onlineTest;
        }

        public static propOnlineTest GetById(int id)
        {
            propOnlineTest onlineTest = new propOnlineTest();
            var data = DataAccess.OnlineTest.GetById(id);
            if (data == null)
                return null;
            while (data.Read())
            {
                onlineTest.id = int.Parse(data["Id"].ToString());
                onlineTest.studentId = int.Parse(data["StudentId"].ToString());
                onlineTest.startDate = DateTime.Parse(data["StartDate"].ToString());
                onlineTest.expiryDate = DateTime.Parse(data["ExpiryDate"].ToString());
                onlineTest.score = int.Parse(data["Score"].ToString());
                onlineTest.submitAt = DateTime.Parse(data["SubmitAt"].ToString());
            }
            data.Close();
            return onlineTest;
        }

        public static void Add(int studentId, DateTime expiryDate)
        {
            DataAccess.OnlineTest.Add(studentId, expiryDate);
        }

        public static void Update(int id, int score, DateTime submitAt)
        {
            DataAccess.OnlineTest.Update(id, score, submitAt);
        }

    }
}
