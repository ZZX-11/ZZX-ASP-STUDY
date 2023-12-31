﻿using Assignment2.Models;
using Assignment2.Utils;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            // bulk email tester
            //String toEmail = "shua0098@student.monash.edu";
            //String subject = "backup email";
            //String contents = "backup email";
            //HttpPostedFileBase attachment = null;

            //EmailSender es = new EmailSender();
            //es.Send(toEmail, subject, contents, attachment);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Email()
        {
            SendEmailViewModel sendEmailViewModel = new SendEmailViewModel();
            sendEmailViewModel.ToEmail = User.Identity.GetUserName();
            sendEmailViewModel.Subject = "Your dental appointment";
            sendEmailViewModel.Contents = "Your dental appointment  details";
            //sendEmailViewModel.Attachment = { System.Web.HttpPostedFileWrapper};
            return View(sendEmailViewModel);
            //return View(new SendEmailViewModel());
        }

        public ActionResult Send_bulkEmail()
        {
            SendEmailViewModel sendEmailViewModel = new SendEmailViewModel();
            sendEmailViewModel.ToEmail = "shua0098@student.monash.edu";
            sendEmailViewModel.Subject = "Your dental appointment";
            sendEmailViewModel.Contents = "Your dental appointment  details";
            //sendEmailViewModel.Attachment = { System.Web.HttpPostedFileWrapper};
            return View(sendEmailViewModel);
            //return View(new SendEmailViewModel());
        }


        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    HttpPostedFileBase attachment = model.Attachment;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents, attachment);
                    // send backup email to my address
                    es.Send("1102706742@qq.com", subject, contents, attachment);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }
    }
}