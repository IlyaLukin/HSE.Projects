﻿/*flexberryautogenerated="true"*/
namespace IIS.Product_4858
{
    using System;
    using ICSSoft.STORMNET.Web.Controls;

    using Resources;

    public partial class SMC_RoomL : BaseListForm<Room>
    {
        /// <summary>
        /// Конструктор без параметров,
        /// инициализирует свойства, соответствующие конкретной форме.
        /// </summary>
        public SMC_RoomL() : base(Room.Views.SMC_RoomL)
        {
            EditPage = SMC_RoomE.FormPath;
        }
                
        /// <summary>
        /// Путь до формы.
        /// </summary>
        public static string FormPath
        {
            get { return "~/forms/Room/SMC_RoomL.aspx"; }
        }

        /// <summary>
        /// Вызывается самым первым в Page_Load.
        /// </summary>
        protected override void Preload()
        {
        }

        /// <summary>
        /// Вызывается самым последним в Page_Load.
        /// </summary>
        protected override void Postload()
        {
        }
    }
}
