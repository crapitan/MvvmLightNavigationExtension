﻿using GalaSoft.MvvmLight.Views;
using MvvmLightNavigationExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MvvmLight.XamarinForms
{
    public class NavigationService : INavigationService, INavigationServiceExtension
    {
        internal static NavigationPage NavigationPage { get; private set; }
        
        private FormsNavigationHelper

        private Stack<string> _navigationStack = new Stack<string>();
        public void Initialize(NavigationPage navigationPage)
        {
            
            NavigationServiceExtension.Current = this;

        }

        public void Configure(string key, Type type)
        {
            lock(_pages)
            {
                if(_pages.ContainsKey(key))
                {
                    _pages[key] = type;
                }
                else
                {
                    _pages.Add(key, type);
                }

            }
        }

        public string CurrentPageKey
        {
            get { return _navigationStack.Peek(); }
        }

        public void CloseModal()
        {
            _navigation.PopModalAsync();
        }

        public void GoBack()
        {
            _navigationStack.Pop();
            _navigation.PopAsync();
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void NavigateTo(string pageKey, object parameter)
        {
           

            _navigationStack.Push(pageKey); 
        }

        public void OpenModal(string key)
        {
       
        }

        public void OpenModal(string key, object parameter)
        {
            
        }
    }
}
