using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SP_Medical_Group_webApi.ViewModel
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "Informe o email do usuário")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a aenha do usuário")]
        public string Senha { get; set; }

    }
}
