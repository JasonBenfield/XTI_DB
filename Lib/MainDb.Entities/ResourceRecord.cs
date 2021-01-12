namespace MainDB.Entities
{
    public sealed class ResourceRecord
    {
        public int ID { get; set; }
        public int GroupID { get; set; }
        public string Name { get; set; } = "xti_notfound";
        public bool IsAnonymousAllowed { get; set; }
    }
}
