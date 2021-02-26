namespace TransactionProcessor.Entities
{
    public partial class ReferenceDataFieldInstance : IHaveId
    {
        public long Id { get; set; }

        public long ReferenceDataInstanceId { get; set; }

        public long ReferenceDataFieldDefinitionId { get; set; }

        public string Value { get; set; }

        public virtual ReferenceDataInstance ReferenceDataInstance { get; set; }

        public virtual ReferenceDataFieldDefinition ReferenceDataFieldDefinition { get; set; }
    }
}
