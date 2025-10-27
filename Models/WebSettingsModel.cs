using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiTapQuayVideo.Models
{

    [Table("WebSettings")]
    public class WebSettings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SettingId { get; set; }

        [Required(ErrorMessage = "Logo is required")]
        [StringLength(255)]
        public string Logo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Max image size is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Max image size must be greater than 0")]
        public int MaxSizeImage { get; set; }

        [StringLength(255)]
        public string? SettingDescription { get; set; }

        [Required(ErrorMessage = "Setting URL is required")]
        [StringLength(255)]
        public string SettingURL { get; set; } = string.Empty;

        [Required(ErrorMessage = "Header is required")]
        [StringLength(255)]
        public string Header { get; set; } = string.Empty;

        [Required(ErrorMessage = "Footer is required")]
        [StringLength(255)]
        public string Footer { get; set; } = string.Empty;
    }
}
