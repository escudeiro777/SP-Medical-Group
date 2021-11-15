using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SENAI_SP_Medical_Group.ViewModels
{
    /// <summary>
    /// classe responsável pelo login do usuario
    /// </summary>
    public class LoginViewModel
    { 
            [Required(ErrorMessage = "Informe o email do usuário.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Informe a senha o usuario.")]

            public string senha { get; set; }
        
    }
}
