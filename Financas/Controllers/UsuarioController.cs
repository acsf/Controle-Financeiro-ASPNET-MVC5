using Financas.DAO;
using Financas.Entities;
using Financas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace Financas.Controllers
{
    public class UsuarioController : Controller
    {
        private UsuarioDAO usuarioDAO;

        public UsuarioController(UsuarioDAO usuarioCtor)
        {
            this.usuarioDAO = usuarioCtor;
        }
        public ActionResult Form()
        {
            return View();
        }
        public ActionResult Adiciona(UsuarioModel usuarioModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(usuarioModel.Nome, usuarioModel.Senha,
                        new { usuarioModel.Email });

                    return RedirectToAction("Index");

                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("usuarioModel.Invalido", e.Message);
                    return View("Form", usuarioModel);
                }
            }
            else
            {
                return View("Form", usuarioModel);
            }
        }
        public ActionResult Index()
        {
            return View(usuarioDAO.Lista());
        }
    }
}

