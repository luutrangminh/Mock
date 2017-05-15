using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{

    public class propScoreBoard
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string college { get; set; }
        public string subject { get; set; }
        public int age { get; set; }
        public DateTime birthday { get; set; }
        public int score { get; set; }
        public DateTime submitAt { get; set; }
        public bool assigned { get; set; }

        public propScoreBoard()
        {
            this.id = 0; this.fullName = null; this.college = null;
            this.subject = null; this.age = 0; this.birthday = DateTime.Now; this.score = 0; this.submitAt = DateTime.Now;
            this.assigned = false;
        }

        public propScoreBoard(propStudent student, propOnlineTest onlineTest)
        {
            this.id = student.id; this.fullName = student.fullName; this.college = student.college;
            this.subject = student.subject; this.age = student.age; this.birthday = student.birthday; this.score = onlineTest.score; this.submitAt = onlineTest.submitAt;
            this.assigned = student.assigned; this.email = student.email;
        }

        public propScoreBoard(propGroupMember student, propOnlineTest onlineTest)
        {
            this.id = student.id; this.fullName = student.fullName; this.college = student.college;
            this.subject = student.subject; this.age = student.age; this.birthday = student.birthday; this.score = onlineTest.score; this.submitAt = onlineTest.submitAt;
            this.assigned = student.assigned; this.email = student.email;
        }
    }

    public class ScoreBoard
    {
        public static List<propScoreBoard> Get()
        {
            var listScoreBoard = new List<propScoreBoard>();
            var listStudent = Student.Get();
            if (listStudent == null)
                return null;
            listStudent.ForEach(student =>
            {
                var onlineTest = OnlineTest.Get(student.id);
                var scoreboard = new propScoreBoard(student, onlineTest);
                listScoreBoard.Add(scoreboard);
            });

            return listScoreBoard;
        }

    }
}
