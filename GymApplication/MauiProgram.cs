﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using GymApplication.Data;
using GymApplication.Services;
using BlazorStrap;

namespace GymApplication;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			});

		builder.Services.AddMauiBlazorWebView();
		#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

		builder.Services.AddBlazorStrap();

		var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), @"AdminDB.db3");
		builder.Services.AddSingleton<AdminService>(x => ActivatorUtilities.CreateInstance<AdminService>(x, dbPath));
        return builder.Build();
	}
}
