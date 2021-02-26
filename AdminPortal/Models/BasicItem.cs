using AdminPortal.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace AdminPortal.Models
{
    public class BasicItem
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(2000)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public Func<BasicItem, string> BaseUrlAction { get; set; }

        public Func<BasicItem, string> AddUrlAction { get; set; } = item => $"{item.BaseUrlAction(item)}/Add";

        public Func<BasicItem, string> DeleteUrlAction { get; set; } = item => $"{item.BaseUrlAction(item)}/Delete/{item.Id}";

        public Func<BasicItem, string> DetailUrlAction { get; set; } = item => $"{item.BaseUrlAction(item)}/Detail/{item.Id}";

        public Func<BasicItem, string> EditUrlAction { get; set; } = item => $"{item.BaseUrlAction(item)}/Edit/{item.Id}";
    }
}