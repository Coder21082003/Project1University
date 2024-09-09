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
                if (string.IsNullOrEmpty(record.blog_title))
                {
                    _errors.Add("Blog title is required.");
                }
                if (string.IsNullOrEmpty(record.blog_author))
                {
                    _errors.Add("Blog author is required.");
                }
                if (record.blog_time == null)
                {
                    _errors.Add("Blog time is required.");
                }

            }

            if (_errors.Count > 0)
            {
                throw new ValidateException(_errors);
            }
        }

        #endregion
    }
}
