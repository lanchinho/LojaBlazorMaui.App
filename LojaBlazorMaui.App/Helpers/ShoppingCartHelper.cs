using Blazored.LocalStorage;
using LojaBlazorMaui.App.Models;

namespace LojaBlazorMaui.App.Helpers
{
    /// <summary>
    /// Classe para operações do carrinho de compras do aplicativo
    /// </summary>
    public class ShoppingCartHelper
    {
        private readonly ILocalStorageService _localStorageService;
        private const string _key = "shopping-cart";

        public ShoppingCartHelper(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        /// <summary>
        /// Método para adicionar 1 item no carrinho de compras
        /// </summary>        
        public async Task Add(ShoppingCartItemModel item)
        {
            //Verificar se já existe um carrinho de compras criado
            var shoppingCart = await _localStorageService.GetItemAsync<ShoppingCartModel>(_key) ?? new ShoppingCartModel
            {
                Itens = new List<ShoppingCartItemModel>()
            };

            //buscando no carrinho de compras um item com o mesmo id do item adicionado
            var itemObtido = shoppingCart.Itens.FirstOrDefault(i => i.Produto.Id == item.Produto.Id);

            if (itemObtido != null)
            {
                //incrementar a quantidade do item
                itemObtido.Qtd++;
            }
            else
            {
                //adicionar o item no carrinho de compras
                shoppingCart.Itens.Add(item);
            }

            //gravando os dados na local storage
            await _localStorageService.SetItemAsync(_key, shoppingCart);
        }

        /// <summary>
        /// Aumentar a quantidade de produtos no carrinho em uma unidade
        /// </summary>
        /// <param name="id">Id do produto</param>        
        public async Task Add(Guid id)
        {
            //ler o conteúdo do carrinho de compras
            var shoppingCart = await _localStorageService.GetItemAsync<ShoppingCartModel>(_key);

            //buscando o item selecionado dentro do carrinho de compras
            var item = shoppingCart.Itens.FirstOrDefault(i => i.Produto.Id == id);

            //incremento a quantidade de itens
            item.Qtd++;

            //gravando os dados na local storage
            await _localStorageService.SetItemAsync(_key, shoppingCart);
        }


        /// <summary>
        /// Diminui a quantidade de produtos no carrinho em uma unidade
        /// </summary>
        /// <param name="id">Id do produto</param>        
        public async Task Remove(Guid id)
        {
            //ler o conteúdo do carrinho de compras
            var shoppingCart = await _localStorageService.GetItemAsync<ShoppingCartModel>(_key);

            //buscando o item selecionado dentro do carrinho de compras
            var item = shoppingCart.Itens.FirstOrDefault(i => i.Produto.Id == id);

            if (item.Qtd > 1)
                //decremento a quantidade de itens
                item.Qtd--;
            else
               shoppingCart.Itens.Remove(item);

            //gravando os dados na local storage
            await _localStorageService.SetItemAsync(_key, shoppingCart);
        }

        /// <summary>
        /// Método para limpar todo o conteúdo do carrinho de compras
        /// </summary>        
        public async Task RemoveAll()
        {
            await _localStorageService.RemoveItemAsync(_key);
        }

        /// <summary>
        /// Método para retornar todo o conteúdo do carrinho de compras
        /// </summary>        
        public async Task<ShoppingCartModel> Get()
        {
            return await _localStorageService.GetItemAsync<ShoppingCartModel>(_key);
        }
    }
}
