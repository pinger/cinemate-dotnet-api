using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class Profile
    {
        /// <summary>
        /// Логин пользователя
        /// </summary>
        public string Username
        {
            get { return username; }
        }

        /// <summary>
        /// Репутация пользователя
        /// </summary>
        public int Reputation
        {
            get { return reputation; }
        }

        /// <summary>
        /// Количество отзывов
        /// </summary>
        public int ReviewsCount
        {
            get { return reviewsCount; }
        }

        /// <summary>
        /// Число золотых наград
        /// </summary>
        public int BadgesGoldCount
        {
            get { return badgesBronzeCount; }
        }

        /// <summary>
        /// Число серебряных наград
        /// </summary>
        public int BadgesSilverCount
        {
            get { return badgesSilverCount; }
        }

        /// <summary>
        /// Число бронзовых наград
        /// </summary>
        public int BadgesBronseCount
        {
            get { return badgesBronzeCount; }
        }

        /// <summary>
        /// Число непрочитанных личных сообщений
        /// </summary>
        public int UnreadPrivateMessagesCount
        {
            get { return unreadPrivateMessagesCount; }
        }

        /// <summary>
        /// Число новых сообщений и/или тем на форуме в отслеживаемых темах и разделах
        /// </summary>
        public int UnreadForumCount
        {
            get { return unreadForumCount; }
        }

        /// <summary>
        /// число новых записей в ленте обновлений
        /// </summary>
        public int UnreadUpdateListCount
        {
            get { return unreadUpdateListCount; }
        }

        /// <summary>
        /// общее число подписок в ленте обновлений
        /// </summary>
        public int FollowersCount
        {
            get { return followersCount; }
        }

        [DataMember]
        private string username;

        [DataMember(Name = "reputation")]
        private int reputation;

        [DataMember(Name = "reviews_count")]
        private int reviewsCount;

        [DataMember(Name = "gold_badges")]
        private int badgesGoldCount;

        [DataMember(Name = "silver_badges")]
        private int badgesSilverCount;

        [DataMember(Name = "bronze_badges")]
        private int badgesBronzeCount;

        [DataMember(Name = "unread_pm_count")]
        private int unreadPrivateMessagesCount;

        [DataMember(Name = "unread_forum_count")]
        private int unreadForumCount;

        [DataMember(Name = "unread_updatelist_count")]
        private int unreadUpdateListCount;

        [DataMember(Name = "followers_count")]
        private int followersCount;
    }
}