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
        public static propAnswer Get(int id)
        {
            var answer = new propAnswer();
            var data = DataAccess.Answer.Get(id);
            while (data.Read())
            {
                answer.id = int.Parse(data["Id"].ToString());
                answer.answer = data["Answer"].ToString();
                answer.questionId = int.Parse(data["QuestionId"].ToString());
                answer.status = bool.Parse(data["Status"].ToString());
            }
            data.Close();
            return answer;
        }

        public static propAnswer GetByQuestion(int questionId)
        {
            var answer = new propAnswer();
            var data = DataAccess.Answer.GetByQuestion(questionId);
            while (data.Read())
            {
                answer.id = int.Parse(data["Id"].ToString());
                answer.answer = data["Answer"].ToString();
                answer.questionId = int.Parse(data["QuestionId"].ToString());
                answer.status = bool.Parse(data["Status"].ToString());
            }
            data.Close();
            return answer;
        }

        public static void Add(int questionId, string _answer, bool status)
        {
            DataAccess.Answer.Add(questionId, _answer, status);
        }

        public static void Update(int id, string answer)
        {
            DataAccess.Answer.Update(id, answer);
        }

        public static void Update(int id, int questionId)
        {
            DataAccess.Answer.Update(id, questionId);
        }

        public static void UpdateStatus(int id, int status)
        {
            DataAccess.Answer.UpdateStatus(id, status);
        }

        public static void Update(int id, string answer, int questionId, bool status)
        {
            DataAccess.Answer.Update(id, answer, questionId, status);
        }

        public static void Delete(int id)
        {
            DataAccess.Answer.Delete(id);
        }

        public static void DeleteByQuestion(int questionId)
        {
            DataAccess.Answer.DeleteByQuestion(questionId);
        }
    }
}
