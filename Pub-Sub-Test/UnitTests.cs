using Pub_Sub_Example_Implementation.Arguments;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pub_Sub_Test
{
    public class UnitTests
    {
        [Fact]
        [Category("Back-End")]
        public void TestBackEndAnswerManipulation()
        {
            string name = "name";
            string link = "L";
            List<KeyValuePair<string, string>> answer = new() { 
                new(".NET1", "true"), 
                new(".NET2", "true"), 
                new(".NET3", "true"), 
                new("cSharp", "true"), 
                new("wrongQKey", "") };
            BackEndAnswers beAns = new (answer, name,link);
            Assert.Contains(new Tuple<bool, KeyValuePair<string, string>>(false,new KeyValuePair<string, string>(".NET", "true true true")), beAns.Answers);
            Assert.True(beAns.Answers.Count() == 3);
        }


        [Fact]
        [Category("Front-End")]
        public void TestFrontEndAnswerManipulationExceptionThrow()
        {
            string link = string.Empty;
            List<KeyValuePair<string, string>> answer = new() {
                new("http", "Hot point")
            };
            FrontEndAnswers beAns ;
            Assert.Throws<ArgumentNullException>(() => beAns = new(answer, link, link));
        }
        [Fact]
        [Category("Front-End")]
        public void TestFrontEndAnswerManipulation()
        {
            string name = "name";
            string link = string.Empty;
            List<KeyValuePair<string, string>> answer = new() {
                new("http", "Hot point"),
                new("table1", "true"),
                new("table2", "false"),
                new("table3", "true"),
                new("table4", "true"),
                new("htmlFileSection", "true"),
                new("angularComponents", "4") };
            FrontEndAnswers beAns = new(answer, name, link);
            Assert.Contains(new Tuple<bool, KeyValuePair<string, string>>(false, new KeyValuePair<string, string>("table", "true false true true")), beAns.Answers);
            Assert.True(beAns.Answers.Count == 4);
        }

    }
}
