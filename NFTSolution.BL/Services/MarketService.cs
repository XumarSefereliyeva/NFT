using Microsoft.EntityFrameworkCore.Update.Internal;
using NFTSolution.BL.Exceptions;
using NFTSolution.BL.ViewModels;
using NFTSolution.DAL.Contexts;
using NFTSolution.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace NFTSolution.BL.Services
{
   public  class MarketService
    {
        private readonly AppDbContext _context;

        public MarketService(AppDbContext context)
        {
            _context = context;
        }

        public void Create(MarketVM marketVM)
         {
            Market newmarket = new Market();
            newmarket.Name = marketVM.Name;
            newmarket.Count = marketVM.Count;
            newmarket.Category = marketVM.Category;

            // string FileName = Guid.NewGuid().ToString() + marketVM.ImgFile.FileName;

            string FileName = Path.GetFileNameWithoutExtension(marketVM.ImgFile.FileName);
            string extension = Path.GetExtension(marketVM.ImgFile.FileName);
            string resulName = FileName + Guid.NewGuid().ToString() + extension;
            newmarket.ImgUrl = resulName;
            
            string UploadedPath = @"C:\Users\Acer\source\repos\NFTSolution\NFTSolution.MVC\wwwroot\assets\Uploadedimages";
            UploadedPath = Path.Combine(UploadedPath, resulName);
            FileStream stream = new FileStream(UploadedPath,FileMode.Create);    
            marketVM.ImgFile.CopyTo(stream);

            _context.markets.Add(newmarket);
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
        public void Update(int id,UpdateMarketVM marketVM)
        {
            Market? Updatemarket = _context.markets.Find(id);
            if (Updatemarket is null)
            {
                throw new MarketException("Tapilmadi");
            }
            Updatemarket.Name = marketVM.Name;
            Updatemarket.Count = marketVM.Count;        
            Updatemarket.Category = marketVM.Category;

            if(marketVM.ImgFile is not null)
            {
                string FileName = Path.GetFileNameWithoutExtension(marketVM.ImgFile.FileName);
                string extension = Path.GetExtension(marketVM.ImgFile.FileName);
                string FullName = FileName + Guid.NewGuid().ToString() + extension;
                Updatemarket.ImgUrl = FullName;

                string uploadPath = @"C:\\Users\\Acer\\source\\repos\\NFTSolution\\NFTSolution.MVC\\wwwroot\\assets\\Uploadedimages";
                uploadPath = Path.Combine(uploadPath, FullName);
                FileStream stream = new FileStream(uploadPath, FileMode.Create);
                marketVM.ImgFile.CopyTo(stream);
            }
            
          
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
