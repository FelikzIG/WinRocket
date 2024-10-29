
# WinRocket

WinRocket is a C# library to help you boost the performance of the Windows OS. The project was recently launched and will continue to receive updates so keep an eye out.




## dirClear
Removes all files within the inputted directory path.

## Usage/Examples

```csharp
WinRocket rocket = new WinRocket();
try
{
    rocket.dirClear("path location");
    MessageBox.Show("Successfully cleared all files in the temp folder that is not being used by another process!");
}
catch (Exception Er)
{
    MessageBox.Show(Er.Message);
}

```
## disableWinUpdate
Disables Windows Update

## Usage/Examples

```csharp
WinRocket rocket = new WinRocket();
rocket.disableWinUpdate();

```

## disableSuperfetch
Disables Superfetch (Now called SysMain)

## Usage/Examples

```csharp
WinRocket rocket = new WinRocket();
rocket.disableSuperfetch();

```



