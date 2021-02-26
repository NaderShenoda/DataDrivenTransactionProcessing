namespace AdminPortal.Entities
{
    public class DataDefinition : IHaveDescription, IHaveId, IHaveName
    {
        public string Description { get; set; }

        public long Id { get; set; }

        public string Name { get; set; }
    }
}
