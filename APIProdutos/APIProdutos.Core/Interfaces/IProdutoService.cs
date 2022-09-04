namespace APIProdutos.Core.Interfaces
{
    public interface IProdutoService
    {
        List<Produto> GetProdutos();
        bool InsertProduto(Produto produto);
        bool DeleteProduto(long id);
        bool UpdateProduto(long id, Produto produto);
        public Produto GetProdutoDesc(string descricao);
    }
}
