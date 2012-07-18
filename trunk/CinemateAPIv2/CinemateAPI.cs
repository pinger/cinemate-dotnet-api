using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml.Serialization;
using CinemateAPI.Account;
using CinemateAPI.Movie;
using CinemateAPI.Person;
using CinemateAPI.Stat;

namespace CinemateAPI
{
    public class CinemateApi
    {
        public bool IsAuthorized
        {
            get { return !string.IsNullOrEmpty(passkey); }
        }

        private readonly string passkey;

        private delegate string Worker(string xml);

        private string ReplaceNameToString(string xml)
        {
            return xml.Replace("<name>", "<string>").Replace("</name>", "</string>");
        }

        private string ReplaceCommentMoviePersonToWatchItem(string xml)
        {
            return xml
                .Replace("<comment>", "<WatchlistItem><type>Comment</type>").Replace("</comment>", "</WatchlistItem>")
                .Replace("<person>", "<WatchlistItem><type>Person</type>").Replace("</person>", "</WatchlistItem>")
                .Replace("<movie>", "<WatchlistItem><type>Movie</type>").Replace("</movie>", "</WatchlistItem>");
        }

        #region Constructors

        public CinemateApi(string username, string password)
        {
            var holder = GetEntity<PasskeyHolder>(UrlFactory.GetAuthUrl(username, password));
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
            return GetEntity<Profile>(UrlFactory.GetProfileUrl(passkey));
        }

        /// <summary>
        /// Метод возвращает записи ленты обновлений пользователя
        /// </summary>
        /// <returns></returns>
        public List<UpdateItem> GetUpdatelist()
        {
            ValidatePassKey();
            return GetEntity<List<UpdateItem>>(UrlFactory.GetUpdateListUrl(passkey));
        }

        /// <summary>
        /// Метод возвращает список объектов слежения пользователя
        /// </summary>
        /// <returns></returns>
        public IList<WatchlistItem> GetWatchlist()
        {
            ValidatePassKey();
            return GetEntity<List<WatchlistItem>>(UrlFactory.GetWatchListUrl(passkey), ReplaceCommentMoviePersonToWatchItem);
        }

        public IList<CinemateFilm> GetMovieList(DateTime fromDate, DateTime toDate, int page, int itemsOnPage, string genre, string country, OrderBy orderBy, bool ascOrder)
        {
            return GetEntity<List<CinemateFilm>>(UrlFactory.GetMovieListUrl(fromDate, toDate, orderBy, ascOrder, page, itemsOnPage, genre, country));
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

        private static string GetString(string url)
        {
            string str = null;
            try
            {
                str = Encoding.UTF8.GetString(new WebClient().DownloadData(url));
            }
            catch (Exception)
            {
                /*DO NOTHING*/
            }
            return str;
        }

        private static T GetEntity<T>(string url, Worker worker) where T : class
        {
            try
            {
                var xml = GetString(url);
                if (worker != null)
                {
                    xml = worker(xml);
                }
                if(!string.IsNullOrEmpty(xml))
                {
                    var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("response"));
                    return serializer.Deserialize(new StringReader(xml)) as T;
                }
            }
            catch (Exception ex)
            {
                /*DO NOTHING*/
            }
            return null;
        }

        private static T GetEntity<T>(string url) where T : class
        {
            return GetEntity<T>(url, null);
        }

        #endregion
    }
}