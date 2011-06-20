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
	public class CinemateAPI
	{
		private readonly string Passkey;
		private const string movie_new_url = "http://cinemate.cc/export/movie/new/";
		private const string movie_search_url = "http://cinemate.cc/export/movie/search/?term={0}";
		private const string account_profile_url = "http://cinemate.cc/export/account/profile/{0}/";
		private const string account_updatelist_url = "http://cinemate.cc/export/account/updatelist/{0}/";
		private const string account_watchlist_url = "http://cinemate.cc/export/account/watchlist/{0}/";
		private const string person_search_url = "http://cinemate.cc/export/person/search/?term={0}";
		private const string stat_url = "http://cinemate.cc/export/stats/new/";

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

		public CinemateAPI()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="passkey">уникальное для каждого пользователя 40-значное 16-ричное число, получить которое можно на странице настроек <see cref="http://cinemate.cc/preferences/"/></param>
		public CinemateAPI(string passkey)
		{
			Passkey = passkey;
		}

		#endregion

		#region Public Methods

		#region Account

		/// <summary>
		/// Метод возвращает данные и статистику пользовательского аккаунта
		/// </summary>
		/// <returns></returns>
		public Profile Account_Profile()
		{
			ValidatePassKey();
			return GetEntity<Profile>(string.Format(account_profile_url, Passkey));
		}

		/// <summary>
		/// Метод возвращает записи ленты обновлений пользователя
		/// </summary>
		/// <returns></returns>
		public List<UpdateItem> Account_Updatelist()
		{
			ValidatePassKey();
			return GetEntity<List<UpdateItem>>(string.Format(account_updatelist_url, Passkey));
		}

		/// <summary>
		/// Метод возвращает список объектов слежения пользователя
		/// </summary>
		/// <returns></returns>
		public IList<WatchlistItem> Account_Watchlist()
		{
			ValidatePassKey();
			return GetEntity<List<WatchlistItem>>(string.Format(account_watchlist_url, Passkey), ReplaceCommentMoviePersonToWatchItem);
		}

		#endregion

		#region Movies

		/// <summary>
		/// Метод возвращает список новых фильмов, добавленных на сайт за последние 24 часа
		/// </summary>
		/// <returns></returns>
		public IEnumerable<CinemateFilm> Movie_New()
		{
			return GetEntity<List<CinemateFilm>>(movie_new_url, ReplaceNameToString);
		}

		/// <summary>
		/// Метод возвращает первые 10 результатов поиска по базе фильмов
		/// </summary>
		/// <param name="title"></param>
		/// <returns></returns>
		public IEnumerable<CinemateFilm> Movie_Search(string title)
		{
			return GetEntity<List<CinemateFilm>>(string.Format(movie_search_url, title), ReplaceNameToString);
		}

		#endregion

		#region Person

		/// <summary>
		/// Метод возвращает первые 10 результатов поиска по базе персон
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public IEnumerable<CinematePerson> Person_Search(string name)
		{
			return GetEntity<List<CinematePerson>>(string.Format(person_search_url, name));
		}

		#endregion

		#region Stat

		/// <summary>
		/// Метод возвращает статистику сайта
		/// </summary>
		/// <returns></returns>
		public Statistic Stats_New()
		{
			return GetEntity<Statistic>(stat_url);
		}

		#endregion

		#endregion

		#region Private Methods

		private void ValidatePassKey()
		{
			if (string.IsNullOrWhiteSpace(Passkey))
			{
				throw new ArgumentException("Вым нужно передать Passkey в конструктор класса API чтобы использовать этот метод");
			}
		}

		private T GetEntity<T>(string url, Worker worker) where T : class
		{
			var xml = string.Empty;
			try
			{
				xml = Encoding.UTF8.GetString(new WebClient().DownloadData(url));
				if(worker != null)
				{
					xml = worker(xml);
				}
			}
			catch (Exception)
			{
				/*DO NOTHING*/
			}
			var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute("response"));
			return serializer.Deserialize(new StringReader(xml)) as T;
		}

		private T GetEntity<T>(string url) where T : class
		{
			return GetEntity<T>(url, null);
		}

		#endregion
	}
}