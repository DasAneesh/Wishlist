using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MYwishlist.Repository;

namespace MyWhishlist.App
{
    public class WishViewModel : ObservableObject
    {
        private IWishRepository repository;
        private ObservableCollection<Wish> wishList;
        public ObservableCollection<Wish> WishList { get => wishList; set { wishList = value; OnPropertyChanged("WishList"); } }
        private string productName;
        private string link;
        private int cost;
        private int wishmeter;
        public string ProductName { get => productName; set { productName = value; SelectedWish.Productname = value; OnPropertyChanged("ProductName"); } }
        public string Link { get => link; set { link = value; SelectedWish.Link = value; OnPropertyChanged("Link"); } }
        public int Cost { get => cost; set { cost = value; SelectedWish.Cost = value; OnPropertyChanged("Cost"); } }
        public int Wishmeter { get => wishmeter; set { wishmeter = value; SelectedWish.Wishmeter = value; OnPropertyChanged("Wishmeter"); } }

        private Wish selectedWish;
        public Wish SelectedWish { get => selectedWish; set 
            { 
                selectedWish = value; 
                ProductName = value.Productname;

                OnPropertyChanged("SelectedWish");
            }
        }
        public WishViewModel(IWishRepository repository) {
            this.repository = repository;
            WishList = new ObservableCollection<Wish>(this.repository.Read());   
        }

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                    (addCommand = new RelayCommand(obj =>
                    {
                        repository.Create(new Wish(0,ProductName,Link,Wishmeter,Cost));
                        WishList = new ObservableCollection<Wish>(repository.Read());
                    }));
            }
        }
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ??
                    (deleteCommand = new RelayCommand(obj =>
                    {
                        repository.Delete(selectedWish.ID);
                        WishList = new ObservableCollection<Wish>(repository.Read());
                    }));
            }
        }

        private RelayCommand updateCommand;
        public RelayCommand UpdateCommand
        {
            get
            {
                return updateCommand ??
                    (updateCommand = new RelayCommand(obj =>
                    {
                        repository.Update(selectedWish);
                        WishList = new ObservableCollection<Wish>(repository.Read());
                    }));
            }
        }
    }
}
