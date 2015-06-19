using System;

namespace PCHome24OnSales.API.Connection
{
    public interface IService<TData, TParser>
        where TParser : IParser<TData>, new()
    {
        Uri TargetUri { get; }
    }
}
