using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pub_Sub_Example_Implementation.Arguments;
using Pub_Sub_Example_Implementation.Subscribers;

namespace Pub_Sub_Example_Implementation.Pages
{
    public class AngularDisplayModel : PageModel
    {
        private GenericSubscriber<FrontEndAnswers> _dataSub;
        [BindProperty]
        public List<FrontEndAnswers> Candidates { get; set; } = new();

        public AngularDisplayModel(EventAggregator eventAgg)
        {

            _dataSub = new(eventAgg);
        }
        public void OnGet()
        {
            Candidates = _dataSub.Messages;
        }
    }
}
