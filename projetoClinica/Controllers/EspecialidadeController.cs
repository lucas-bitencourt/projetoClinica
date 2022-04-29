using projetoClinica.Dados;
using projetoClinica.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projetoClinica.Controllers
{
    public class EspecialidadeController : Controller
    {
        AcoesEspecialidades acE = new AcoesEspecialidades();
    
        // GET: Especialidade
        public ActionResult Index()
        {
            Session["tipo"] = "";
            return View();
        }

        public ActionResult CadEsp()
        {
            Session["tipo"] = "";
            return View();
        }

        [HttpPost]
        public ActionResult CadEsp(ModelEspecialidade cmEsp)
        {
            Session["tipo"] = "";
            acE.inserirEsp(cmEsp);
            Response.Write("<script>alert('Cadastro realizado com sucesso')</script>");
            return View();
        }

        public ActionResult ConsEsp()
        {
            Session["tipo"] = "";
            GridView dgv = new GridView();
            dgv.DataSource = acE.ConsultaEsp();
            dgv.DataBind();
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            dgv.RenderControl(htw);
            ViewBag.GridViewString = sw.ToString();
            return View();
        }

    }
}