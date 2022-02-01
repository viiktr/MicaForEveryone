﻿using Microsoft.Extensions.DependencyInjection;
using Vanara.PInvoke;

using MicaForEveryone.Interfaces;
using MicaForEveryone.Win32;
using MicaForEveryone.ViewModels;

namespace MicaForEveryone.Models
{
    public class GlobalRule : IRule
    {
        public string Name => "Global";

        public TitlebarColorMode TitlebarColor { get; set; }

        public BackdropType BackdropPreference { get; set; }

        public bool ExtendFrameIntoClientArea { get; set; }

        public bool IsApplicable(HWND windowHandle) => windowHandle.IsTopLevel() && windowHandle.HasCaption();

        public override string ToString() => Name;

        public RulePaneItem GetPaneItem(ISettingsViewModel parent)
        {
            var viewModel = Program.CurrentApp.Container.GetService<IRuleSettingsViewModel>();
            viewModel.ParentViewModel = parent;
            viewModel.InitializeData(this);
            return new RulePaneItem("", PaneItemType.Global, viewModel);
        }
    }
}
