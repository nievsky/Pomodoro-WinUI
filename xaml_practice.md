**Instructions:** 
1. Open your web browser and go to **[playground.platform.uno](https://playground.platform.uno)**.
2. Delete everything in the left-hand code panel.
3. Copy and paste the "Starter Code" for each exercise below.
4. Follow the tasks to fix the broken UI!

---

# Exercise 1: The StackPanel (The 1D List)
**The Problem:** All of our buttons are squished on top of each other!
**The Goal:** Arrange them into a neat row.

### Your Tasks:
- [ ] Change the `<Grid>` tag to a `<StackPanel>`. (Watch them form a vertical list!)
- [ ] Add `Spacing="10"` inside the `<StackPanel>` tag to give them breathing room.
- [ ] Change the list to a horizontal line by adding `Orientation="Horizontal"`.
- [ ] Center the entire menu by adding `HorizontalAlignment="Center"` and `VerticalAlignment="Center"` to the StackPanel.

### Starter Code:
```xml
<Page
    x:Class="Playground.MainPage"
    xmlns="[http://schemas.microsoft.com/winfx/2006/xaml/presentation](http://schemas.microsoft.com/winfx/2006/xaml/presentation)"
    xmlns:x="[http://schemas.microsoft.com/winfx/2006/xaml](http://schemas.microsoft.com/winfx/2006/xaml)">

    <Grid Background="#1E1E1E">
        <Button Content="First Button" Background="#20E585" Foreground="Black" />
        <Button Content="Second Button" Background="#5C8AFF" />
        <Button Content="Third Button" Background="#FF5C5C" />
    </Grid>

</Page>
```

# Exercise 2: The Grid (The 2D Structure)
## The Problem
We have four colored boxes inside a `<Grid>`, but they are all stacked dead-center on top of each other! Because they are different sizes, they look like a target or a bullseye. 


## The Goal
Use the `Grid` container's superpower (Rows and Columns) to spread them out into a diagonal staircase from the top-left corner to the bottom-right corner.

### Your Tasks:
- First, define the skeleton! Right above the borders, write the `<Grid.RowDefinitions>` and `<Grid.ColumnDefinitions>` to create a **4x4 grid** (4 rows and 4 columns). 
  *(Hint: You will need to write `<RowDefinition Height="*" />` four times, and `<ColumnDefinition Width="*" />` four times).*
- Assign the biggest **Red** border to the top-left corner by adding `Grid.Row="0"` and `Grid.Column="0"` inside its tag.
- Assign the **Green** border to the next step down (`Row="1"`, `Column="1"`).
- Assign the **Blue** border to the third step (`Row="2"`, `Column="2"`).
- Assign the smallest **Yellow** border to the bottom-right corner (`Row="3"`, `Column="3"`).
- Set **Height** and **Width** properties of all Borders to `auto` so they fill out the whole space.

### Starter Code:
```xml
<Page
    x:Class="Playground.MainPage"
    xmlns="[http://schemas.microsoft.com/winfx/2006/xaml/presentation](http://schemas.microsoft.com/winfx/2006/xaml/presentation)"
    xmlns:x="[http://schemas.microsoft.com/winfx/2006/xaml](http://schemas.microsoft.com/winfx/2006/xaml)">

    <Grid Background="#1E1E1E">
        <Border Background="#FF5C5C" Width="100" Height="100" /> 
        <Border Background="#5CFF8A" Width="80" Height="80" /> 
        <Border Background="#5C8AFF" Width="60" Height="60" /> 
        <Border Background="#FFE65C" Width="40" Height="40" /> 
    </Grid>

</Page>
```

# Exercise 3: Profile Card (Combined Layouts)
**The Problem**
We are trying to build a professional user profile card. We set up a `Grid` with two columns, but right now, the user's name and bio are mashed right on top of the blue avatar circle!

## The Goal
Learn the Golden Rule of XAML: **Use Grids for the skeleton, and StackPanels for the inner content.** 

### Your Tasks:
- Look at the three `TextBlock` items at the bottom of the code. They are overlapping in the left corner because they don't have a layout container, and they default to `Grid.Column="0"`.
- Wrap all three of those `TextBlock` items inside a new `<StackPanel>`. (This will stack them into a neat vertical list).
- Tell that new `<StackPanel>` to sit in the right side of the card by adding `Grid.Column="1"` to its tag.
- Make it look professional! Add `VerticalAlignment="Center"` to the `<StackPanel>` so the block of text floats perfectly in the middle, matching the avatar.

### Starter Code:
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

        <TextBlock Text="Jane Doe" FontSize="24" FontWeight="Bold" Foreground="White" />
        <TextBlock Text="Senior Developer" FontSize="16" Foreground="#CCCCCC" />
        <TextBlock Text="Currently working on the Pomodoro App" FontSize="14" Foreground="#888888" TextWrapping="Wrap" Margin="0,8,0,0"/>
        
    </Grid>

</Page>
```