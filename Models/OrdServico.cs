using System;
using System.Collections.Generic;

namespace PI_PorrtabilidadeWebOkPrrojetos.Models;

public partial class OrdServico
{
    public int Id { get; set; }

    public string? NumeroPo { get; set; }

    public string? NomeOperadora { get; set; }

    public string? DescricaoPo { get; set; }

    public string? FaseAtual { get; set; }

    public DateTime? DataDeCriacao { get; set; }

    public DateTime? UltimaModificacao { get; set; }

    public virtual ICollection<ItnServRec> ItnServRecs { get; set; } = new List<ItnServRec>();
}
