﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IIS.Product_4858
{
    using System;
    using System.Xml;
    using ICSSoft.STORMNET;
    
    
    // *** Start programmer edit section *** (Using statements)

    // *** End programmer edit section *** (Using statements)


    /// <summary>
    /// Building.
    /// </summary>
    // *** Start programmer edit section *** (Building CustomAttributes)

    // *** End programmer edit section *** (Building CustomAttributes)
    [PublishName("Здание")]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    [View("SMC_BuildingE", new string[] {
            "Type as \'Тип постройки\'",
            "BuiltYear as \'Год постройки\'",
            "Address as \'Адрес\'",
            "Address.City as \'Город\'"})]
    [View("SMC_BuildingL", new string[] {
            "Type as \'Тип постройки\'",
            "BuiltYear as \'Год постройки\'",
            "Address.City as \'Город\'"})]
    public class Building : ICSSoft.STORMNET.DataObject
    {
        
        private IIS.Product_4858.TypeBuilding fType;
        
        private int fBuiltYear;
        
        private IIS.Product_4858.Address fAddress;
        
        // *** Start programmer edit section *** (Building CustomMembers)

        // *** End programmer edit section *** (Building CustomMembers)

        
        /// <summary>
        /// Type.
        /// </summary>
        // *** Start programmer edit section *** (Building.Type CustomAttributes)

        // *** End programmer edit section *** (Building.Type CustomAttributes)
        [PublishName("Тип постройки")]
        public virtual IIS.Product_4858.TypeBuilding Type
        {
            get
            {
                // *** Start programmer edit section *** (Building.Type Get start)

                // *** End programmer edit section *** (Building.Type Get start)
                IIS.Product_4858.TypeBuilding result = this.fType;
                // *** Start programmer edit section *** (Building.Type Get end)

                // *** End programmer edit section *** (Building.Type Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Building.Type Set start)

                // *** End programmer edit section *** (Building.Type Set start)
                this.fType = value;
                // *** Start programmer edit section *** (Building.Type Set end)

                // *** End programmer edit section *** (Building.Type Set end)
            }
        }
        
        /// <summary>
        /// BuiltYear.
        /// </summary>
        // *** Start programmer edit section *** (Building.BuiltYear CustomAttributes)

        // *** End programmer edit section *** (Building.BuiltYear CustomAttributes)
        [PublishName("Год постройки")]
        public virtual int BuiltYear
        {
            get
            {
                // *** Start programmer edit section *** (Building.BuiltYear Get start)

                // *** End programmer edit section *** (Building.BuiltYear Get start)
                int result = this.fBuiltYear;
                // *** Start programmer edit section *** (Building.BuiltYear Get end)

                // *** End programmer edit section *** (Building.BuiltYear Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Building.BuiltYear Set start)

                // *** End programmer edit section *** (Building.BuiltYear Set start)
                this.fBuiltYear = value;
                // *** Start programmer edit section *** (Building.BuiltYear Set end)

                // *** End programmer edit section *** (Building.BuiltYear Set end)
            }
        }
        
        /// <summary>
        /// Building.
        /// </summary>
        // *** Start programmer edit section *** (Building.Address CustomAttributes)

        // *** End programmer edit section *** (Building.Address CustomAttributes)
        [PropertyStorage(new string[] {
                "Address"})]
        [NotNull()]
        public virtual IIS.Product_4858.Address Address
        {
            get
            {
                // *** Start programmer edit section *** (Building.Address Get start)

                // *** End programmer edit section *** (Building.Address Get start)
                IIS.Product_4858.Address result = this.fAddress;
                // *** Start programmer edit section *** (Building.Address Get end)

                // *** End programmer edit section *** (Building.Address Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Building.Address Set start)

                // *** End programmer edit section *** (Building.Address Set start)
                this.fAddress = value;
                // *** Start programmer edit section *** (Building.Address Set end)

                // *** End programmer edit section *** (Building.Address Set end)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// "SMC_BuildingE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View SMC_BuildingE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("SMC_BuildingE", typeof(IIS.Product_4858.Building));
                }
            }
            
            /// <summary>
            /// "SMC_BuildingL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View SMC_BuildingL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("SMC_BuildingL", typeof(IIS.Product_4858.Building));
                }
            }
        }
    }
}
