using Umbraco.Web.Mvc;
using System.Web.Mvc;
using Helpdesk_evry.Models;
using System.Net.Mail;
using Umbraco.Web;

namespace Helpdesk_evry.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        public const string PARTIAL_VIEW_FOLDER = "~/Views/Partials/Contact/";

        public ActionResult RenderForm(int pageId)
        {
            var model = new ContactModel();
            var page = Umbraco.Content(pageId);

            var problems = page.Value<string[]>("typeOfProblem");
            var department = page.Value<string[]>("serviceDepartment");

            model.TypeOfProblems = problems;
            model.ServiceDepartments = department;

            model.PageId = pageId;
            return PartialView(PARTIAL_VIEW_FOLDER + "_Contact.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(ContactModel model, int pageId)
        {
            if(ModelState.IsValid)
            {
                SendEmail(model, pageId);
                return RedirectToCurrentUmbracoPage(); 
            }
            return CurrentUmbracoPage();
        }

        private void SendEmail(ContactModel model, int pageId)
        {
            var page = Umbraco.Content(pageId);
            var homePage = page.Root();

            string sender = (!string.IsNullOrEmpty(page.Value<string>("sendingEmail")) ? page.Value<string>("sendingEmail") : homePage.Value<string>("defaultSendingEmail"));
            string receiever = (!string.IsNullOrEmpty(page.Value<string>("receievingEmail")) ? page.Value<string>("receievingEmail") : homePage.Value<string>("defaultReceievingEmail"));

            MailMessage message = new MailMessage(sender, receiever);
            message.Subject = string.Format("{0} - {1}", model.Subject, model.EmailAddress);
            message.Body = string.Format("Avdelning: {0}.\nÄrende: {1}.\nTelefon: {2}\nE-postadress: {3}\n \n{4}",
            model.TypeOfProblems, model.ServiceDepartments, model.PhoneNumber, model.EmailAddress, model.Message);
            SmtpClient client = new SmtpClient("127.0.0.1", 25);
            client.Send(message);
        }
    }
}