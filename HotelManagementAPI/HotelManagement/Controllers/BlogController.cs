using CommonDataLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusinessLogicLayer;
using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;


namespace HotelManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : BaseController<Blog>
    {
        #region Field

        private IBlogBL _blogBL;

        #endregion

        #region Constructor

        public BlogController(IBlogBL blogBL) : base(blogBL) 
        {
            _blogBL = blogBL;
        }

        #endregion

        #region Method

       
        #endregion
    }
}
