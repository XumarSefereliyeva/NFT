using Microsoft.EntityFrameworkCore.Update.Internal;
using NFTSolution.BL.Exceptions;
using NFTSolution.DAL.Contexts;
using NFTSolution.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTSolution.BL.Services
{
   public  class MarketService
    {
        private readonly AppDbContext _context;

        public MarketService()
        {
            _context = new AppDbContext();
        }

        public void Create(Market market)
        {
            _context.markets.Add(market);
            _context.SaveChanges();
        }
        public List<Market> GetAllMarket()
        {
          List<Market> markets = _context.markets.ToList();
            return markets;
        }
        public Market GetMarketById(int id)
        {
            Market? market = _context.markets.Find(id);
            if(market is null)
            {
                throw new MarketException("Tapilmadi");
            }
            return market;
        }
        public void Update(int id,Market market)
        {
            Market? Updatemarket = _context.markets.Find(id);
            if (market is null)
            {
                throw new MarketException("Tapilmadi");
            }
            Updatemarket.Name = market.Name;
            Updatemarket.Count = market.Count;        
            Updatemarket.Category = market.Category;
            Updatemarket.ImgUrl = market.ImgUrl;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            Market? market = _context.markets.Find(id);
            if (market is null)
            {
                throw new MarketException("Tapilmadi");
            }
               _context.markets.Remove(market);
            _context.SaveChanges();
        }
    }
}
