using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    //newlememek için static kullanıldı
    //messajları buradan vericem
    public static class Messages
    {
        public static string RequestAdded = "Talep eklendi";
        public static string ReasonRequestInvalid = "talep metni geçersiz";
        public static string MaintenanceTime="Sistem bakımda";
        public static string RequestsListed="Talepler listelendi";
        public static string RequestCountOfCategoryError=" bu kategoriden en fazla 10 talep eklenebilir";
        public static string ReasonRequestAlreadyExists="bu talep nedeni zaten kullanılmıştır";
        public static string AuthorizationDenied="Yetkiniz yok.";
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        public static string UserAlreadyExists="kullanıcı mevcut";
        internal static string AccessTokenCreated;
    }
}
