using System;
using System.ComponentModel.DataAnnotations;

namespace Filmes2012.Models;

public class Usuario {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; } 

    [Display(Name="Gênero")]
    public string Genero { get; set; }
    
    
    }
