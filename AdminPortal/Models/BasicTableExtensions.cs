using AdminPortal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminPortal.Models
{
    public static class BasicTableExtensions
    {
        public static BasicTable ToBasicTable<T>(this IEnumerable<T> items, Func<BasicItem, string> urlAction) 
            where T : IHaveDescription, IHaveId, IHaveName
            => new BasicTable { Items = items.ToBasicItems(urlAction) };

        public static BasicItem[] ToBasicItems<T>(this IEnumerable<T> items, Func<BasicItem, string> urlAction) 
            where T : IHaveDescription, IHaveId, IHaveName
            => items.Select(item => item.ToBasicItem(urlAction)).ToArray();

        public static BasicItem ToBasicItem<T>(this T item, Func<BasicItem, string> urlAction) 
            where T : IHaveDescription, IHaveId, IHaveName
            => new BasicItem
            {
                Id = item.Id,
                Description = item.Description,
                Name = item.Name,
                BaseUrlAction = urlAction
            };
    }
}