using System.Linq;

namespace Pub_Sub_Example_Implementation.Arguments
{
    public class BackEndAnswers : BaseAnswers
    {
        public BackEndAnswers(List<KeyValuePair<string, string>> answers,string name, string email) :base(name,email)
        {
            Answers = new();
            List<string> oneDotNetAnswer = answers
                .Where(x => x.Key.Equals(".NET1") || x.Key.Equals(".NET2") || x.Key.Equals(".NET3"))
                .Select(y => y.Value)
                .ToList();
            string ans = String.Join(" ", oneDotNetAnswer);
            var shortList = answers.RemoveAll(x => x.Key.Equals(".NET1") || x.Key.Equals(".NET2") || x.Key.Equals(".NET3"));
            answers.Add(new KeyValuePair<string, string>(".NET", ans));
            DetermineResult(answers);
        }

        protected override bool IsAnsweredCorect(KeyValuePair<string, string> question)
        {
            switch (question.Key)
            {
                case "cSharp":
                    {
                        return question.Value.Equals("true");
                    }
                case "NET":
                    {
                        return question.Value.Equals("true false true");
                    }
                case "asynchronously":
                    {
                        string answer = question.Value.ToLower();
                        return answer.Contains("async") && answer.Contains("await");
                    }
                case "throw":
                    {
                        return question.Value.Equals("3");
                    }

                default:
                    return string.IsNullOrEmpty(question.Value) || question.Value.Equals("false");
            }
        }
    }
}
