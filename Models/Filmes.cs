using System;
using System.ComponentModel.DataAnnotations;

namespace Filmes2012.Models;

public class Filmes {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Ano { get; set; } 

    [Display(Name="Duração")]
    public int Duracao { get; set; }

    [Display(Name="Gênero")]
    public string Genero { get; set; }
    public Boolean Bom { get; set; }
}
