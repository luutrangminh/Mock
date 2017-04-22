using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class propAnswer
    {
        public int id { get; set; }
        public string answer { get; set; }
        public int questionId { get; set; }
        public bool status { get; set; }
    }

    public class Answer
    {
        DataAccess.Answer answerDAO = new DataAccess.Answer();

        public propAnswer Get(int id)
        {
            var answer = new propAnswer();
            var data = answerDAO.Get(id);
            while (data.Read())
            {
                answer.id = int.Parse(data["Id"].ToString());
                answer.answer = data["Answer"].ToString();
                answer.questionId = int.Parse(data["QuestionId"].ToString());
                answer.status = bool.Parse(data["Status"].ToString());
            }
            return answer;
        }

        public propAnswer GetByQuestion(int questionId)
        {
            var answer = new propAnswer();
            var data = answerDAO.GetByQuestion(questionId);
            while (data.Read())
            {
                answer.id = int.Parse(data["Id"].ToString());
                answer.answer = data["Answer"].ToString();
                answer.questionId = int.Parse(data["QuestionId"].ToString());
                answer.status = bool.Parse(data["Status"].ToString());
            }
            return answer;
        }

        public propAnswer Add(int questionId, string _answer, bool status)
        {
            var answer = new propAnswer();
            var data = answerDAO.Add(questionId, _answer, status);
            while (data.Read())
            {
                answer.id = int.Parse(data["Id"].ToString());
                answer.answer = data["Answer"].ToString();
                answer.questionId = int.Parse(data["QuestionId"].ToString());
                answer.status = bool.Parse(data["Status"].ToString());
            }
            return answer;
        }

        public void Update(int id, string answer)
        {
            answerDAO.Update(id, answer);
        }

        public void Update(int id, int questionId)
        {
            answerDAO.Update(id, questionId);
        }

        public void UpdateStatus(int id, int status)
        {
            answerDAO.UpdateStatus(id, status);
        }

        public void Update(int id, string answer, int questionId, bool status)
        {
            answerDAO.Update(id, answer, questionId, status);
        }

        public void Delete(int id)
        {
            answerDAO.Delete(id);
        }

        public void DeleteByQuestion(int questionId)
        {
            answerDAO.DeleteByQuestion(questionId);
        }
    }
}
