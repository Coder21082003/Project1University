using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.ReviewDL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.ReviewBL
{
    public class ReviewBL : BaseBL<Review>, IReviewBL
    {
        #region Field

        private readonly IReviewDL _reviewDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public ReviewBL(IReviewDL reviewDL) : base(reviewDL)
        {
            _reviewDL = reviewDL;
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for Review here
        // For example:
        // public void SomeReviewMethod() { ... }

        #endregion
    }
}
