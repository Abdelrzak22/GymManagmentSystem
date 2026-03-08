using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.MemberViewModel;
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
            {
                TempData["ErrorMessage"] = "the Member id not be 0 or Negative";
                return RedirectToAction(nameof(Index));

            }
            var memberData = _memberService.GetMemberDetails(id);
            if (memberData is null)
            {
                TempData["ErrorMessage"] = "there is no data with this id ";

                return RedirectToAction(nameof(Index));

            }
            return View(memberData);
        }

        public ActionResult HealthRecordDetails(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "the Member id not be 0 or Negative";
                return RedirectToAction(nameof(Index));
            }
            var memberData = _memberService.GetHealthRecordViewModel(id);
            if (memberData is null)
            {
                TempData["ErrorMessage"] = "there is no data with this id ";

                return RedirectToAction(nameof(Index));
            }
            return View(memberData);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateMember(CreateMemberViewModel Created)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataError", "check data and missing field");
                return View(nameof(Create),Created);
            }

            bool member=_memberService.Creat(Created);
            if (member)
            {
                TempData["SuccessMessage"] = "the member created successfully";
            }
            else
            {
                TempData["ErrorMessage"] = "the member not created , check phone and Email";

            }

            return RedirectToAction(nameof(Index));
        }

        public ActionResult MemberEdit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "the Member id not be 0 or Negative";
                return RedirectToAction(nameof(Index));
            }
            var memberData = _memberService.GetDataToUpdate(id);
            if (memberData is null)
            {
                TempData["ErrorMessage"] = "there is no data with this id ";

                return RedirectToAction(nameof(Index));
            }
            return View(memberData);
        }

        [HttpPost]

        public ActionResult MemberEdit([FromRoute] int id ,MemberToUpdateViewModel MemberToUpdate)
        {
            if (!ModelState.IsValid)
                return View(MemberToUpdate);

            var member = _memberService.Update( MemberToUpdate,id);
            if (member)
            {
                TempData["SuccessMessage"] = "the member updated successfully";
            }
            else
            {

                TempData["ErrorMessage"] = "the member  is not updated  ";
            }
            return RedirectToAction(nameof(Index));
        }


    }
}
