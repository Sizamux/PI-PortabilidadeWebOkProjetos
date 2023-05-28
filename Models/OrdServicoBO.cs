namespace PI_PorrtabilidadeWebOkPrrojetos.Models
{
    static class OrdServicoBO
    {
        public static void CriarOrdServico(OrdServico ordServico)
        {
            ordServico.DataDeCriacao = System.DateTime.Now;
            ordServico.UltimaModificacao = System.DateTime.Now;
        }

        public static void AtuaizarOrdServico(OrdServico ordServico)
        {
            ordServico.UltimaModificacao = System.DateTime.Now;
        }
    }
}
