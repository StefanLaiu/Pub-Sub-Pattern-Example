using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Pub_Sub_Example_Implementation.Arguments;
using Pub_Sub_Example_Implementation.Subscribers;
using Pub_Sub_Example_Implementation.Subscriptions;

namespace Pub_Sub_Example_Implementation.Pages
{
    public class HumanResourcesDisplayModel : PageModel
    {
        private GenericSubscriber<HRData> hrDataSub;
        [BindProperty]
        public List<HRData> Candidates { get; set; } = new();
        
        public HumanResourcesDisplayModel(EventAggregator eventAgg)
        {

            hrDataSub = new(eventAgg);
        }
        public void OnGet()
        {
            Candidates = hrDataSub.Messages;
        }
       


    }
}
