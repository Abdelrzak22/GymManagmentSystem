using GymManagmentBLL.Services.Classes;
using GymManagmentBLL.Services.Interfaces;
using GymManagmentBLL.ViewModels.MemberViewModel;
using GymManagmentBLL.ViewModels.TrainerViewModel;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentPL.Controllers
{
    public class TrainerController : Controller
    {
        private readonly ITrainerService _trainerService;

        public TrainerController(ITrainerService trainerService)
        {
            _trainerService = trainerService;
        }

        public ActionResult Index()
        {
            var date = _trainerService.GetTrainers();

            return View(date);
        }

        public ActionResult TrainerDetails(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "the Member id not be 0 or Negative";
                return RedirectToAction(nameof(Index));

            }
            var memberData = _trainerService.GetById(id);
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
        public ActionResult CreateTrainer(CreateTrainerVIewModel Created)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("DataError", "check data and missing field");
                return View(nameof(Create), Created);
            }

            bool member = _trainerService.CreateTrainer(Created);
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


        public ActionResult TrainerEdit(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "the Member id not be 0 or Negative";
                return RedirectToAction(nameof(Index));
            }
            var memberData = _trainerService.GetDataToUpdate(id);
            if (memberData is null)
            {
                TempData["ErrorMessage"] = "there is no data with this id ";

                return RedirectToAction(nameof(Index));
            }
            return View(memberData);
        }

        [HttpPost]

        public ActionResult TrainerEdit([FromRoute] int id, TrainerUpdateViewModel MemberToUpdate)
        {
            if (!ModelState.IsValid)
                return View(MemberToUpdate);

            var member = _trainerService.Update(id,MemberToUpdate);
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


        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                TempData["ErrorMessage"] = "the Member id not be 0 or Negative";
                return RedirectToAction(nameof(Index));
            }

            var data = _trainerService.GetById(id);
            if (data is null)
            {
                TempData["ErrorMessage"] = "there is no data with this id ";

                return RedirectToAction(nameof(Index));

            }

            ViewBag.TrainerId = id;
            ViewBag.TrainerName = data.Name;
            return View();

        }

        [HttpPost]
        public ActionResult DeleteConfirmed([FromForm] int id)
        {
            var member = _trainerService.Delete(id);
            if (member)
            {
                TempData["SuccessMessage"] = "the member deleted successfully";
            }
            else
            {

                TempData["ErrorMessage"] = "the member  is not deleted  ";
            }
            return RedirectToAction(nameof(Index));

        }
    }
}
