using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarListed = "Arabalar Listelendi";

        public static string BrandAdded = "Kategori eklendi";
        public static string BrandNameInvalid = "Kategori ismi geçersiz";
        public static string BrandListed = "Kategoriler Listelendi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorListed = "Renkler Listelendi";

        public static string UserAdded = "User eklendi";
        public static string UserNameInvalid = "User ismi geçersiz";
        public static string UserListed = "Userlar Listelendi";

        public static string CustomerAdded = "Customer eklendi";
        public static string CustomerNameInvalid = "Customer ismi geçersiz";
        public static string CustomerListed = "Customerlar Listelendi";

        public static string RentalAdded = "Araba Kiralama işlemi baraşıyla gerçekleşti.";
        public static string RentalDeleted = "Araba Kiralama işlemi iptal edildi.";
        public static string RentalUpdated = "Araba Kiralama işlemi güncellendi.";
        public static string FailedRentalAddOrUpdate = "Bu araba henüz teslim edilmediği için kiralayamazsınız.";
        public static string ReturnedRental = "Kiraladığınız araç teslim edildi.";

        public static string MaintenanceTime = "Site Bakımda";

        public static string FailAddedImageLimit = "Fotoğraf Sınırı Aşıldı";

        public static string CategoryLimitExceded = "Kategori limiti aşıma uğradığından yeni ürün eklenemedi";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string PasswordError = "Şifre Hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string AccessTokenCreated = "Giriş Yapıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string BrandDeleted = "Kategori Silindi";
    }
}
