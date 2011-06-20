using System;
using System.Xml.Serialization;

namespace CinemateAPI.Account
{
	[Serializable]
	public class Profile
	{
		/// <summary>
		/// логин пользователя
		/// </summary>
		[XmlElement("username")]
		public string Username;

		/// <summary>
		/// репутация пользователя
		/// </summary>
		[XmlElement("reputation")]
		public int Reputation;

		/// <summary>
		/// количество отзывов
		/// </summary>
		[XmlElement("reviews_count")]
		public int ReviewsCount;

		/// <summary>
		/// число золотых наград
		/// </summary>
		[XmlElement("gold_badges")]
		public int BadgesGoldCount;

		/// <summary>
		/// число серебряных наград
		/// </summary>
		[XmlElement("silver_badges")]
		public int BadgesSilverCount;

		/// <summary>
		/// число бронзовых наград
		/// </summary>
		[XmlElement("bronze_badges")]
		public int BadgesBronseCount;

		/// <summary>
		/// число непрочитанных личных сообщений
		/// </summary>
		[XmlElement("unread_pm_count")]
		public int UnreadPrivateMessagesCount;

		/// <summary>
		/// число новых сообщений и/или тем на форуме в отслеживаемых темах и разделах
		/// </summary>
		[XmlElement("unread_forum_count")]
		public int UnreadForumCount;

		/// <summary>
		/// число новых записей в ленте обновлений
		/// </summary>
		[XmlElement("unread_updatelist_count")]
		public int UnreadUpdateListCount;

		/// <summary>
		/// общее число подписок в ленте обновлений
		/// </summary>
		[XmlElement("followers_count")]
		public int FollowersCount;
	}
}