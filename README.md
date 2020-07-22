# HCPaginationBug
This is bug reproduce repo... do not use this as example!

Related to bug: https://github.com/ChilliCream/hotchocolate/issues/2154

Test data included! (in Program.cs)

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
