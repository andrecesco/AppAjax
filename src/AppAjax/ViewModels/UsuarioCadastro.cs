using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppAjax.ViewModels
{
    /// <summary>
    /// Classe model para cadastro do usuário
    /// </summary>
    public class UsuarioCadastro
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
