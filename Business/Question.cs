using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptography;
using DataAccess;

namespace Business
{
    public class propQuestion
    {
        public int id { get; set; }
        public string question { get; set; }
        public int projectId { get; set; }
    }

    public class Question
    {

        public static List<propQuestion> Get(int projectId)
        {
            var listQuestion = new List<propQuestion>();
            var data = DataAccess.Question.GetByProject(projectId);
            while (data.Read())
            {
                propQuestion question = new propQuestion();
                question.id = int.Parse(data["Id"].ToString());
                question.question = data["Question"].ToString();
                question.projectId = int.Parse(data["ProjectId"].ToString());
                listQuestion.Add(question);
            }
            data.Close();
            return listQuestion;
        }

        public static propQuestion GetById(int id)
        {
            var data = DataAccess.Question.Get(id);
            var question = new propQuestion();
            while (data.Read())
            {
                question.id = int.Parse(data["Id"].ToString());
                question.question = data["Question"].ToString();
                question.projectId = int.Parse(data["ProjectId"].ToString());
            }
            data.Close();
            return question;
        }

        public static void Add(int projectId, string questionStr)
        {
            DataAccess.Question.Add(projectId, questionStr);
        }

        public static void Update(int id, string question)
        {
            DataAccess.Question.Update(id, question);
        }


        public static void Update(int id, int projectId)
        {
            DataAccess.Question.Update(id, projectId);
        }

        public static void Update(int id, string question, int projectId)
        {
            DataAccess.Question.Update(id, question, projectId);
        }

        public static void Delete(int id)
        {
            DataAccess.Question.Delete(id);
        }
    }
}
