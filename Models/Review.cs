using System;
using System.ComponentModel.DataAnnotations;

namespace Filmes2012.Models;

public class Review {
    public int Id { get; set; }

    [Range(0, 10)]
    public int Nota { get; set; }

    [Display(Name="Comentário")]
    public string Comentario { get; set; } 
    
    [Display(Name="Usuário")]
    public int IdUsuario { get; set; }

    [Display(Name="Filme")]
    public int IdFilme { get; set; }
}
