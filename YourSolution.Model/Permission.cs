namespace YourSolution.Model
{
    public class Permission : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Module { get; set; }
    }
} 