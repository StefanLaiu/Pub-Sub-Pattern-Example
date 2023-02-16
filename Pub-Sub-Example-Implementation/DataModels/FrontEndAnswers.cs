namespace Pub_Sub_Example_Implementation.Arguments
{
    public class FrontEndAnswers : BaseAnswers
    {public FrontEndAnswers(List<KeyValuePair<string,string>> answers,string name, string email):base(name,email)
        {
            Answers = new();
            List<string> oneTableAnswer = answers
                .Where(x => x.Key.Equals("table1") || x.Key.Equals("table2") || x.Key.Equals("table3") || x.Key.Equals("table4"))
                .Select(y => y.Value)
                .ToList();
            string ans = string.Join(" ", oneTableAnswer);
            var shortList = answers.RemoveAll(x => x.Key.Equals("table1") || x.Key.Equals("table2") || x.Key.Equals("table3") || x.Key.Equals("table4"));
            answers.Add(new KeyValuePair<string, string>("table", ans));
            DetermineResult(answers);
        }
        protected override bool IsAnsweredCorect(KeyValuePair<string,string> question) {
            switch (question.Key)
            {
                case "http":
                    {
                        return question.Value.Equals("HyperText Transfer Protocol");
                    }
                case "table":
                    {
                        return question.Value.Equals("false true false false");
                    }
                case "htmlFileSection":
                    {
                        return question.Value.Equals("head");
                    }
                case "angularComponents":
                    {
                        return question.Value.Equals("3");
                    }

                default:
                    return string.IsNullOrEmpty(question.Value)|| question.Value.Equals("false");
            }
        }
    }
}
