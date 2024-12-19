using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace StarWarsClient.Extensions
{
    public class DataGridColumnExtensions
    {
        public static readonly DependencyProperty IsCustomSortProperty = DependencyProperty.RegisterAttached(
            "IsCustomSort",
            typeof(bool),
            typeof(DataGridColumnExtensions),
            new PropertyMetadata(false, OnIsCustomSortChanged));

        public static bool GetIsCustomSort(DataGrid grid)
        {
            return (bool)grid.GetValue(IsCustomSortProperty);
        }

        public static void SetIsCustomSort(DataGrid grid, bool value)
        {
            grid.SetValue(IsCustomSortProperty, value);
        }

        private static void OnIsCustomSortChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not DataGrid dataGrid)
                return;

            if (!(bool)e.OldValue && (bool)e.NewValue)
                dataGrid.Sorting += DataGrid_Sorting;
            else
                dataGrid.Sorting -= DataGrid_Sorting;
        }

        public static readonly DependencyProperty CustomSorterProperty = DependencyProperty.RegisterAttached(
            "CustomSorter",
            typeof(IComparer),
            typeof(DataGridColumnExtensions));

        public static IComparer GetCustomSorter(DataGridColumn column)
        {
            return (IComparer)column.GetValue(CustomSorterProperty);
        }

        public static void SetCustomSorter(DataGridColumn column, IComparer value)
        {
            column.SetValue(CustomSorterProperty, value);
        }

        private static void DataGrid_Sorting(object sender, DataGridSortingEventArgs e)
        {
            if (GetCustomSorter(e.Column) is null || sender is not DataGrid dataGrid)
                return;

            e.Column.SortDirection = e.Column.SortDirection == ListSortDirection.Ascending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;

            if (ApplyCustomSort(dataGrid, e.Column))
                e.Handled = true;
        }

        private static bool ApplyCustomSort(DataGrid grid, DataGridColumn column)
        {
            if (GetCustomSorter(column) is not IComparer comparer)
                return false;

            if (CollectionViewSource.GetDefaultView(grid.ItemsSource) is not ListCollectionView lcv)
                return false;

            lcv.CustomSort = new DataGridSortComparer(comparer, column.SortDirection ?? ListSortDirection.Ascending, column.SortMemberPath);

            return true;
        }

        private class DataGridSortComparer(IComparer comparer, ListSortDirection sortDirection, string propertyName) : IComparer
        {
            private PropertyInfo? property;

            public int Compare(object? x, object? y)
            {
                if (x == null && y == null)
                    return 0;

                property ??= x?.GetType()?.GetProperty(propertyName);
                property ??= y!.GetType().GetProperty(propertyName);

                int result = comparer.Compare(property!.GetValue(x), property.GetValue(y));

                if (sortDirection == ListSortDirection.Descending)
                {
                    result = -result;
                }

                return result;
            }
        }
    }
}