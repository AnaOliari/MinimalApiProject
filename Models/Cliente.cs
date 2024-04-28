using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApiProject.Models;

public class Cliente{
  [Key] // Indica que a propriedade ClienteId é a chave primária da tabela.
  public int ClienteId{ get; set;}

  [Required] //Especifica que o campo é obrigatório.
  [StringLength(100)] //Define o tamanho máximo do campo para 100 caracteres.
  public string Nome{ get; set;}

  [EmailAddress] //Valida que o campo deve conter um endereço de e-mail válido.
  [StringLength(100)]
  public string Email{ get; set;}

  public  virtual ICollection<Pagamento> Pagamentos{ get; set;}

  public Cliente()
  {
    Pagamentos = new HashSet<Pagamento>();
  }
}