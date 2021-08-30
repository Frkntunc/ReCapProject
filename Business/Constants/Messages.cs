using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";
        public static string BrandLimit = "Bu markada sadece 10 adet araba olabilir";
        public static string BrandLimitExceded = "En fazla 12 adet Marka Olabilir.";
        public static string CarImageOutOfLimit = "Bir arabanın En fazla 5 resmi olabilir";
        public static string CarImageNotFound = "Böyle bir resim bulunamadı";
        public static string CarImageDeleted = "Resim silindi";
        public static string CarImageUpdated = "Resim güncellendi";
        public static string UserRegistered = "Kayıt olundu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Böyle bir kullanıcı zaten var";
        public static string AccessTokenCreated = "Access Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
