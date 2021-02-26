namespace AdminPortal.Entities
{
    public class DataFieldDefinition : IHaveDescription, IHaveId, IHaveName
    {
        public string Description { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsArray { get; set; }

        public long DataDefiniitionId { get; set; }
    }
}
