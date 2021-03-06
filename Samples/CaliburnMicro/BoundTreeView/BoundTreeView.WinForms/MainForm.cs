﻿using System;
using System.Collections.Generic;
using MvvmFx.CaliburnMicro;
using MvvmFx.Bindings.Data;
#if WISEJ
using Wisej.Web;
using LogManager = MvvmFx.Controls.WisejWeb.LogManager;
#else
using System.Windows.Forms;
using LogManager = MvvmFx.Controls.WinForms.LogManager;
#endif

namespace BoundTreeView
{
    public partial class MainForm : Form, IHaveDataContext
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        private bool _isBindingSet;

        public MainForm()
        {
            InitializeComponent();
            LogManager.GetLog = type => new MvvmFx.Logging.DebugLogger(type);
        }

        #region IHaveDataContext implementation

        public event EventHandler<DataContextChangedEventArgs> DataContextChanged = delegate { };

        private MainFormViewModel _viewModel;

        public object DataContext
        {
            get { return _viewModel; }
            set
            {
                if (value != _viewModel)
                {
                    _viewModel = value as MainFormViewModel;
                    DataContextChanged(this, new DataContextChangedEventArgs());
                }
            }
        }

        #endregion

        #region Bind menu items

        public void BindMenuItems(List<Control> namedElements)
        {
            if (_isBindingSet)
                return;

            // Binds the control visible and enabled properties.
            WinFormExtensionMethods.BindComponentProxyProperties(namedElements, _viewModel, _bindingManager);

            _isBindingSet = true;
        }

        #endregion
    }
}