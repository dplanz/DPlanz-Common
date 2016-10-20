using System;
using System.Collections.Generic;
using System.Data;

namespace CommonLibrary
{
    class DataSets
    {
        public static DataTable ConvertListToDataTable<T>(IEnumerable<T> list)
        {
            var type = typeof(T);
            var properties = type.GetProperties();

            var dataTable = new DataTable();
            foreach (var info in properties)
            {
                dataTable.Columns.Add(
                    Nullable.GetUnderlyingType(info.PropertyType) != null
                    ? new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType))
                    : new DataColumn(info.Name, info.PropertyType));
            }

            foreach (var entity in list)
            {
                var values = new object[properties.Length];
                for (var i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

        public static class Medians
        {
            public static decimal GetMedian(List<int> source)
            {
                // Create a copy of the input, and sort the copy
                var temp = source.ToArray();
                Array.Sort(temp);

                var count = temp.Length;
                if (count == 0)
                {
                    throw new InvalidOperationException("Empty collection");
                }
                if (count%2 != 0) return temp[count/2];
                // count is even, average two middle elements
                var a = temp[count / 2 - 1];
                var b = temp[count / 2];
                return (a + b) / 2m;
                // count is odd, return the middle element
            }
            public static decimal GetQuad1(List<int> source)
            {
                // Create a copy of the input, and sort the copy
                var temp = source.ToArray();
                Array.Sort(temp);

                var count = temp.Length;
                if (count == 0)
                {
                    throw new InvalidOperationException("Empty collection");
                }
                if (count % 4 == 0)
                {
                    // count is even, average two middle elements
                    var a = temp[count / 4 - 1];
                    var b = temp[count / 4];
                    return (a + b) / 2m;

                }
                // count is odd, return the middle element
                return temp[count / 4];
            }
            public static decimal GetQuad3(List<int> source)
            {
                // Create a copy of the input, and sort the copy
                var temp = source.ToArray();
                Array.Sort(temp);

                var count = temp.Length;
                if (count == 0)
                {
                    throw new InvalidOperationException("Empty collection");
                }
                if (count % 4 == 0)
                {
                    // count is even, average two middle elements
                    var a = temp[3 * count / 4 - 1];
                    var b = temp[3 * count / 4];
                    return (a + b) / 2m;

                }
                // count is odd, return the middle element
                return temp[3 * count / 4];
            }
        }
    }
}
