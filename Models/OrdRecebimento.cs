using System;
using System.Collections.Generic;

namespace PI_PorrtabilidadeWebOkPrrojetos.Models;

public partial class OrdRecebimento
{
    public int Id { get; set; }

    public string? NumeroNf { get; set; }

    public string? Status { get; set; }

    public DateTime? DataDeRecebimento { get; set; }

    public DateTime? DataDeCriacao { get; set; }

    public DateTime? UltimaModificacao { get; set; }

    public virtual ICollection<ItnServRec> ItnServRecs { get; set; } = new List<ItnServRec>();
}
