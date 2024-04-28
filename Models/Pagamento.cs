using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApiProject.Models;

public class Pagamento
{
  [Key]
  public int IdPagamento{ get; set;}

  [ForeignKey("Cliente")]
  public int ClienteId{ get; set;}

  [Column(TypeName ="decimal(18, 2)")]
  public decimal Valor {get; set;}

  public DateTime Data {get; set;}

  [Required]
  [StringLength(50)]
  public string Status {get; set;}

  public virtual Cliente Cliente {get; set;}

  public Pagamento()
  {
    Data = DateTime.Now;
    Status = "Pendente";
  }
}
