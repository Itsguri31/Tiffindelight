using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Tiffindelight.ViewModels
{
    public partial class ManageOrdersViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private ObservableCollection<CustomerOrder> customerOrders;

        public ManageOrdersViewModel()
        {
            // Initialize with some dummy data for now
            CustomerOrders = new ObservableCollection<CustomerOrder>
            {
                new CustomerOrder
                {
                    CustomerName = "Gurkirat Singh",
                    OrderDetails = "2x Veg Thali, 1x Chicken Burger",
                    MembershipInfo = "Gold Member - Valid till 31 Dec 2024"
                },
                new CustomerOrder
                {
                    CustomerName = "Baljinder Maan",
                    OrderDetails = "1x Vegetable Pulao, 1x Paneer Tikka",
                    MembershipInfo = "Silver Member - Valid till 30 Nov 2024"
                },   
                new CustomerOrder
                {
                    CustomerName = "Amritpal Singh",
                    OrderDetails = "2x Vegetable Pulao, 1x Veg Thali",
                    MembershipInfo = "Bronze Member - Valid till 30 Oct 2024"
                    }

            };
        }
    }

    public class CustomerOrder
    {
        public string CustomerName { get; set; }
        public string OrderDetails { get; set; }
        public string MembershipInfo { get; set; }
    }
}