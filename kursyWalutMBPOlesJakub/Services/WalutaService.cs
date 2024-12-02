using kursyWalutMBPOlesJakub.Models;
using System.Text;

namespace kursyWalutMBPOlesJakub.Services
{
    public class WalutaService : IWalutaService
    {
        private WalutaDbContext _dbContext;

        public WalutaService(WalutaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string buildUrlToApi(string url, string date, string code)
        {
            try
            {
                StringBuilder apiUrl = new StringBuilder(url);

                apiUrl.Replace("currencyCode", code);
                apiUrl.Replace("date", date);
                return apiUrl.ToString();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public void DeleteWalutaByCurrencyId(int id)
        {
            Waluta waluta = _dbContext.Set<Waluta>().Find(id);
            if (waluta != null)
            {
                _dbContext.Remove(waluta);
                _dbContext.SaveChanges();
            }
        }

        public Waluta fromJSONtypeToObject(WalutaJSONSerializer serializer)
        {
            return new Waluta(serializer.currency,
                serializer.code, 
                serializer.rates[0].effectiveDate, 
                serializer.rates[0].bid, 
                serializer.rates[0].ask);
        }

        public Waluta GetWalutaByCurrencyCodeAndDate(string currencyCode, string date)
        {
            Waluta waluta;

            try
            {
                waluta = _dbContext.Set<Waluta>().Where(x => x.Code == currencyCode)
                    .Where(y => y.EffectiveDate == date)
                    .FirstOrDefault();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
            return waluta;
        }

        public void SaveWaluta(Waluta waluta)
        {
            var checkForDouble = GetWalutaByCurrencyCodeAndDate(waluta.Code, waluta.EffectiveDate);

            if(checkForDouble == null)
            {
                try
                {
                    _dbContext.Add(waluta);
                    _dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    throw new NotImplementedException();
                }
            }
        }
    }
}
