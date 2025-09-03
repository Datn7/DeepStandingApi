namespace DeepStandingApi.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;        // soft delete
        public DateTime CreatedAt { get; set; }             // audit
        public DateTime? UpdatedAt { get; set; }            // audit
        public string? CreatedBy { get; set; }              // optional (fill later if you add auth)
        public string? UpdatedBy { get; set; }
    }
}
