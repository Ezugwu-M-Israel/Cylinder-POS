using System.ComponentModel.DataAnnotations.Schema;

namespace GasPOS.Models
{
	public class Cynlinder : BaseModel
	{
		public string? Price { get; set; }
		public string? ImageUrl { get; set; }
		public int? CynlinderCategoryId { get; set; }
		[ForeignKey("CynlinderCategoryId")]
		public virtual CynlinderCategory? CynlinderCategory { get; set; }
	}
}
