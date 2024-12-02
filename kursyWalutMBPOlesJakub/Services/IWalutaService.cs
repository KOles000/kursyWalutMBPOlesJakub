using kursyWalutMBPOlesJakub.Models;

namespace kursyWalutMBPOlesJakub.Services
{
    public interface IWalutaService
    {
        /// <summary>
        /// add and update Waluta object to db
        /// </summary>
        /// <param name="waluta"></param>
        void SaveWaluta(Waluta waluta);

        /// <summary>
        /// removes Waluta object from db by Id
        /// </summary>
        /// <param name="currencyCode"></param>
        void DeleteWalutaByCurrencyId(int id);

        /// <summary>
        /// parse json mapped class to db Waluta object
        /// </summary>
        /// <param name="serializer"></param>
        /// <returns></returns>
        Waluta fromJSONtypeToObject(WalutaJSONSerializer serializer);

        /// <summary>
        /// creates url to nbp api using attributes
        /// </summary>
        /// <param name="url"></param>
        /// <param name="date"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        string buildUrlToApi(string url, string date, string code);

        /// <summary>
        /// returns waluta object by currCode and date
        /// </summary>
        /// <param name="currencyCode"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        Waluta GetWalutaByCurrencyCodeAndDate(string currencyCode, string date);
    }
}
