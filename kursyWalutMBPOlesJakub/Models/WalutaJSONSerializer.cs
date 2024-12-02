namespace kursyWalutMBPOlesJakub.Models
{
    public class WalutaJSONSerializer
    {
        public string table { get; set; }
        public string currency { get; set; }
        public string code { get; set; }
        public Rate[] rates { get; set; }
    }

    public class Rate
    {
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public float bid { get; set; }
        public float ask { get; set; }
    }

}
