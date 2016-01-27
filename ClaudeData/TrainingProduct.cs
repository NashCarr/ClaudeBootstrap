using System;
using System.ComponentModel.DataAnnotations;

namespace ClaudeData
{
    public class TrainingProduct
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "GiftCard must be filled in.")]
        [Display(Description = "GiftCard")]
        [StringLength(150, MinimumLength = 4,
            ErrorMessage = "GiftCard must be greater than {2} characters and less than {1} characters.")]
        public string Name { get; set; }

        [Range(typeof (DateTime), "1/1/2000", "12/31/2020",
            ErrorMessage = "Introduction Date must be between {1} and {2}")]
        public DateTime IntroductionDate { get; set; }

        [Required(ErrorMessage = "URL must be filled in.")]
        [Display(Description = "Product URL")]
        [Url]
        [StringLength(2000, MinimumLength = 5,
            ErrorMessage = "URL must be greater than {2} characters and less than {1} characters.")]
        public string Url { get; set; }

        [Range(1, 9999, ErrorMessage = "{0} must be between {1} and {2}")]
        public decimal Price { get; set; }
    }
}