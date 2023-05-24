using System;
using System.Collections.Generic;

namespace PI_PorrtabilidadeWebOkPrrojetos.Models;

public partial class ItnServRec
{
    public int Id { get; set; }

    public int? IdOrdRec { get; set; }

    public int? IdOrdServ { get; set; }

    public string? Descricao { get; set; }

    public string? Valor { get; set; }

    public DateTime? DataDeCriacao { get; set; }

    public DateTime? UltimaModificacao { get; set; }

    public virtual OrdRecebimento? IdOrdRecNavigation { get; set; }

    public virtual OrdServico? IdOrdServNavigation { get; set; }
}
