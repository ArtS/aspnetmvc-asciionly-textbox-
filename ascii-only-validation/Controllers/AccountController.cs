using System.Web.Mvc;
using FilerPrintableOnlyTextInput.Models;

namespace FilerPrintableOnlyTextInput.Controllers
{
    public class AccountController : Controller
    {
        //
        // 1. Action method for displaying the 'Create Account' page
        //
        public ActionResult Index()
        {
            // Get existing Account object from the session or create a new one
            var model = Session["AccountModel"] as AccountModel ?? new AccountModel();

            return View(model);
        }

        //
        // 2. Action method for handling user-entered data when 'Update' button is pressed.
        //
        [HttpPost]
        public ActionResult UpdateAccount(AccountModel model)
        {
            // In case everything is fine - i.e. "AccountName" is entered and valid,
            // redirect the user to the "ViewAccount" page, and pass the account object along via Session
            if (ModelState.IsValid)
            {
                Session["AccountModel"] = model;

                // In here you can add saving of object to a database

                return RedirectToAction("ViewAccount");
            }

            // Validation falied, something is not right. Re-render the registration page, keeping user-entered data
            // and display validation errors
            return View("Index" ,model);
        }

        //
        // 3. Action method for displaying 'ViewAccount' page
        //
        public ActionResult ViewAccount()
        {
            // Get acount information from the session
            var model = Session["AccountModel"] as AccountModel;
            if (model == null)
                return RedirectToAction("Index");

            // Display View Account page that shows AccountName.
            return View(model);
        }

    }
}