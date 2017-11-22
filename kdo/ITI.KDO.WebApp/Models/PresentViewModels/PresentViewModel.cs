using System;

namespace ITI.KDO.WebApp.Models.PresentViewModels
{
    public class PresentViewModel
    {
        public int PresentId { get; set; }

        public string PresentName { get; set; }

        public float Price { get; set; }

        public string LinkPresent { get; set; }

        public int CategoryPresentId { get; set; }

        public int UserId { get; set; }
    }
}
