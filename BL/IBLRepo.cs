using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace BL
{
    public interface IBLRepo
    {
        //Sales CRUD
        Task<Sale> AddSaleAsync(Sale sale);
        Task<List<Sale>> GetUserSalesAsync(string sellername, long phoneNumber);
        Task<List<Sale>> GetUserPurchasesAsync(string buyername, long phoneNumber);
        Task<List<Sale>> GetSalesAsync();

        //Cart CRUD
        Task<Cart> AddToCartAsync(Cart cart);
        Task<Cart> GetOneCartAsync(int id);
        Task<List<Cart>> GetCartsAsync(string buyername, long phoneNumber);
        Task DeleteCartAsync(int id);
        Task<Cart> UpdateCartAsync(Cart cart);
    }
}
