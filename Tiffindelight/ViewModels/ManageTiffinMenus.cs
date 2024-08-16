using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;

using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tiffindelight.ViewModels
{
    public partial class ManageTiffinMenus : ObservableObject
    {
        public ManageTiffinMenus()
        {
            // Initialize commands
            AddNewItemCommand = new RelayCommand(OnAddNewItem);
            EditItemCommand = new RelayCommand(OnEditItem);
            DeleteItemCommand = new RelayCommand(OnDeleteItem);
            SearchItemsCommand = new RelayCommand<string>(OnSearchItems);

            // Initialize collections with sample data
            MenuItems = new ObservableCollection<MenuItem>
            {
                new MenuItem { Name = "Item1", Description = "Description1", Price = 10.0 },
                new MenuItem { Name = "Item2", Description = "Description2", Price = 20.0 }
            };

            Categories = new ObservableCollection<Category>
            {
                new Category { Name = "Category1" },
                new Category { Name = "Category2" }
            };

            SpecialOffers = new ObservableCollection<SpecialOffer>
            {
                new SpecialOffer { Title = "Offer1", Description = "Description1", Discount = 0.20 }
            };
        }

        // Command properties
        public IRelayCommand AddNewItemCommand { get; }
        public IRelayCommand EditItemCommand { get; }
        public IRelayCommand DeleteItemCommand { get; }
        public IRelayCommand<string> SearchItemsCommand { get; }

        // Command methods
        private void OnAddNewItem()
        {
            // Implementation for adding a new item
        }

        private void OnEditItem()
        {
            // Implementation for editing an item
        }

        private void OnDeleteItem()
        {
            // Implementation for deleting an item
        }

        private void OnSearchItems(string searchText)
        {
            // Implementation for searching items
        }

        // Collections
        public ObservableCollection<MenuItem> MenuItems { get; }
        public ObservableCollection<Category> Categories { get; }
        public ObservableCollection<SpecialOffer> SpecialOffers { get; }
    }

    // Example classes for data binding
    public class MenuItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; } // Optional, if using images
    }

    public class Category
    {
        public string Name { get; set; }
    }

    public class SpecialOffer
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Discount { get; set; }
    }
}
