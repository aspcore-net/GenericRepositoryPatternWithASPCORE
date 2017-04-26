using System;

namespace SampleAspCore.Helpers
{
    public class Common
    {
        public static int PageSize => 10;

        public static int GetTotalPages(int totalRecords)
        {
            return (int)Math.Ceiling(totalRecords / (double)PageSize);
        }
        
        public static int GetRecordsToSkip(int page)
        {
            if (page == 0) page = 1;
            return (page - 1) * PageSize;
        }
     
           
    }
}
