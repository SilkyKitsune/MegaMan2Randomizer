﻿using System;
using System.Windows.Forms;

namespace MM2Randomizer;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainWindow());
    }
}