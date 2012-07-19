using System;
using System.Text;
using CinemateAPI.Properties;

namespace CinemateAPI
{
    internal static class UrlFactory
    {
        private static string ConcatBase(string format, object param1)
        {
            return string.Concat(Settings.Default.BaseUrl, string.Format(format, param1));
        }

        private static string ConcatBase(string format, object param1, object param2)
        {
            return string.Concat(Settings.Default.BaseUrl, string.Format(format, param1, param2));
        }

        public static string GetAuthUrl(string userame, string password)
        {
            return ConcatBase(Settings.Default.AuthUrlPattern, userame, password);
        }

        public static string GetProfileUrl(string passkey)
        {
            return ConcatBase(Settings.Default.ProfileUrlPattern, passkey);
        }

        public static string GetUpdateListUrl(string passkey, bool newOnly = false)
        {
            return ConcatBase(Settings.Default.UpdateListUrlPattern, passkey, newOnly ? 1 : 0);
        }

        public static string GetWatchListUrl(string passkey)
        {
            return ConcatBase(Settings.Default.WatchListUrlPattern, passkey);
        }

        public static string GetMovieListUrl(DateTime fromDate, DateTime toDate, OrderBy orderBy, bool ascOrder, int pageNumber, int itemsPerPage, string genre, string country)
        {
            var sb = new StringBuilder(string.Format("&from={0}&to={1}&order_by={2}&order={3}&page={4}&per_page={5}", fromDate, toDate, OrderByToString(orderBy), ascOrder ? "asc" : "desc", pageNumber, itemsPerPage));
            if (!string.IsNullOrEmpty(genre))
            {
                sb.Append(string.Format("&genre={0}", genre));
            }
            if (!string.IsNullOrEmpty(country))
            {
                sb.Append(string.Format("&country={0}", country));
            }
            return ConcatBase(Settings.Default.MovieListUrlPart, sb);
        }

        public static string GetMovieSearchUrl(string term)
        {
            return ConcatBase(Settings.Default.MovieSearchUrlPattern, term);
        }

        public static string GetMovieInfoUrl(string apiKey, long id)
        {
            return ConcatBase(Settings.Default.MovieGetUrlPattern, apiKey, id);
        }

        public static string GetPersonInfoUrl(string apiKey, long id)
        {
            return ConcatBase(Settings.Default.PersonGetUrlPattern, apiKey, id);
        }

        private static string OrderByToString(OrderBy orderBy)
        {
            switch (orderBy)
            {
                case OrderBy.CreateDate:
                    return "create_date";
                case OrderBy.RuReleaseDate:
                    return "ru_releae_date";
                default:
                    return "release_date";
            }
        }
    }
}