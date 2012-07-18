using System;
using System.Text;
using CinemateAPI.Properties;

namespace CinemateAPI
{
    internal static class UrlFactory
    {
        private static string ConcatBase(string urlEnding)
        {
            return string.Concat(Settings.Default.BaseUrl, urlEnding);
        }

        public static string GetAuthUrl(string userame, string password)
        {
            return ConcatBase(string.Format(Settings.Default.AuthUrlPattern, userame, password));
        }

        public static string GetProfileUrl(string passkey)
        {
            return ConcatBase(string.Format(Settings.Default.ProfileUrlPattern, passkey));
        }

        public static string GetUpdateListUrl(string passkey, bool newOnly = false)
        {
            return ConcatBase(string.Format(Settings.Default.UpdateListUrlPattern, passkey, newOnly ? 1 : 0));
        }

        public static string GetWatchListUrl(string passkey)
        {
            return ConcatBase(string.Format(Settings.Default.WatchListUrlPattern, passkey));
        }

        public static string GetMovieListUrl(DateTime fromDate, DateTime toDate, OrderBy orderBy, bool ascOrder, int pageNumber, int itemsPerPage, string genre, string country)
        {
            var sb = new StringBuilder(string.Format("?from={0}&to={1}&order_by={2}&order={3}&page={4}&per_page={5}", fromDate, toDate, OrderByToString(orderBy), ascOrder ? "asc" : "desc", pageNumber, itemsPerPage));
            if (!string.IsNullOrEmpty(genre))
            {
                sb.Append(string.Format("&genre={0}", genre));
            }
            if (!string.IsNullOrEmpty(country))
            {
                sb.Append(string.Format("&country={0}", country));
            }
            return ConcatBase(string.Concat(Settings.Default.MovieListUrlPart, sb.ToString()));
        }

        public static string GetMovieInfoUrl(string apiKey, long id)
        {
            return ConcatBase(string.Format(Settings.Default.MovieGetUrlPattern, apiKey, id));
        }

        public static string GetPersonInfoUrl(string apiKey, long id)
        {
            return ConcatBase(string.Format(Settings.Default.PersonGetUrlPattern, apiKey, id));
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