using APIProdutos.Core.Interfaces;

namespace APIProdutos.Core.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public List<Produto> GetProdutos()
        {
            return _produtoRepository.GetProdutos();
        }
        public bool InsertProduto(Produto produto)
        {
            return _produtoRepository.InsertProduto(produto);
        }
        public bool DeleteProduto(long id)
        {
            return _produtoRepository.DeleteProduto(id);
        }
        public bool UpdateProduto(long id, Produto produto)
        {
            return _produtoRepository.UpdateProduto(id, produto);
        }
        public Produto GetProdutoDesc(string descricao)
        {
            return _produtoRepository.GetProdutoDesc(descricao);
        }
    }
}
