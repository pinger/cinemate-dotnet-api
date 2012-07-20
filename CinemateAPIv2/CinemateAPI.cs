using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using CinemateAPI.Domain;

namespace CinemateAPI
{
    public class CinemateApi
    {
        public bool IsAuthorized
        {
            get { return !string.IsNullOrEmpty(passkey); }
        }

        public string ApiKey
        {
            set { apikey = value; }
        }

        private readonly string passkey;
        private string apikey;

        private static string FixJsonDate(string text)
        {
            return Regex.Replace(text, @"\d{4}-\d{2}-\d{2}(T\d{2}:\d{2}:\d{2})?", ConvertDateStringToJsonDate);
        }

        /// <summary>
        /// Convert Date String as Json Time
        /// </summary>
        private static string ConvertDateStringToJsonDate(Capture m)
        {
            var dt = DateTime.Parse(m.Value);
            dt = dt.ToUniversalTime();
            var ts = dt - DateTime.Parse("1970-01-01");
            var result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
            return result;
        }

        #region Constructors

        public CinemateApi(string username, string password)
        {
            var holder = GetEntityFromJson<PasskeyHolder>(UrlFactory.GetAuthUrl(username, password));
            if(holder != null)
            {
                passkey = holder.Passkey;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="passkey">уникальное для каждого пользователя 40-значное 16-ричное число, получить которое можно на странице настроек <see cref="http://cinemate.cc/preferences/"/></param>
        public CinemateApi(string passkey)
        {
            this.passkey = passkey;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Метод возвращает данные и статистику пользовательского аккаунта
        /// </summary>
        /// <returns></returns>
        public Profile GetProfile()
        {
            ValidatePassKey();
            return GetEntityFromJson<Profile>(UrlFactory.GetProfileUrl(passkey));
        }

        /// <summary>
        /// Метод возвращает записи ленты обновлений пользователя
        /// </summary>
        /// <returns></returns>
        public Update GetUpdatelist()
        {
            ValidatePassKey();
            return GetEntityFromJson<Update>(UrlFactory.GetUpdateListUrl(passkey));
        }

         ///<summary>
         /// Метод возвращает список объектов слежения пользователя
         ///</summary>
         ///<returns></returns>
        public Watch GetWatchlist()
        {
            ValidatePassKey();
            return GetEntityFromJson<Watch>(UrlFactory.GetWatchListUrl(passkey));
        }

        public MovieListResult GetMovieList(DateTime fromDate, DateTime toDate, int page, int itemsOnPage, string genre, string country, OrderBy orderBy, bool ascOrder)
        {
            return GetEntityFromJson<MovieListResult>(UrlFactory.GetMovieListUrl(fromDate, toDate, orderBy, ascOrder, page, itemsOnPage, genre, country));
        }

        public MovieListResult SearchMovie(string term)
        {
            return GetEntityFromJson<MovieListResult>(UrlFactory.GetMovieSearchUrl(term));
        }

        public MovieInfoResult GetMovieInfo(long id)
        {
            return GetEntityFromJson<MovieInfoResult>(UrlFactory.GetMovieInfoUrl(apikey, id));
        }

        public PersonSearchResult SearchPerson(string term)
        {
            return GetEntityFromJson<PersonSearchResult>(UrlFactory.GetPersonSearchUrl(term));
        }

        public PersonInfoResult GetPersonInfo(long id)
        {
            return GetEntityFromJson<PersonInfoResult>(UrlFactory.GetPersonInfoUrl(apikey, id));
        }

        public Stats GetStats()
        {
            return GetEntityFromJson<Stats>(UrlFactory.GetStatUrl());
        }

        #endregion

        #region Private Methods

        private void ValidatePassKey()
        {
            if (string.IsNullOrWhiteSpace(passkey))
            {
                throw new ArgumentException("Вым нужно передать Passkey в конструктор класса API, чтобы использовать этот метод");
            }
        }

        private static T GetEntityFromJson<T>(string url) where T : class
        {
            try
            {
                var responseString = Encoding.UTF8.GetString(new WebClient().DownloadData(url));
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(FixJsonDate(responseString))))
                {
                    var ser = new DataContractJsonSerializer(typeof(T));
                    return (T)ser.ReadObject(ms);
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}