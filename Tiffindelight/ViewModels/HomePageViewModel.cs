using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace Tiffindelight.ViewModels
{
    public partial class HomePageViewModel: ObservableRecipient
    {
        [ObservableProperty]
        private ObservableCollection<FoodItem> foodItems;

        [ObservableProperty]
        private ObservableCollection<FoodItem> filteredFoodItems;

        [ObservableProperty]
        private string searchQuery = string.Empty;  // Initialize with an empty string

        public HomePageViewModel()
        {
            FoodItems = new ObservableCollection<FoodItem>
            {
                new FoodItem { Name = "Paneer Tikka", Description = "Delicious grilled paneer cubes.", ImageUrl = "paneer_tikka.png" },
                new FoodItem { Name = "Chicken Biryani", Description = "Aromatic and flavorful rice with chicken.", ImageUrl = "chicken_biryani.png" },
                new FoodItem { Name = "Chicken Burgur", Description = "Delicious grilled chicken.", ImageUrl = "chicken_burgur.png" },
                new FoodItem { Name = "Vegetable Pulao", Description = "Healthy and tasty vegetable rice.", ImageUrl = "vegetable_pulao.png" },
                
            };

            FilteredFoodItems = new ObservableCollection<FoodItem>(FoodItems);
        }

        [RelayCommand]
        private void PerformSearch()
        {
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                FilteredFoodItems = new ObservableCollection<FoodItem>(FoodItems);
            }
            else
            {
                FilteredFoodItems = new ObservableCollection<FoodItem>(
                    FoodItems.Where(f => f.Name.ToLower().Contains(SearchQuery.ToLower())));
            }
        }

        [RelayCommand]
        private void ViewAllItems()
        {
            // Navigate to the page showing all items
        }

        [RelayCommand]
        private void ManageMenus()
        {
            // Navigate to the menu management page
        }

        [RelayCommand]
        private void ManageOrders()
        {
            // Navigate to the order management page
        }

        [RelayCommand]
        private void ManageUsers()
        {
            // Navigate to the user management page
        }
    }

    public class FoodItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
