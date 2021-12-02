using System;
using Models;
using DL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public class BLRepo : IBLRepo
    {
        readonly private IDLRepo _repo;

        public BLRepo(IDLRepo repo)
        {
            _repo = repo;
        }

        public async Task<Sale> AddSaleAsync(Sale sale)
        {
            return await _repo.AddSaleAsync(sale);
        }
        public async Task<List<Sale>> GetUserSalesAsync(string sellername, long phoneNumber)
        {
            return await _repo.GetUserSalesAsync(sellername, phoneNumber);
        }

        public async Task<List<Sale>> GetUserPurchasesAsync(string buyername, long phoneNumber)
        {
            return await _repo.GetUserPurchasesAsync(buyername, phoneNumber);
        }
        public async Task<List<Sale>> GetSalesAsync()
        {
            return await _repo.GetSalesAsync();
        }

        //Cart CRUD
        public async Task<Cart> AddToCartAsync(Cart cart)
        {
            return await _repo.AddToCartAsync(cart);
        }

        public async Task<Cart> GetOneCartAsync(int id)
        {
            return await _repo.GetOneCartAsync(id);
        }

        public async Task<List<Cart>> GetCartsAsync(string buyername, long phoneNumber)
        {
            return await _repo.GetCartsAsync(buyername, phoneNumber);
        }
        public async Task DeleteCartAsync(int id)
        {
            await _repo.DeleteCartAsync(id);
        }
        public async Task<Cart> UpdateCartAsync(Cart cart)
        {
            return await _repo.UpdateCartAsync(cart);
        }
    }
}
