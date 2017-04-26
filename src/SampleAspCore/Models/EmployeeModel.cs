using System.Linq;
using SampleAspCore.DataLayer.Entities;
using SampleAspCore.DataLayer.Interfaces;
using SampleAspCore.Helpers;

namespace SampleAspCore.Models
{
    public class EmployeeModel
    {
        public static void Fill(IRepository<Employee> repository, Pager<Employee> pager)
        {
            //building linq query
            var linqStmt = string.IsNullOrEmpty(pager.FilterKey)
                  ? repository.All().AsQueryable()
                  : repository.Filter(x => x.FirstName.Contains(pager.FilterKey)
                            || x.LastName.Contains(pager.FilterKey));
            //setting page size
            pager.PageSize = Common.PageSize;
            //getting count
            var totalRecords = linqStmt.Count();
            //getting total pages
            pager.TotalPages = Common.GetTotalPages(totalRecords);
            //getting start index
            var recordsToSkip = Common.GetRecordsToSkip(pager.Page);
            //building pager summary
            pager.PageSummary = $"Showing {recordsToSkip + 1 } to {recordsToSkip + Common.PageSize } of {totalRecords} records.";
            //applying pagination
            pager.ResultSet = linqStmt
                  .OrderBy(x => x.Id)
                  .Skip(recordsToSkip)
                  .Take(Common.PageSize);

        }
    }
}
