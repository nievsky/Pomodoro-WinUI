## Exercise 1 Solution: The StackPanel
**Why this works:** The `<StackPanel>` automatically prevents elements from overlapping. Adding `Orientation="Horizontal"` changes the flow from top-to-bottom to left-to-right. Finally, the `Spacing` property pushes the buttons apart so they aren't touching.

```xml
<Page
    x:Class="Playground.MainPage"
    xmlns="[http://schemas.microsoft.com/winfx/2006/xaml/presentation](http://schemas.microsoft.com/winfx/2006/xaml/presentation)"
    xmlns:x="[http://schemas.microsoft.com/winfx/2006/xaml](http://schemas.microsoft.com/winfx/2006/xaml)">

    <StackPanel Background="#1E1E1E" Spacing="10" Orientation="Horizontal" HorizontalAlignment="Center" VerticalAlignment="Center">
        <Button Content="First Button" Background="#20E585" Foreground="Black" />
        <Button Content="Second Button" Background="#5C8AFF" />
        <Button Content="Third Button" Background="#FF5C5C" />
    </StackPanel>

</Page>

```
# ex. 2

```xml
<Page
    x:Class="Playground.MainPage"
    xmlns="[http://schemas.microsoft.com/winfx/2006/xaml/presentation](http://schemas.microsoft.com/winfx/2006/xaml/presentation)"
    xmlns:x="[http://schemas.microsoft.com/winfx/2006/xaml](http://schemas.microsoft.com/winfx/2006/xaml)">

    <Grid Background="#1E1E1E">
        <Grid.RowDefinitions>
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>
        
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>
        
        <Border Grid.Row="0" Grid.Column="0" Background="#FF5C5C" Width="100" Height="100" /> 
        <Border Grid.Row="1" Grid.Column="1" Background="#5CFF8A" Width="80" Height="80" /> 
        <Border Grid.Row="2" Grid.Column="2" Background="#5C8AFF" Width="60" Height="60" /> 
        <Border Grid.Row="3" Grid.Column="3" Background="#FFE65C" Width="40" Height="40" /> 
    </Grid>

</Page>
```

## ex. 3

```xml
<Page
    x:Class="Playground.MainPage"
    xmlns="[http://schemas.microsoft.com/winfx/2006/xaml/presentation](http://schemas.microsoft.com/winfx/2006/xaml/presentation)"
    xmlns:x="[http://schemas.microsoft.com/winfx/2006/xaml](http://schemas.microsoft.com/winfx/2006/xaml)">

    <Grid Background="#272727" Width="400" Height="150" CornerRadius="12" Padding="16">
        
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto" />
            <ColumnDefinition Width="*" />
        </Grid.ColumnDefinitions>

        <Border Grid.Column="0" Width="80" Height="80" CornerRadius="40" Background="#5C8AFF" VerticalAlignment="Center" Margin="0,0,16,0" />

        <StackPanel Grid.Column="1" VerticalAlignment="Center">
            <TextBlock Text="Jane Doe" FontSize="24" FontWeight="Bold" Foreground="White" />
            <TextBlock Text="Senior Developer" FontSize="16" Foreground="#CCCCCC" />
            <TextBlock Text="Currently working on the Pomodoro App" FontSize="14" Foreground="#888888" TextWrapping="Wrap" Margin="0,8,0,0"/>
        </StackPanel>
        
    </Grid>

</Page>
``` 
