
namespace LayeredArchitecture.Controllers.Models;

public class PaginatedList<T>
{
    public List<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public PaginatedList(List<T> items,int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalCount =  count;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
        Items =  items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

}