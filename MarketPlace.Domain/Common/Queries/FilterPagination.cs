﻿namespace MarketPlace.Domain.Common.Queries;

/// <summary>
/// Represents a pagination filter with page size and page token for querying collection of items.
/// </summary>
public class FilterPagination
{
    /// <summary>
    /// Gets or sets the number of items to include on each page. (deafult: 20)
    /// </summary>
    public uint PageSize { get; set; } = 20;

    /// <summary>
    /// Gets or sets the token representing the page to retrieve in a paginated collection. (default: 1)
    /// </summary>
    public uint PageToken { get; set; } = 1;

    /// <summary>
    /// Initializes a new instance of `FilterPagination` class with specified page size and page token.
    /// </summary>
    /// <param name="pageSize"></param>
    /// <param name="pageToken"></param>
    public FilterPagination(uint pageSize, uint pageToken)
    {
        PageSize = pageSize;
        PageToken = pageToken;
    }

    /// <summary>
    /// Initializes a new instance of `FilterPagination`
    /// </summary>
    public FilterPagination()
    {
    }

    /// <summary>
    /// Gets the hash code for the current `FilterPagination` instance.
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        hashCode.Add(PageSize);
        hashCode.Add(PageToken);

        return hashCode.ToHashCode();
    }

    /// <summary>
    /// Determines whether the specified object is equal to the current `FilterPagination` instance.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public override bool Equals(object? obj)
    {
        return obj is FilterPagination filterPagination && filterPagination.GetHashCode() == GetHashCode();
    }

}