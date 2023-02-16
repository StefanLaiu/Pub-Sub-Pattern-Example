using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pub_Sub_Example_Implementation.Arguments;
using Pub_Sub_Example_Implementation.Publishers;

namespace Pub_Sub_Example_Implementation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public EventAggregator _eventAgg;
        [BindProperty]
        public List<HRData> Candidates { get; set; } = new();
        [BindProperty]
        public List<BackEndAnswers> BeCandidates { get; set; } = new();
        [BindProperty]
        public List<FrontEndAnswers> FeCandidates { get; set; } = new();

        public IndexModel(ILogger<IndexModel> logger, EventAggregator eventAgg)
        {
            _logger = logger;
            _eventAgg = eventAgg;
        }

        public void OnGet()
        {
            _eventAgg.Subscribe<HRData>(ReturnToDisplay);
            _eventAgg.Subscribe<FrontEndAnswers>(ReturnToDisplayFrontEnd);
            _eventAgg.Subscribe<BackEndAnswers>(ReturnToDisplayBackEnd);
        }
        public void OnPost()
        {
            List<string> personal = new() { "emailaddress", "fullname", "linkedin" };
            List<string> feKeylist = new() { "http", "table1", "table2", "table3", "table4", "htmlFileSection", "angularComponents" };
            List<string> beKeylist = new() { "cSharp", ".NET1", ".NET2", ".NET3", "asynchronously", "throw" };
            try
            {
                var personalItems = Request.Form.Where(x => personal.Contains(x.Key)).ToDictionary(x => x.Key, y => y.Value.ToString());
                var frontEndItems = Request.Form.Where(x => feKeylist.Contains(x.Key)).ToDictionary(x => x.Key, y => y.Value.ToString());
                var backEndItems = Request.Form.Where(x => beKeylist.Contains(x.Key)).ToDictionary(x => x.Key, y => y.Value.ToString());
                string fullName = personalItems["fullname"];
                string linkedinProfileURL = string.IsNullOrEmpty(personalItems["linkedin"]) ? string.Empty : personalItems["linkedin"];
                GenericPublisher publisher = new(_eventAgg);
                BackEndAnswers beAns = new(backEndItems.ToList(), fullName, linkedinProfileURL);
                FrontEndAnswers feAns = new(frontEndItems.ToList(), fullName, linkedinProfileURL);

                    publisher.PublishMessage(beAns);
                    publisher.PublishMessage(feAns);

                HRData hrData = new(fullName, linkedinProfileURL)
                {
                    Email = personalItems["emailaddress"],
                    BacEndEndScore = beAns.Score,
                    FrontEndScore = beAns.Score
                };
                publisher.PublishMessage(hrData);
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void ReturnToDisplay(HRData answers)
        {
            Candidates.Add(answers);
        }
        private void ReturnToDisplayFrontEnd(FrontEndAnswers answers)
        {
            FeCandidates.Add(answers);
        }
        private void ReturnToDisplayBackEnd(BackEndAnswers answers)
        {
            BeCandidates.Add(answers);
        }
    }
}