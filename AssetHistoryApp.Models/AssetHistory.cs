using Dul.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetHistoryApp.Models
{
    [Table("AssetsHistories")]
    public class AssetHistory : AuditableBase
    {
        /// <summary>
        /// 일련번호
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 제목
        /// </summary>
        //[Required]
        [MaxLength(255)]
        [Required(ErrorMessage = "제목을 입력하세요.")]
        public string Title { get; set; }

        /// <summary>
        /// 내용
        /// </summary>
        [Required(ErrorMessage = "내용을 입력하세요.")]
        public string Content { get; set; }
    }
}
