using System;
using System.Runtime.Serialization;

namespace CinemateAPI.Domain
{
    [DataContract]
    public class UpdateItem
    {
        /// <summary>
        /// Дата и время добавления записи в ленту обновлений пользователя в ISO формате
        /// </summary>
        public DateTime Date
        {
            get { return date; }
        }

        /// <summary>
        /// Текстовое описание обновления
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        /// Ссылка на обновление; переход по ссылке отмечает запись в ленте прочитанной и производит редирект на страницу с обновлением
        /// </summary>
        public string Url
        {
            get { return url; }
        }

        /// <summary>
        /// флаг прочитанного обновления (1 - непрочтенное, 0 - прочтенное)
        /// </summary>
        public int New
        {
            get { return @new; }
        }

        /// <summary>
        /// Список объектов object, к которым привязано обновление
        /// </summary>
        public UpdateItemObject ForObject
        {
            get { return forObject; }
        }

        public override string ToString()
        {
            return Description;
        }

        [DataMember]
        private DateTime date;

        [DataMember]
        private string description;

        [DataMember]
        private string url;

        [DataMember(Name = "new")]
        private int @new;

        [DataMember(Name = "for_object")]
        private UpdateItemObject forObject;
    }
}