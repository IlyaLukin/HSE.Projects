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
    /// Man.
    /// </summary>
    // *** Start programmer edit section *** (Man CustomAttributes)

    // *** End programmer edit section *** (Man CustomAttributes)
    [PublishName("Человек")]
    [AutoAltered()]
    [AccessType(ICSSoft.STORMNET.AccessType.none)]
    [View("SMC_ManE", new string[] {
            "Name as \'Имя\'",
            "SecondName as \'Фамилия\'",
            "FatherName as \'Отчество\'",
            "PhoneNumber as \'Номер телефона\'",
            "Email as \'Электронная почта\'",
            "Address as \'Адрес\'",
            "Address.City as \'Город\'"})]
    [View("SMC_ManL", new string[] {
            "Name as \'Имя\'",
            "SecondName as \'Фамилия\'",
            "FatherName as \'Отчество\'",
            "PhoneNumber as \'Номер телефона\'",
            "Email as \'Электронная почта\'",
            "Address.City as \'Город\'"})]
    public class Man : ICSSoft.STORMNET.DataObject
    {
        
        private string fName;
        
        private string fSecondName;
        
        private string fFatherName;
        
        private string fPhoneNumber;
        
        private string fEmail;
        
        private IIS.Product_4858.Address fAddress;
        
        // *** Start programmer edit section *** (Man CustomMembers)

        // *** End programmer edit section *** (Man CustomMembers)

        
        /// <summary>
        /// Name.
        /// </summary>
        // *** Start programmer edit section *** (Man.Name CustomAttributes)

        // *** End programmer edit section *** (Man.Name CustomAttributes)
        [StrLen(255)]
        [PublishName("Имя")]
        public virtual string Name
        {
            get
            {
                // *** Start programmer edit section *** (Man.Name Get start)

                // *** End programmer edit section *** (Man.Name Get start)
                string result = this.fName;
                // *** Start programmer edit section *** (Man.Name Get end)

                // *** End programmer edit section *** (Man.Name Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Man.Name Set start)

                // *** End programmer edit section *** (Man.Name Set start)
                this.fName = value;
                // *** Start programmer edit section *** (Man.Name Set end)

                // *** End programmer edit section *** (Man.Name Set end)
            }
        }
        
        /// <summary>
        /// SecondName.
        /// </summary>
        // *** Start programmer edit section *** (Man.SecondName CustomAttributes)

        // *** End programmer edit section *** (Man.SecondName CustomAttributes)
        [StrLen(255)]
        [PublishName("Фамилия")]
        public virtual string SecondName
        {
            get
            {
                // *** Start programmer edit section *** (Man.SecondName Get start)

                // *** End programmer edit section *** (Man.SecondName Get start)
                string result = this.fSecondName;
                // *** Start programmer edit section *** (Man.SecondName Get end)

                // *** End programmer edit section *** (Man.SecondName Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Man.SecondName Set start)

                // *** End programmer edit section *** (Man.SecondName Set start)
                this.fSecondName = value;
                // *** Start programmer edit section *** (Man.SecondName Set end)

                // *** End programmer edit section *** (Man.SecondName Set end)
            }
        }
        
        /// <summary>
        /// FatherName.
        /// </summary>
        // *** Start programmer edit section *** (Man.FatherName CustomAttributes)

        // *** End programmer edit section *** (Man.FatherName CustomAttributes)
        [StrLen(255)]
        [PublishName("Отчество")]
        public virtual string FatherName
        {
            get
            {
                // *** Start programmer edit section *** (Man.FatherName Get start)

                // *** End programmer edit section *** (Man.FatherName Get start)
                string result = this.fFatherName;
                // *** Start programmer edit section *** (Man.FatherName Get end)

                // *** End programmer edit section *** (Man.FatherName Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Man.FatherName Set start)

                // *** End programmer edit section *** (Man.FatherName Set start)
                this.fFatherName = value;
                // *** Start programmer edit section *** (Man.FatherName Set end)

                // *** End programmer edit section *** (Man.FatherName Set end)
            }
        }
        
        /// <summary>
        /// PhoneNumber.
        /// </summary>
        // *** Start programmer edit section *** (Man.PhoneNumber CustomAttributes)

        // *** End programmer edit section *** (Man.PhoneNumber CustomAttributes)
        [StrLen(255)]
        [PublishName("Номер телефона")]
        public virtual string PhoneNumber
        {
            get
            {
                // *** Start programmer edit section *** (Man.PhoneNumber Get start)

                // *** End programmer edit section *** (Man.PhoneNumber Get start)
                string result = this.fPhoneNumber;
                // *** Start programmer edit section *** (Man.PhoneNumber Get end)

                // *** End programmer edit section *** (Man.PhoneNumber Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Man.PhoneNumber Set start)

                // *** End programmer edit section *** (Man.PhoneNumber Set start)
                this.fPhoneNumber = value;
                // *** Start programmer edit section *** (Man.PhoneNumber Set end)

                // *** End programmer edit section *** (Man.PhoneNumber Set end)
            }
        }
        
        /// <summary>
        /// Email.
        /// </summary>
        // *** Start programmer edit section *** (Man.Email CustomAttributes)

        // *** End programmer edit section *** (Man.Email CustomAttributes)
        [StrLen(255)]
        [PublishName("Электронная почта")]
        public virtual string Email
        {
            get
            {
                // *** Start programmer edit section *** (Man.Email Get start)

                // *** End programmer edit section *** (Man.Email Get start)
                string result = this.fEmail;
                // *** Start programmer edit section *** (Man.Email Get end)

                // *** End programmer edit section *** (Man.Email Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Man.Email Set start)

                // *** End programmer edit section *** (Man.Email Set start)
                this.fEmail = value;
                // *** Start programmer edit section *** (Man.Email Set end)

                // *** End programmer edit section *** (Man.Email Set end)
            }
        }
        
        /// <summary>
        /// Man.
        /// </summary>
        // *** Start programmer edit section *** (Man.Address CustomAttributes)

        // *** End programmer edit section *** (Man.Address CustomAttributes)
        [PropertyStorage(new string[] {
                "Address"})]
        [NotNull()]
        public virtual IIS.Product_4858.Address Address
        {
            get
            {
                // *** Start programmer edit section *** (Man.Address Get start)

                // *** End programmer edit section *** (Man.Address Get start)
                IIS.Product_4858.Address result = this.fAddress;
                // *** Start programmer edit section *** (Man.Address Get end)

                // *** End programmer edit section *** (Man.Address Get end)
                return result;
            }
            set
            {
                // *** Start programmer edit section *** (Man.Address Set start)

                // *** End programmer edit section *** (Man.Address Set start)
                this.fAddress = value;
                // *** Start programmer edit section *** (Man.Address Set end)

                // *** End programmer edit section *** (Man.Address Set end)
            }
        }
        
        /// <summary>
        /// Class views container.
        /// </summary>
        public class Views
        {
            
            /// <summary>
            /// "SMC_ManE" view.
            /// </summary>
            public static ICSSoft.STORMNET.View SMC_ManE
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("SMC_ManE", typeof(IIS.Product_4858.Man));
                }
            }
            
            /// <summary>
            /// "SMC_ManL" view.
            /// </summary>
            public static ICSSoft.STORMNET.View SMC_ManL
            {
                get
                {
                    return ICSSoft.STORMNET.Information.GetView("SMC_ManL", typeof(IIS.Product_4858.Man));
                }
            }
        }
    }
}
