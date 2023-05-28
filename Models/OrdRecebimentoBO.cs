namespace PI_PorrtabilidadeWebOkPrrojetos.Models
{
    static class OrdRecebimentoBO
    {
        public static void CriarOrdRecebimento(OrdRecebimento ordRecebimento)
        {
            ordRecebimento.DataDeCriacao = System.DateTime.Now;
            ordRecebimento.UltimaModificacao = System.DateTime.Now;
        }

        public static void AtuaizarOrdRecebimento(OrdRecebimento ordRecebimento)
        {
            ordRecebimento.UltimaModificacao = System.DateTime.Now;
        }
    }
}
