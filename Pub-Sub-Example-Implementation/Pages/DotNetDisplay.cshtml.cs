using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pub_Sub_Example_Implementation.Arguments;
using Pub_Sub_Example_Implementation.Subscribers;

namespace Pub_Sub_Example_Implementation.Pages
{
    public class DotNetDisplayModel : PageModel
    {
        private GenericSubscriber<BackEndAnswers> _dataSub;
        [BindProperty]
        public List<BackEndAnswers> Candidates { get; set; } = new();

        public DotNetDisplayModel(EventAggregator eventAgg)
        {

            _dataSub = new(eventAgg);
        }
        public void OnGet()
        {
            Candidates = _dataSub.Messages;
        }

    }
}
