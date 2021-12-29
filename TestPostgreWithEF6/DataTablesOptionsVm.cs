namespace TestPostgreWithEF6;

public class DataTablesOptionsVm
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Skip => PageSize * (Page - 1);
    public string SortColumn { get; set; }
    public string SortColumnDirection { get; set; }
    public string SearchValue { get; set; }
    public string Draw { get; set; }
    public string Parameter1 { get; set; }


    public void BindValuesFromRequest(IFormCollection form)
    {
        if (string.IsNullOrEmpty(form["length"]))
        {
            PageSize = 10;
        }
        else
        {
            PageSize = int.Parse(form["length"]);
        }

        if (string.IsNullOrEmpty(form["start"]))
        {
            Page = 1;
        }
        else
        {
            Page = (int.Parse(form["start"]) / PageSize) + 1;
        }

        SortColumn = form["columns[" + form["order[0][column]"] + "][data]"];// Sort Column Name  
        SortColumnDirection = form["order[0][dir]"];// Sort Column Direction ( asc ,desc)  
        SearchValue = form["search[value]"].FirstOrDefault();// Search Value from (Search box)  
        Parameter1 = form["query[Status]"].FirstOrDefault();
    }

    public void BindValuesFromRequest(IQueryCollection form)
    {
        if (string.IsNullOrEmpty(form["length"]))
        {
            PageSize = 10;
        }
        else
        {
            PageSize = int.Parse(form["length"]);
        }

        if (string.IsNullOrEmpty(form["start"]))
        {
            Page = 1;
        }
        else
        {
            Page = (int.Parse(form["start"]) / PageSize) + 1;
        }

        SortColumn = form["columns[" + form["order[0][column]"] + "][data]"];// Sort Column Name  
        SortColumnDirection = form["order[0][dir]"];// Sort Column Direction ( asc ,desc)  
        SearchValue = form["search[value]"].FirstOrDefault();// Search Value from (Search box)  
        Parameter1 = form["query[Status]"].FirstOrDefault();
    }
}