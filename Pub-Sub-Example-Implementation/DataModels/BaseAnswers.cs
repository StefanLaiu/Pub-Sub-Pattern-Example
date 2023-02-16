using Pub_Sub_Example_Implementation.DataModels;

namespace Pub_Sub_Example_Implementation.Arguments
{
    public abstract class BaseAnswers : PersonBasicInfo
    {
        public BaseAnswers(string fullName, string linkedin): base(fullName, linkedin) { }

        public decimal Score { get; protected set; } = 0M;
        public List<Tuple<bool, KeyValuePair<string, string>>> Answers { get; set; } = new();

        /// <summary>
        /// Determines the score and corectness of the Answers
        /// </summary>
        /// <param name="answers"></param>
        public void DetermineResult(IEnumerable<KeyValuePair<string,string>> submissions) {
            decimal percentagePerQuestion = submissions.Count() / 100;
            foreach (var item in submissions)
            {
                bool isCorrect = IsAnsweredCorect(item);
                Score += isCorrect ? percentagePerQuestion : 0;
                Answers.Add(new(isCorrect, item));
            }
        }
        /// <summary>
        /// Determines if the answer is correct. !Hardcoding will not be present in a real world application!
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        protected virtual bool IsAnsweredCorect(KeyValuePair<string, string> question) { return false; }
    }
}
