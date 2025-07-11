﻿using System.ComponentModel.DataAnnotations;

namespace MusicShop.Models.Statistics
{
    public class StatisticsVM
    {
        [Display(Name ="Count Clients")]
        public int CountClients { get; set; }
        [Display(Name = "Count Products")]
        public int CountProducts { get; set; }
        [Display(Name = "Count Orders")]
        public int CountOrders{ get; set; }
        [Display(Name = "Total Sum orders")]
        public decimal SumOrders { get; set; }


    }
}
