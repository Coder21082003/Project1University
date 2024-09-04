using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using CommonDataLayer.Enum;
using DataAccessLayer;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer
{
    public class BlogBL : BaseBL<Blog>, IBlogBL
    {
        #region Field

        private readonly IBlogDL _blogDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public BlogBL(IBlogDL blogDL) : base(blogDL)
        {
            _blogDL = blogDL;
        }

        #endregion

        #region Methods

        // Override Validate method to include validation logic for Blog
        protected override void Validate(Blog record, Method method)
        {
            _errors.Clear(); // Ensure errors list is cleared before validation

            if (method == Method.Insert || method == Method.Update)
            {
                if (string.IsNullOrEmpty(record.BlogTitle))
                {
                    _errors.Add("Blog title is required.");
                }
                if (string.IsNullOrEmpty(record.BlogAuthor))
                {
                    _errors.Add("Blog author is required.");
                }
                if (record.BlogTime == null)
                {
                    _errors.Add("Blog time is required.");
                }

                if (method == Method.Insert && _blogDL.CheckDuplicateTitle(record.BlogId, record.BlogTitle))
                {
                    _errors.Add("A blog with this title already exists.");
                }
            }

            if (_errors.Count > 0)
            {
                throw new ValidateException(_errors);
            }
        }

        // Implementation of Insert method
        public IEnumerable<Blog> GetAllBlogs()
        {
            return _blogDL.GetAllBlogs();
        }

        // Implementation of Insert method
        public int InsertBlog(Blog blog)
        {
            Validate(blog, Method.Insert);
            return _blogDL.Insert(blog);
        }

        // Implementation of Update method
        public bool UpdateBlog(int id, Blog blog)
        {
            Validate(blog, Method.Update);
            return _blogDL.Update(id, blog);
        }

        // Implementation of Delete method
        public bool DeleteBlog(int id)
        {
            return _blogDL.Delete(id);
        }

        // Implementation of Filter method
        public IEnumerable<Blog> GetFilteredBlogs(FilterBlog filterBlog)
        {
            return _blogDL.GetFilteredBlogs(filterBlog);
        }

        #endregion
    }
}
