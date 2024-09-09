using BusinessLogicLayer.Exceptions;
using CommonDataLayer.DTO;
using CommonDataLayer.Entities;
using DataAccessLayer;
using DataAccessLayer.RoomDL;
using System;
using System.Collections.Generic;

namespace BusinessLogicLayer.RoomBL
{
    public class RoomBL : BaseBL<Room>, IRoomBL
    {
        #region Field

        private readonly IRoomDL _roomDL;
        private readonly List<string> _errors = new List<string>();

        #endregion

        #region Constructor

        public RoomBL(IRoomDL roomDL) : base(roomDL)
        {
            _roomDL = roomDL;
        }

        #endregion

        #region Methods

        // Implement specific business logic methods for Room here
        // For example:
        // public void SomeRoomMethod() { ... }

        #endregion
    }
}
