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
        DataAccess.Question questionDAO = new DataAccess.Question();

        public List<propQuestion> Get(int projectId)
        {
            var listQuestion = new List<propQuestion>();
            var data = questionDAO.GetByProject(projectId);
            while (data.Read())
            {
                propQuestion question = new propQuestion();
                question.id = int.Parse(data["Id"].ToString());
                question.question = data["Question"].ToString();
                question.projectId = int.Parse(data["ProjectId"].ToString());
                listQuestion.Add(question);
            }

            return listQuestion;
        }

        public propQuestion GetById(int id)
        {
            var data = questionDAO.Get(id);
            var question = new propQuestion();
            while (data.Read())
            {
                question.id = int.Parse(data["Id"].ToString());
                question.question = data["Question"].ToString();
                question.projectId = int.Parse(data["ProjectId"].ToString());
            }
            return question;
        }

        public propQuestion Add(int projectId, string questionStr)
        {
            var data = questionDAO.Add(projectId, questionStr);
            propQuestion question = new propQuestion();
            while(data.Read())
            {
                question.id = int.Parse(data["Id"].ToString());
                question.question = data["Question"].ToString();
                question.projectId = int.Parse(data["ProjectId"].ToString());
            }
            return question;
        }

        public void Update(int id, string question)
        {
            questionDAO.Update(id, question);
        }


        public void Update(int id, int projectId)
        {
            questionDAO.Update(id, projectId);
        }

        public void Update(int id, string question, int projectId)
        {
            questionDAO.Update(id, question, projectId);
        }

        public void Delete(int id)
        {
            questionDAO.Delete(id);
        }
    }
}
