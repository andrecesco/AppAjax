using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AppAjax.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace AppAjax.Controllers
{
    public class UsuarioController : Controller
    {
        
        /// <summary>
        /// Index leva o mesmo nome da view, assim fica mais fácil de retornar.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Filtrar(UsuarioConsultar modelConsulta)
        {
            //Realiza a consulta.
            //Converte para a entidade ou chama uma camada de service para realizar isso.
            List<UsuarioConsultar> listaResultado = new List<UsuarioConsultar>();
            UsuarioConsultar usuario = new UsuarioConsultar();
            for (int i = 0; i < 10; i++)
            {
                usuario.IdUsuario = i;
                usuario.NomeCompleto = "Usuário Teste " + i.ToString();
                //string.format faz o replace {0} pelo i.ToString()
                usuario.Email = string.Format("usuarioteste{0}@teste.com.br", i.ToString());
                //Mesma funcionalidade do string.format só que mais elegante
                usuario.Senha = $"senha{i.ToString()}";

                listaResultado.Add(usuario);
                usuario = new UsuarioConsultar();
            }

            ViewData["DataSource"] = listaResultado;

            //Caso é uma requisição ajax retorna somente a partial e carrega atualiza ela somente
            //Na div que foi setada no form através do data-ajax-update
            //O seja essa partial vai ser rederizada naquele ponto
            return View("_Consultar");
        }

        /// <summary>
        /// Chama a página de cadastro
        /// Pode ser modal, aí nesse caso é ajax ou pode ser POST
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        /// <summary>
        /// Realiza o cadastro do objeto, novamente.
        /// Pode ser ajax ou post só depende da chamada da VIEW
        /// **IMPORTANTE DEVE ESPECIFICAR SE É UM POST OU UM GET ATRAVÉS DA TAG [HttpPost]
        /// SE NÃO FALAR NADA POR DEFAULT É GET**
        /// </summary>
        /// <param name="modelCadastro"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CadastrarObjeto(UsuarioCadastro modelCadastro)
        {
            //Redireciona para a action da index acima.
            //Para recarregar a tela, se for AJAX deve ter uma tratativa para esse tipo de retorno.
            //Tal como fiz no outro projeto.
            return RedirectToAction("Index");
        }
    }
}
