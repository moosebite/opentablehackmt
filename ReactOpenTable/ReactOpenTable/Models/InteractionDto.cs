using System;

namespace ReactOpenTable.Models
{
    public class InteractionDto
    {
        public string Name_input { get; set; }
        public DateTime? Date_input { get; set; }
        public string Num_assisted { get; set; } // int?
        public string Location { get; set; }
        public string Reject_assistance { get; set; }
        public string Other { get; set; } // int?
        public string Emergency { get; set; } // int?
        public string Launchpad { get; set; } // int?
        public string Mission { get; set; } // int?
        public string Staging { get; set; } // int?
        public string Other_comment { get; set; }
    }
}
