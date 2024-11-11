namespace XBuddy.Share.Paging;

public class PagedResponse<T>(IList<T> data, Page pageInfo)
{
    public PagedResponse() : this([], new Page())
    {
        
    }

    public IList<T> Data { get; set; } = data;
    public Page PageInfo { get; set; } = pageInfo;
}