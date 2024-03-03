﻿using DataTier.Models;
using DataTier.Repository.Interface;
using DataTier.View.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Repository.Implement
{
    public class ProductRepository : IProductRepository
    {
        private readonly projectSWDContext _context;

        public ProductRepository(projectSWDContext context)
        {
            _context = context;
        }

        public List<UserProductViewModel> GetAllProductUser(int id)
        {
            var artworks = _context.Artworks.Where(e => e.Owner == id).ToList();
            var users = _context.Users.ToDictionary(u => u.IdUser);

            var userProductViewModels = artworks.Select(artwork =>
            {
                if (!users.TryGetValue(artwork.Owner ?? 0, out var user))
                    return null;

                return new UserProductViewModel
                {
                    IdArtwork = artwork.IdArtwork,
                    Name = artwork.Name,
                    IdUser = artwork.Owner ?? 0,
                    Username = user.Username,
                    CategoryName = artwork.CategoryName,
                    Status = artwork.Status,
                    Price = artwork.Price,
                    Address = user.Address,
                };
            }).Where(viewModel => viewModel != null).ToList();

            return userProductViewModels;
        }

        public List<HotProductViewModel> GetHotProduct()
        {
            var maxLikes = _context.Likes
                .GroupBy(l => l.ArtworkId)
                .Select(g => new { ArtworkId = g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault()?.Count;

            if (maxLikes == null)
                return new List<HotProductViewModel>(); // Trả về danh sách rỗng nếu không có sản phẩm nào

            // Lấy ra tất cả sản phẩm có số lượt like bằng maxLikes
            var mostLikedArtworks = _context.Artworks
                .Where(a => a.Likes.Count == maxLikes)
                .Select(a => new HotProductViewModel
                {
                    Name = a.Name,
                    Price = a.Price
                })
                .ToList();

            return mostLikedArtworks;
        }

        public List<ImageViewModel> GetImageURL(int artworkid)
        {
            var imageUrls = _context.ImageLists
                .Where(image => image.ArtworkId == artworkid)
                .Select(image => new ImageViewModel { ImageUrl = image.ImageUrl })
                .ToList();

            return imageUrls;
        }
    }
}
