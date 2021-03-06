﻿using BoundControls.Business;
using MvvmFx.Bindings.Data;
using MvvmFx.Controls.WisejWeb;
using Wisej.Web;
using Binding = MvvmFx.Bindings.Data.Binding;
using Control = Wisej.Web.Control;
using IBindableComponent = Wisej.Web.IBindableComponent;
using MenuItem = Wisej.Web.MenuItem;
using StatusBar = Wisej.Web.StatusBar;
using StatusBarPanel = Wisej.Web.StatusBarPanel;
using ToolBar = Wisej.Web.ToolBar;
using ToolBarButton = Wisej.Web.ToolBarButton;

namespace WisejWeb.ComponentBinding
{
    public class MvvmFxBindComponents
    {
        private readonly BindingManager _bindingManager = new BindingManager();

        public void SetMvvmFxBindings(Control masterControl)
        {
            _bindingManager.Bindings.Clear();

            if ((masterControl as Form)?.Menu != null)
                ParseComponents((masterControl as Form).Menu);

            foreach (Control control in masterControl.Controls)
            {
                if (control is MenuBar)
                {
                    ParseComponents(control as MenuBar);
                }
                else if (control is ToolBar)
                {
                    ParseComponents(control as ToolBar);
                }
                else if (control is StatusBar)
                {
                    ParseComponents(control as StatusBar);
                }
            }
        }

        private void ParseComponents(MainMenu mainMenu)
        {
            TryBind(mainMenu);

            foreach (MenuItem item in mainMenu.MenuItems)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private void ParseComponents(MenuBar menubar)
        {
            foreach (MenuItem item in menubar.MenuItems)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private void ParseComponents(ToolBar toolBar)
        {
            foreach (ToolBarButton item in toolBar.Buttons)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private void ParseComponents(StatusBar statusBar)
        {
            foreach (StatusBarPanel item in statusBar.Panels)
            {
                TryBind(item);
                RecurseItem(item);
            }
        }

        private void RecurseItem(Component component)
        {
            if (component is MenuItem)
            {
                foreach (MenuItem item in ((MenuItem) component).MenuItems)
                {
                    TryBind(item);
                    RecurseItem(item);
                }
            }
            else if ((component as ToolBarButton)?.DropDownMenu != null)
            {
                foreach (MenuItem item in ((ToolBarButton) component).DropDownMenu.MenuItems)
                {
                    TryBind(item);
                    RecurseItem(item);
                }
            }

            /*else if (component is StatusBarPanel)
            {
                foreach (MenuItem item in ((StatusBarPanel) component).Panels)
                {
                    TryBind(item);
                    RecurseItem(item);
                }
            }*/
        }

        private void TryBind(Component component)
        {
            if (component is INamedBindable)
            {
                var namedBindable = component as INamedBindable;
                var item = ItemCollection.GetItem(namedBindable);
                Bind(namedBindable, item);
            }
        }

        private void Bind(IBindableComponent bindable, Item item)
        {
            _bindingManager.Bindings.Add(new Binding(bindable, "Text", item, "Text")
            {
                Mode = BindingMode.OneWayToTarget
            });

            if (!(bindable is MenuItem || bindable is ToolBarButton))
            {
                _bindingManager.Bindings.Add(new Binding(bindable, "ToolTipText", item, "ToolTipText")
                {
                    Mode = BindingMode.OneWayToTarget
                });
            }

            if (!(bindable is StatusBarPanel))
            {
                _bindingManager.Bindings.Add(new Binding(bindable, "Enabled", item, "Enabled")
                {
                    Mode = BindingMode.OneWayToTarget
                });
                _bindingManager.Bindings.Add(new Binding(bindable, "Visible", item, "Visible")
                {
                    Mode = BindingMode.OneWayToTarget
                });
            }
        }
    }
}