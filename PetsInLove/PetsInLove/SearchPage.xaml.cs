﻿using PetsInLove.ViewModels;
using Xamarin.Forms;

namespace PetsInLove
{
    public partial class SearchPage
    {
        private SearchViewModel ViewModel => BindingContext as SearchViewModel;

        public SearchPage()
        {
            InitializeComponent();
        }

        private void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
               // ViewModel.ShowContentCommand.Execute(e.SelectedItem);
            }
        }
    }
}