using System;
using System.ComponentModel.DataAnnotations;

namespace Filmes2012.Models;

public class Review {
    public int Id { get; set; }
    public int Nota { get; set; }
    public string Comentario { get; set; } 
    
    public int IdUsuario { get; set; }
    public int IdFilme { get; set; }
}
