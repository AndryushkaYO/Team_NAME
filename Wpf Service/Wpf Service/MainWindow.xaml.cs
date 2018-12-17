﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media.Effects;

using Wpf_Service.Bussiness_Logic;
using Wpf_Service.Models;
using Wpf_Service.Orders;
using System.Windows.Media;
using System.Windows.Input;
using Wpf_Service.Models.Contexts;
using Wpf_Service.Models.UnitOfWork;

namespace Wpf_Service
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Holds an id number of the next order.
        /// </summary>
        private long _nextId;

        /// <summary>
        /// Contains information of current creating/editing order.
        /// </summary>
        private Order order;

        /// <summary>
        /// Validator instance.
        /// </summary>
        private readonly Validator _validator;

        /// <summary>
        /// An object for storage connection.
        /// </summary>
        private readonly IUnitOfWork _storage;

        
        private static MainWindow _instance;

        public ICommand _saveCommand;

        public ICommand SaveCommand
        {
            
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new SaveCommand();
                }
                return _saveCommand;
            }
        }

        public static MainWindow Instance
        {
            get { return _instance; }
        }

        public Order Order { get => order; set => order = value; }

        bool cans = false;
        /// <summary>
        /// Parameterless constructor of application's main window.
        /// </summary>
        public MainWindow()
        {
            
            InitializeComponent();
            
            EditOrderButton.IsEnabled = false;
            DeletOrderButton.IsEnabled = false;
            try
            {
                _storage = new UnitOfWork(new OrderDbContext());
                //Order toSeed = new Order(0,
                //    new ClientModel("Leroy","Jenkins","damnsongmail","69696",
                //    new AddressModel("Kansas","Booze",69),"0"),new StoreModel("GetRect",new AddressModel("Kansas","ShposStreet",123,""),"0"),
                //    new ProductModel(53623,12,0.ToString()));
                //toSeed.ClientData.AddressModel.ClientId = toSeed.ClientKey;
                //_storage.Orders.Add(toSeed);
                _storage.Complete();
                //var wat = _storage.Orders.GetAll();               
                //_nextId = ordersList.Count() != 0 ? Convert.ToInt64(ordersList.Last().Id + 1) : 0;
                _storage.Complete();
            }
            catch (NullReferenceException e)
            {
                Util.Error("Storage fatal error", e.Message);
                Application.Current.Shutdown();
            }
            this.DataContext = Order;
            _validator = new Validator(
                new List<TextBox>
                {
                    FirstName,
                    LastName,
                    Email,
                    PhoneNumber,
                    ClientAddressCity,
                    ClientAddressStreet,
                    ClientAddressBuildingNumber,
                    ShopName,
                    ShopAddressCity,
                    ShopAddressStreet,
                    ShopAddressBuildingNumber,
                    GoodsCode,
                    GoodsWeight
                },
                Email,
                PhoneNumber);
            ResetOrderInstance();
            Closing += new System.ComponentModel.CancelEventHandler((object sender, System.ComponentModel.CancelEventArgs e) =>
            {
                OnWindowClose(sender, e);
                if (cans)
                {
                    e.Cancel = true;
                }
            });
            _instance = this;
            SetTextBoxAction();
            setUpdater();
        }

        private void setUpdater()
        {
            UpdateButton();
        }
        private async void UpdateButton()
        {
            SaveButton.IsEnabled = HasChanges2();
            while (true)
            {
                await Task.Delay(50);
                SaveButton.IsEnabled = HasChanges2();
            }
        }

        /// <summary>
        /// Fires when user opens pop-up window with a list of available oredrs.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private  void ExploreOrders(object sender, RoutedEventArgs e)
        {
            var wat = _storage.Orders.GetAll();
            List<Order> ordersList = (wat).ToList();

            var list = from p in ordersList select new KeyValuePair<double, Order>(Convert.ToInt64(p.Id), p);
            Dictionary<double, Order> orders = new Dictionary<double, Order>(list.ToDictionary(x => x.Key, x => x.Value));
            if (orders.Count > 0)
            {
                OrdersList.ItemsSource = orders;
                OrdersExplorer.IsOpen = true;
                ResetOrderInstance();
                WindowMain.IsEnabled = false;
                EditOrderButton.IsEnabled = false;
                DeletOrderButton.IsEnabled = false;
                Opacity = 0.5;
                Effect = new BlurEffect();
            }
            else
            {
                Util.Info("Explore orders", "Orders database is empty!");
            }
        }

        /// <summary>
        /// Fires when user presses 'Edit' button on pop-up window.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private void SetTargetEditingOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrdersList.SelectedItems.Count == 1)
                {
                    var selectedItem = (dynamic)OrdersList.SelectedItems[0];
                    Order = _storage.Orders.Find(selectedItem.Key.ToString()).Result;
                    DataContext = Order;
                }
            }
            catch (Exception exc)
            {
                Util.Error("Can't set order for editing", exc.Message);
            }

            OrdersList.SelectedItem = null;
            OrdersExplorer.IsOpen = false;
            EditOrderButton.IsEnabled = false;
            DeletOrderButton.IsEnabled = false;
            WindowMain.IsEnabled = true;
            Opacity = 1;
            Effect = null;
        }

        /// <summary>
        /// Fires when user rejects pop-up window by pressing 'Cancel' button.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private void Cancel(object sender, RoutedEventArgs e)
        {
            OrdersExplorer.IsOpen = false;
            EditOrderButton.IsEnabled = false;
            DeletOrderButton.IsEnabled = false;
            WindowMain.IsEnabled = true;
            Opacity = 1;
            Effect = null;
        }

        /// <summary>
        /// Fires when user creates or updates an order.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private void SaveOrder(object sender, RoutedEventArgs e)
        {
            Save();
        }

        public void Save()
        {
            _storage.Complete();
            try
            {
                _validator.Validate();
                long id = Convert.ToInt64(Order.Id);
                if (id == -1)
                {

                    _storage.Complete();                   
                    Order.Id = (678).ToString();
                    Order.ClientKey = Order.ClientData.getKey();
                    Order.ClientData.AddressKey = Order.ClientData.AddressModel.getKey();
                    Order.ClientData.AddressModel.Id = Order.ClientData.AddressModel.getKey();
                    Order.ClientData.Id = Order.ClientData.getKey();
                    Order.ClientKey = Order.ClientData.getKey();
                    Order.ProdId = Order.GoodsData.Code;
                    Order.ShopData.AddressModel.Id = Order.ShopData.AddressModel.getKey();
                    Order.ShopData.AddressKey = Order.ShopData.AddressModel.getKey();
                    Order.StoreId = Order.ShopData.Name;
                    Order.ClientData.OrderId = Order.Id;
                    Order.GoodsData.OrderKey = Order.Id;
                    Order.ShopData.OrderId = Order.Id;
                    Order.ClientData.AddressModel.ClientId = Order.ClientData.Id;
                    Order.ShopData.AddressModel.ClientId = Order.ShopData.Name;
                    _storage.Orders.Add(Order);
                    _storage.Complete();
                    ResetOrderInstance();
                }
                else
                {
                    _storage.Orders.Remove(_storage.Orders.FindFirst(or=>or.Id == id.ToString()));
                    //_storage.Orders.Add(Order);
                    _storage.Complete();
                }

                Util.Info("Wpf_Service", "An order was saved successfully!");
            }
            catch (Exception exc)
            {
                Util.Error("Order error", exc.Message);
            }
        }

        /// <summary>
        /// Fires when user selects some input field.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private void InputFocused(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource is TextBox textBox)
            {
                textBox.SelectAll();
            }
        }

        /// <summary>
        /// Fires when user presses on items in pop-up window's list view.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private void ItemIsSelected(object sender, RoutedEventArgs e)
        {
            EditOrderButton.IsEnabled = true;
            DeletOrderButton.IsEnabled = true;
        }

        /// <summary>
        /// Fires when user resets input fields for creating new order by pressing 'New' button.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private void NewOrder(object sender, RoutedEventArgs e)
        {
            if (HasChanges()) SaveWindow();
            ResetOrderInstance();
        }

        /// <summary>
        /// Fires when user deletes order by pressing 'Delete' button on pop-up window.
        /// </summary>
        /// <param name="sender">The button New that the action is for.</param>
        /// <param name="e">Arguments that the implementor of this event may find useful.</param>
        private async void DeleteOrder(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OrdersList.SelectedItems.Count != 1)
                {
                    return;
                }

                var selectedItem = (dynamic)OrdersList.SelectedItems[0];
                string id = selectedItem.Key.ToString();
                var toRemove =  _storage.Orders.FindFirst(op=>op.Id == id);
                _storage.Orders.Remove(toRemove);
                OrdersList.SelectedItem = null;
                EditOrderButton.IsEnabled = false;
                DeletOrderButton.IsEnabled = false;
                var orders = _storage.Orders.GetAll().ToList();
                if (orders.Count < 1)
                {
                    OrdersExplorer.IsOpen = false;
                    Opacity = 1;
                    Effect = null;
                    WindowMain.IsEnabled = true;
                }
                else
                {
                    OrdersList.ItemsSource = orders;
                }
            }
            catch (Exception exc)
            {
                Util.Error("Order deleting error", exc.Message);
            }
        }

        /// <summary>
        /// Resets _order field: set _order to new Order with id = -1.
        /// </summary>
        private void ResetOrderInstance()
        {
            Order = new Order { Id = "-1" };
            DataContext = Order;
        }

       
        public void OnWindowClose(object sender, System.ComponentModel.CancelEventArgs e)
        {

            if (HasChanges()) SaveWindow();
        }

        public void SetTextBoxAction()
        {
            var textBoxes = FindVisualChildren<TextBox>(this);
            foreach (var textBox in textBoxes)
            {
                textBox.TextChanged += new TextChangedEventHandler((sender, args) => UpdateButton());
            }
        }

        public bool HasChanges2()
        {
            var textBoxes = FindVisualChildren<TextBox>(this);
            bool hasChanges = false;
            foreach (var textBox in textBoxes)
            {
                if (textBox.Text != string.Empty && textBox.Text != "0")
            {
                hasChanges = true;

            }
            else
            {
                    hasChanges = false;
                    break; }
            }
            return hasChanges;
        }

        public bool HasChanges()
        {
            var textBoxes = FindVisualChildren<TextBox>(this);
            bool hasChanges = false;
            foreach (var textBox in textBoxes)
            {

                if (textBox.Text != string.Empty && textBox.Text != "0")
                {
                    hasChanges = true;
                    break;
                }

            }
            return hasChanges;
        }

        private void SaveWindow()
        {
            cans = false;
            string sMessageBoxText = "Do you want to Save?";
            string sCaption = "";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNo;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;
            MessageBoxResult rsltMessageBox = MessageBox.Show("Do you want to save?",
                                          "Confirmation",
                                          MessageBoxButton.YesNoCancel,
                                          MessageBoxImage.Question);
            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    Save();
                    break;

                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    cans = true;
                    break;
            }
        }

        public void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = HasChanges();
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}



