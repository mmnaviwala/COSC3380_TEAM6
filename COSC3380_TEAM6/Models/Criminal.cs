
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace COSC3380_TEAM6.Models
{
    public class Criminal
    {
        [StringLength(6)]
        public string criminal_id { get; set; }

        [StringLength(30)]
        public string first_name { get; set; }

        [StringLength(30)]
        public string last_name { get; set; }

        [Range(1, 7)]
        public int eye_color { get; set; }

        [StringLength(6)]
        public int weight { get; set; }

        [StringLength(2)]
        public int feet { get; set; }

        [StringLength(2)]
        public int inches { get; set; }

        [Range(1, 2)]
        public int gender { get; set; }

        [StringLength(9)]
        public int ssn { get; set; }


        public string alias { get; set; }

        [Range(1, 7)]
        public int hair_color { get; set; }

        public string known_affiliates { get; set; }

        [DataType(DataType.Date)]
        public DateTime date_of_birth { get; set; }

        [Range(1, 6)]
        public int race { get; set; }

        [StringLength(60)]
        public string address { get; set; }

        [Range(1, 50)]
        public int state { get; set; }

        [StringLength(5)]
        public int zip_code { get; set; }

        [StringLength(10)]
        public int phone_number { get; set; }

        //byte[] imageData = ReadFile(txtImagePath.Text);
        //public blob mugshot { get; set; }

        public string misc { get; set; }

    }
}
