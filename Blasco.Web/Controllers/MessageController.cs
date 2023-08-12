namespace Blasco.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Interfaces;
    using Infrastructure.Extentions;
    using ViewModels.Challenge;
    using ViewModels.Message;

    using static Common.NotificationMessagesConstents;
    using static Common.GeneralApplicationConstants;

    public class MessageController : Controller
    {
        private readonly IMessageService messageService;
        private readonly IUserService userService;

        public MessageController(IUserService userService, IMessageService messageService)
        {
            this.userService = userService;
            this.messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage(string id)
        {
            bool recipientExist = await this.userService.ExistByIdAsync(id);
            if (!recipientExist)
            {
                this.TempData[ErrorMessage] = "The User you are trying to messege does not Exist";
                return this.RedirectToAction("Index", "Home");
            }
            string userId = this.User.GetId()!;
            if (userId == id.ToLower())
            {
                this.TempData[ErrorMessage] = "You can not message yourself";
                return this.RedirectToAction("Index", "Home");
            }
            try
            {
                MessageFormModel formModel = new MessageFormModel()
                {
                    ReceiverName = await this.userService.GetFullNameByIdAsync(id),
                    ReceiverId = id,
                };

                return View(formModel);
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, GeneralErronrMassage);

                return this.RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(MessageFormModel model)
        {
            bool recipientExist = await this.userService.ExistByIdAsync(model.ReceiverId);
            if (!recipientExist)
            {
                this.TempData[ErrorMessage] = "The User you are trying to messege does not Exist";
                return this.RedirectToAction("Index", "Home");
            }
            string userId = this.User.GetId()!;
            if (userId == model.ReceiverId.ToLower())
            {
                this.TempData[ErrorMessage] = "You can not message yourself";
                return this.RedirectToAction("Index", "Home");
            }
            try
            {
                string senderId = this.User.GetId()!;
                await this.messageService.CreateMessageAsync(model, senderId);

                this.TempData[SuccessMessage] = "Message was sent successfully";

                return this.RedirectToAction("Index", "Home");
            }
            catch (Exception)
            {
                this.TempData[ErrorMessage] = GeneralErronrMassage;

                return this.RedirectToAction("Index", "Home");
            }
        }
    }
}
