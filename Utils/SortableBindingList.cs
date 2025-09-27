using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace IssueWatcher.Utils
{
    using System;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Reflection;

    public class SortableBindingList<T> : BindingList<T>
    {
        private bool _isSorted;
        private ListSortDirection _sortDirection;
        private PropertyDescriptor _sortProperty;

        public SortableBindingList() : base() { }

        // Construtor que aceita lista inicial
        public SortableBindingList(IList<T> list) : base(list) { }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _isSorted;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            var itemsList = Items as List<T>;
            if (itemsList == null) return;

            var propertyInfo = typeof(T).GetProperty(prop.Name, BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null) return;

            itemsList.Sort((x, y) =>
            {
                var valX = propertyInfo.GetValue(x);
                var valY = propertyInfo.GetValue(y);
                int result = Comparer<object>.Default.Compare(valX, valY);
                return direction == ListSortDirection.Ascending ? result : -result;
            });

            _sortProperty = prop;
            _sortDirection = direction;
            _isSorted = true;

            OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
        }

        protected override void RemoveSortCore()
        {
            _isSorted = false;
            _sortProperty = null;
        }
    }
}
