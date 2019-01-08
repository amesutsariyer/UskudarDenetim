using MailReceiver.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UskudarDenetim.Core.Extensions;
using UskudarDenetim.Repository.EF;
using UskudarDenetim.UI.Models;

namespace UskudarDenetim.UI.Controllers
{
    public class MailController : BaseController
    {

        private Repository.Interface.GenericRepository<Subscribe> _subscribeRepository;
        public MailController()
        {
            _subscribeRepository = new Repository.GenericRepository<Subscribe>();
        }
        [Authorize]
        public ActionResult Index()
        {
            var subscribeList = _subscribeRepository.GetAll().ToList();

            var model = new ModelMail()
            {
                Credential = new Credential()
                {
                    UserName = MailCredentialUserName,
                    Password = "Infouskudardenetim12345"
                },
                HostName = MailHostName,
                Port = Convert.ToInt32(MailPort),
                Subject = MailSubject,
                From = MailFrom,
                // ToArray = "ahmet",
                Content = new Content()
                {
                    Header = "2018 Yılı İçin Yeniden Değerleme Oranı",
                    Link = "http://213.128.89.156/plesk-site-preview/uskudardenetim.com/Circular/Detail/8effacc6-3912-457b-98dd-e89a8d90300f",
                    StrongSubHeader = "Üsküdar Denetim",
                    SubHeader = "Yayınlamış olan bu sirküyü okumak için lütfen bizi ziyaret edin."
                }
            };
            //foreach (var subsitem in subscribeList)
            //{
            //    model.ToArrayString = model.ToArrayString + subsitem.EmailAddress + ";" + "\n";
            //}
            for (int i = 0; i < subscribeList.Count; i++)
            {
                if (i == subscribeList.Count - 1)
                {
                    model.ToArrayString = model.ToArrayString + subscribeList[i].EmailAddress;
                }
                else
                {
                    model.ToArrayString = model.ToArrayString + subscribeList[i].EmailAddress + ";" + "\n";
                }
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public ActionResult SendMail(ModelMail request)
        {
            try
            {
                var response = SendMailHelper(request);
                return Json(new { Status = true, Message = "Email Atma İşlemi Başarılı." });
            }
            catch (Exception ex)
            {
                return Json(new { Status = false, Message = "Hata Oluştu." + ex.Message });
            }
        }
        [Authorize]
        private Response SendMailHelper(ModelMail request)
        {
            Response resp = MailToParser(request);
            if (!resp.Success)
            {
                return new Response() { Message = resp.Message, Success = false };
            }
            var toArray = new List<string>();
            foreach (var item in resp.Data as string[])
            {
                toArray.Add(item);
            }
            var model = new MailRequest()
            {
                Credential = new Credential()
                {
                    UserName = MailCredentialUserName,
                    Password = request.Credential.Password
                },
                HostName = MailHostName,
                Port = Convert.ToInt32(MailPort),
                Subject = MailSubject,
                From = MailFrom,
                ToArray = toArray,
                Content = new Content()
                {
                    Header = request.Content.Header,
                    Link = request.Content.Link,
                    StrongSubHeader = request.Content.StrongSubHeader,
                    SubHeader = request.Content.SubHeader
                }
            };
            var response = MailReceiver.Base.MailService.SendMail(model);
            return response;
        }

        private Response MailToParser(ModelMail request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.ToArrayString))
                {
                    return new Response() { Message = "Lütfen Gönderici Bilgisi Giriniz.", Success = false };
                }
                string[] toArray = request.ToArrayString.Replace("\r\n", "").Split(';');

                return new Response() { Message = "Parser Ok", Success = true, Data = toArray };
            }
            catch (Exception ex)
            {
                return new Response() { Message = "Parser Error.Mail adresses could't parse in Method.(Mail adresleri arasındaki noktalı virgülleri kontrol ediniz.Aksi Takdirde site yöneticiniz ile iletişime geçiniz.)" + ex.Message, Success = false };
            }
        }
    }
}