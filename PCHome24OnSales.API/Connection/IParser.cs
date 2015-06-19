using System;

namespace PCHome24OnSales.API.Connection
{
    public interface IParser<TData>
    {
        TData Parse(String source);
    }
}
