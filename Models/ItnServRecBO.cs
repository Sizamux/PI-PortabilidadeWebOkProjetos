namespace PI_PorrtabilidadeWebOkPrrojetos.Models
{
    static class ItnServRecBO
    {
        public static void CriarItnServRec(ItnServRec itnServRec)
        {
            itnServRec.DataDeCriacao = System.DateTime.Now;
            itnServRec.UltimaModificacao = System.DateTime.Now;
        }

        public static void AtuaizarCriarItnServRec(ItnServRec itnServRec)
        {
            itnServRec.UltimaModificacao = System.DateTime.Now;
        }
    }
}
