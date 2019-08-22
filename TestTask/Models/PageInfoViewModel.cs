using System;

namespace TestTask.Models
{
    /// <summary>
    /// Модель представление для паджинации
    /// </summary>
    public class PageInfoViewModel
    {
        public int PageNumber { get; set; } = 1;

        public int PageSize { get; set; } = 8;

        public int TotalItems { get; set; }

        public int TotalPages
        {
            get
            {
                return (int)Math.Ceiling((decimal)TotalItems / PageSize);
            }
        }
    }
}