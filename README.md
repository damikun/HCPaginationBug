# HCPaginationBug
This is bug reproduce repo... do not use this as example!

Related to bug: https://github.com/ChilliCream/hotchocolate/issues/2154

Test data included! (in Program.cs)


[Readme](Domain)

## Bug location

After quick check it looks like problem in this part but im not sure... i did not debug it yet... It looks like going from + over 0 to - is not handled...

under: https://github.com/ChilliCream/hotchocolate/blob/a7b1f39c686d2d572f0ef61ff9d8c0ceea90b795/src/HotChocolate/Core/src/Types/Types/Relay/QueryableConnectionResolver.cs 

```
      int count = temp.Count();
      int skip = count - last;
```
            
```
 protected virtual IQueryable<T> GetLastEdges(
            IQueryable<T> edges, int last,
            ref int offset)
        {
            if (last < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(last));
            }

            IQueryable<T> temp = edges;

            int count = temp.Count();
            int skip = count - last;

            if (skip > 1)
            {
                temp = temp.Skip(skip);
                offset += count;
                offset -= temp.Count();
            }

            return temp;
        }
```

# To Run
```
1 Fetch to local Git
2 Run: dotnet restore
3 Run: dotnet wacth run
```
Info: Running on .Net5 Standard

# Playground Query
```
  query Users(
        $first: PaginationAmount
        $last: PaginationAmount
        $after: String
        $before: String
      ) {
        users(
          first: $first
          after: $after
          before: $before
          last: $last
        ) {
          pageInfo {
            hasPreviousPage
            hasNextPage
            startCursor
            endCursor
          }
          edges {
            cursor
            node {
              iD
              name
            }
          }
        }
      }
```
## Query Variables
```
{
  "first": null,
  "last": 1 ,
  "before": "Mg==",
  "after": null
}

```
# SQLite database table

under:
appDB.db

| # | ID |  Name |
|:-:|:--:|:-----:|
| 1 | 1  | user1 |
| 2 | 2  | user2 |
| 3 | 3  | user3 |
| 4 | 4  | user4 |

# Packages:
```
 <ItemGroup>
    <PackageReference Include="HotChocolate" Version="10.5.0-rc.1" />
    <PackageReference Include="HotChocolate.AspNetCore" Version="10.5.0-rc.1" />
    <PackageReference Include="HotChocolate.AspNetCore.Playground" Version="10.5.0-rc.1" />
    <PackageReference Include="HotChocolate.AspNetCore.Voyager" Version="10.5.0-rc.1" />
    <PackageReference Include="HotChocolate.Types" Version="10.5.0-rc.1" />
    <PackageReference Include="HotChocolate.Types.Filters" Version="10.5.0-rc.1" />
    <PackageReference Include="HotChocolate.Types.Selections" Version="10.5.0-rc.1" />
    <PackageReference Include="HotChocolate.Types.Sorting" Version="10.5.0-rc.1" />
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.1.5" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.0-preview.5.20278.2" />
    <PackageReference Include="Newtonsoft.Json" Version="12.0.3" />
    <PackageReference Include="Microsoft.Data.Sqlite.Core" Version="5.0.0-preview.5.20278.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="5.0.0-preview.5.20278.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Sqlite" Version="5.0.0-preview.5.20278.2" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.0-preview.5.20278.2">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
 
  </ItemGroup>

```
