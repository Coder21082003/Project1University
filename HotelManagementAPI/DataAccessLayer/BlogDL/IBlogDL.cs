using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using System;
using System.Collections.Generic;

namespace DataAccessLayer
{
    public interface IBlogDL : IBaseDL<Blog>
    {
        // Check for duplicate blog titles
        bool CheckDuplicateTitle(Guid id, string title);

        //Get all blog in db
        IEnumerable<Blog> GetAllBlogs();

        // Insert a new blog record
        int Insert(Blog blog);

        // Update an existing blog record
        bool Update(int id, Blog blog);

        // Delete a blog record by ID
        bool Delete(int id);

        // Get a filtered list of blogs based on filter criteria
        IEnumerable<Blog> GetFilteredBlogs(FilterBlog filterBlog);
        bool CheckDuplicateTitle(int blogId, string blogTitle);
    }
}
