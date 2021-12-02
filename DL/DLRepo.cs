using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace DL
{
    public class DLRepo : IDLRepo
    {
        readonly private SalesDbContext _context;

        public DLRepo(SalesDbContext context)
        {
            _context = context;
        }

        public async Task<Sale> AddSaleAsync(Sale sale)
        {
            await _context.AddAsync(sale);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return sale;
        }
        public async Task<List<Sale>> GetUserSalesAsync(string sellername, long phoneNumber)
        {
            return await _context.Sales
                .Where(s => s.SellerName == sellername && s.SellerPhoneNumber == phoneNumber)
                .Select(s => new Sale()
                {
                    Id = s.Id,
                    SellerName = s.SellerName,
                    SellerPhoneNumber = s.SellerPhoneNumber,
                    BuyerName = s.BuyerName,
                    BuyerPhoneNumber = s.BuyerPhoneNumber,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Cost = s.Cost,
                    PurchaseDateTime = s.PurchaseDateTime
                }).ToListAsync();
        }

        public async Task<List<Sale>> GetUserPurchasesAsync(string buyername, long phoneNumber)
        {
            return await _context.Sales
                .Where(s => s.BuyerName == buyername && s.BuyerPhoneNumber == phoneNumber)
                .Select(s => new Sale()
                {
                    Id = s.Id,
                    SellerName = s.SellerName,
                    SellerPhoneNumber = s.SellerPhoneNumber,
                    BuyerName = s.BuyerName,
                    BuyerPhoneNumber = s.BuyerPhoneNumber,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Cost = s.Cost,
                    PurchaseDateTime = s.PurchaseDateTime
                }).ToListAsync();
        }

        public async Task<List<Sale>> GetSalesAsync()
        {
            return await _context.Sales
                .Select(s => new Sale()
                {
                    Id = s.Id,
                    SellerName = s.SellerName,
                    SellerPhoneNumber = s.SellerPhoneNumber,
                    BuyerName = s.BuyerName,
                    BuyerPhoneNumber = s.BuyerPhoneNumber,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Cost = s.Cost,
                    PurchaseDateTime = s.PurchaseDateTime
                }).ToListAsync();
        }

        //Cart CRUD
        public async Task<Cart> AddToCartAsync(Cart cart)
        {
            await _context.AddAsync(cart);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return cart;
        }

        public async Task<Cart> GetOneCartAsync(int id)
        {
            return await _context.Carts
                .Select(s => new Cart()
                {
                    Id = s.Id,
                    SellerName = s.SellerName,
                    SellerPhoneNumber = s.SellerPhoneNumber,
                    BuyerName = s.BuyerName,
                    BuyerPhoneNumber = s.BuyerPhoneNumber,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Cost = s.Cost,
                    CartDateTime = s.CartDateTime
                })
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Cart>> GetCartsAsync(string buyername, long phoneNumber)
        {
            return await _context.Carts
                .Where(c => c.BuyerName == buyername && c.BuyerPhoneNumber == phoneNumber)
                .Select(s => new Cart()
                {
                    Id = s.Id,
                    SellerName = s.SellerName,
                    SellerPhoneNumber = s.SellerPhoneNumber,
                    BuyerName = s.BuyerName,
                    BuyerPhoneNumber = s.BuyerPhoneNumber,
                    ProductName = s.ProductName,
                    Quantity = s.Quantity,
                    Cost = s.Cost,
                    CartDateTime = s.CartDateTime
                }).ToListAsync();
        }
        public async Task DeleteCartAsync(int id)
        {
            _context.Carts.Remove(await GetOneCartAsync(id));
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();
        }
        public async Task<Cart> UpdateCartAsync(Cart cart)
        {
            _context.Carts.Update(cart);
            await _context.SaveChangesAsync();
            _context.ChangeTracker.Clear();

            return new Cart()
            {
                Id = cart.Id,
                SellerName = cart.SellerName,
                SellerPhoneNumber = cart.SellerPhoneNumber,
                BuyerName = cart.BuyerName,
                BuyerPhoneNumber = cart.BuyerPhoneNumber,
                ProductName = cart.ProductName,
                Quantity = cart.Quantity,
                Cost = cart.Cost,
                CartDateTime = cart.CartDateTime
            };
        }
    }
}
