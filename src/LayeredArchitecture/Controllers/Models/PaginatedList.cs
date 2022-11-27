
namespace LayeredArchitecture.Controllers.Models;

public class PaginatedList<T>
{
    public IEnumerable<T> Items { get; }
    public int PageNumber { get; }
    public int TotalPages { get; }
    public int TotalCount { get; }

    public PaginatedList(IEnumerable<T> items,int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        TotalCount =  count;
        TotalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
        Items =  items;
    }

    public bool HasPreviousPage => PageNumber > 1;

    public bool HasNextPage => PageNumber < TotalPages;

    
    public override bool Equals(Object? obj)
    {
        if (obj == null)
            return false;

        PaginatedList<T>? other = obj as PaginatedList<T>;
        if ((Object?)other == null)
            return false;

        return this.PageNumber == other.PageNumber
            && this.TotalCount == other.TotalCount
            && this.TotalPages == other.TotalPages
            && this.Items.SequenceEqual(other.Items);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }
}