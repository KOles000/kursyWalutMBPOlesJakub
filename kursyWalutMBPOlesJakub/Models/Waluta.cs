namespace kursyWalutMBPOlesJakub.Models
{
    public class Waluta
    {
        public int Id { get; set; }

        public string Currency { get; set; }

        public string Code { get; set; }

        public string EffectiveDate { get; set; }

        public double Bid { get; set; }

        public double Ask { get; set; }

        public Waluta(string currency, string code, string effectiveDate, double bid, double ask)
        {
            Currency = currency;
            Code = code;
            EffectiveDate = effectiveDate;
            Bid = bid;
            Ask = ask;
        }
    }
}
