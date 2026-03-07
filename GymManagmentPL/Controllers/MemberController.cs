using GymManagmentBLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GymManagmentPL.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService) {
            _memberService = memberService;
        }
        public ActionResult Index()
        {
            var Data = _memberService.GetMembers();
            return View(Data);
        }

        public ActionResult MemberDetails(int id)
        {
            if (id <= 0)
                return RedirectToAction(nameof(Index));
            var memberData = _memberService.GetMemberDetails(id);
            if (memberData is null)
                return RedirectToAction(nameof(Index));
            return View(memberData);
        }

        public ActionResult HealthRecordDetails(int id)
        {
            if (id <= 0)
                return RedirectToAction(nameof(Index));
            var memberData = _memberService.GetHealthRecordViewModel(id);
            if (memberData is null)
                return RedirectToAction(nameof(Index));
            return View(memberData);
        }


    }
}
