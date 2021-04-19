namespace SharedKernel
{
    public abstract class IdentifiedEntity
    {
        public int Id { get; set; }

        public bool AreSame(IdentifiedEntity target) => Id == target.Id;
    }
}
