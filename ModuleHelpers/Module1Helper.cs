using System;

namespace MovieApp
{
    public static class Module1Helper
    {
        internal static void SelectList()
        {
            Console.WriteLine(nameof(SelectList));
        }

        internal static void SelectById()
        {
            Console.WriteLine(nameof(SelectById));
        }
        internal static void CreateItem()
        {
            Console.WriteLine(nameof(CreateItem));
        }

        internal static void UpdateItem()
        {
            Console.WriteLine(nameof(UpdateItem));
        }
        
        internal static void DeleteItem()
        {
            Console.WriteLine(nameof(DeleteItem));
        }
    }
}