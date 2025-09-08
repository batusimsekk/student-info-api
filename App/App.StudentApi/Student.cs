using System.ComponentModel.DataAnnotations;

namespace App.StudentApi
{
    public class Student
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad boş olamaz")]
        [StringLength(20,MinimumLength = 4,ErrorMessage = "Ad en az 4 karakter olmalı!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad boş olamaz")]
        [StringLength(20,MinimumLength = 4, ErrorMessage = "Soyad en az 4 karakter olmalı!")]
        public string Surname { get; set; }
        [Range(1,12,ErrorMessage = "Sınıf 1 ile 12 arasında olmalı!")]
        public int Class { get; set; }
        [Range(1,1000,ErrorMessage = "Numara 1 ile 1000 arasında olmalı!")]
        public int Number { get; set; }

    }
}
