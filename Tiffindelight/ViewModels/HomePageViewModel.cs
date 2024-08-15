using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;  // Ensure you have this for Shell navigation

namespace Tiffindelight.ViewModels
{
    public partial class HomePageViewModel : ObservableRecipient
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
                new FoodItem { Name = "Veg Thali", Description = "Delicious grilled paneer cubes.", ImageUrl = "veg_thali.png" },
                new FoodItem { Name = "Chicken Biryani", Description = "Aromatic and flavorful rice with chicken.", ImageUrl = "chicken_biryani.png" },
                new FoodItem { Name = "Chicken Burger", Description = "Delicious grilled chicken.", ImageUrl = "chicken_burger.png" },
                new FoodItem { Name = "Salad", Description = "Healthy and tasty vegetable rice.", ImageUrl = "greek_salad.png" },
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
        private async Task ViewAllItems()
        {
            // Navigate to the page showing all items
            await Shell.Current.GoToAsync("AllItemsPage");  // Adjust the route name as needed
        }

        
        [RelayCommand]
        private async Task ManageOrders()
        {
            // Navigate to the order management page
            //await Shell.Current.GoToAsync("ManageOrdersPage");  // Adjust the route name as needed
            await Shell.Current.GoToAsync($"///{nameof(Views.ManageOrdersPage)}");
        }
        [RelayCommand]
        private async Task ManageMenus()
        {
            await Shell.Current.GoToAsync($"///{nameof(Views.Manage_Tiffin_Menus)}");
        }
        [RelayCommand]
        private async Task ManageUsers()
        {
            await Shell.Current.GoToAsync($"///{nameof(Views.ManageUsers)}");
        }

    }

    public class FoodItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
