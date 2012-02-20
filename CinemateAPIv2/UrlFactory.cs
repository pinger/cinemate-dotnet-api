using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CinemateAPI
{
	class UrlFactory
	{
		private const string baseUrl = "http://cinemate.cc/api/2.0/";
		private const string auth = "account/auth/?username={0}&password={1}";
		private const string profile = "account/profile/?passkey={0}";
		private const string updatelist = "account/updatelist/?passkey={0}&newonly={1}";
		private const string watchlist = "account/watchlist/?passkey={0}";
		private const string movieList = "movie/list/";
		private const string movieSearch = "";
		private const string movieGet = "movie/get/?apikey={0}&id={1}";
		private const string personGet = "person/get/?apikey={0}&id={1}";

		public string Auth(string userame, string password)
		{
			return string.Concat(baseUrl, string.Format(auth, userame, password));
		}

		public string Profile(string passkey)
		{
			return string.Concat(baseUrl, string.Format(profile, passkey));
		}

		public string UpdateList(string passkey, bool newOnly = false)
		{
			return string.Concat(baseUrl, string.Format(updatelist, passkey, newOnly ? 1 : 0));
		}

		public string WatchList(string passkey)
		{
			return string.Concat(baseUrl, string.Format(watchlist, passkey));
		}

		public string MovieList(DateTime from, DateTime to, OrderBy orderBy, bool order, int page, int perPage, string genre, string country)
		{
			var sb = new StringBuilder(string.Format("?from={0}&to={1}&order_by={2}&order={3}&page={4}&per_page={5}", from, to, OrderByToString(orderBy), order, page, perPage));
			if(!string.IsNullOrEmpty(genre))
			{
				sb.Append(string.Format("&genre={0}", genre));
			}
			if(!string.IsNullOrEmpty(country))
			{
				sb.Append(string.Format("&country={0}", country));
			}
			return string.Concat(baseUrl, movieList, sb.ToString());
		}

		public string MovieGet(string apiKey, long id)
		{
			return string.Concat(baseUrl, string.Format(movieGet, apiKey, id));
		}

		public string PersonGet(string apiKey, long id)
		{
			return string.Concat(baseUrl, string.Format(personGet, apiKey, id));
		}

		private string OrderByToString(OrderBy orderBy)
		{
			switch (orderBy)
			{
				case OrderBy.CreateDate:
					return "create_date";
				case OrderBy.ReReleaseDate:
					return "ru_releae_date";
				default:
					return "release_date";
			}
		}
	}

	public enum OrderBy
	{
		CreateDate = 2,
		ReleaseDate = 3,
		ReReleaseDate = 4
	}
}
