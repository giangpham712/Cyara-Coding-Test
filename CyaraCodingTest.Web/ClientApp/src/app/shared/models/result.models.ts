export interface PaginatedResult<T> extends ListResult<T>
{
  total: number
}

export interface ListResult<T>
{
  items: T[];
}