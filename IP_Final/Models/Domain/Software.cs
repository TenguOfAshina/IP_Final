using System.ComponentModel.DataAnnotations;

namespace IP_Final.Models.Domain
{
    public class Software
    {
        [Key]
        public int app_id { get; set; }
        
        public string app_name { get; set; }

        public string app_version { get; set;}

        public string app_description { get; set;}

        public string app_size { get; set;}

        public string app_owner { get; set;}

        public string app_image_url { get; set;}

        public int app_install_count { get; set; }

        public int lang_code { get; set;}

        public int os_code { get; set;}

        public int cat_code { get; set;}
    }

    //public class Category
    //{
    //    [Key]
    //    public int category_id { get; set; }

    //    public string category_name { get; set; }
    //}

    //public class ApplicationCategory
    //{
    //    [Key]
    //    public int app_category_id { get; set; }

    //    public Software Software_id { get; set; }

    //    public Category Category_id { get; set; }
    //}

    //public class OperatingSystem
    //{
    //    [Key]
    //    public int operating_system_id { get; set; }

    //    public string operating_system_name { get; set; }
    //}

    //public class OperatingSystemApplication
    //{
    //    [Key]
    //    public int operating_system_application_id { get; set; }

    //    public Software Software_id { get; set; }

    //    public OperatingSystem OperatingSystem_id { get; set; }
    //}

    //public class Language
    //{
    //    [Key]
    //    public int language_id { get; set; }

    //    public string language_name { get; set;}

        
    //}

    public class DenemeTable
    {
        [Key]
        public int deneme_id { get; set; }

        public string deneme_name { get; set;}
    }


}
